![image](https://github.com/JDSherbert/Wwise-Soundbank-Excluder/assets/43964243/032e759e-e554-423b-b644-f35935790958)


# Wwise Soundbank Excluder

<!-- Header Start -->
  <a href = "hhttps://www.audiokinetic.com/en/"> <img align="left" img height="40" img width="40" src="https://cdn.simpleicons.org/wwise/white"> </a> 
  <a href = "https://docs.unity.com/"> <img align="left" img height="40" img width="40" src="https://cdn.simpleicons.org/unity/white"> </a> 
  <a href = "https://learn.microsoft.com/en-us/dotnet/csharp"> <img align="left" img height="40" img width="40" src="https://cdn.simpleicons.org/csharp"> </a>
<img align="right" alt="Stars Badge" src="https://img.shields.io/github/stars/jdsherbert/Wwise-Soundbank-Excluder?label=%E2%AD%90"/>
<img align="right" alt="Forks Badge" src="https://img.shields.io/github/forks/jdsherbert/Wwise-Soundbank-Excluder?label=%F0%9F%8D%B4"/>
<img align="right" alt="Watchers Badge" src="https://img.shields.io/github/watchers/jdsherbert/Wwise-Soundbank-Excluder?label=%F0%9F%91%81%EF%B8%8F"/>
<img align="right" alt="Issues Badge" src="https://img.shields.io/github/issues/jdsherbert/Wwise-Soundbank-Excluder?label=%E2%9A%A0%EF%B8%8F"/>
<img align="right" src="https://hits.seeyoufarm.com/api/count/incr/badge.svg?url=https%3A%2F%2Fgithub.com%2FJDSherbert%2FWwise-Soundbank-Excluder%2Fhit-counter%2FREADME&count_bg=%2379C83D&title_bg=%23555555&labelColor=0E1128&title=🔍&style=for-the-badge">
  <br></br>
  -----------------------------------------------------------------------
  
<a href="https://www.audiokinetic.com/en/"> 
  <img align="top" alt="Extension Tool For Wwise" src="https://img.shields.io/badge/Extension%20Tool%20For%20Wwise-00549F?style=for-the-badge&logo=wwise&logoColor=white&color=black&labelColor=00549F"> </a>
    <a href="https://unity.com/"> 
  <img align="top" alt="Extension Tool For Unity" src="https://img.shields.io/badge/Extension%20Tool%20For%20Unity-FFFFFF?style=for-the-badge&logo=unity&logoColor=black&color=black&labelColor=FFFFFF"> </a>
  
  -----------------------------------------------------------------------
## Overview
For some reason, Unity makes it incredibly difficult to exclude unused assets in the StreamingAssets folder, so here is a quick and dirty System.IO solution for making sure Wwise Soundbanks (that are not necessary) are excluded from your builds in Unity. This is an automnated tool which will run during the Unity pre and post build pipeline steps.

This repository contains a build tool for excluding Wwise Soundbanks via System.IO. If the system you are running Unity on isn't the same as your target platform, you'll need to generate all the banks needed so you can listen in editor and also have the audio in the build! In addition to this, you only need the soundbank for your target platform, so any extras included are just bloat. Soundbanks can get rather huge, so it is important to keep unnecessary banks out of the build. Of course, you can just manually move/delete the files yourself. This tool simply automates this task.

### Notes:
This tool is tested and known to be working with Jenkins, TeamCity, and many other CLI.

### Features:
- Moves Soundbanks to a "Temp/ExcludedSoundbanks" folder at Unity Pre Build Step.
- Returns Soundbanks at the Unity Post Build Step.

### Usage:
1. Drag and drop into your scripts folder, in a folder called "Editor".
2. Do a build.

 -----------------------------------------------------------------------
