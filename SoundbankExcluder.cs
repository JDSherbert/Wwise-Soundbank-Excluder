// ©2023 JDSherbert

using UnityEditor;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using System.IO;

namespace Sherbert.Editor.Build
{
    /// <summary>
    /// Soundbank Build Exclusion Class that attempts to exclude Wwise soundbanks from the build during the preprocess step,
    /// if those soundbanks are unnecessary for our target platform.
    /// Also attempts to return them back to the original path during the postprocess step. See: 
    /// <see cref="IPreprocessBuildWithReport"/> and 
    /// <see cref="BuildPipelineInterfaces"/>.
    ///
    /// Note that:
    /// <code>
    /// public int callbackOrder
    /// {
    ///    get { return 0; }
    /// }
    ///
    /// </code> Must be implemented this specific way due to how the Unity build stack functions.
    /// </summary>
    public class SoundbankExcluder : IPreprocessBuildWithReport, IPostprocessBuildWithReport
    {
        /// Path to the default soundbank folder
        private const string _soundbankPath = "Assets/StreamingAssets/Audio/GeneratedSoundBanks";
        /// Path to the designated exclusion folder
        private const string _exclusionPath = "Temp/ExcludedSoundbanks";
        /// Map buildtarget to soundbank definitions
        private readonly Dictionary<BuildTarget, string> _soundbanks = new()
        {
            { BuildTarget.Android, "Android" },
            { BuildTarget.StandaloneWindows, "Windows" },
            { BuildTarget.StandaloneWindows64, "Windows" },
            { BuildTarget.StandaloneOSX, "Mac" }
        };

        /// <summary> Internally required implementation. See: <see cref="BuildPipelineInterfaces"/> </summary>
        public int callbackOrder
        {
            get { return 0; }
        }

        public void OnPreprocessBuild(BuildReport report)
        {
            ExcludeSoundbanks(report.summary.platform);
        }

        public void OnPostprocessBuild(BuildReport report)
        {
            RestoreSoundbanks(report.summary.platform);
            SafePurge(_exclusionPath); //Cleanup temp folder
        }

        /// <summary>
        /// Attempts to exclude Wwise soundbanks from the build during the preprocess step that do not match our target
        /// platform by moving them to our defined temp folder.
        /// <param name="target">The target platform reference.</param>
        /// </summary>
        private void ExcludeSoundbanks(BuildTarget target)
        {
            ResetDirectory(_exclusionPath); // Ensure temp folder is empty before moving

            string keepBank = _soundbanks[target];
            foreach (var soundbank in _soundbanks)
            {
                if (soundbank.Value == keepBank)
                {
                    continue; //Skip this bank as we want to keep it in this build
                }
                
                string startPath = Path.Combine(_soundbankPath, soundbank.Value);
                string destinationPath = Path.Combine(_exclusionPath, soundbank.Value);
                SafeMoveDirectory(startPath, destinationPath);
            }

            AssetDatabase.Refresh(); //Refresh so that Unity notices the changes
        }

        /// <summary>
        /// Attempts to return Wwise soundbanks at the post process step by moving them to our defined original folder.
        /// <param name="target">The target platform reference.</param>
        /// </summary>
        private void RestoreSoundbanks(BuildTarget target)
        {
            foreach (var soundbank in _soundbanks)
            {
                string startPath = Path.Combine(_exclusionPath, soundbank.Value);
                string destinationPath = Path.Combine(_soundbankPath, soundbank.Value);

                if (Directory.Exists(startPath)) // Skip banks that don't exist
                {
                    SafePurge(destinationPath); // Ensure destination is empty before moving, or else there will be an IO fail
                    SafeMoveDirectory(startPath, destinationPath);
                }
            }

            AssetDatabase.Refresh(); //Refresh so that Unity notices the changes
        }

        /// <summary>
        /// Attempts to move a directory from one location to another.
        /// <param name="from">The source directory.</param>
        /// <param name="to">The destination directory.</param>
        /// </summary>
        private void SafeMoveDirectory(string from, string to)
        {
            if (Directory.Exists(from))
            {
                Directory.Move(from, to);
            }
        }

        /// <summary>
        /// Attempts to reset a directory by purging and then restoring it.
        /// <param name="path">The target directory.</param>
        /// </summary>
        private void ResetDirectory(string path)
        {
            SafePurge(path);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        /// <summary>
        /// Attempts to purge a directory and its entire contents.
        /// <param name="path">The target directory.</param>
        /// </summary>
        private void SafePurge(string path)
        {
            if (Directory.Exists(path))
            {
                Directory.Delete(path, true);
            }
        }
    }
}
