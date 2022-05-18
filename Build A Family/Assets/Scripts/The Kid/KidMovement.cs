using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class KidMovement : MonoBehaviour
{
    // public Animator playerAnim;
    public Rigidbody playerRigid;
    public float w_speed, wb_speed, olw_speed, rn_speed, ro_speed;
    public bool walking;
    public Transform playerTrans;
    public static Transform latestKidPosition;

    public bool flag = false;


    void Start()
    {
		playerTrans.position=SaveLocation.Instance.SpawnLocation;
		playerTrans.rotation=Quaternion.Euler(SaveLocation.Instance.SpawnRotation);
		

    }

    void FixedUpdate()
    {


        if (Input.GetKey(KeyCode.W))
        {
            playerRigid.velocity = transform.forward * w_speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            playerRigid.velocity = -transform.forward * wb_speed * Time.deltaTime;
        }

        // latestKidPosition = playerTrans
    }
    void Update()
    {
       

        if (Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log("W'ye bastı");
            walking = true;

        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            Debug.Log("W'den kaldırdı");
            walking = false;

        }
        if (Input.GetKeyDown(KeyCode.S))
        {


        }
        if (Input.GetKeyUp(KeyCode.S))
        {


        }
        if (Input.GetKey(KeyCode.A))
        {
            playerTrans.Rotate(0, -ro_speed * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            playerTrans.Rotate(0, ro_speed * Time.deltaTime, 0);
        }

        if (walking == true)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                w_speed = w_speed + rn_speed;
            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                w_speed = olw_speed;

            }
        }
        else
        {
            playerRigid.velocity = new Vector3(0, 0, 0);
        }

       // latestKidPosition = playerTrans;



        /* Debug.Log("Kid position at START: " + playerTrans.localPosition.x + playerTrans.localPosition.y + playerTrans.localPosition.z );
		Debug.Log("Latest poisiton at UPDATE:" + latestKidPosition.localPosition.x + latestKidPosition.localPosition.y + latestKidPosition.localPosition.z );
 */

 
    }

    private void OnDestroy()
    {
		SaveLocation.Instance.SpawnLocation = playerTrans.position;
		var temp = new Vector3(playerTrans.localEulerAngles.x,playerTrans.localEulerAngles.y,playerTrans.localEulerAngles.z);
		SaveLocation.Instance.SpawnRotation=temp;
    
    }

}