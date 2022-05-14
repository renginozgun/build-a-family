using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagementGameObject : MonoBehaviour
{

     public static int totalSolvedPuzzles = 0;
    // [SerializeField] 
    // private  Text solvedPuzzleStatus;

    private static bool updateBar = false;


    // Start is called before the first frame update
    void Start()
    {

        foreach(Transform child in transform){
            if(child.gameObject.tag!=PuzzleManagement.selectedObject){
                child.gameObject.SetActive(false);
            }
        }

    }

    public static void updateHomeSceneStatusBar()
    {

        updateBar = true;

    }

    public static void updateTotalSolvedPuzzles()
    {

        totalSolvedPuzzles++;

        PuzzleUIController.triggerPuzzleUIUpdate();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
