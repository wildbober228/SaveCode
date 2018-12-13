
using System.Collections.Generic;
using System.Collections;

using UnityEngine;
using UnityEditor;

public class AI_Transport : MonoBehaviour {
    [Space(10, order = 10)]
    #region LayerMask
    [Header("LayerMask")]
    public LayerMask raycastLayerSklad;
    public LayerMask raycastLayerMiner;
    // Initialization
    public GameObject ThisShip;
    #endregion
    #region All Targets
    [Header("All Targets")]
    public GameObject TargetTransform;
    public GameObject TargetEnemy;
    public GameObject TargetRun;
    #endregion
    #region Station Colliders(Dont look)
    [Header("Station Colliders(Dont look)")]
    public GameObject[] Sklads;
    public GameObject[] Miners;
    #endregion
    [Space(10, order = 10)]
    #region SHIP SETTINGS
    [Header("SHIP SETTINGS")]
    public float rotation_speed;  
    public float move_speed;
    public float shoot_time;
    public int ShipHealth;
    [Header("Guns properties")]
    public float gunsSpeedRotation;
    public bool CanShoot;
    [Header("Cargo")]
    public int KIlogrammOfCargo;
    public int MaxKIlogrammOfCargo;

    #endregion
    //
    public enum StateTravel
    {
        Miner_to_Sklad,
        Sklad_to_Miner      
    }
    //
    #region Ship States
    [Header("Ship States")]

    public StateTravel stateTravel;
    private int StateTravelE
    {

        get { return (int)stateTravel; }

        set { stateTravel = (StateTravel)value; }
    }
    #endregion

    #region Main Bools
    [Header("Main Bools")]
    public bool Fly;
    public bool Atack;
    public bool Panic;
    public bool IsLoading;
    #endregion
    #region Main Bools
    [Header("Help Bools")]
    public bool TargetIsNotNull;
    #endregion
    #region Guns obj
    [Header("Guns obj")]
    public GameObject[] GunsLeft;
    public GameObject[] GunsRight;
    public GameObject Left;
    public GameObject Right;
    public GameObject[] SelectGuns;
    //
    public enum typeofweapon
    {
        gun,
        laser,
        plazma
    }
    //
    #endregion

    #region Guns Params
    [Header("Guns Params")]
    public typeofweapon[] Type;
    public GameObject[] bullet;
    public bool Platform_L;
    public bool Platform_R;
    #endregion

    #region Guns Spawns bullets
    [Header("Guns Spawns bullets")]
    public Transform[] bullet_spawn_L;
    public Transform[] bullet_spawn_R;
    #endregion


    #region TestRegion
    [Header("Test Tools(Dont look)")]
    public Collider[] hitColliders_Sklad;
    public Collider[] hitColliders_Miner;
    RaycastHit hit;
    #endregion


