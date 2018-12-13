using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventori_Player : MonoBehaviour {

    public InventoriMain inventMain;

    
    

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "ItemInSpace" && inventMain.CurrentAmountItems<5 && other.gameObject.GetComponent<Item>().collide == false)
        {
            other.gameObject.GetComponent<Item>().collide = true;
            if (other.gameObject.GetComponent<Item>().random == false)
            {
                inventMain.AddItemsToCargo(other.gameObject.GetComponent<Item>());
                Destroy(other.gameObject);
            }
            if (other.gameObject.GetComponent<Item>().random == true)
            {
                inventMain.AddItemsToCargo(other.gameObject.GetComponent<Item>(), SelectRandomItem(other.gameObject.GetComponent<Item>().RandomItems));
                Destroy(other.gameObject);
            }

        }
    }

    int SelectRandomItem(GameObject[] Items)
    {
        int rand = Random.Range(0, Items.Length);
        return rand;
    }
}
