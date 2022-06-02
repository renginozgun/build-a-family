using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcPathWalk : MonoBehaviour
{
    
    [SerializeField] GameObject Jake;

     private Vector3 initialPivotPosition = new Vector3(-26.04f, 0.2973232f, -0.85f); //0

    private Vector3 firstPivotPosition = new Vector3(4.56f, 0.2973232f, 1.01f); //1+

    private Vector3 secondPivotPosition = new Vector3(-15, 0.2973232f, 11); //2 +


    private Vector3 beginning = new Vector3(-9.64f, -1, 16.21f);

    void Update()
    {
        if (Jake.transform.position == initialPivotPosition )
        {
           
            this.gameObject.transform.localPosition = firstPivotPosition;
        }
        else if (Jake.transform.localPosition == firstPivotPosition)
        {
            this.gameObject.transform.localPosition = secondPivotPosition;
        }
        else if (Jake.transform.localPosition == secondPivotPosition)
        {
            this.gameObject.transform.localPosition = initialPivotPosition;
        }
     
    }

   
}
