using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagementGameObject : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        foreach(Transform child in transform){
            if(child.gameObject.tag!=PuzzleManagement.selectedObject){
                child.gameObject.SetActive(false);
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
