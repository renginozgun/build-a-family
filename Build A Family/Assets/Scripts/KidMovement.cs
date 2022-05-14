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
	
	
	void FixedUpdate(){
		if(Input.GetKey(KeyCode.W)){
			playerRigid.velocity = transform.forward * w_speed * Time.deltaTime;
		}
		if(Input.GetKey(KeyCode.S)){
			playerRigid.velocity = -transform.forward * wb_speed * Time.deltaTime;
		}
	}
	void Update(){
		if(Input.GetKeyDown(KeyCode.W)){
            Debug.Log("W'ye bastı");
			walking = true;
		
		}
		if(Input.GetKeyUp(KeyCode.W)){
            Debug.Log("W'den kaldırdı");
			walking = false;
	
		}
		if(Input.GetKeyDown(KeyCode.S)){
	
		
		}
		if(Input.GetKeyUp(KeyCode.S)){


		}
		if(Input.GetKey(KeyCode.A)){
			playerTrans.Rotate(0, -ro_speed * Time.deltaTime, 0);
		}
		if(Input.GetKey(KeyCode.D)){
			playerTrans.Rotate(0, ro_speed * Time.deltaTime, 0);
		}

		if(walking == true){				
			if(Input.GetKeyDown(KeyCode.LeftShift)){
				w_speed = w_speed + rn_speed;
			}
			if(Input.GetKeyUp(KeyCode.LeftShift)){
				w_speed = olw_speed;
			
			}
		}else{
            playerRigid.velocity = new Vector3(0,0,0);
        }
	}

}