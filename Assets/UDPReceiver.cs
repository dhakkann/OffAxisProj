using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using UnityEngine;
using System.Threading;

public class UDPReceiver : MonoBehaviour
{
    private UdpClient udpClient;
    private IPEndPoint endPoint;
    private Thread receiveThread;

    public Vector3 inversion = new Vector3(1,-1,-1);
    public Vector3 allignment  = new Vector3(0,0,0);
    public float constant  = 1;
    public int port = 4242;


    // Array for storing received values
    private double[] values;

    // Vector3 for storing position data
    private Vector3 Position;

    // Vector3 for storing rotation data
    private Vector3 Rotation;

    // GameObject to apply position and rotation data
    public GameObject targetObject;

    void Start()
    {
        // Initialize end point with the port number that OpenTrack is sending to
        endPoint = new IPEndPoint(IPAddress.Any, port);

        // Initialize UDP client with the end point
        udpClient = new UdpClient(endPoint);

        // Set the receive buffer size
        udpClient.Client.ReceiveBufferSize = 512;

        // Start the receive thread
        receiveThread = new Thread(new ThreadStart(ReceiveData));
        receiveThread.IsBackground = true;
        receiveThread.Start();
    }

    private void ReceiveData()
    {
        while (true)
        {
            try
            {
                // Receive data
                byte[] data = udpClient.Receive(ref endPoint);

                // Check if data length is 48 bytes
                if (data.Length != 48) throw new Exception("Data length is not 48 bytes");

                // Size of each section
                int sectionSize = 8;

                // Initialize values array
                values = new double[data.Length / sectionSize];

                // Number of sections
                int numSections = data.Length / sectionSize;

                // Array for storing sections
                byte[][] sections = new byte[numSections][];

                // Split data into sections
                for (int i = 0; i < numSections; i++)
                {
                    sections[i] = new byte[sectionSize];
                    Buffer.BlockCopy(data, i * sectionSize, sections[i], 0, sectionSize);
                }

                // Convert sections to doubles and assign to Position and Rotation
                for (int i = 0; i < 6; i++)
                {
                    double value = BitConverter.ToDouble(sections[i], 0);
                    values[i] = value;

                    if (i < 3)
                    {
                        // Assign the first three values to Position
                        Position[i] = (float)value / -100;
                    }
                    else
                    {
                        // Switch the y and x rotation
                        if (i == 3)
                        {
                            Rotation.y = (float)value;
                        }
                        else if (i == 4)
                        {
                            Rotation.x = (float)value * -1;
                        }
                        else
                        {
                            Rotation.z = (float)value;
                        }
                    }
                }

              
            }
            catch (Exception e)
            {
                Debug.Log("Error: " + e.ToString());
            }

            // Sleep for 10 milliseconds to reduce the frequency of UDP calls
            Thread.Sleep(10);
        }
    }

    private void OnApplicationQuit()
    {
        // Abort the receive thread
        if (receiveThread != null)
        {
            receiveThread.Abort();
        }

        // Close the UDP client
        udpClient.Close();
    }

    void Update()
    {
        // Apply the position and rotation to the targetObject
        if (targetObject != null)
        {
            targetObject.transform.localPosition = constant * Vector3.Scale(inversion, Position) - allignment;
            //targetObject.transform.localEulerAngles = Rotation;
        }
    }
}