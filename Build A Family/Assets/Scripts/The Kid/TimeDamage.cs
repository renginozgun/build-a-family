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

    [SerializeField]
    Text damageText;

    float maxRange = 5;

    bool temp = true;

    RaycastHit hit;

    private float distance;

    public static bool allowTimeDamage = true;

    void Start()
    {
        damageText.enabled = false;
    }

    void Update()
    {
        //Checks whether TheDad is in the field of Kid's view
        
        if (checkVisibility())
        {
            status.enabled = true;
             
                if (allowTimeDamage)
                {
                    Timer.damageTrigger = true;
                    damageText.enabled = true;

                    //Make time damage possible again in 10 seconds
                    //Make time damage text dissappear in 2 seconds
                    Invoke("setDamageText", 2f);
                    Invoke("setAllowTimeDamage", 10f);
                    allowTimeDamage = false;
                }
            
        }
        else
        {
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

    private void setDamageText()
    {
        damageText.enabled = false;
    }

    private void setAllowTimeDamage()
    {
        allowTimeDamage = true;
    }
}
