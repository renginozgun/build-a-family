using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TimeDamage : MonoBehaviour
{
    [SerializeField] GameObject theKid;

    [SerializeField] GameObject theDad;
    [SerializeField] Text status;

    [SerializeField] Camera cam;

    float maxRange = 5;
    RaycastHit hit;

    private float distance;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (checkVisibility())
        {

            status.text = "Danger";
            status.color = Color.red;
        }
        else
        {
            status.text = "Safe";
            status.color = Color.green;
        }

    }

/*     private bool checkFieldOfView(Camera cam, GameObject target)
    {

        var planes = GeometryUtility.CalculateFrustumPlanes(cam);
        var point = target.transform.position;

        foreach (var plane in planes)
        {

            if (plane.GetDistanceToPoint(point) < 0)
            {
                return false;
            }
        }

        return true;

    }

    private bool view()
    {
        RaycastHit hit;

        if (Physics.Raycast(theKid.transform.position, theKid.transform.TransformDirection(Vector3.forward), out hit, 5f))
        {

            if (hit.collider.name == "Cube")
            {
                return true;

            }
        }

        return false;

    }

    private bool view2()
    {

        LayerMask layer = LayerMask.NameToLayer("Default");


        if (Physics.Raycast(cam.transform.position, (theDad.transform.position - cam.transform.position), out hit))
        {
            Debug.Log("hit " + hit.collider.gameObject.name);
            if (hit.transform.tag == "Dad")
            {
                Debug.Log("dad");
                return true;

            }

        }

        return false;


    } */

    bool checkVisibility()
    {

        Vector3 directionToPlayer = (theDad.transform.position - cam.transform.position).normalized;
        float angleBetweenGuardAndPlayer = Vector3.Angle(cam.transform.forward, directionToPlayer);
        if (angleBetweenGuardAndPlayer <= 40)
        {
            

            if (Physics.Raycast(cam.transform.position, (theDad.transform.position - cam.transform.position), out hit))
            {
                Debug.Log("hit " + hit.collider.gameObject.name);
                if (hit.transform.tag == "Dad")
                {
                    Debug.Log("dad");
                    return true;

                }

            }

        }

        return false;
    }


}
