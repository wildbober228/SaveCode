using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Guns : MonoBehaviour {

    //public Turret turret;

    public GameObject[] guns;

    public enum typeofweapon
    {
        gun,
        laser,
        plazma
    }
    public typeofweapon[] Type;

    public GameObject[] bullet;

    private void Start()
    {
        for(int i = 0; i < guns.Length; i++)
        {
            guns[i].GetComponent<Turret>().button = bullet[(int)Type[i]];
        }
    }
}
