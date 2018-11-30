using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


class MyEditorScript {
         static string APP_NAME = "MachineAR";
        static string TARGET_DIR = "D:\\Documentos\\MachineAR";

        static void PerformBuild(){
        string[] scenes = { "Assets/SampleScene.unity" };
        BuildPipeline.BuildPlayer(scenes,TARGET_DIR,BuildTarget.Android,BuildOptions.AutoRunPlayer);
        }
}
