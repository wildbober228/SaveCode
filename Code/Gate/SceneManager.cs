using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SceneManager : MonoBehaviour
{
    [Header("Params")]



    /// <summary>
    /// 1000 and 1 = 1000 sectors
    /// </summary>
    public int amountSystems;//1000 
    public int k;//1
    public int k_distance;
    public int[] AmountBloks;

    [Header("Objects")]
    public GameObject[] ObjectsInSpace;
    public GameObject[] SkladStations;
    public GameObject[] MineStations;
    public GameObject[] ArmyStation;
    public GameObject[] Asteroid_Spawner;
    public GameObject[] ReserchStation;
    public GameObject[] Xlam;
    public GameObject[] Freightors;
    [Header("Fraction Objects")]
    public GameObject[] Fractions;

    [Header("Main Vars for Fractions")]
    [Header("All Types of Names")]
    public string[] formsnames;
    public int id;
    [Header("Max Fractions")]
    public int max_fractions;
   
    [Header("System Coords")]
    public int x_f;
    public int y_f;
    [Header("TypeSystem")]
    public string TypeSystem;
    [Header("currentSystemArea")]
    public int currentSystemArea;
    [Header("Bordes")]
    public int minBoard;
    public int maxBoard;
    [Header("StartSystem")]
    public int StartSystem;
    [Header("Chanse to spawn new Fraction")]
    public int chanse;
    public int AmountSystemsInArea;
    [Header("Refs to Obj for Fractions")]
    public Text x_text;
    public Text y_text;
    public Text NameFraction_text;
    public Text TypeSystem_text;
    [Header("Amount of Objects")]
    public int AmountOfObjects;
    [Header("Your Relations")]
    public int[] relation;

    public enum TypeOfspace
    {
        warrior,
        sience,
        miners,
        xlam
    }
    [Header("Type of Generate Space")]
    public TypeOfspace typeofspace;
    [Header("Player Ship")]
    public GameObject PlayerShip;
    [Header("Player Camera")]
    public Camera PlayerCamera;
    [Header("Player UI")]
    public GameObject UI;
    public GameObject RelationShip;

    public GameObject Parent;
    public GameObject ParentWorld;
    public GameObject CurrentParent;

    public GameObject[,] SavedSystems = new GameObject[1000, 1000]; //= amountSystems/k
    public GameObject[,] CurrentParent_Mass = new GameObject[1000, 1000];//= amountSystems/k

    public int x;
    public int y;
    public int AmountOfSystems;
    public bool help;

    [Header("Help vars")]
    public int AmountBlocks;
    void Start()
    {
        //AmountSystemsInArea = 1;
        //for(int i=0;i< 5;i++)

        UI = GameObject.Find("UI");
        //Initialisation
        GameObject player = PlayerShip;
        player.transform.position = new Vector3(200, 200, 200);
        player.name = "Player";

        //Initialisation

        GeneratySystem(x, y);
        CurrentParent.name = x + " " + y;
        SavedSystems[x, y] = CurrentParent;
    }

    public Color UpdateColor(int rep)
    {
        Color color = Color.gray;
        if (rep > 60000)
        {
            color = Color.green;
        }
        if (rep >= 40000 && rep <= 60000)
        {
            color = Color.yellow;
        }

        if (rep >= 10000 && rep < 40000)
        {
            color = Color.red;
        }

        return color;
    }

    public int reputation_get()
    {
        return relation[currentSystemArea];
    }

    void AddParamsToFraction(int type_system, int type_fraction, GameObject par)
    {
        GameObject frac = (GameObject)Instantiate(Fractions[0], Fractions[0].transform.position, Fractions[0].transform.rotation);
        frac.GetComponent<Fractions>().id = type_fraction;
        frac.GetComponent<Fractions>().relations = relation[type_fraction];
        //frac.GetComponent<Fractions>().relations = relation;
        frac.transform.SetParent(par.transform);
        frac.GetComponent<Fractions>().x_text = x_text;
        frac.GetComponent<Fractions>().y_text = y_text;
        frac.GetComponent<Fractions>().NameFraction_text = NameFraction_text;
        frac.GetComponent<Fractions>().TypeSystem_text = TypeSystem_text;
        frac.GetComponent<Fractions>().x = x;
        frac.GetComponent<Fractions>().y = y;
        frac.GetComponent<Fractions>().scenemanager = this;
        NameFraction_text.GetComponent<Text>().color = UpdateColor(relation[type_fraction]);
        frac.GetComponent<Fractions>().NameFraction = formsnames[type_fraction];
        switch (type_system)
        {
            case 0:
                frac.GetComponent<Fractions>().TypeSystem = "warrior";
                break;
            case 1:
                frac.GetComponent<Fractions>().TypeSystem = "sience";
                break;
            case 2:
                frac.GetComponent<Fractions>().TypeSystem = "miners";
                break;
            case 3:
                frac.GetComponent<Fractions>().TypeSystem = "xlam";
                break;
        }
    }

    void AddFraction(int type_system, GameObject par)
    {
        //int type_fraction = Random.Range(0,max_fractions);
        int type_fraction = StartSystem;
        currentSystemArea = StartSystem;
            if (AmountSystemsInArea >= minBoard && AmountSystemsInArea < maxBoard)
            {

                int rand = Random.Range(0, 101);
                if (rand < chanse)
                {
                AddParamsToFraction(type_system, type_fraction, par);
                Debug.Log("BEETWEEN  1111");
                    AmountSystemsInArea++;
                    chanse -= 10;
                goto exit;
            }
                else
                {
                    Debug.Log("BEETWEEN  2222");
                    chanse = 100;
                    type_fraction = Random.Range(0, max_fractions);
                   
                    AmountSystemsInArea = 1;
                    StartSystem = type_fraction;
                currentSystemArea = StartSystem;
                AddParamsToFraction(type_system, type_fraction, par);
                goto exit;
            }


            }
            if (AmountSystemsInArea < minBoard)
            {
                AddParamsToFraction(type_system, type_fraction, par);
                AmountSystemsInArea++;
            goto exit;
        }
            if (AmountSystemsInArea >= maxBoard)
            {
                chanse = 100;
                type_fraction = Random.Range(0, max_fractions);
              
                AmountSystemsInArea = 1;
                StartSystem = type_fraction;
            currentSystemArea = StartSystem;
            AddParamsToFraction(type_system, type_fraction, par);
            goto exit;
            }

        exit:
        Debug.Log("ExitException");


    }

    void StopSpawn()
    {
        UI.SetActive(false);
        PlayerCamera.gameObject.SetActive(true);

    }

    void StartSpawn()
    {
        PlayerCamera.gameObject.SetActive(false);

    }

    #region Formuls

    int RandomDistance(int AmountOfStations)
    {
        return AmountOfStations * k_distance;
    }

    void CalculateAmountStations(int xx, int yy)
    {
        //400--600
        if (xx >= 400 / k && xx <= 600 / k && yy >= 400 / k && yy <= 600 / k)
        {
            AmountOfObjects = Random.Range(2, 4);//2-3
            AmountBlocks = AmountBloks[0];
        }
        //200-800 !400-600
        if ((xx >= 200 / k && xx <= 800 / k && yy >= 200 / k && yy <= 800 / k) && (xx < 400 / k && x > 600 / k && yy < 400 / k && y > 600 / k))
        {
            AmountOfObjects = Random.Range(3, 5);//3-4
            AmountBlocks = AmountBloks[1];
        }
        //0 -- 1000 ! 200-800
        if ((xx >= 0 / k && xx <= 1000 / k && yy >= 0 / k && yy <= 1000 / k) && (xx < 200 / k && x > 800 / k && yy < 200 / k && y > 800 / k))
        {
            AmountOfObjects = Random.Range(5, 7);//5-6
            AmountBlocks = AmountBloks[2];
        }
    }
    #endregion


    public void SaveSystem(int xx, int yy)
    {
        x = xx;
        y = yy;
        SavedSystems[xx, yy] = CurrentParent.gameObject;
        Debug.Log("NameOfSavedObject = " + CurrentParent.gameObject.name);

        //GeneratySystem(xx,yy);
        //Debug.Log("Saved System " + " x " + xx + " yy " + yy);
    }

    public void LoadSystem(int xx, int yy)
    {
        GameObject obj = SavedSystems[xx, yy];
        if (obj != null)
            obj.SetActive(true);
        Debug.Log("Load System " + " x " + xx + " yy " + yy);
    }

    public void DestoySystem()
    {
        GameObject obj = GameObject.Find(x + " " + y);
        obj.SetActive(false);
    }

    public void GeneratySystem(int xx, int yy)
    {
        Debug.Log("Generate System " + " x " + xx + " yy " + yy);

        GameObject parent = (GameObject)Instantiate(Parent, new Vector3(0, 0, 0), Parent.transform.rotation);
        CurrentParent = parent;
        CurrentParent.name = x + " " + y;
        StartSpawn();
        CalculateAmountStations(xx, yy);
        int km = RandomDistance(AmountOfObjects);
        Debug.Log("Distance km = " + km);

        AddFraction((int)typeofspace, parent);

        switch ((int)typeofspace)
        {


            case 0:
                {
                    Debug.Log("GenWorldType" + (int)typeofspace);
                    Vector3 vector3_centre_system = new Vector3(0, 0, 0);
                    //SKLAD
                    for (int i = 0; i < AmountOfObjects; i++)
                    {


                        Vector3 vecSpawn = new Vector3(Random.Range(-km, km), Random.Range(-km, km), Random.Range(-km, km));
                        GameObject sklad_Stations = (GameObject)Instantiate(SkladStations[0], vecSpawn, SkladStations[0].transform.rotation);
                        sklad_Stations.GetComponent<manag_station>().max_karkass = AmountBlocks;
                        sklad_Stations.transform.SetParent(parent.transform);
                        sklad_Stations.GetComponent<manag_station>().SceneManager_Obj = this.gameObject;

                    }
                    //ARMY
                    for (int i = 0; i < AmountOfObjects; i++)
                    {


                        Vector3 vecSpawn = new Vector3(Random.Range(-km, km), Random.Range(-km, km), Random.Range(-km, km));
                        GameObject armyStation = (GameObject)Instantiate(ArmyStation[0], vecSpawn, ArmyStation[0].transform.rotation);
                        armyStation.GetComponent<manag_station>().max_karkass = AmountBlocks;
                        armyStation.transform.SetParent(parent.transform);
                        armyStation.GetComponent<manag_station>().SceneManager_Obj = this.gameObject;

                    }
                }
                break;
            case 1:
                {
                    Debug.Log("GenWorldType" + (int)typeofspace);

                    Vector3 vector3_centre_system = new Vector3(0, 0, 0);
                    //SKLAD
                    for (int i = 0; i < AmountOfObjects; i++)
                    {


                        Vector3 vecSpawn = new Vector3(Random.Range(-km, km), Random.Range(-km, km), Random.Range(-km, km));
                        GameObject sklad_Stations = (GameObject)Instantiate(SkladStations[0], vecSpawn, SkladStations[0].transform.rotation);
                        sklad_Stations.GetComponent<manag_station>().max_karkass = AmountBlocks;
                        sklad_Stations.transform.SetParent(parent.transform);
                        sklad_Stations.GetComponent<manag_station>().SceneManager_Obj = this.gameObject;

                    }
                    //RESERCH
                    for (int i = 0; i < AmountOfObjects; i++)
                    {
                        Vector3 vecSpawn = new Vector3(Random.Range(-km, km), Random.Range(-km, km), Random.Range(-km, km));
                        GameObject reserchStation = (GameObject)Instantiate(ReserchStation[0], vecSpawn, ReserchStation[0].transform.rotation);
                        reserchStation.GetComponent<manag_station>().max_karkass = AmountBlocks;
                        reserchStation.transform.SetParent(parent.transform);
                        reserchStation.GetComponent<manag_station>().SceneManager_Obj = this.gameObject;

                    }
                }
                break;
            case 2:
                {
                    Debug.Log("GenWorldType" + (int)typeofspace);

                    Vector3 vector3_centre_system = new Vector3(0, 0, 0);
                    //SKLAD
                    for (int i = 0; i < AmountOfObjects; i++)
                    {


                        Vector3 vecSpawn = new Vector3(Random.Range(-km, km), Random.Range(-km, km), Random.Range(-km, km));
                        GameObject sklad_Stations = (GameObject)Instantiate(SkladStations[0], vecSpawn, SkladStations[0].transform.rotation);
                        sklad_Stations.GetComponent<manag_station>().max_karkass = AmountBlocks;
                        sklad_Stations.transform.SetParent(parent.transform);
                        sklad_Stations.GetComponent<manag_station>().SceneManager_Obj = this.gameObject;

                    }
                    //ASTEROIDS
                    for (int i = 0; i < Asteroid_Spawner.Length; i++)
                    {

                        Vector3 vecSpawn = new Vector3(Random.Range(-km, km), Random.Range(-km, km), Random.Range(-km, km));
                        GameObject asteroid_Spawner = (GameObject)Instantiate(Asteroid_Spawner[0], vector3_centre_system, Asteroid_Spawner[0].transform.rotation);

                        asteroid_Spawner.transform.SetParent(parent.transform);
                    }
                    //MINER
                    for (int i = 0; i < AmountOfObjects; i++)
                    {

                        Vector3 vecSpawn = new Vector3(Random.Range(-km, km), Random.Range(-km, km), Random.Range(-km, km));
                        GameObject mineStation = (GameObject)Instantiate(MineStations[0], vecSpawn, MineStations[0].transform.rotation);

                        mineStation.GetComponent<GenerateBigAsteroid>().AmountKarkass = AmountBlocks;
                        mineStation.transform.SetParent(parent.transform);
                        mineStation.GetComponent<GenerateBigAsteroid>().sceneManager_Obj = this.gameObject;
                    }
                }
                //FREITHER
                for (int i = 0; i < AmountOfObjects; i++)
                {
                    Vector3 vecSpawn = new Vector3(Random.Range(-km, km), Random.Range(-km, km), Random.Range(-km, km));
                    GameObject Freithor = (GameObject)Instantiate(Freightors[0], vecSpawn, Freightors[0].transform.rotation);
                    Freithor.transform.SetParent(parent.transform);
                    Freithor.name = "Freighter " + i;
                }

                break;
            case 3:
                {
                    Debug.Log("GenWorldType" + (int)typeofspace);
                    Vector3 vector3_centre_system = new Vector3(0, 0, 0);
                    //XLAM
                    for (int i = 0; i < AmountOfObjects; i++)
                    {
                        Vector3 vecSpawn = new Vector3(Random.Range(-km * 2, km * 2), Random.Range(-km * 2, km * 2), Random.Range(-km * 2, km * 2));
                        GameObject Xlam_Stations = (GameObject)Instantiate(Xlam[0], vecSpawn, Xlam[0].transform.rotation);
                        Xlam_Stations.GetComponent<manag_station>().max_karkass = AmountBlocks;
                        Xlam_Stations.transform.SetParent(parent.transform);
                        Xlam_Stations.GetComponent<manag_station>().SceneManager_Obj = this.gameObject;

                    }

                }
                break;

        }

        StopSpawn();

        //GameObject parent2 = (GameObject)Instantiate(ParentWorld, new Vector3(0, 0, 0), ParentWorld.transform.rotation);
        //parent.transform.SetParent(parent2.transform);
        //parent.name = "System " + x + " " + y;
    }


    /* public void GeneratySystem1(int xx, int yy,bool start)
     {
         Debug.Log("Generate System " + " x " + xx + " yy " + yy);
         //if (SavedSystems[xx, yy] != null)
          //CurrentParent.SetActive(false);
         GameObject parent = (GameObject)Instantiate(Parent, new Vector3(0, 0, 0), Parent.transform.rotation);

         CurrentParent = parent;

         StartSpawn();
         switch ((int)typeofspace)
         {
             case 0:
                 {
                     Debug.Log("GenWorldType" + (int)typeofspace);
                 }
                 break;
             case 1:
                 {
                     Debug.Log("GenWorldType" + (int)typeofspace);
                 }
                 break;
             case 2:
                 {
                     Debug.Log("GenWorldType" + (int)typeofspace);

                     Vector3 vector3_centre_system = new Vector3(0, 0, 0);
                     for (int i = 0; i < SkladStations.Length; i++)
                     {


                         Vector3 vecSpawn = new Vector3(Random.Range(-10000, 10000), Random.Range(-10000, 10000), Random.Range(-10000, 10000));
                         GameObject sklad_Stations = (GameObject)Instantiate(SkladStations[i], vecSpawn, SkladStations[i].transform.rotation);
                         sklad_Stations.transform.SetParent(parent.transform);
                         sklad_Stations.GetComponent<manag_station>().SceneManager_Obj = this.gameObject;

                     }
                     for (int i = 0; i < Asteroid_Spawner.Length; i++)
                     {

                         Vector3 vecSpawn = new Vector3(Random.Range(-10000, 10000), Random.Range(-10000, 10000), Random.Range(-10000, 10000));
                         GameObject asteroid_Spawner = (GameObject)Instantiate(Asteroid_Spawner[i], vector3_centre_system, Asteroid_Spawner[i].transform.rotation);
                         asteroid_Spawner.transform.SetParent(parent.transform);
                     }
                     for (int i = 0; i < MineStations.Length; i++)
                     {

                         Vector3 vecSpawn = new Vector3(Random.Range(-10000, 10000), Random.Range(-10000, 10000), Random.Range(-10000, 10000));
                         GameObject mineStation = (GameObject)Instantiate(MineStations[i], vecSpawn, MineStations[i].transform.rotation);
                         mineStation.transform.SetParent(parent.transform);
                         mineStation.GetComponent<manag_station>().SceneManager_Obj = this.gameObject;
                     }
                 }
                 break;
             case 3:
                 {
                     Debug.Log("GenWorldType" + (int)typeofspace);
                 }
                 break;

         }


     }
     */
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            Debug.Log("L");
            for (int i = 0; i <= x; i++)
                for (int j = 0; j <= y; j++)
                    Debug.Log(" x " + i + " y " + j + " Name = " + SavedSystems[i, j]);
        }
    }




}
