using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trans : MonoBehaviour {

    #region Tools for Aiming
    [Header("Tools for Aiming")]
    public Transform xk0;
    public Transform xs0;
    public Vector3 v_current;
    public Vector3 previousTargetPosition;
    public Vector3 vs_minus;
    public Vector3 vstrelok;
    #endregion

    // Update is called once per frame
    void Update () {
       
        this.transform.GetComponent<Rigidbody>().AddForce(Vector3.left*0.1f);
        
    }

    

    private void LateUpdate()
    {  
        vstrelok = this.transform.GetComponent<Rigidbody>().velocity;
    }
}
