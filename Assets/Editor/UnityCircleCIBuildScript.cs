using System.Collections;
using System.Collections.Generic;
using SuperUnityBuild.BuildTool;
using UnityEngine;

public static class UnityCircleCIBuildScript
{
    /// <summary>
    /// Example: .\Unity.exe -quit -batchmode -projectPath "D:\DATA\Unity Project\UnityCircleCI" -executeMethod UnityCircleCI.BuildSingleWindowsMono -logFile "D:\DATA\Unity Project\UnityCircleCI\BL.txt"
    /// </summary>
    public static void BuildSingleWindowsMono()
    {
        BuildProject.BuildSingle("PROD/PC/Windows x64 (App)/Mono", UnityEditor.BuildOptions.None);
    }

    /// <summary>
    /// Ecample: .\Unity.exe -quit -batchmode -projectPath "D:\DATA\Unity Project\UnityCircleCI" -executeMethod UnityCircleCI.BuildSingle -keyChain "PROD/PC/Windows x64 (App)/Mono" -logFile "D:\DATA\Unity Project\UnityCircleCI\BL.txt"
    /// </summary>
    public static void BuildSingle()
    {
        var keyChain = GetArg("-keyChain");
        BuildProject.BuildSingle(keyChain, UnityEditor.BuildOptions.None);
    }

    private static string GetArg(string name)
    {
        var args = System.Environment.GetCommandLineArgs();
        for (int i = 0; i < args.Length; i++)
        {
            if (args[i] == name && args.Length > i + 1)
            {
                return args[i + 1];
            }
        }
        return null;
    }
}
