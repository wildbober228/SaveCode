using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCOUNT : MonoBehaviour
{

    void OnGUI()
    {
        float fps = 1.0f / Time.deltaTime;
        GUILayout.Label("FPS = " + fps);
    }
}
