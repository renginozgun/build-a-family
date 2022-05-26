using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Analytics;

public class SaveLocation : MonoBehaviour
{
    public static SaveLocation Instance;
    public Vector3 SpawnLocation = new Vector3(0.01659607f, -1.01769f, -0.0008964922f);

    public Vector3 SpawnRotation = new Vector3(0, 0, 0);

    public float timeValue = 660;

    public bool flag = true;

    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
            if(PuzzleManagement.totalSolvedPuzzles==9 && flag){

                AnalyticsResult analyticsResult=Analytics.CustomEvent("GameCompletionTime" + timeValue);
                Debug.Log("analytics result:"  + analyticsResult);

                SceneManager.LoadScene("Final Scene");
                flag=false;
            }

            if(timeValue==0 && flag){
                SceneManager.LoadScene("Fail Scene");
                flag=false;
            }
    }
}
