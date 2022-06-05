using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField]
    public Text damageText;
    [SerializeField]
    public RawImage damageArrow;

    [SerializeField]
    public AudioSource damageSoundEffect;

    public static float timeValue = 660;

    public Text timeText;

    public AudioSource timeTickingSound;

    public static bool damageTrigger = false;

    public static float latestDamageTime = 0;

    public static bool allowTimeDamage = true;

    void Start()
    {
        damageText.enabled = false;
        damageArrow.enabled=false;

        if (SaveLocation.Instance != null)
        {
            timeValue = SaveLocation.Instance.timeValue;
        }
    }

    void Update()
    {
        //Allow time damage after at least 10 seconds passes after latest damage
        if (
            (
            SaveLocation.Instance.latestTimeDamageValue -
            SaveLocation.Instance.timeValue
            ) >=
            10
        )
        {
            allowTimeDamage = true;
        }

        if (SaveLocation.Instance.timeValue > 0)
        {
            SaveLocation.Instance.timeValue -= Time.deltaTime;

            //If damage is triggered decrease the time left by 10 seconds
            if (damageTrigger && allowTimeDamage)
            {
                SaveLocation.Instance.timeValue -= 60;
                damageText.enabled = true;
                damageArrow.enabled=true;

                allowTimeDamage = false;
                damageSoundEffect.Play();
                Invoke("hideDamageText", 2f);
                SaveLocation.Instance.latestTimeDamageValue =
                    SaveLocation.Instance.timeValue;
            }
        }
        else
        {
            SaveLocation.Instance.timeValue = 0;
        }
        DisplayTime(SaveLocation.Instance.timeValue);

        if (SaveLocation.Instance.timeValue == 0)
        {
            SceneManager.LoadScene("Fail Scene");
        }

        if (SaveLocation.Instance.timeValue < 30)
        {
            timeText.color = Color.red;
            
            timeTickingSound.mute=false;
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

    /*  private void OnDestroy()
    {
        SaveLocation.Instance.timeValue = timeValue;
    } */
    public static float getCurrentTime()
    {
        return timeValue;
    }

    public void hideDamageText()
    {
        damageText.enabled = false;
        damageArrow.enabled=false;
    }
}
