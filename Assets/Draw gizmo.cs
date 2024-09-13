using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawgizmo : MonoBehaviour
{   
    public bool DrawGizmo = true;
    
    public void OnDrawGizmos()
        {
            if (DrawGizmo)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawLine(this.gameObject.transform.localPosition, this.gameObject.transform.localPosition - new Vector3(0,0,-50));
            }
        }
}
