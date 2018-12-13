using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class new_station : MonoBehaviour {
	void Start () {
		
	}	
	void Update () {
		
	}
    int help_1 = 9;
    public void spawn(Transform[] tubes, Transform[] tubes2,int help,ref bool can_spawn,GameObject obj,int count,int max, GameObject station)   
    {
        if (count != max)
        {
            can_spawn = false;
            if (help < tubes.Length)
            {
                    GameObject go1 = (GameObject)Instantiate(obj, tubes[help].position, obj.transform.rotation);
                go1.transform.SetParent(station.transform);
                //if(go1.GetComponent<Physics1>() == null)
                //{
                //    go1.AddComponent<Physics1>().mang = this.gameObject.GetComponent<Physics1>().mang; ;
                //   // go1.GetComponent<Physics1>()
                //}
                go1.name = "krakass" + count;
                    go1.GetComponent<generate_station>().help = help;
                    go1.GetComponent<Physics1>().prev_node = this.gameObject;
                    this.gameObject.GetComponent<Physics1>().next_node = go1;
                Destroy_tubes(tubes,help);


            }
        }
    }
    /// <summary>
    /// Постройка доп модулей
    /// </summary>
    /// <param name="tubes"></param>
    /// <param name="tubes2"></param>
    /// <param name="help"></param>
    /// <param name="can_spawn"></param>
    /// <param name="obj"></param>
    /// <param name="count"></param>
    /// <param name="max"></param>
    /// <param name="name"></param>
    public void spawn_modul(Transform[] tubes, Transform[] tubes2, int help, ref bool can_spawn, GameObject obj, int count, int max,string name, GameObject station)
    {
        if (count != max)
        {
            can_spawn = false;
            if (help < tubes.Length)
            {
               
                GameObject go1 = (GameObject)Instantiate(obj, tubes[help].position, obj.transform.rotation);
                go1.transform.SetParent(station.transform);
                if(name == "Angar")
                {
                    station.GetComponent<manag_station>().dock = go1;//ссылка на док в манаджер
                }
                go1.name = "Modul" +name+ count;
                if(go1.GetComponent<Physics1>() != null)
                go1.GetComponent<Physics1>().mang = this.gameObject.GetComponent<Physics1>().mang;
                else
                    go1.AddComponent<Physics1>().mang = this.gameObject.GetComponent<Physics1>().mang;
                //go1.GetComponent<generate_station>().help = help;
                go1.GetComponent<Physics1>().prev_node = this.gameObject;
                go1.GetComponent<Physics1>().next_node = go1;
              
                this.gameObject.GetComponent<Physics1>().next_node = go1;
                // this.gameObject.GetComponent<Physics1>().next_node = go1;
                Destroy_tubes_modul(tubes,tubes2, help);


            }
        }
    }
    public void spawn_dock(Transform[] tubes, Transform[] tubes2, int storona, ref bool can_spawn, GameObject obj, int count, int max, GameObject station)
    {
        
            can_spawn = false;
            if (storona < tubes.Length)
            {
         
            GameObject go1 = (GameObject)Instantiate(obj, tubes[storona].position, obj.transform.rotation);
            go1.transform.SetParent(station.transform);
            go1.name = "dvigatel" + count;
            if(go1.GetComponent<Physics1>()==null)
            go1.AddComponent<Physics1>().mang = this.gameObject.GetComponent<Physics1>().mang;
            else
            this.gameObject.GetComponent<Physics1>().next_node = go1;
        }
        
    }
    public void Destroy_tubes(Transform[] tubes, int storona)
    {
        Destroy(tubes[storona].gameObject);
      
    }
    public void Destroy_tubes_modul(Transform[] tubes, Transform[] tubes2, int storona)
    {
        Destroy(tubes[storona].gameObject);
       // Destroy_Tubes_Visual(tubes,tubes2,storona);
    }
    public void Destroy_Tubes_Visual(Transform[] tubes, Transform[] tubes2,int storona)
    {
        for (int i =0;i<tubes.Length;i++)
        {
            if (tubes[i] != null )
            {
                tubes2[i].gameObject.SetActive(false);
            }
        }
    }
}
