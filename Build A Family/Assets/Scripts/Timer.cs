using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public static float timeValue = 660;

    public Text timeText;

    public AudioSource timeTickingSound;

    public static bool damageTrigger = false;

    public static float latestDamageTime = 0;

    void Start()
    {
        if (SaveLocation.Instance != null)
        {
            timeValue = SaveLocation.Instance.timeValue;
        }
    }

    void Update()
    {
        if (timeValue > 0)
        {
            timeValue -= Time.deltaTime;

            //If damage is triggered decrease the time left by 10 seconds
            if (damageTrigger)
            {
                timeValue -= 10;
                damageTrigger = false;
                latestDamageTime = timeValue;
            }

/*             //Allow time damage after at least 10 seconds pass
            if ((latestDamageTime - timeValue) >= 10)
            {
                TimeDamage.allowTimeDamage = true;
            } */
        }
        else
        {
            timeValue = 0;
        }
        DisplayTime (timeValue);

        if (timeValue == 0)
        {
            SceneManager.LoadScene("Fail Scene");
        }

        if (timeValue < 30)
        {
            timeText.color = Color.red;
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

    private void OnDestroy()
    {
        SaveLocation.Instance.timeValue = timeValue;
    }

    public static float getCurrentTime()
    {
        return timeValue;
    }
}
