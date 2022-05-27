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
        if (btn != null)
        {
            btn.onClick.AddListener(onButtonClick);
        }

    }

    void onButtonClick()
    {

        var name = this.name;

        switch (name)
        {

            case "Resume":
                Resume();
                break;

            case "Retry":
               // SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
               Retry();
                break;

            case "Gameplay":
                GamePlay();
                break;

            case "Quit":
                Quit();
                break;

        }
    }

    void Resume()
    {
        SceneManager.LoadScene("HomeScene");
    }

    void GamePlay()
    {
        SceneManager.LoadScene("Gameplay");
    }

    public static void Retry(){

        Destroy(SaveLocation.Instance);
        PuzzleManagement.totalSolvedPuzzles=0;
        SceneManager.LoadScene("HomeScene");
    }

    public static void Quit(){
        UnityEditor.EditorApplication.isPlaying = false; //TODO delete later it only closes editor
        Application.Quit();

    }


}
