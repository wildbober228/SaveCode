using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateBigAsteroid : MonoBehaviour {

    [Header("Vars to Getcomponent")]
    public int AmountKarkass;
    public GameObject sceneManager_Obj;

    public GameObject[] asteroids;

    public GameObject Station;
    public Transform Station_Spawn;
    public Transform Astreroid_spawn;
    public float RangPlus;
    public float RangMinus;
    public int size;
    int count;
    private Quaternion euler;

    //public GameObject SceneManager_obj;
	void Start ()
    {
        for (int i =0;i< size;i++)
        {
            for (int j = 0; j < asteroids.Length; j++)
            {
                count++;
                //Random.Range(RangMinus, RangPlus);
                Astreroid_spawn.position = this.transform.position;
                Astreroid_spawn.position = new Vector3(Astreroid_spawn.position.x+ Random.Range(RangMinus, RangPlus), Astreroid_spawn.position.y+ Random.Range(RangMinus, RangPlus), Astreroid_spawn.position.z+ Random.Range(RangMinus, RangPlus));                
                Astreroid_spawn.rotation = new Quaternion(Random.Range(-180, 180), Random.Range(-180, 180), Random.Range(-180, 180), 0);
                int r = Random.Range(0, asteroids.Length);
                Debug.Log("Random= " + r);
                GameObject go1 = (GameObject)Instantiate(asteroids[r], Astreroid_spawn.gameObject.transform.position, Astreroid_spawn.rotation);
                go1.name = "Aseroid" + count;
                go1.transform.SetParent(this.transform);
            }
        }
        GameObject station = (GameObject)Instantiate(Station, Station_Spawn.gameObject.transform.position + transform.up *-150, Station_Spawn.rotation);
        station.transform.SetParent(this.transform);
        station.GetComponent<manag_station>().max_karkass = AmountKarkass;
        station.GetComponent<manag_station>().SceneManager_Obj = sceneManager_Obj;
      
        station.name = "AsteroidMiner_Station";
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
