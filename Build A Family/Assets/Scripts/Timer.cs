using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float timeValue = 3;
    public Text timeText;
    public AudioSource timeTickingSound;

    void Start()
    {
        if(SaveLocation.Instance!=null){
              timeValue = SaveLocation.Instance.timeValue;
        }
      
    }
    void Update()
    {
        if (timeValue > 0)
        {
            timeValue -= Time.deltaTime;
        }
        else
        {
            timeValue = 0;
        }
        DisplayTime(timeValue);

        if(timeValue==0){
             SceneManager.LoadScene("Fail Scene");
        }

        if (timeValue<30){
            timeText.color=Color.red;
            timeTickingSound.Play();
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

    private void OnDestroy() {
         SaveLocation.Instance.timeValue = timeValue;
    }
}
