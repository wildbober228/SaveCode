using UnityEngine;
using System.Collections;

public class Turret : MonoBehaviour
{
		public float horizontalSpeed;
	public float verticalSpeed;
    public Transform hub;           // Turret hub 
    public Transform barrel;        // Turret barrel
	public float turnRate;
    public Camera cam;
    public GameObject button;
    public Transform spawn_button;
    
    // Is turret currently in firing state


    // Project vector on plane
    Vector3 ProjectVectorOnPlane(Vector3 planeNormal, Vector3 vector)
    {
        return vector - (Vector3.Dot(vector, planeNormal) * planeNormal);
    }



    // Turret tracking
    void Track()
    {
		
        if(hub != null && barrel != null)
        {
            RaycastHit hitInfo;
            // Construct a ray pointing from screen mouse position into world space
            Ray cameraRay = cam.ScreenPointToRay(Input.mousePosition);

            // Raycast
            Vector3 vv =  cameraRay.GetPoint(100);
            //     Vector3 v = cam.ScreenPointToRay(Input.mousePosition).origin;
            //        if (Physics.Raycast(cameraRay, out hitInfo))
            //        {
            //Transform objectHit = hitInfo.transform;
            //            // Horizont
            //              Vector3 headingVector = ProjectVectorOnPlane(hub.up, hitInfo.point - hub.position);
            
            //            Quaternion newHubRotation = Quaternion.LookRotation(headingVector);
            //            hub.rotation = Quaternion.Slerp(hub.rotation, newHubRotation, Time.deltaTime * horizontalSpeed);

            //            // Vertical
            //            Vector3 elevationVector = ProjectVectorOnPlane(hub.right, hitInfo.point - barrel.position);
            //            Quaternion newBarrelRotation = Quaternion.LookRotation(elevationVector);
            //            barrel.rotation = Quaternion.Slerp(barrel.rotation, newBarrelRotation, Time.deltaTime * verticalSpeed);
            //        }
            Vector3 headingVector = ProjectVectorOnPlane(hub.up, vv - hub.position);
            Quaternion newHubRotation = Quaternion.LookRotation(headingVector);
                       hub.rotation = Quaternion.Slerp(hub.rotation, newHubRotation, Time.deltaTime * horizontalSpeed);
            Vector3 elevationVector = ProjectVectorOnPlane(hub.right, vv - barrel.position);
                     Quaternion newBarrelRotation = Quaternion.LookRotation(elevationVector);
                       barrel.rotation = Quaternion.Slerp(barrel.rotation, newBarrelRotation, Time.deltaTime * verticalSpeed);

        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            //Ray cameraRay = cam.ScreenPointToRay(Input.mousePosition);
          //  Vector3 vv = cameraRay.GetPoint(100);
            GameObject bullet = Instantiate(button, spawn_button.transform.position, spawn_button.transform.rotation) as GameObject;
            bullet.AddComponent<BulletOwner>().Owner = this.gameObject;
            bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.forward * 4000);
        }
    }

    void Update()
    {
        // Track turret
        Track();
       

    }
}
