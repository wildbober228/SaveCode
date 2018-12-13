using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dock_Info : MonoBehaviour
{
    string[] info;

    public GameObject Dock;
  
    public bool Ok = false;
    public void StartSetup(GameObject dock,string[] text)
    {
        Dock = dock;
        dock.GetComponent<SystemDock>().info = text;
    }
}
