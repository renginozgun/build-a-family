using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ManagementGameObject : MonoBehaviour
{

     public static int totalSolvedPuzzles = 0;

    [SerializeField]
    public Text timeText;
    // [SerializeField] 
    // private  Text solvedPuzzleStatus;

    private static bool updateBar = false;


    // Start is called before the first frame update
    void Start()
    {
        DisplayTime(SaveLocation.Instance.timeValue);
        

        foreach(Transform child in transform){
            if(child.gameObject.tag!=PuzzleManagement.selectedObject){
                child.gameObject.SetActive(false);
            }
        }

    }

    public static void UpdateTotalSolvedPuzzles()
    {

        totalSolvedPuzzles++;

        PuzzleUIController.triggerPuzzleUIUpdate();

    }

    // Update is called once per frame
    //Continue decreasing the time on save location object
    void Update()
    {
         if (SaveLocation.Instance.timeValue > 0)
        {
            SaveLocation.Instance.timeValue -= Time.deltaTime;
        }
        else
        {
            SaveLocation.Instance.timeValue = 0;
        }

        DisplayTime (SaveLocation.Instance.timeValue);

        if (SaveLocation.Instance.timeValue == 0)
        {
            SceneManager.LoadScene("Fail Scene");
        }

        if (SaveLocation.Instance.timeValue < 30)
        {
            timeText.color = Color.red;
           
        }
    }



    void DisplayTime(float timeToDisplay)
    {
        if (timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }



}


