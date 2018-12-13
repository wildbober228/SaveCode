using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generate_station : MonoBehaviour
{
   
    public GameObject obj;
    public GameObject Dvigatel;
    [Header("стороны монтажа")]
    public Transform[] tubes;//стороны монтажа
    public Transform[] tubes2;//стороны монтажа
    public int help;
    public bool can_spawn = true;
    public new_station st;
    public int help_1;
    public GameObject station_manager;
    [Header("Moduls")]
    public GameObject Angar;
    [Header("Main Moduls")]
    public GameObject Sklad;
    public GameObject Ammo_box;
    public GameObject Shild_modul;
    public GameObject Refactoring;
    public GameObject Antena;
    public GameObject Xlam_Utilize;
    
    [Header("Main Moduls")]
    public GameObject fuel_bage;
    public GameObject trade_modul;
    public GameObject Energy_storage;
    public GameObject Sun_battary;
    public GameObject Life_bloks;
    public GameObject Modul_Zhatia;
    



    void Start () {

        
       if(station_manager.GetComponent<manag_station>().karkass_count !=0)
        switch (help)
        {
            case 0:
                help_1 = 1;
                break;
            case 1:
                help_1 = 0;
                break;
            case 2:
                help_1 = 3;
                break;
            case 3:
                help_1 = 2;
                break;
            case 4:
                help_1 = 5;
                break;
            case 5:
                help_1 = 4;
                break;
        }
        if (station_manager.GetComponent<manag_station>().karkass_count == 0)
            help = Random.Range(0, 6);
          //  help = 1;
        else
        {
            x: help = Random.Range(0, 6);
            // 
            if (help == help_1)
                goto x;
        }
        
        station_manager.GetComponent<manag_station>().karkass_count++;
        st.spawn(tubes,tubes2, help, ref can_spawn,obj, station_manager.GetComponent<manag_station>().karkass_count, station_manager.GetComponent<manag_station>().max_karkass, station_manager);
        if (station_manager.GetComponent<manag_station>().karkass_count == station_manager.GetComponent<manag_station>().max_karkass)
        {
            st.spawn_dock(tubes, tubes2, help, ref can_spawn, Dvigatel, station_manager.GetComponent<manag_station>().karkass_count, station_manager.GetComponent<manag_station>().max_karkass, station_manager);
            
            Destroy(this);
        }

        ///Постройка доп модулей
        if(station_manager.GetComponent<manag_station>().sklad == true)
        {
            Gen_Sklad();
        }
        if (station_manager.GetComponent<manag_station>().miner == true)
        {
            Gen_Miner();
        }
        if (station_manager.GetComponent<manag_station>().army == true)
        {
            Gen_Army();
        }
        if (station_manager.GetComponent<manag_station>().reserch == true)
        {
            Gen_Reserch();
        }
        if (station_manager.GetComponent<manag_station>().xlam == true)
        {
            Gen_Xlam();
        }
    }

    void Gen_Sklad()
    {
        Debug.Log("BUILD SKLAD");
        int help_new;
        x: help_new = Random.Range(0, 6);
        if (help_new != help)
        {
            if (station_manager.GetComponent<manag_station>().count_angar != station_manager.GetComponent<manag_station>().max_angar)
            {
                st.spawn_modul(tubes, tubes2, help_new, ref can_spawn, Angar, station_manager.GetComponent<manag_station>().count_angar, station_manager.GetComponent<manag_station>().max_angar, "Angar", station_manager);
                station_manager.GetComponent<manag_station>().count_angar++;
            }
            else
            if (station_manager.GetComponent<manag_station>().count_fuel_bage != station_manager.GetComponent<manag_station>().max_fuel_bage)
            {
                st.spawn_modul(tubes, tubes2, help_new, ref can_spawn, fuel_bage, station_manager.GetComponent<manag_station>().count_fuel_bage, station_manager.GetComponent<manag_station>().max_fuel_bage, "Fuel", station_manager);
                station_manager.GetComponent<manag_station>().count_fuel_bage++;
            }
            else
            if (station_manager.GetComponent<manag_station>().main_modul != station_manager.GetComponent<manag_station>().max_mainmodul)
            {
                st.spawn_modul(tubes, tubes2, help_new, ref can_spawn, Sklad, station_manager.GetComponent<manag_station>().main_modul, station_manager.GetComponent<manag_station>().max_mainmodul, "Sklad", station_manager);
                station_manager.GetComponent<manag_station>().main_modul++;
            }
            else
            if (station_manager.GetComponent<manag_station>().count_trade_module != station_manager.GetComponent<manag_station>().max_trade_module)
            {
                st.spawn_modul(tubes, tubes2, help_new, ref can_spawn, trade_modul, station_manager.GetComponent<manag_station>().count_trade_module, station_manager.GetComponent<manag_station>().max_trade_module, "Trade", station_manager);
                station_manager.GetComponent<manag_station>().count_trade_module++;
            }
            else
            if (station_manager.GetComponent<manag_station>().count_life_blocks != station_manager.GetComponent<manag_station>().max_life_blocks)
            {
                st.spawn_modul(tubes, tubes2, help_new, ref can_spawn, Life_bloks, station_manager.GetComponent<manag_station>().count_life_blocks, station_manager.GetComponent<manag_station>().max_life_blocks, "Life_Block", station_manager);
                station_manager.GetComponent<manag_station>().count_life_blocks++;
            }
            else
            if (station_manager.GetComponent<manag_station>().count_energy_storage != station_manager.GetComponent<manag_station>().max_energy_storage)
            {
                st.spawn_modul(tubes, tubes2, help_new, ref can_spawn, Energy_storage, station_manager.GetComponent<manag_station>().count_energy_storage, station_manager.GetComponent<manag_station>().max_energy_storage, "Energy_storage", station_manager);
                station_manager.GetComponent<manag_station>().count_energy_storage++;
            }
            else
                   if (station_manager.GetComponent<manag_station>().count_sun_battary != station_manager.GetComponent<manag_station>().max_sun_battary)
            {
                st.spawn_modul(tubes, tubes2, help_new, ref can_spawn, Sun_battary, station_manager.GetComponent<manag_station>().count_sun_battary, station_manager.GetComponent<manag_station>().max_sun_battary, "Sun_battary", station_manager);
                station_manager.GetComponent<manag_station>().count_sun_battary++;
            }


        }
        else
        {
            goto x;
        }
    }

    void Gen_Xlam()
    {
        Debug.Log("BUILD XLAM");
        int help_new;
        x: help_new = Random.Range(0, 6);
        if (help_new != help)
        {
            if (station_manager.GetComponent<manag_station>().count_angar != station_manager.GetComponent<manag_station>().max_angar)
            {
                st.spawn_modul(tubes, tubes2, help_new, ref can_spawn, Angar, station_manager.GetComponent<manag_station>().count_angar, station_manager.GetComponent<manag_station>().max_angar, "Angar", station_manager);
                station_manager.GetComponent<manag_station>().count_angar++;
            }
            else
            if (station_manager.GetComponent<manag_station>().count_fuel_bage != station_manager.GetComponent<manag_station>().max_fuel_bage)
            {
                st.spawn_modul(tubes, tubes2, help_new, ref can_spawn, fuel_bage, station_manager.GetComponent<manag_station>().count_fuel_bage, station_manager.GetComponent<manag_station>().max_fuel_bage, "Fuel", station_manager);
                station_manager.GetComponent<manag_station>().count_fuel_bage++;
            }
            else
            if (station_manager.GetComponent<manag_station>().main_modul != station_manager.GetComponent<manag_station>().max_mainmodul)
            {
               
                st.spawn_modul(tubes, tubes2, help_new, ref can_spawn, Xlam_Utilize, station_manager.GetComponent<manag_station>().main_modul, station_manager.GetComponent<manag_station>().max_mainmodul, "Xlam Utilize", station_manager);              
                station_manager.GetComponent<manag_station>().main_modul++;
            }
            else
            if (station_manager.GetComponent<manag_station>().count_trade_module != station_manager.GetComponent<manag_station>().max_trade_module)
            {
                st.spawn_modul(tubes, tubes2, help_new, ref can_spawn, trade_modul, station_manager.GetComponent<manag_station>().count_trade_module, station_manager.GetComponent<manag_station>().max_trade_module, "Trade", station_manager);
                station_manager.GetComponent<manag_station>().count_trade_module++;
            }
            else
            if (station_manager.GetComponent<manag_station>().count_life_blocks != station_manager.GetComponent<manag_station>().max_life_blocks)
            {
                st.spawn_modul(tubes, tubes2, help_new, ref can_spawn, Life_bloks, station_manager.GetComponent<manag_station>().count_life_blocks, station_manager.GetComponent<manag_station>().max_life_blocks, "Life_Block", station_manager);
                station_manager.GetComponent<manag_station>().count_life_blocks++;
            }
            else
            if (station_manager.GetComponent<manag_station>().count_energy_storage != station_manager.GetComponent<manag_station>().max_energy_storage)
            {
                st.spawn_modul(tubes, tubes2, help_new, ref can_spawn, Energy_storage, station_manager.GetComponent<manag_station>().count_energy_storage, station_manager.GetComponent<manag_station>().max_energy_storage, "Energy_storage", station_manager);
                station_manager.GetComponent<manag_station>().count_energy_storage++;
            }
            else
            if (station_manager.GetComponent<manag_station>().count_sun_battary != station_manager.GetComponent<manag_station>().max_sun_battary)
            {
                st.spawn_modul(tubes, tubes2, help_new, ref can_spawn, Sun_battary, station_manager.GetComponent<manag_station>().count_sun_battary, station_manager.GetComponent<manag_station>().max_sun_battary, "Sun_battary", station_manager);
                station_manager.GetComponent<manag_station>().count_sun_battary++;
            }
        }
        else
        {
            goto x;
        }    
    }

    void Gen_Reserch()
    {
        Debug.Log("BUILD RESERCH");
        int help_new;
        x: help_new = Random.Range(0, 6);
        if (help_new != help)
        {
            if (station_manager.GetComponent<manag_station>().count_angar != station_manager.GetComponent<manag_station>().max_angar)
            {
                st.spawn_modul(tubes, tubes2, help_new, ref can_spawn, Angar, station_manager.GetComponent<manag_station>().count_angar, station_manager.GetComponent<manag_station>().max_angar, "Angar", station_manager);
                station_manager.GetComponent<manag_station>().count_angar++;
            }
            else
            if (station_manager.GetComponent<manag_station>().count_fuel_bage != station_manager.GetComponent<manag_station>().max_fuel_bage)
            {
                st.spawn_modul(tubes, tubes2, help_new, ref can_spawn, fuel_bage, station_manager.GetComponent<manag_station>().count_fuel_bage, station_manager.GetComponent<manag_station>().max_fuel_bage, "Fuel", station_manager);
                station_manager.GetComponent<manag_station>().count_fuel_bage++;
            }
            else
            if (station_manager.GetComponent<manag_station>().main_modul != station_manager.GetComponent<manag_station>().max_mainmodul)
            {
                st.spawn_modul(tubes, tubes2, help_new, ref can_spawn, Antena, station_manager.GetComponent<manag_station>().main_modul, station_manager.GetComponent<manag_station>().max_mainmodul, "Antena", station_manager);
                station_manager.GetComponent<manag_station>().main_modul++;
            }
            else
            if (station_manager.GetComponent<manag_station>().count_trade_module != station_manager.GetComponent<manag_station>().max_trade_module)
            {
                st.spawn_modul(tubes, tubes2, help_new, ref can_spawn, trade_modul, station_manager.GetComponent<manag_station>().count_trade_module, station_manager.GetComponent<manag_station>().max_trade_module, "Trade", station_manager);
                station_manager.GetComponent<manag_station>().count_trade_module++;
            }
            else
            if (station_manager.GetComponent<manag_station>().count_life_blocks != station_manager.GetComponent<manag_station>().max_life_blocks)
            {
                st.spawn_modul(tubes, tubes2, help_new, ref can_spawn, Life_bloks, station_manager.GetComponent<manag_station>().count_life_blocks, station_manager.GetComponent<manag_station>().max_life_blocks, "Life_Block", station_manager);
                station_manager.GetComponent<manag_station>().count_life_blocks++;
            }
            else
            if (station_manager.GetComponent<manag_station>().count_energy_storage != station_manager.GetComponent<manag_station>().max_energy_storage)
            {
                st.spawn_modul(tubes, tubes2, help_new, ref can_spawn, Energy_storage, station_manager.GetComponent<manag_station>().count_energy_storage, station_manager.GetComponent<manag_station>().max_energy_storage, "Energy_storage", station_manager);
                station_manager.GetComponent<manag_station>().count_energy_storage++;
            }
            else
                   if (station_manager.GetComponent<manag_station>().count_sun_battary != station_manager.GetComponent<manag_station>().max_sun_battary)
            {
                st.spawn_modul(tubes, tubes2, help_new, ref can_spawn, Sun_battary, station_manager.GetComponent<manag_station>().count_sun_battary, station_manager.GetComponent<manag_station>().max_sun_battary, "Sun_battary", station_manager);
                station_manager.GetComponent<manag_station>().count_sun_battary++;
            }


        }
        else
        {
            goto x;
        }
    }


    void Gen_Army()
    {
        Debug.Log("BUILD ARMY");
        int help_new;
        x: help_new = Random.Range(0, 6);
        if (help_new != help)
        {
            if (station_manager.GetComponent<manag_station>().count_angar != station_manager.GetComponent<manag_station>().max_angar)
            {
                st.spawn_modul(tubes, tubes2, help_new, ref can_spawn, Angar, station_manager.GetComponent<manag_station>().count_angar, station_manager.GetComponent<manag_station>().max_angar, "Angar", station_manager);
                station_manager.GetComponent<manag_station>().count_angar++;
            }
            else
            if (station_manager.GetComponent<manag_station>().count_fuel_bage != station_manager.GetComponent<manag_station>().max_fuel_bage)
            {
                st.spawn_modul(tubes, tubes2, help_new, ref can_spawn, fuel_bage, station_manager.GetComponent<manag_station>().count_fuel_bage, station_manager.GetComponent<manag_station>().max_fuel_bage, "Fuel", station_manager);
                station_manager.GetComponent<manag_station>().count_fuel_bage++;
            }
            else
            if (station_manager.GetComponent<manag_station>().main_modul != station_manager.GetComponent<manag_station>().max_mainmodul)
            {
                int r = Random.Range(1, 3);
                if (r == 1)
                    st.spawn_modul(tubes, tubes2, help_new, ref can_spawn, Ammo_box, station_manager.GetComponent<manag_station>().main_modul, station_manager.GetComponent<manag_station>().max_mainmodul, "Ammo_box", station_manager);
                if (r == 2)
                    st.spawn_modul(tubes, tubes2, help_new, ref can_spawn, Shild_modul, station_manager.GetComponent<manag_station>().main_modul, station_manager.GetComponent<manag_station>().max_mainmodul, "Shild_modul", station_manager);
                    station_manager.GetComponent<manag_station>().main_modul++;
            }
            else
            if (station_manager.GetComponent<manag_station>().count_trade_module != station_manager.GetComponent<manag_station>().max_trade_module)
            {
                st.spawn_modul(tubes, tubes2, help_new, ref can_spawn, trade_modul, station_manager.GetComponent<manag_station>().count_trade_module, station_manager.GetComponent<manag_station>().max_trade_module, "Trade", station_manager);
                station_manager.GetComponent<manag_station>().count_trade_module++;
            }
            else
            if (station_manager.GetComponent<manag_station>().count_life_blocks != station_manager.GetComponent<manag_station>().max_life_blocks)
            {
                st.spawn_modul(tubes, tubes2, help_new, ref can_spawn, Life_bloks, station_manager.GetComponent<manag_station>().count_life_blocks, station_manager.GetComponent<manag_station>().max_life_blocks, "Life_Block", station_manager);
                station_manager.GetComponent<manag_station>().count_life_blocks++;
            }
            else
            if (station_manager.GetComponent<manag_station>().count_energy_storage != station_manager.GetComponent<manag_station>().max_energy_storage)
            {
                st.spawn_modul(tubes, tubes2, help_new, ref can_spawn, Energy_storage, station_manager.GetComponent<manag_station>().count_energy_storage, station_manager.GetComponent<manag_station>().max_energy_storage, "Energy_storage", station_manager);
                station_manager.GetComponent<manag_station>().count_energy_storage++;
            }
            else
                   if (station_manager.GetComponent<manag_station>().count_sun_battary != station_manager.GetComponent<manag_station>().max_sun_battary)
            {
                st.spawn_modul(tubes, tubes2, help_new, ref can_spawn, Sun_battary, station_manager.GetComponent<manag_station>().count_sun_battary, station_manager.GetComponent<manag_station>().max_sun_battary, "Sun_battary", station_manager);
                station_manager.GetComponent<manag_station>().count_sun_battary++;
            }


        }
        else
        {
            goto x;
        }
    }
    void Gen_Miner()
    {
        Debug.Log("BUILD MINER");
        int help_new;
        x: help_new = Random.Range(0, 6);
        if (help_new != help)
        {
            if (station_manager.GetComponent<manag_station>().count_angar != station_manager.GetComponent<manag_station>().max_angar)
            {
                st.spawn_modul(tubes, tubes2, help_new, ref can_spawn, Angar, station_manager.GetComponent<manag_station>().count_angar, station_manager.GetComponent<manag_station>().max_angar, "Angar", station_manager);
                station_manager.GetComponent<manag_station>().count_angar++;
            }
            else
            if (station_manager.GetComponent<manag_station>().count_fuel_bage != station_manager.GetComponent<manag_station>().max_fuel_bage)
            {
                st.spawn_modul(tubes, tubes2, help_new, ref can_spawn, fuel_bage, station_manager.GetComponent<manag_station>().count_fuel_bage, station_manager.GetComponent<manag_station>().max_fuel_bage, "Fuel", station_manager);
                station_manager.GetComponent<manag_station>().count_fuel_bage++;
            }
            else
            if (station_manager.GetComponent<manag_station>().main_modul != station_manager.GetComponent<manag_station>().max_mainmodul)
            {
                st.spawn_modul(tubes, tubes2, help_new, ref can_spawn, Refactoring, station_manager.GetComponent<manag_station>().main_modul, station_manager.GetComponent<manag_station>().max_mainmodul, "Refactoring", station_manager);
                station_manager.GetComponent<manag_station>().main_modul++;
            }
            else
            if (station_manager.GetComponent<manag_station>().count_trade_module != station_manager.GetComponent<manag_station>().max_trade_module)
            {
                st.spawn_modul(tubes, tubes2, help_new, ref can_spawn, trade_modul, station_manager.GetComponent<manag_station>().count_trade_module, station_manager.GetComponent<manag_station>().max_trade_module, "Trade", station_manager);
                station_manager.GetComponent<manag_station>().count_trade_module++;
            }
            else
            if (station_manager.GetComponent<manag_station>().count_life_blocks != station_manager.GetComponent<manag_station>().max_life_blocks)
            {
                st.spawn_modul(tubes, tubes2, help_new, ref can_spawn, Life_bloks, station_manager.GetComponent<manag_station>().count_life_blocks, station_manager.GetComponent<manag_station>().max_life_blocks, "Life_Block", station_manager);
                station_manager.GetComponent<manag_station>().count_life_blocks++;
            }
            else
            if (station_manager.GetComponent<manag_station>().count_energy_storage != station_manager.GetComponent<manag_station>().max_energy_storage)
            {
                st.spawn_modul(tubes, tubes2, help_new, ref can_spawn, Energy_storage, station_manager.GetComponent<manag_station>().count_energy_storage, station_manager.GetComponent<manag_station>().max_energy_storage, "Energy_storage", station_manager);
                station_manager.GetComponent<manag_station>().count_energy_storage++;
            }
            else
                   if (station_manager.GetComponent<manag_station>().count_sun_battary != station_manager.GetComponent<manag_station>().max_sun_battary)
            {
                st.spawn_modul(tubes, tubes2, help_new, ref can_spawn, Sun_battary, station_manager.GetComponent<manag_station>().count_sun_battary, station_manager.GetComponent<manag_station>().max_sun_battary, "Sun_battary", station_manager);
                station_manager.GetComponent<manag_station>().count_sun_battary++;
            }


        }
        else
        {
            goto x;
        }
    }


    /*
    void Gen_Miner()
    {
        int help_new;
        x: help_new = Random.Range(0, 6);
        if (help_new != help)
        {
            if (station_manager.GetComponent<manag_station>().count_angar != station_manager.GetComponent<manag_station>().max_angar)
            {
                st.spawn_modul(tubes, tubes2, help_new, ref can_spawn, Angar, station_manager.GetComponent<manag_station>().count_angar, station_manager.GetComponent<manag_station>().max_angar, "Angar", station_manager);
                station_manager.GetComponent<manag_station>().count_angar++;
            }
            else
            if (station_manager.GetComponent<manag_station>().count_fuel_bage != station_manager.GetComponent<manag_station>().max_fuel_bage)
            {
                st.spawn_modul(tubes, tubes2, help_new, ref can_spawn, fuel_bage, station_manager.GetComponent<manag_station>().count_fuel_bage, station_manager.GetComponent<manag_station>().max_fuel_bage, "Fuel", station_manager);
                station_manager.GetComponent<manag_station>().count_fuel_bage++;
            }
            else
            if (station_manager.GetComponent<manag_station>().main_modul != station_manager.GetComponent<manag_station>().max_mainmodul)
            {
                st.spawn_modul(tubes, tubes2, help_new, ref can_spawn, Refactoring, station_manager.GetComponent<manag_station>().main_modul, station_manager.GetComponent<manag_station>().max_mainmodul, "Refactoring", station_manager);
                station_manager.GetComponent<manag_station>().main_modul++;
            }
            else
            if (station_manager.GetComponent<manag_station>().count_trade_module != station_manager.GetComponent<manag_station>().max_trade_module)
            {
                st.spawn_modul(tubes, tubes2, help_new, ref can_spawn, trade_modul, station_manager.GetComponent<manag_station>().count_trade_module, station_manager.GetComponent<manag_station>().max_trade_module, "Trade", station_manager);
                station_manager.GetComponent<manag_station>().count_trade_module++;
            }
            else
            if (station_manager.GetComponent<manag_station>().count_life_blocks != station_manager.GetComponent<manag_station>().max_life_blocks)
            {
                st.spawn_modul(tubes, tubes2, help_new, ref can_spawn, Life_bloks, station_manager.GetComponent<manag_station>().count_life_blocks, station_manager.GetComponent<manag_station>().max_life_blocks, "Life_Block", station_manager);
                station_manager.GetComponent<manag_station>().count_life_blocks++;
            }
            else
            if (station_manager.GetComponent<manag_station>().count_sklad != station_manager.GetComponent<manag_station>().max_sklad)
            {
                st.spawn_modul(tubes, tubes2, help_new, ref can_spawn, Sklad, station_manager.GetComponent<manag_station>().count_sklad, station_manager.GetComponent<manag_station>().max_sklad, "Sklad", station_manager);
                station_manager.GetComponent<manag_station>().count_sklad++;
            }
            else
            if (station_manager.GetComponent<manag_station>().count_modul_shatia != station_manager.GetComponent<manag_station>().max_modul_shatia)
            {
                st.spawn_modul(tubes, tubes2, help_new, ref can_spawn, Modul_Zhatia, station_manager.GetComponent<manag_station>().count_modul_shatia, station_manager.GetComponent<manag_station>().max_modul_shatia, "Modul_Zhatia", station_manager);
                station_manager.GetComponent<manag_station>().count_modul_shatia++;
            }
            else
            if (station_manager.GetComponent<manag_station>().count_energy_storage != station_manager.GetComponent<manag_station>().max_energy_storage)
            {
                st.spawn_modul(tubes, tubes2, help_new, ref can_spawn, Energy_storage, station_manager.GetComponent<manag_station>().count_energy_storage, station_manager.GetComponent<manag_station>().max_energy_storage, "Energy_storage", station_manager);
                station_manager.GetComponent<manag_station>().count_energy_storage++;
            }
            else
            if (station_manager.GetComponent<manag_station>().count_sun_battary != station_manager.GetComponent<manag_station>().max_sun_battary)
            {
                st.spawn_modul(tubes, tubes2, help_new, ref can_spawn, Sun_battary, station_manager.GetComponent<manag_station>().count_sun_battary, station_manager.GetComponent<manag_station>().max_sun_battary, "Sun_battary", station_manager);
                station_manager.GetComponent<manag_station>().count_sun_battary++;
            }
           
        }
        else
        {
            goto x;
        }
    }
    */
	void Update ()
    {
        if (station_manager.GetComponent<manag_station>().start_destr == true)
        {
            st.Destroy_Tubes_Visual(tubes, tubes2, help);
            Destroy(this);
        }
    }
}
