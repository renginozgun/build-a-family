using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Statistics : MonoBehaviour
{

    [SerializeField] private Text firstText;
    [SerializeField] private Text secondText;
    [SerializeField] private Text thirdText;
    [SerializeField] private Text fourthText;
    // Start is called before the first frame update
    void Start()
    {
        setTexts();

    }

    public void setTexts()
    {
      var data = APIHelper.GetNewData();
      firstText.text = "According to the US Department of Health & Human, there are total number of " + data.neglect_only + " children that are victims of child neglect. \n To this day, " 
      + data.psychological_maltreatment + " psychological maltreatment cases are reported and " + data.physical_abuse_only + " children experienced physical abuse in their life." ;

      secondText.text = "Every second in a kid's life matters." ;

      thirdText.text = "When you see a kid in need of help, call social services before they turn into a statistic.";

      fourthText.text="Help them build a family.";

    }

    

}
