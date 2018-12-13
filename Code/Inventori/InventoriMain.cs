using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoriMain : MonoBehaviour {


    public int MaxAmountItems;
    public int CurrentAmountItems;

    public List<Item> Items;

    public List<GameObject> Items_Obj;

    //public GameObject[] Items;

    public void AddItemsToCargo(Item item)
    {
        Items[CurrentAmountItems] = item;
        Items_Obj[CurrentAmountItems] = Items[CurrentAmountItems].referen;
        CurrentAmountItems++;
    }
    public void AddItemsToCargo(Item item, int Id)
    {
        Items[CurrentAmountItems] = item;
        Items_Obj[CurrentAmountItems] = Items[CurrentAmountItems].RandomItems[Id];
        CurrentAmountItems++;
    }

    public void DropCargo(int Amount, Transform ParentWreck)
    {
        //for (int i = 0;i< Amount; i++)
        //{
        //    GameObject go1 = (GameObject)Instantiate(Items[i], Items[i].transform.position, Items[i].transform.rotation);
        //    Items[i] = null;
        //    CurrentAmountItems--;
        //    go1.transform.SetParent(ParentWreck);
        //}
    }


    void Start ()
    {
		
	}
	
	
	void Update ()
    {
        if (Items.Count > 0)
        {
            for (int i=0;i< Items.Count;i++)
            {
                Debug.Log("Inventori "+ Items[i]);
            }
        }
	}
}
