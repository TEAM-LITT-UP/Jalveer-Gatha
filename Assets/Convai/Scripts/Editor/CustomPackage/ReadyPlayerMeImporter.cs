using System;
using Convai.Scripts.Runtime.LoggerSystem;
using UnityEditor;
using UnityEditor.PackageManager;
using UnityEditor.PackageManager.Requests;
using Random = UnityEngine.Random;
#if !READY_PLAYER_ME
using UnityEditor.PackageManager;
using UnityEditor.PackageManager.Requests;
using UnityEngine;
#endif


namespace Convai.Scripts.Editor.CustomPackage
{
    [InitializeOnLoad]
    public class ReadyPlayerMeImporter
    {
        private static AddRequest _request;

        static ReadyPlayerMeImporter()
        {
#if !READY_PLAYER_ME
        ConvaiLogger.DebugLog("Ready Player Me is not installed, importing it", ConvaiLogger.LogCategory.Editor);
        _request = Client.Add("https://github.com/readyplayerme/rpm-unity-sdk-core.git");
        EditorUtility.DisplayProgressBar("Importing Ready Player Me", "Importing.....", Random.Range(0,1f));
        EditorApplication.update += UnityEditorUpdateCallback;

#endif
        }

#if !READY_PLAYER_ME
        private static void UnityEditorUpdateCallback()
        {
            if (_request == null) return;
            if (!_request.IsCompleted) return;
            switch (_request.Status)
            {
                case StatusCode.Success:
                    ConvaiLogger.DebugLog( "Ready Player Me has been imported successfully", ConvaiLogger.LogCategory.Editor);
                    break;
                case StatusCode.Failure:
                    ConvaiLogger.Error($"Ready Player Me has failed to import: {_request.Error.message}", ConvaiLogger.LogCategory.Editor);
                    break;
                case StatusCode.InProgress:
                    ConvaiLogger.DebugLog("Ready Player Me is still importing...", ConvaiLogger.LogCategory.Editor);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            EditorApplication.update -= UnityEditorUpdateCallback;
            EditorUtility.ClearProgressBar();
        }
#endif
    }
}