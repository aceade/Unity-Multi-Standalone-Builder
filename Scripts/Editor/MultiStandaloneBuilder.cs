using UnityEditor;
using UnityEngine;
using System;

public class MultiStandaloneBuilder {

    // constants for defaults
    const string WINDOWS_FILENAME = "_Windows";
    const string LINUX_FILENAME = "_Linux";
    const string MAC_FILENAME = "_Mac";
    const string SCENE_FOLDER = "Assets/_Scenes/";
    const string BUILD_PATH = "Player Files/";

    // TODO: find how to combine these
    static BuildOptions devOptions = BuildOptions.AllowDebugging;

    [MenuItem("Tools/Aceade/Multi-Standalone Build")]
    public static void Build()
    {
        Debug.LogFormat("Creating new builds at {0}", DateTime.Now);

        // Assign your levels here.
        // TODO: prompt for list of levels
        var levels = new string[]{
            SCENE_FOLDER + "Sample Scene.unity"
        };

        // prompt for the build path. Defaults to using the product name.
        var savePath = EditorUtility.SaveFolderPanel("Put build in...", BUILD_PATH, Application.productName);

        // get the build date, then kick off the builds.
        var buildDate = GetBuildDate();
        MakeLinuxBuild(levels, buildDate, savePath);
        MakeWindowsBuild(levels, buildDate, savePath);
        MakeMacBuild(levels, buildDate, savePath);

        Debug.LogFormat("All builds finished at {0}", DateTime.Now);
    }

    /// <summary>
    /// Create a string representing the build date. The default syntax is "_dd.mm.yyyy", e.g "_04.12.2016".
    /// </summary>
    /// <returns>The build date.</returns>
    static string GetBuildDate()
    {
        // calculate the build date
        DateTime date = DateTime.Now;
        string buildDate = string.Format("_{0}.{1}.{2}",date.Day, date.Month, date.Year);
        Debug.LogFormat("Creating new builds on {0}", buildDate);
        return buildDate;
    }

    /// <summary>
    /// Makes a Linux build.
    /// </summary>
    /// <param name="levelsToBuild">Levels to build.</param>
    /// <param name="dateString">Date string.</param>
    /// <param name="path">Path.</param>
	static void MakeLinuxBuild(string[] levelsToBuild, string dateString, string path)
    {
        Debug.Log("Creating Linux build");
        string fileName = LINUX_FILENAME + dateString + ".x86_64";
        BuildTarget target = BuildTarget.StandaloneLinux64;
        BuildPipeline.BuildPlayer(levelsToBuild, path + fileName, target, devOptions);
    }

    /// <summary>
    /// Makes the Windows build.
    /// </summary>
    /// <param name="levelsToBuild">Levels to build.</param>
    /// <param name="dateString">Date string.</param>
    /// <param name="path">Path.</param>
    static void MakeWindowsBuild(string[] levelsToBuild, string dateString, string path)
    {
        Debug.Log("Creating Windows build");
        string fileName = WINDOWS_FILENAME + dateString + ".exe";
        BuildTarget target = BuildTarget.StandaloneWindows64;
        BuildPipeline.BuildPlayer(levelsToBuild, path + fileName, target, devOptions);
    }

    /// <summary>
    /// Makes a build for Mac devices.
    /// </summary>
    /// <param name="levelsToBuild">Levels to build.</param>
    /// <param name="dateString">Date string.</param>
    /// <param name="path">Path.</param>
    static void MakeMacBuild(string[] levelsToBuild, string dateString, string path)
    {
        Debug.Log("Creating Mac OSX build");
        string fileName = MAC_FILENAME + dateString + ".app";
        BuildTarget target = BuildTarget.StandaloneOSXIntel64;
        BuildPipeline.BuildPlayer(levelsToBuild, path + fileName, target, devOptions);
    }
}
