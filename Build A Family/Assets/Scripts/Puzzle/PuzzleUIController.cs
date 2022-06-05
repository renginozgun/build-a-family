using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PuzzleUIController : MonoBehaviour
{
    [SerializeField]
    private Button closeButton;


//Manipulated by DragDrop script and indicates there is an update in number of solved puzzles
    public static bool isUpdated = false;

    // Start is called before the first frame update
    void Start()
    {
        closeButton.onClick.AddListener(onCloseButtonClick);
     

    }
    void Update()
    {
        if (isUpdated)
        {
            isUpdated = false;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
      
            SceneManager.LoadScene("HomeScene");
        }
    }


    public static void triggerPuzzleUIUpdate()
    {
        isUpdated = true;
    }



    public static void onCloseButtonClick()
    {
        SceneManager.LoadScene("HomeScene");
    }
}
