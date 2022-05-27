using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fail : MonoBehaviour
{
    private Button btn;

    // Start is called before the first frame update
    void Start()
    {
        btn = gameObject.GetComponent<Button>();
        btn.onClick.AddListener(onButtonClick);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void onButtonClick()
    {
        if (btn.tag == "Retry")
        {
            Option.Retry();
        }
        else if (btn.tag == "Exit")
        {
            Option.Quit();
        }
    }
}
