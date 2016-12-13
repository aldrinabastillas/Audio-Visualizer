# Lorenz System Audio Visualizer in Unity3D

## Overview
This is my first project in [Unity3D](https://unity3d.com/) and first experience in game development and CGI.
It is an audio visualizer in the pattern of a [Lorenz System](https://en.wikipedia.org/wiki/Lorenz_system),
which is a system of 3 ordinary differential equations that form the shape of a butterfly or figure-eight. 
The objects at each point change size and color with the song's [audio frequency](https://en.wikipedia.org/wiki/Audio_frequency).    

## Changes
This project was modified from Hypnotoad09's original project (see Videos and References sections below), 
which was then converted from UnityScript to C# by [Dommii](https://github.com/Domiii/UnityAudioVisualizer).

#### Code Refactoring
* The pattern that is created can now be changed in the IDE, by making an enum value for the pattern type a public field.  This enum 
is passed into a Factory Method that creates a List of vector points.  The List of points is a property on an abstract base class, Pattern.
The classes Lorenz and Circle inherit from Pattern and add to this List according to their own variables like radius for Circle and 
sigma, rho and beta for Lorenz.
* Fields that were duplicated between scripts like maxHeight for the object, were made public in AudioManager.cs and internal elsewhere.  
  This creates one central access point for editing parameters, rather than having to know which script to open, and eliminates ambiguity of 
  which value from the two scripts will actually be used.  
* Objects expand depending on the type of prefab mesh is used.  For example, if the mesh is a sphere, it expands in all dimensions, but
only expands in the y-dimension for cubes.
* Added an accessor method into the AudioManager's internal array of frequency samples rather than indexing into the array directly.
* Commented code, sectioned off regions for Fields, Parameters, Event Functions, and Methods.

#### Visual Updates
* Added a skybox background.
* Added a silver reflective object material for each prefab object. 
* Prefab objects expand downwards as well as up.

## Assets
#### Scripts
* [Visualizer.cs](https://github.com/aldrinabastillas/Audio-Visualizer/blob/master/Assets/Scripts/Visualizer.cs):
Creates a prefab object at each location for the specified pattern. Currenctly either Lorenz or Circle patterns
can be chosen from the Unity IDE. 

* [AudioManager.cs](https://github.com/aldrinabastillas/Audio-Visualizer/blob/master/Assets/Scripts/AudioManager.cs):
Saves the song's [audio frequency](https://en.wikipedia.org/wiki/Audio_frequency) data to an array with a size of the given sampling rate. 
Samples are taken using a [Hamming Window](https://en.wikipedia.org/wiki/Window_function#Hamming_window).

* [PrefabBehaviour.cs](https://github.com/aldrinabastillas/Audio-Visualizer/blob/master/Assets/Scripts/PrefabBehaviour.cs):
Updates each prefab's size and color according to the current audio spectrum value and its position in the Hamming Window.

* [CameraRotation.cs](https://github.com/aldrinabastillas/Audio-Visualizer/blob/master/Assets/Scripts/CameraRotation.cs):
Rotates the camera's position on a specified axis and at a specified rotation rate.


#### Patterns
* [Pattern.cs](https://github.com/aldrinabastillas/Audio-Visualizer/blob/master/Assets/Patterns/Pattern.cs):
Abstract base class that others below derive from.  Has a List of points that the derived classes add to using 
its specific implementation of the AddPoints method. 

* [Lorenz.cs](https://github.com/aldrinabastillas/Audio-Visualizer/blob/master/Assets/Patterns/Lorenz.cs):
Implements a [Lorenz system](https://en.wikipedia.org/wiki/Lorenz_system).

* [Circle.cs](https://github.com/aldrinabastillas/Audio-Visualizer/blob/master/Assets/Patterns/Circle.cs):
The points that were generated in Hypnotoad09's original project.


#### Materials
* [DSG.mat](https://github.com/aldrinabastillas/Audio-Visualizer/blob/master/Assets/Materials/DeepSpaceGreen/DSG.mat):
Material used for the space skybox background.  From the [Unity Asset Store](https://www.assetstore.unity3d.com/en/#!/content/25142).

* [Silver.mat](https://github.com/aldrinabastillas/Audio-Visualizer/blob/master/Assets/Materials/PBS%20Metallic/Silver.mat):
Material used for the cylinders. From the [Unity Asset Store](https://www.assetstore.unity3d.com/en/#!/content/25422).


#### Executables
Executable files to download, which allow you to change resolution and frame rate.
* [AudioVisualizer.exe.zip](https://github.com/aldrinabastillas/Audio-Visualizer/blob/master/AudioVisualizer.exe.zip):
For Windows

* [AudioVisualizer.app.zip](https://github.com/aldrinabastillas/Audio-Visualizer/blob/master/AudioVisualizer.app.zip):
For macOS.


## Videos
* [My Version](https://www.youtube.com/watch?v=Rgu4TiTfQYs)
* [Hypnotoad09's second version](https://www.youtube.com/watch?v=vQFNL4nNL_I)
* [Hypnotoad09's first version](https://www.youtube.com/watch?v=dbVz0tYfGcw)



## References
* [Hypnotoad09's original Reddit post](https://www.reddit.com/r/Unity3D/comments/35dm0n/check_out_this_cool_3d_audio_visualizer_ive_just/)
* [AudioSource.GetSpectrumData](https://docs.unity3d.com/ScriptReference/AudioSource.GetSpectrumData.html), the API that allows you to 
sample the song's [audio frequency](https://en.wikipedia.org/wiki/Audio_frequency) data.



## Future Enhancements
* Create a UI with sliders that changes the visualizer's parameters, like number and max size of objects, as seen in this [project](https://github.com/bellatesla/AudioVisualizer-Basic).
* Add the ability to select your own audio file.
* Listen to any audio coming out of speakers.  This is much harder to implement, as it would require writing a [plugin](https://docs.unity3d.com/Manual/Plugins.html) 
  to get the audio directly from the hardware device.