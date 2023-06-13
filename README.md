![image](https://github.com/JDSherbert/Wwise-Soundbank-Excluder/assets/43964243/032e759e-e554-423b-b644-f35935790958)


# Wwise Soundbank Excluder

<!-- Header Start -->
  <a href = "https://www.audiokinetic.com/en/"><img align="left" height="40" img width="40" src="https://simpleicons.org/wwise/white"> </a>
  <a href = "https://docs.unity.com/"> <img align="left" img height="40" img width="40" src="https://cdn.simpleicons.org/unity/white"> </a> 
  <a href = "https://learn.microsoft.com/en-us/dotnet/csharp"> <img align="left" img height="40" img width="40" src="https://cdn.simpleicons.org/csharp"> </a>
  <img align="right" alt="stars badge" src="https://img.shields.io/github/stars/jdsherbert/Wwise-Soundbank-Excluder"/>
  <img align="right" alt="forks badge" src="https://img.shields.io/github/forks/jdsherbert/Wwise-Soundbank-Excluder=Fork"/>
  <img align="right" alt="watching badge" src="https://img.shields.io/github/watchers/jdsherbert/Wwise-Soundbank-Excluder"/>
  <img align="right" alt="Visitors" src="https://visitor-badge.glitch.me/badge?page_id=github.com/jdsherbert/Wwise-Soundbank-Excluder"/>
  <br></br>
  -----------------------------------------------------------------------
  
  <a href="https://www.audiokinetic.com/en/"> 
  <img align="top" alt="Extension Tool For Wwise" src="https://img.shields.io/badge/Extension%20Tool%20For%20Wwise-00549F?style=for-the-badge&logo=wwise&logoColor=white&color=black&labelColor=00549F"> </a>
    <a href="https://unity.com/"> 
  <img align="top" alt="Extension Tool For Unity" src="https://img.shields.io/badge/Extension%20Tool%20For%20Unity-000000?style=for-the-badge&logo=unity&logoColor=white&color=black&labelColor=FFFFFF"> </a>
  
  -----------------------------------------------------------------------
This repository contains a build tool for excluding Wwise Soundbanks. If the system you are running Unity on isn't the same as your target platform, you'll need to generate all the banks needed so you can listen in editor and also have the audio in the build! In addition to this, you only need the soundbank for your target platform, so any extras included are just bloat. Soundbanks can get rather huge, so it is important to keep unnecessary banks out of the build. Of course, you can just manually move/delete the files yourself.

This tool automates this task.

Features:
- Moves Soundbanks to a "Temp/ExcludedSoundbanks" folder at Unity Pre Build Step.
- Returns Soundbanks at the Unity Post Build Step.

Usage:
1. Drag and drop into your scripts folder, in a folder called "Editor".
2. Do a build.

Contributions:
Contributions to this repository are welcome. If you have improvements or additional features to add, feel free to submit a pull request.

License:
All rights reserved.

 -----------------------------------------------------------------------
## Overview

The Unity build system is a crucial component of the game development process that transforms your Unity project into a runnable application or package for the target platform(s). It handles tasks such as compiling scripts, processing assets, and generating platform-specific executables. The build system can be accessed through the Build Settings window in Unity, where you can configure various settings, select the target platform(s), and initiate the build process. Unity's build system streamlines the deployment workflow, enabling developers to create and distribute their games efficiently across multiple platforms.

During the build process, Unity compiles scripts, optimizes assets, and bundles everything together to create the final output. It follows a sequence of steps, including scene compilation, script compilation, asset processing, and platform-specific packaging. Additionally, the build system provides options for testing and debugging the built application. With Unity's build system, developers have the flexibility to target different platforms, customize settings, and prepare their projects for distribution, allowing them to bring their games to a wide range of devices and audiences.

As good as the system is however, it is not easy to exclude files from a build, so that's why I use a System.IO approach to exclude files and folders from the Asset folder!

