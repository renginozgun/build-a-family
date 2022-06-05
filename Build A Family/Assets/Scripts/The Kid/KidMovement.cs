using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class KidMovement : MonoBehaviour
{

    public Rigidbody playerRigid;
    public float w_speed, wb_speed, olw_speed, rn_speed, ro_speed;
    public bool walk, lTurn, rTurn, walkBack, walkFast, crouch;

    public Transform playerTrans;
    public static Transform latestKidPosition;

    public AudioSource walkingSound;

    public Animator playerAnimation;

    public bool flag = false;


    void Start()
    {
        playerTrans.position = SaveLocation.Instance.SpawnLocation; //Gets the position of child from saved object 
        playerTrans.rotation = Quaternion.Euler(SaveLocation.Instance.SpawnRotation);

    }

    void FixedUpdate()
    {

//Give velocity values on W or S click
        if (Input.GetKey(KeyCode.W))
        {
            playerRigid.velocity = transform.forward * w_speed * Time.deltaTime;

        }
        if (Input.GetKey(KeyCode.S))
        {
            playerRigid.velocity = -transform.forward * wb_speed * Time.deltaTime;
        }


    }
    void Update()
    {

//Set bool values on each click
        if (Input.GetKeyDown(KeyCode.W))
        {

            walk = true;

        }
        if (Input.GetKeyUp(KeyCode.W))
        {

            walk = false;
            walkFast = false;

        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            walkBack = true;

        }
        if (Input.GetKeyUp(KeyCode.S))
        {

            walkBack = false;

        }

        if (Input.GetKey(KeyCode.A))
        {
            playerTrans.Rotate(0, -ro_speed * Time.deltaTime, 0);

        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            lTurn = true;
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            lTurn = false;
        }
        if (Input.GetKey(KeyCode.D))
        {
            playerTrans.Rotate(0, ro_speed * Time.deltaTime, 0);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            rTurn = true;
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            rTurn = false;
        }

        if (walk)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                w_speed = w_speed + rn_speed;
                walkFast = true;
            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                w_speed = olw_speed;
                walkFast = false;

            }

            if(Input.GetKeyDown(KeyCode.Space)){
                walkFast = false;
                crouch=true;
            }
            if(Input.GetKeyUp(KeyCode.Space)){
                crouch=false;
            }
            walkingSound.mute = false;
        }
        else
        {
            playerRigid.velocity = new Vector3(0, 0, 0);
            walkingSound.mute = true;
            crouch=false;

        }

        if(walkBack){

            if(Input.GetKeyDown(KeyCode.Space)){
               
                crouch=true;
            }
            if(Input.GetKeyUp(KeyCode.Space)){
                crouch=false;
            }

            walkingSound.mute = false;
        }else{
            walkingSound.mute = true;
        }



        setAnimations();


    }

//Set animations
    private void setAnimations()
    {

        playerAnimation.SetBool("Walk", walk);
        playerAnimation.SetBool("Left Turn", lTurn);
        playerAnimation.SetBool("Walk Back", walkBack);
        playerAnimation.SetBool("Right Turn", rTurn);

        if (walk)
        {
            playerAnimation.SetBool("Walk Fast", walkFast);
             playerAnimation.SetBool("CrouchWalk", crouch);
        }
        else if (!walk)
        {
            playerAnimation.SetBool("Walk Fast", false);
            playerAnimation.SetBool("CrouchWalk", false);
        }


        if(lTurn || rTurn){
            if(walk){
                playerAnimation.SetBool("Left Turn", false);
                playerAnimation.SetBool("Right Turn", false);
            }

 

        }

    }

    private void OnDestroy()
    {
        SaveLocation.Instance.SpawnLocation = playerTrans.position;
        var temp = new Vector3(playerTrans.localEulerAngles.x, playerTrans.localEulerAngles.y, playerTrans.localEulerAngles.z);
        SaveLocation.Instance.SpawnRotation = temp;

    }

}