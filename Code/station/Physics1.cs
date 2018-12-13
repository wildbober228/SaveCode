using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Physics1 : MonoBehaviour {
    [Header("Scripts")]
    public manag_station mang;
    [Header("Nods")]
    public GameObject prev_node;
    public GameObject next_node;
    public int Health ;
   
    public string name_station;
    public float TimeLife;

    [Header("For LifeModul")]
    public GameObject LifeModul;
    public Light[] LifeModul_Light;
    [Header("Effects")]
    public GameObject plazmaeffects;

    // Use this for initialization
    void Start () {
        Health = 10;


    }

    private void OnTriggerEnter(Collider other)
    {
        
        if(other.tag == "Plazma")
        {
            if (plazmaeffects == null)
                Debug.Log("Error="+this.gameObject.name);
           GameObject bullet = (GameObject)Instantiate(plazmaeffects,other.transform.position, other.transform.rotation);
            Debug.Log("Plazma Shoot");
            Destroy(other.gameObject);
            Destroy(bullet, 2);
            Health--;
            if (mang != null)
                mang.Relation -= 1000;
            else
                Debug.Log("ManagStation Dont load");
            if (Health <= 0)
            {       
                if(this.gameObject.GetComponent<Rigidbody>() == false)
                this.gameObject.AddComponent<Rigidbody>().mass = 300;
                if (this.gameObject.GetComponent<Rigidbody>() == true)
                this.gameObject.GetComponent<Rigidbody>().mass = 300;
                this.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * 5000 + Vector3.left * 9000);
                this.gameObject.GetComponent<Rigidbody>().useGravity = false;
                if(LifeModul!=null)
                StartCoroutine(LifeTimeLifeModul(TimeLife));
            }
        }
    }
    IEnumerator LifeTimeLifeModul(float timee)
    {
        float tim = 0;
        while (true)
        {
            yield return null;

            if (tim < timee)
            {
                tim += Time.deltaTime;
            }
            if (tim >= timee)
            {
                for(int i =0; i< LifeModul_Light.Length;i++)
                LifeModul_Light[i].color = Color.red;
                 yield break;
            }

        }
    }
    void Update ()
    {

        // mang = GameObject.Find(name_station).GetComponent<manag_station>();
        //if (mang.karkass_count == mang.max_karkass && this.gameObject.GetComponent<Rigidbody>() == null)
        //{
        //    if (prev_node == false || next_node == false)
        //    {
        //        //for(int i = 0; i < mang.max_karkass; i++)
        //        //{
        //        //    if (prev_node.GetComponent<Physics1>().prev_node == null || next_node.GetComponent<Physics1>().next_node == null)
        //        //    {
        //        this.gameObject.AddComponent<Rigidbody>().mass = 30;
        //        this.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * 5000 + Vector3.left * 9000);
        //        this.gameObject.GetComponent<Rigidbody>().useGravity = false;

        //        //   this.gameObject.GetComponent<Rigidbody>().useGravity = false;
        //        //    }
        //        //}
        //    }

        //}
    }
}
