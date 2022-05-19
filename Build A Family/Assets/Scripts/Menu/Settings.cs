using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Settings : MonoBehaviour
{
    [SerializeField]
    public Button btn;
    // Start is called before the first frame update
    void Start()
    {
        btn.onClick.AddListener(onButtonClick);
    }

    // Update is called once per frame

  void onButtonClick(){
   
    SceneManager.LoadScene("Pause Menu");
    }
}
