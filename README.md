
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
* Changing the scale of ProjectionPlane GameObject messed up the the scale for the camera as well, as Camera is child of the ProjectionPlane, which made the input data to translate to accurate movement a bit hard.


## Resources Used
* https://arxiv.org/pdf/2311.05887
* https://docs.unity3d.com/ScriptReference/Camera-nonJitteredProjectionMatrix.html
* https://www.hackster.io/ndaniel/interactive-ai-powered-3d-screen-f9d81d
* http://160592857366.free.fr/joe/ebooks/ShareData/Generalized%20Perspective%20Projection.pdf
* https://web.archive.org/web/20180309131934/http://www.anxious-bored.com/blog/2018/2/25/theparallaxview-illusion-of-depth-by-3d-head-tracking-on-iphone-x
* https://web.archive.org/web/20180309131934/http://www.anxious-bored.com/blog/2018/2/25/theparallaxview-illusion-of-depth-by-3d-head-tracking-on-iphone-x
* https://ntrs.nasa.gov/api/citations/20130014602/downloads/20130014602.pdf
* https://paulbourke.net/stereographics/stereorender/
* https://en.wikibooks.org/wiki/Cg_Programming/Unity/Projection_for_Virtual_Reality
* https://roextended.ro/forum/viewtopic.php?t=1983&start=10
* https://github.com/opentrack/opentrack/discussions/1850
* https://discussions.unity.com/t/freetrackir-unity3d-full-success/500115
* https://docs.opencv.org/2.4/modules/calib3d/doc/camera_calibration_and_3d_reconstruction.html
* https://catalog.ngc.nvidia.com/orgs/nvidia/teams/tao/models/facenet
* https://roextended.ro/forum/viewtopic.php?p=799#p799
* https://github.com/sinnwrig/URP-Fog-Volumes

## Authors

- Dharmesh Sahu [@dhakkann](https://www.github.com/dhakkann) (Team Leader)

- Utkarsh Ranjan
- C Yuktha
- Chirag

## Related Projects

[Implementation for Advertising](https://medium.com/try-creative-tech/off-axis-projection-in-unity-1572d826541e)

[Wii Remote Tracking](http://johnnylee.net/projects/wii/)

[Similar implementation with FreeTrack API](https://github.com/marcteys/unityFaceTracking)

[Off-Axis_Projection in Unreal Engine](https://github.com/GeodesicGames/SimpleOffAxisProjection)
 
[Unreal Engine plugin](https://github.com/GeodesicGames/SimpleOffAxisProjection)

[DepthIllusionWithARCore](https://github.com/kocosman/DepthIllusionWithARCore)

[iPhone X](https://github.com/algomystic/TheParallaxView)


## License

[MIT](https://choosealicense.com/licenses/mit/)

