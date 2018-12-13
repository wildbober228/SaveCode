using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SystemDock : MonoBehaviour {
    
    public Text Dock_information;
    public bool start_timer;
    public string[] info;
    public GameObject UI;
    public GameObject Cross;
    public bool LoadUi;


    public GameObject SceneManager;
    void Start ()
    {
        SceneManager = GameObject.FindWithTag("SceneManager");
         Dock_information = GameObject.Find("InfoDock").GetComponent<Text>();
        UI = SceneManager.GetComponent<SceneManager>().UI;
        Cross = GameObject.Find("Cross");
        if (Cross != null)
            Debug.Log("Cross is load");
        else
            Debug.Log("Cross is not load");
        if (UI != null)
        {
            Debug.Log("UI is load");
           // UI.active = false;
        }
        else
            Debug.Log("UI is not load");
        if (Dock_information != null)
            Debug.Log("Dock is load");
        else
            Debug.Log("Dock is not load");
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            for (int i =0; i < info.Length;i++)
            {
                Dock_information.text += info[i]+"\n";

                //  Dock_information.text += "\n";
                LoadUi = true;
                Cross.active = false;
                Cursor.visible = true;
                StartCoroutine(TestCoroutine(5));
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {

            Dock_information.text = "Disconecting";
            LoadUi = false;
            Cross.active = true;
            StartCoroutine(TestCoroutine(1));
           

        }
    }
    IEnumerator TestCoroutine(float timee)
    {
        float tim = 0;
        while (true)
        {
            yield return null;
          
            if (tim < timee)
            {
                tim += Time.deltaTime;
            }
            if (tim >= timee)
            {
                //Debug.Log("Test");
                if (LoadUi)
                {
                    if(UI!=null)
                    UI.active = true;
                    else
                    {
                        UI = SceneManager.GetComponent<SceneManager>().UI;
                        UI.active = true;
                    }
            }
                else
                {
                    UI.active = false;
                }
                Dock_information.text = "";
                yield break;


            }
           
        }
    }
   

    public void Update()
    {
        
    }
}
