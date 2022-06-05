using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Statistics : MonoBehaviour
{

    [SerializeField] private Text firstText;

    // Start is called before the first frame update
    void Start()
    {
        //Fetch texts from API
        SetTexts();
        Invoke("SetCreditScene", 15f);
    }

    public void SetTexts()
    {
      //Fill the texts with the data
      var data = APIHelper.GetNewData();
      firstText.text = "According to the US Department of Health & Human, there are total number of " + data.neglect_only + " children that are victims of child neglect. \n \n To this day, " 
      + data.psychological_maltreatment + " psychological maltreatment cases are reported and " + data.physical_abuse_only + " children experienced physical abuse in their life." ;

    }

    public void SetCreditScene() { SceneManager.LoadScene("Credits Scene"); }

}