    #region MainFucn
    //Main FUNC
    void Start ()
    {
       
        raycastLayerSklad = 1 << LayerMask.NameToLayer("Sklad");
        raycastLayerMiner = 1 << LayerMask.NameToLayer("Miner");


        hitColliders_Sklad = Physics.OverlapSphere(ThisShip.transform.position, 11000, raycastLayerSklad);
        hitColliders_Miner = Physics.OverlapSphere(ThisShip.transform.position, 11000, raycastLayerMiner);

        
        if (CheckCargoNull() == true)
        {

            SelectTarget(hitColliders_Miner);
            Fly = true;
        }
    }
    private void Update()
    {
        
        #region HelpDraw
        //Draw Raycasts
        if (TargetEnemy != null)
        {
            Debug.DrawLine(Right.transform.position, TargetEnemy.transform.position, Color.red);
            Debug.DrawLine(Left.transform.position, TargetEnemy.transform.position, Color.yellow);
        }
        #endregion
        if (Fly == true)
        {
            if(TargetRun == null)
            TransformTranslate(ThisShip.transform, TargetTransform.transform);
            else
                TransformTranslate(ThisShip.transform, TargetRun.transform);
        }
        if (Atack == true)
        {
            voidAtack();
            Panic = true;
          
        }
        if (Panic == true)
        {
            selectRunTarget(hitColliders_Sklad);
        }
        //for (int i = 0; i < Guns.Length; i++)
        //rotateobj.transform.RotateAround(zer.transform.position, Vector3.down, 50 * Time.deltaTime);
    }

    
    //Main FUNC
    #endregion
    //
    #region Trigger
    /// <summary>
    /// Load cargo to ship||UnLoad cargo to ship||Check shoot
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Miner" && Atack == false)
        {
            Stop();
            Debug.Log("Start load");
            StartCoroutine(LoadCoroutine());
        }
        if (other.tag == "Sklad" && Atack == false)
        {
            Stop();
            Debug.Log("Start Unload");
            StartCoroutine(UnLoadCoroutine());
        }
        if (other.tag == "Sklad" && Atack == true)
        {
            Stop();
            //Дописать проверку на отогнали ли игрока, тогда разрещать двигаться кораблю
            Atack = false;
            //Panic = false;
            Debug.Log("Start Unload Panic");
            StartCoroutine(UnLoadCoroutine());
        }
        if (other.tag == "Plazma")
        {
            TargetEnemy = other.GetComponent<BulletOwner>().Owner;
            Atack = true;
            Fly = true;
            //TargetIsNotNull = false;
            //selectRunTarget(hitColliders_Sklad);
            Debug.Log("Atack");
        }
    }
    #endregion
    //
    #region CheckGuns
    private void CheckRaycastGuns(GameObject[] gunsleft, GameObject[] gunsright, Transform target)
    {

        //RaycastHit hit;
           GameObject[] selectguns = null;

        
        
        if (!Physics.Raycast(Left.transform.position, TargetEnemy.transform.position, out hit))
        {
            SelectGuns = new GameObject[gunsleft.Length];
            for (int i = 0; i < gunsleft.Length; i++)
                SelectGuns[i] = gunsleft[i];
            Platform_R = false;
            Platform_L = true;


        }
        if (!Physics.Raycast(Right.transform.position, TargetEnemy.transform.position, out hit))
        {
            SelectGuns = new GameObject[gunsright.Length];
            for (int i = 0; i < gunsright.Length; i++)
                SelectGuns[i] = gunsright[i];
            Platform_L = false;
            Platform_R = true;
        }
      

    }
    #endregion
    //
    #region StateFunc
    public void voidAtack()
    {
        CheckRaycastGuns(GunsLeft, GunsRight, TargetEnemy.transform);
        
        if (SelectGuns != null)
        {
            for (int i = 0; i < SelectGuns.Length; i++)
            {
                Aim(TargetEnemy.transform, SelectGuns[i].transform);
            }
        }
        if (Platform_L == true)
        {
            for (int i = 0; i < SelectGuns.Length; i++)
            {
                shoot(TargetEnemy.transform, SelectGuns[i].transform, bullet_spawn_L[i], (int)Type[i], bullet);
            }
            CanShoot = false;
        }
        if (Platform_R == true)
        {
            for (int i = 0; i < SelectGuns.Length; i++)
            {
                shoot(TargetEnemy.transform, SelectGuns[i].transform, bullet_spawn_R[i], (int)Type[i], bullet);

            }
            CanShoot = false;
        }
    }

    

    public void Stop()
    {      
        Fly = false;
    }
    #endregion
    //
    #region HelpFunc
    bool CheckCargoNull()
    {
        if (KIlogrammOfCargo > 0)
            return false;
        else
            return true;
    }

    void SelectTarget(Collider[] col)
    {
        int rand = Random.Range(0, col.Length);
        
        TargetTransform = col[rand].gameObject;
        //TargetIsNotNull = true;
    }


    void selectRunTarget(Collider[] col)
    {
        if (TargetIsNotNull == false)
        {
            int rand = Random.Range(0, col.Length);

            TargetRun = col[rand].gameObject;
            TargetIsNotNull = true;
          
        }
    }
    void Aim(Transform target, Transform gun)
    {
        Debug.Log("StartTransformGuns");
        //X = xk0+t*vk = xs0+t*vs
       
        //Vector3 a = TargetEnemy.transform.TransformDirection;
        var look_dir = target.position+ TargetEnemy.transform.forward*1.5f - gun.position;
        //gun.rotation = Quaternion.Slerp(gun.rotation, Quaternion.LookRotation(look_dir), gunsSpeedRotation * Time.deltaTime);
        gun.rotation = Quaternion.Slerp(gun.rotation, Quaternion.LookRotation(look_dir), gunsSpeedRotation);
    }

    //protected virtual Vector3 CalculateAim(Transform target, Transform gun)
    //{
    //    //По умолчанию турель стреляет прямо по цели, но, если цель движется, то нужно высчитать точку,
    //    //которая находится перед движущейся целью и по которой будет стрелять турель.
    //    //То есть турель должна стрелять на опережение
    //   Vector3 targetingPosition = target.position;

    //    //Высчитываем точку, перед мишенью, по которой нужно произвести выстрел, чтобы попасть по движущейся мишени
    //    //по идее, чем больше итераций, тем точнее будет положение точки для упреждающего выстрела
    //    for (int i = 0; i < 10; i++)
    //    {
    //        float dist = (gun.position - targetingPosition).magnitude;
    //        float timeToTarget = dist / projectileSpeed;
    //        targetingPosition = target.position + targetSpeed * timeToTarget;
    //    }

    //     return targetingPosition;
    //   // return target.position;
    //}

    void shoot(Transform target, Transform gun, Transform spawn_bullet_pos,int type,GameObject[] bullet)
    {
        if (CanShoot == true)
        {
           
            GameObject bullet_current = (GameObject)Instantiate(bullet[type], spawn_bullet_pos.transform.position, spawn_bullet_pos.transform.rotation);
            //vs = bullet_current.GetComponent<Rigidbody>().velocity;
            Debug.Log("Spawn at Spawnpoint " + spawn_bullet_pos.name);
            bullet_current.AddComponent<BulletOwner>().Owner = this.gameObject;
            bullet_current.GetComponent<Rigidbody>().AddForce(bullet_current.transform.forward * 6000);
            StartCoroutine(Shooting(shoot_time));
        }
       
    }

    void TransformTranslate(Transform thisObj, Transform target)
    {
        Debug.Log("StartTransform");
        var look_dir = target.position - thisObj.position;
        //look_dir.y = 0;
        thisObj.rotation = Quaternion.Slerp(thisObj.rotation, Quaternion.LookRotation(look_dir), rotation_speed * Time.deltaTime);
        thisObj.position += thisObj.forward * move_speed * Time.deltaTime;
    }

    #endregion
    //
    #region IEnumerator
    IEnumerator LoadCoroutine()
    {
        Debug.Log("Load");
        float tim = 0;
        IsLoading = true;
        while (true)
        {
            yield return null;
          
                tim += Time.deltaTime;
                KIlogrammOfCargo = Mathf.RoundToInt(tim);

            if (KIlogrammOfCargo >= MaxKIlogrammOfCargo)
            {
                IsLoading = false;
                
                SelectTarget(hitColliders_Sklad);
                StateTravelE = 0;
                Fly = true;
                yield break;
            }
            if (Atack == true)
            {
                IsLoading = false;
                yield break;
            }

        }
    }
    IEnumerator UnLoadCoroutine()
    {
        Debug.Log("UnLoad");
        float tim = KIlogrammOfCargo;
        IsLoading = true;
        while (true)
        {
            yield return null;
            Debug.Log("UnLoad2");
            tim -= Time.deltaTime;
            KIlogrammOfCargo = Mathf.RoundToInt(tim);

            if (KIlogrammOfCargo <= 0)
            {
                IsLoading = false;
                if (Panic == false)
                {
                    SelectTarget(hitColliders_Miner);
                    StateTravelE = 1;
                    Fly = true;
                }
                else
                {
                    Fly = false;
                }
                yield break;
            }

            if (Atack == true)
            {
                IsLoading = false;
                //if (Panic == true)
                //{
                //    Fly = false;
                //}
                yield break;

            }

        }
    }
    IEnumerator Shooting(float timer)
    {
        Debug.Log("Start shoot");
        float tim = 0;
      
        while (true)
        {
            yield return null;
          
            tim += Time.deltaTime;
            if (tim >= timer)
            {
                tim = 0;
                CanShoot = true;
                yield break;
            }

        }
    }
    #endregion

}
