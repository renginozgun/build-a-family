using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Option : MonoBehaviour
{

    [SerializeField]
    public Button btn;
    // Start is called before the first frame update
    void Start()
    {        
        btn.onClick.AddListener(onButtonClick);
    }

    void onButtonClick(){
      
      var name = this.name;

      switch(name){

        case "Resume":
        Resume();
        break;

        case "Retry":
         SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        break;

        case "Gameplay":
        GamePlay();
        break;

        case "Quit Game": 
        Application.Quit();
        break;

      }
    }

    void Resume(){
     SceneManager.LoadScene("HomeScene");
    }

    void GamePlay(){
        SceneManager.LoadScene("Gameplay");
    }


}
