using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Option : MonoBehaviour
{

//btn: button on the option scene
    [SerializeField]
    public Button btn;
    // Start is called before the first frame update
    void Start()
    {
        if (btn != null)
        {
            btn.onClick.AddListener(onButtonClick);
        }

    }
//set button click function based on clicked button's name
    void onButtonClick()
    {

        var name = this.name;

        switch (name)
        {

            case "Resume":
                Resume();
                break;
            case "Start":
                GameObject.FindGameObjectWithTag("Music").GetComponent<Sound>().StopMusic();
                Resume();
                break;

            case "Retry":
               // SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
               Retry();
                break;

            case "Gameplay":
                GamePlay();
                break;
                
            case "Gameplay_in":
                GamePlayIn();
                break;

            case "Quit":
                Quit();
                break;
        }
    }
//Open HomeScene with same data
    void Resume()
    {
        SceneManager.LoadScene("HomeScene");
    }
//Open Gameplay Scene
    void GamePlay()
    {
        SceneManager.LoadScene("Gameplay");
    }
//Open GameplayIn Scene
    void GamePlayIn()
    {
        SceneManager.LoadScene("Gameplay_in");
    }

//Destroy SaveLocation instance which holds necessary data in Home Scene.
//Reset all puzzle related data and reload Home Scene again
    public static void Retry(){

        Destroy(SaveLocation.Instance);
        PuzzleManagement.totalSolvedPuzzles=0;
        PuzzleManagement.resetPuzzleObjectMap();
        SceneManager.LoadScene("HomeScene");
    }
// Quits the app.
    public static void Quit(){
       
        Application.Quit();

    }


}
