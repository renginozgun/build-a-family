using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeDamage : MonoBehaviour
{
    [SerializeField]
    GameObject theKid;

    [SerializeField]
    GameObject theDad;

    [SerializeField]
    Image status;

    [SerializeField]
    Camera cam;

    RaycastHit hit;

    private float distance;

    public static bool allowTimeDamage = true;

    void Start()
    {
    }

    void Update()
    {
        //Checks whether TheDad is in the field of Kid's view

            if (checkVisibility())
            {
                //Check wheter user presses Space or not
                if(Input.GetKey(KeyCode.Space)){
                    status.enabled = false;
                    Timer.damageTrigger = false;   
                }else{
                    status.enabled = true;
                    Timer.damageTrigger = true;   
                }

            }
            else
            {
                Timer.damageTrigger = false;
                status.enabled = false;
            }
        
    }

    bool checkVisibility()
    {
        Vector3 directionToPlayer =
            (theDad.transform.position - cam.transform.position).normalized;
        float angleBetweenGuardAndPlayer =
            Vector3.Angle(cam.transform.forward, directionToPlayer);
        if (angleBetweenGuardAndPlayer <= 40)
        {
            if (
                Physics
                    .Raycast(cam.transform.position,
                    (theDad.transform.position - cam.transform.position),
                    out hit)
            )
            {
                if (hit.transform.tag == "Dad")
                {
                    return true;
                }
            }
        }

        return false;
    }

    private void setAllowTimeDamage()
    {
        allowTimeDamage = true;
    }
}
