using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletOwner : MonoBehaviour {

    public GameObject Owner;
	void Start () {
        Destroy(this.gameObject, 5f);
    }

    private void OnTriggerEnter(Collider other)
    {
        //if (other)
        //{
        //    Destroy(this.gameObject,0.1f);
        //}

    }
}
