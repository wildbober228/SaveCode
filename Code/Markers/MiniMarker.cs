﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MiniMarker : MonoBehaviour {
    public GameObject markerFab;
    public GameObject offScreenFab;
    public Color color = Color.blue;

    GameObject offscreenMarker;
    GameObject marker;
    RectTransform tform;

    RectTransform offscreenTform;
    public Canvas canvas;
    bool isVisible = false;
    Renderer ren;

    public Transform player;
    public SceneManager scenemanager;
    bool first = true;
    bool help;
    public int reputation;

    public bool gate;

    void Start()
    {


        player = GameObject.FindGameObjectWithTag("Player").transform;
        scenemanager = GameObject.FindGameObjectWithTag("SceneManager").GetComponent<SceneManager>();
        canvas = GameObject.Find("HUD").GetComponent<Canvas>();

        help = true;
        
    }

    private void OnDisable()
    {
        Debug.Log("OnDisable");
        if (offscreenMarker != null && marker != null)
        {
            offscreenMarker.gameObject.SetActive(false);
            marker.gameObject.SetActive(false);
        }

    }

    private void OnEnable()
    {
      
        Debug.Log("OnEnable");
        if (offscreenMarker != null && marker != null)
        {
            offscreenMarker.gameObject.SetActive(true);
            marker.gameObject.SetActive(true);
        }
    }

    void Update() 
    {

        if (help == true)
        {
            reputation = scenemanager.reputation_get();

            if (gate == false)
            {
                color = scenemanager.UpdateColor(reputation);
            }

            if (gate == true)
            {
                color = Color.gray;
            }
            help = false;
        }
        if (first)
        {
            first = false;

           

            offscreenMarker = Instantiate(offScreenFab) as GameObject;
            offscreenTform = offscreenMarker.GetComponent<RectTransform>();
            offscreenTform.SetParent(canvas.transform);
            offscreenMarker.GetComponent<Image>().color = color;

            marker = Instantiate(markerFab) as GameObject;
            tform = marker.GetComponent<RectTransform>();
            tform.SetParent(canvas.transform);
            marker.GetComponent<Image>().color = color;
            ren = GetComponent<Renderer>();

           

        }
        Vector3 markPos = Camera.main.WorldToScreenPoint(transform.position);

        if (markPos.z > 0 && markPos.x < Screen.width && markPos.x > 0 && markPos.y < Screen.height && markPos.y > 0)
        {
            isVisible = true;
            marker.SetActive(true);
            offscreenMarker.SetActive(false);

        }
        else
        {
         isVisible = false;
         marker.SetActive(false);
         offscreenMarker.SetActive(true);
        }


    
        if (isVisible)
        { 
            tform.position = markPos;
        }
        else
        {
            PlaceOffscreen(markPos);
        }
    }

    void OnDestroy()
    {
        Destroy(marker);
        Destroy(offscreenMarker);
    }

    void PlaceOffscreen(Vector3 screenpos)
    {
        float x = screenpos.x;
        float y = screenpos.y;
        float offset = 10;

        if (screenpos.z < 0)
        {
            screenpos = -screenpos;
        }

        if (screenpos.x > Screen.width)
        {
            x = Screen.width - offset;
        }
        if (screenpos.x < 0)
        {
            x = offset;
        }

        if (screenpos.y > Screen.height)
        {
            y = Screen.height - offset;
        }
        if (screenpos.y < 0)
        {
            y = offset;
        }

         offscreenTform.position = new Vector3(x, y, 0);
         if (player != null)
         {
             float dist = (transform.position - player.position).magnitude;

             offscreenTform.localScale = new Vector3(1, 1, 1) * (Mathf.Clamp((500 - dist) / 500, 0.25f, 1.1f));

         }
        
    }

}
