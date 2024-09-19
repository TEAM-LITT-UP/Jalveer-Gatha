#if !CC_TOOLS
using System;
using System.Collections.Generic;
using System.Linq;
using Convai.Scripts.Runtime.LoggerSystem;
using UnityEditor;
using UnityEditor.Build;
using UnityEditor.PackageManager;
using UnityEditor.PackageManager.Requests;
using UnityEngine.Rendering;

namespace Convai.Scripts.Editor.CustomPackage
{
    [InitializeOnLoad]
    public static class CCToolsImporter
    {
        private const string CC_TOOLS_SYMBOL = "CC_TOOLS";
        private const string URP_URL = "https://github.com/soupday/cc_unity_tools_URP.git";
        private const string HDRP_URL = "https://github.com/soupday/cc_unity_tools_HDRP.git";
        private const string BASE_URL = "https://github.com/soupday/cc_unity_tools_3D.git";

        static CCToolsImporter()
        {
            AddRequest addRequest;
            if (GraphicsSettings.currentRenderPipeline == null)
                addRequest = Client.Add(BASE_URL);
            else if (GraphicsSettings.currentRenderPipeline.GetType().Name == "UniversalRenderPipelineAsset")
                addRequest = Client.Add(URP_URL);
            else addRequest = Client.Add(HDRP_URL);

            while (!addRequest.IsCompleted)
            {
                ConvaiLogger.Warn("CC Tools installation is in progress.", ConvaiLogger.LogCategory.UI);
            }

            switch (addRequest.Status)
            {
                case StatusCode.Success:
                    ConvaiLogger.DebugLog("CC Tools has been installed successfully.", ConvaiLogger.LogCategory.UI);
                    break;
                case StatusCode.Failure:
                    ConvaiLogger.Warn($"CC Tools installation failed: {addRequest.Error.message}", ConvaiLogger.LogCategory.UI);
                    break;
                case StatusCode.InProgress:
                    ConvaiLogger.Warn("CC Tools installation is in progress.", ConvaiLogger.LogCategory.UI);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            foreach (BuildTarget target in Enum.GetValues(typeof(BuildTarget)))
            {
                BuildTargetGroup group = BuildPipeline.GetBuildTargetGroup(target);

                if (group == BuildTargetGroup.Unknown) continue;

                NamedBuildTarget namedTarget = NamedBuildTarget.FromBuildTargetGroup(group);
                List<string> symbols = PlayerSettings.GetScriptingDefineSymbols(namedTarget).Split(';').Select(d => d.Trim())
                    .ToList();

                if (!symbols.Contains(CC_TOOLS_SYMBOL)) symbols.Add(CC_TOOLS_SYMBOL);
                PlayerSettings.SetScriptingDefineSymbols(namedTarget, string.Join(";", symbols.ToArray()));
            }
        }
    }
}

#endif