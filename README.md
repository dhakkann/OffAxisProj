
# ComVis

Implementation of Off-Axis-Projection in Unity Game Engine, with 6-DoF headtracking using webcam.


## Installation

* Clone repository with

```bash
  git clone https://github.com/dhakkann/OffAxisProj.git
```
* Open the project with appropriate version of Unity(2022.3.45f1 +)
    
    
    Install the 'Universal Render Pipeline'(URP) package from the Package Manager window within unity if you encounter errors. 

### Opentrack 
Install OpenTrack for headtracking from https://github.com/opentrack/opentrack.

Set output port in OpenTrack to 5252.

## Usage/Examples

* Build from Unity to make a standalone installation, appropriate for your desired device Operating System.

* Use your desired method for head tracking
    A list for possible tracking options is available in the https://github.com/opentrack/opentrack Wiki.

    Set your desired output port in Opentrack output field setting window.(Make sure to change the port in the port variable attacked to the UDPReceiver GameObject)


## Lessons Learned

* Much of the problems were related to face tracking, jiterryness and lag between movement translation to virtual camera.
    I am planning to implement better methods for headtracking(ArUco Marker / Infrared Leds).
* Changing from Unity basic-render-pipeline to Universal-Render-Pipeline posed problems with materials.
* PostProcessing-v2 stack did not work with the current implementation of the code. There was a lot of jiterryness in the rendering process.

## Authors

- Dharmesh Sahu [@dhakkann](https://www.github.com/dhakkann) Team Leader

- Utkarsh Ranjan
- C Yuktha
- Chirag
## Related Projects



[Implementation for Advertising](https://medium.com/try-creative-tech/off-axis-projection-in-unity-1572d826541e)

[Wii Remote Tracking](http://johnnylee.net/projects/wii/)

[Similar implementation with FreeTrack API](https://github.com/marcteys/unityFaceTracking)



## License

[MIT](https://choosealicense.com/licenses/mit/)

