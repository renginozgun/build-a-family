using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcPathWalk : MonoBehaviour
{
    public int pivotPoint = 0;

    //Jake i game object olarak alal�m komple
    [SerializeField] GameObject Jake;

    // �ncelikle hedef objemizin konumlar�n� pivot1,pivot2 de�i�ken olarak tan�mlayal�m ve kar��mamas� i�in yorum sat�r� yazal�m.
    private Vector3 initialPivotPosition = new Vector3(-9, -1, -5); //0

    private Vector3 firstPivotPosition = new Vector3(-18, -1, -6); //1

    private Vector3 secondPivotPosition = new Vector3(-24, -1, 5); //2

    private Vector3 thirdPivotPosition = new Vector3(-9, -1, 14); //3

    private Vector3 beginning = new Vector3(-9, -1, 14);

    void Update()
    {
        moveJake();
    }

    private void moveJake()
    {

        //E�er Jake ilk pivota vard�ysa, k�p�n pozisyonunu ikinciye �ek. E�er jake ikinciye vard�ysa, k�p�n pozisyonunu ���nc�ye �ek gibi gibi
        if (Jake.transform.position == initialPivotPosition || Jake.transform.position == beginning)
        {
            this.gameObject.transform.position = firstPivotPosition;
        }
        else if (Jake.transform.position == firstPivotPosition)
        {
            this.gameObject.transform.position = secondPivotPosition;
        }
        else if (Jake.transform.position == secondPivotPosition)
        {
            this.gameObject.transform.position = thirdPivotPosition;
        }
        else if (Jake.transform.position == thirdPivotPosition)
        {
            this.gameObject.transform.position = initialPivotPosition;
        }

    }

    /* void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Jake")
        {
            Debug.Log("OnTriggerJakeInside");

            if (pivotPoint == 3)
            {
                this.gameObject.transform.position = new Vector3(-1, 1, 8);
                pivotPoint = 0;
                Debug.Log("OnTriggerInside3");
            }

            if (pivotPoint == 2)
            {
                this.gameObject.transform.position = new Vector3(-11, 1, 2);
                pivotPoint = 3;
                Debug.Log("OnTriggerInside3");
            }

            if (pivotPoint == 1)
            {
                this.gameObject.transform.position = new Vector3(27, 1, 25);
                pivotPoint = 2;
                Debug.Log("OnTriggerInside2");
            }

            if (pivotPoint == 0)
            {
                this.gameObject.transform.position = new Vector3(18, 1, 2);
                pivotPoint = 1;
                Debug.Log("OnTriggerInside1");
            }
        }
    } */
}
