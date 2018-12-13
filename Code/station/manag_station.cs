using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class manag_station : MonoBehaviour
{
    public int max_karkass;
    public int karkass_count;
    [Header("Скрипты")]
    public Dock_Info dock_info;
    [Header("Типы Станции")]
    public bool sklad;
    public bool army;
    public bool reserch;
    public bool miner;
    public bool xlam;
    [Header("Station info")]
    public string[] dock_info_text;
    public bool start_destr;
    [Header("Max переменные для модулей")]
    public int max_angar;
    public int max_mainmodul;
    public int max_fuel_bage;
    public int max_trade_module;
    public int max_energy_storage;
    public int max_life_blocks;
    public int max_sun_battary;
    public int max_modul_shatia;
    public int max_sklad;
    public int max_ammunition_box;
    [Header("Счетчики переменные для модулей")]
    public int count_angar;//+
    public int main_modul;//+
    public int count_fuel_bage;//+
    public int count_trade_module;//+
    public int count_energy_storage;//+ 
    public int count_life_blocks;//+
    public int count_sun_battary;//+
    public int count_modul_shatia;//+
    public int count_sklad;//+
    public int count_ammunition_box;//+
    [Header("Main Moduls for XLAM")]
    public GameObject Xlam_Spawner;
    public Transform Spawn_Xlam_Transform;
    [Header("Ссылки на модули")]
    public GameObject dock;
    public GameObject SceneManager_Obj;
    [Header("Relation")]
    public int Relation;
    public Text Relation_Text;

    private void Start()
    {
        
        Relation_Text = SceneManager_Obj.GetComponent<SceneManager>().RelationShip.GetComponent<Text>();
       // Relation_Text = GameObject.Find("RelationShip").GetComponent<Text>();
        Relation = 50000;
        int max_karkas = max_karkass - 2;
        if (sklad == true)
        {
            Debug.Log("SKLAD == true");
            max_angar = 1;
            max_mainmodul = max_karkas / 2 - max_karkas / 5;
            max_fuel_bage = max_karkas / 10;
            max_trade_module = max_karkas / 50;
            max_energy_storage = max_karkas / 5;
            max_sun_battary = max_energy_storage;
            max_life_blocks = max_karkas - max_angar - max_mainmodul - max_fuel_bage - max_trade_module - max_energy_storage - max_sun_battary;
            max_karkass += max_sklad;
        }
        if (miner == true)
        {
            max_angar = 1;
            max_mainmodul = max_karkas / 2 - max_karkas / 5;
            max_fuel_bage = max_karkas / 10;
            max_trade_module = max_karkas / 50;
            max_energy_storage = max_karkas / 5;
            max_sun_battary = max_energy_storage;
            max_life_blocks = max_karkas - max_angar - max_mainmodul - max_fuel_bage - max_trade_module - max_energy_storage - max_sun_battary;
            max_karkass += max_sklad;
        }
        if (army == true)
        {
            max_angar = 1;
            max_mainmodul = max_karkas / 2 - max_karkas / 5;
            max_fuel_bage = max_karkas / 10;
            max_trade_module = max_karkas / 50;
            max_energy_storage = max_karkas / 5;
            max_sun_battary = max_energy_storage;
            max_life_blocks = max_karkas - max_angar - max_mainmodul - max_fuel_bage - max_trade_module - max_energy_storage - max_sun_battary;
            max_karkass += max_sklad;
        }
        if (reserch == true)
        {
            max_angar = 1;
            max_mainmodul = max_karkas / 2 - max_karkas / 5;
            max_fuel_bage = max_karkas / 10;
            max_trade_module = max_karkas / 50;
            max_energy_storage = max_karkas / 5;
            max_sun_battary = max_energy_storage;
            max_life_blocks = max_karkas - max_angar - max_mainmodul - max_fuel_bage - max_trade_module - max_energy_storage - max_sun_battary;
            max_karkass += max_sklad;
        }
        if(xlam == true)
        {
            max_angar = 1;
            max_mainmodul = max_karkas / 2 - max_karkas / 5;
            max_fuel_bage = max_karkas / 10;
            max_trade_module = max_karkas / 50;
            max_energy_storage = max_karkas / 5;
            max_sun_battary = max_energy_storage;
            max_life_blocks = max_karkas - max_angar - max_mainmodul - max_fuel_bage - max_trade_module - max_energy_storage - max_sun_battary;
            max_karkass += max_sklad;
            Debug.Log("GENERATE RABUSH");
            GameObject go1 = (GameObject)Instantiate(Xlam_Spawner, Spawn_Xlam_Transform.position, Spawn_Xlam_Transform.rotation);
           // go1.transform.position = new Vector3(0, 0, 0);
            go1.name = "XlamGenerator";
            go1.transform.SetParent(Spawn_Xlam_Transform);
        }


        //max_karkass += max_sklad+ max_modul_shatia;
        //max_angar = (max_karkas - max_sklad- max_modul_shatia) / 50;
        //max_mainmodul = (max_karkas - max_sklad - max_modul_shatia) / 2 - max_karkas / 5;
        //max_fuel_bage = (max_karkas - max_sklad - max_modul_shatia) / 10;
        //max_trade_module = (max_karkas - max_sklad - max_modul_shatia) / 50;
        //max_energy_storage = (max_karkas - max_sklad - max_modul_shatia) / 5;
        //max_sun_battary = max_energy_storage;
        //max_life_blocks = (max_karkas - max_sklad - max_modul_shatia) - max_angar - max_mainmodul - max_fuel_bage - max_trade_module - max_energy_storage - max_sun_battary;

    }

    public void Update()
    {
        if(count_sun_battary == max_sun_battary && count_angar == max_angar)
        {
            start_destr = true;
            dock_info.StartSetup(dock, dock_info_text);
        }
        if (Relation_Text != null)
        {
            if (Relation >= 40000 && Relation <= 60000)
            {
                Relation_Text.color = Color.yellow;
            }
            if (Relation > 60000)
            {
                Relation_Text.color = Color.green;
            }
            if (Relation < 40000 && Relation >= 10000)
            {
                Relation_Text.color = Color.red;
            }
        }
    }

}
