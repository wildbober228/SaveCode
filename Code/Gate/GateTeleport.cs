using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateTeleport : MonoBehaviour {


    public GameObject SceneManager;


    public Transform W;
    public Transform S;
    public Transform A;
    public Transform D;

    public enum GateType
    {
        W,S,A,D
    }
    public GateType gatetype;
    public GameObject player;

    public int xx;
    public int yy;
    void Start ()
    {


       // UpdateCoordinate();
        player = SceneManager.GetComponent<SceneManager>().PlayerShip.GetComponent<ShipInput>().ship_obj;

    }

    private void Update()
    {
        xx = SceneManager.GetComponent<SceneManager>().x;
        yy = SceneManager.GetComponent<SceneManager>().y;
    }


    public void SendDestriySystem()
    {
        SceneManager.GetComponent<SceneManager>().DestoySystem();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
           
            switch ((int)gatetype)
            {
                case 0:
                    
                    player.transform.position = S.position;                   
                    player.transform.rotation = S.rotation;

                    if (SceneManager.GetComponent<SceneManager>().SavedSystems[SceneManager.GetComponent<SceneManager>().x, SceneManager.GetComponent<SceneManager>().y] == null)
                    {
                        SceneManager.GetComponent<SceneManager>().SaveSystem(SceneManager.GetComponent<SceneManager>().x, SceneManager.GetComponent<SceneManager>().y);
                       
                        Debug.Log("Test1 Save");
                    }

                    //
                    SendDestriySystem();
                    //

                    SceneManager.GetComponent<SceneManager>().y++;

                    if (SceneManager.GetComponent<SceneManager>().SavedSystems[SceneManager.GetComponent<SceneManager>().x, SceneManager.GetComponent<SceneManager>().y] != null)
                    {
                        SceneManager.GetComponent<SceneManager>().LoadSystem(SceneManager.GetComponent<SceneManager>().x, SceneManager.GetComponent<SceneManager>().y);
                        Debug.Log("Test2  Load");
                    }
                    else
                    {
                        SceneManager.GetComponent<SceneManager>().GeneratySystem(SceneManager.GetComponent<SceneManager>().x, SceneManager.GetComponent<SceneManager>().y);
                        Debug.Log("Test3 Generate");
                    }
                    
                    break;
                  
                case 1:
                   
                    player.transform.position = W.position;
                    player.transform.rotation = W.rotation;
                    if (SceneManager.GetComponent<SceneManager>().SavedSystems[SceneManager.GetComponent<SceneManager>().x, SceneManager.GetComponent<SceneManager>().y] == null)
                    {
                        SceneManager.GetComponent<SceneManager>().SaveSystem(SceneManager.GetComponent<SceneManager>().x, SceneManager.GetComponent<SceneManager>().y);

                        Debug.Log("Test1 Save");
                    }

                    //
                    SendDestriySystem();
                    //

                    SceneManager.GetComponent<SceneManager>().y--;

                    if (SceneManager.GetComponent<SceneManager>().SavedSystems[SceneManager.GetComponent<SceneManager>().x, SceneManager.GetComponent<SceneManager>().y] != null)
                    {
                        SceneManager.GetComponent<SceneManager>().LoadSystem(SceneManager.GetComponent<SceneManager>().x, SceneManager.GetComponent<SceneManager>().y);
                        Debug.Log("Test2  Load");
                    }
                    else
                    {
                        SceneManager.GetComponent<SceneManager>().GeneratySystem(SceneManager.GetComponent<SceneManager>().x, SceneManager.GetComponent<SceneManager>().y);
                        Debug.Log("Test3 Generate");
                    }

                    break;
                   
                case 2:
                   
                    player.transform.position =D.position;
                    player.transform.rotation = D.rotation;
                    if (SceneManager.GetComponent<SceneManager>().SavedSystems[SceneManager.GetComponent<SceneManager>().x, SceneManager.GetComponent<SceneManager>().y] == null)
                    {
                        SceneManager.GetComponent<SceneManager>().SaveSystem(SceneManager.GetComponent<SceneManager>().x, SceneManager.GetComponent<SceneManager>().y);

                        Debug.Log("Test1 Save");
                    }

                    //
                    SendDestriySystem();
                    //

                    SceneManager.GetComponent<SceneManager>().x--;

                    if (SceneManager.GetComponent<SceneManager>().SavedSystems[SceneManager.GetComponent<SceneManager>().x, SceneManager.GetComponent<SceneManager>().y] != null)
                    {
                        SceneManager.GetComponent<SceneManager>().LoadSystem(SceneManager.GetComponent<SceneManager>().x, SceneManager.GetComponent<SceneManager>().y);
                        Debug.Log("Test2  Load");
                    }
                    else
                    {
                        SceneManager.GetComponent<SceneManager>().GeneratySystem(SceneManager.GetComponent<SceneManager>().x, SceneManager.GetComponent<SceneManager>().y);
                        Debug.Log("Test3 Generate");
                    }

                    break;
                   
                case 3:
                   
                    player.transform.position = A.position;
                    player.transform.rotation = A.rotation;
                    if (SceneManager.GetComponent<SceneManager>().SavedSystems[SceneManager.GetComponent<SceneManager>().x, SceneManager.GetComponent<SceneManager>().y] == null)
                    {
                        SceneManager.GetComponent<SceneManager>().SaveSystem(SceneManager.GetComponent<SceneManager>().x, SceneManager.GetComponent<SceneManager>().y);

                        Debug.Log("Test1 Save");
                    }

                    //
                    SendDestriySystem();
                    //

                    SceneManager.GetComponent<SceneManager>().x++;

                    if (SceneManager.GetComponent<SceneManager>().SavedSystems[SceneManager.GetComponent<SceneManager>().x, SceneManager.GetComponent<SceneManager>().y] != null)
                    {
                        SceneManager.GetComponent<SceneManager>().LoadSystem(SceneManager.GetComponent<SceneManager>().x, SceneManager.GetComponent<SceneManager>().y);
                        Debug.Log("Test2  Load");
                    }
                    else
                    {
                        SceneManager.GetComponent<SceneManager>().GeneratySystem(SceneManager.GetComponent<SceneManager>().x, SceneManager.GetComponent<SceneManager>().y);
                        Debug.Log("Test3 Generate");
                    }

                    break;                 
            }
           
        }
    }
}
