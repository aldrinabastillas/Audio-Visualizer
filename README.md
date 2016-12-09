# Lorenz System Audio Visualizer in Unity3D

## Overview


## Assets
### Scripts
* [Visualizer.cs](https://github.com/aldrinabastillas/Audio-Visualizer/blob/master/Assets/Scripts/Visualizer.cs):

* [AudioManager.cs](https://github.com/aldrinabastillas/Audio-Visualizer/blob/master/Assets/Scripts/AudioManager.cs):
Saves audio spectrum data to an array with a size of the given sampling rate. 
Samples are taken using a [Hamming Window](https://en.wikipedia.org/wiki/Window_function#Hamming_window).

* [SpectrumController.cs](https://github.com/aldrinabastillas/Audio-Visualizer/blob/master/Assets/Scripts/SpectrumController.cs):

* [CameraRotation.cs](https://github.com/aldrinabastillas/Audio-Visualizer/blob/master/Assets/Scripts/CameraRotation.cs):

### Patterns
* [Pattern.cs](https://github.com/aldrinabastillas/Audio-Visualizer/blob/master/Assets/Patterns/Pattern.cs):
Abstract base class that others below derive from.

* [Lorenz.cs](https://github.com/aldrinabastillas/Audio-Visualizer/blob/master/Assets/Patterns/Lorenz.cs):
Implements a [Lorenz system](https://en.wikipedia.org/wiki/Lorenz_system).

* [Circle.cs](https://github.com/aldrinabastillas/Audio-Visualizer/blob/master/Assets/Patterns/Circle.cs):
Pattern used in Hypnotoad09's original project.


### Other Assets
* [DSG.mat](https://github.com/aldrinabastillas/Audio-Visualizer/blob/master/Assets/Materials/DeepSpaceGreen/DSG.mat):
Material used for the space skybox background.  From the [Unity Asset Store](https://www.assetstore.unity3d.com/en/#!/content/25142).
* [Silver.mat](https://github.com/aldrinabastillas/Audio-Visualizer/blob/master/Assets/Materials/PBS%20Metallic/Silver.mat):
Material used for the cylinders. From the [Unity Asset Store](https://www.assetstore.unity3d.com/en/#!/content/25422).


### Executables
Executable files that allow you to change resolution and frame rate.
* [AudioVisualizer.exe](https://github.com/aldrinabastillas/Audio-Visualizer/blob/master/AudioVisualizer.exe):
For Windows

* [AudioVisualizer.app.zip](https://github.com/aldrinabastillas/Audio-Visualizer/blob/master/AudioVisualizer.app.zip):
For macOS.  Must be zipped, as Github adds the package as a folder instead of one .app file.




## Videos
* [My Version](https://www.youtube.com/watch?v=Rgu4TiTfQYs)
* [Hypnotoad09's second version](https://www.youtube.com/watch?v=vQFNL4nNL_I)
* [Hypnotoad09's first version](https://www.youtube.com/watch?v=dbVz0tYfGcw)



## References
* [Hypnotoad09's original Reddit post](https://www.reddit.com/r/Unity3D/comments/35dm0n/check_out_this_cool_3d_audio_visualizer_ive_just/)
* [AudioSource.GetSpectrumData](https://docs.unity3d.com/ScriptReference/AudioSource.GetSpectrumData.html), the API that allows you to 
sample the song's audio data.



## Future Enhancements
* Add sliders to UI that changes visualizer's parameters as seen in this [project](https://github.com/bellatesla/AudioVisualizer-Basic).
* Add ability to change audio file in UI.
* Listen to any audio coming out of speakers.  This is much harder, as it would require writing a [plugin](https://docs.unity3d.com/Manual/Plugins.html) 
  to get the audio directly from the device.