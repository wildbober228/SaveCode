using UnityEngine;
using System.Collections;

public class intel : MonoBehaviour {
	public bool a;
	public bool b;
	public bool c;
	public bool d;
	public Transform player;
	public float move_speed;
	public float rotation_speed;
	public Transform enemy2;
	public GameObject Cube_1;
	public GameObject Cube_2;
	public GameObject Cube_3;
	public float speed;



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Vector3.Distance (transform.position, GameObject.FindGameObjectWithTag ("Player").transform.position) <= 10) {
			a = true;

		} else {

			a =false;
			transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Cube_1.transform.position - transform.position),speed + Time.deltaTime);
			d = true;
			if (Vector3.Distance(transform.position, Cube_1.transform.position) <= 1f & d == true)
			{

				d =false;
				b = true;
				transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Cube_2.transform.position - transform.position), speed + Time.deltaTime);

			}
			if (Vector3.Distance(transform.position, Cube_2.transform.position) <= 1f & b == true)
			{

				b = false;
				c = true;
				transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Cube_3.transform.position - transform.position), speed + Time.deltaTime);

			}
			if (Vector3.Distance(transform.position, Cube_3.transform.position) <= 1f & 	c == true)
			{

				c = false;

				transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Cube_1.transform.position - transform.position), speed + Time.deltaTime);

			}




		}
		if (a == true) {
			var look_dir = player.position - enemy2.position;
			look_dir.y = 0;
			enemy2.rotation = Quaternion.Slerp (enemy2.rotation, Quaternion.LookRotation (look_dir), rotation_speed * Time.deltaTime);
			enemy2.position += enemy2.forward * move_speed * Time.deltaTime;
		} else 
		{


			a = false;

		}

	}
}
