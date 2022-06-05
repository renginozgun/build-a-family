using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcPathWalk : MonoBehaviour
{
    //theDad
    [SerializeField] GameObject theDad;

     private Vector3 initialPivotPosition = new Vector3(-26.04f, 0.3672122f, -1.317f); //0

    private Vector3 firstPivotPosition = new Vector3(4.56f, 0.3672122f, 1.01f); //1+

    private Vector3 secondPivotPosition = new Vector3(-15, 0.3672122f, 11); //2 +


    private Vector3 beginning = new Vector3(-9.64f, -1, 16.21f);

    void Update()
    {
        if (theDad.transform.position == initialPivotPosition )
        {
           
            this.gameObject.transform.localPosition = firstPivotPosition;
        }
        else if (theDad.transform.localPosition == firstPivotPosition)
        {
            this.gameObject.transform.localPosition = secondPivotPosition;
        }
        else if (theDad.transform.localPosition == secondPivotPosition)
        {
            this.gameObject.transform.localPosition = initialPivotPosition;
        }
     
    }

   
}
