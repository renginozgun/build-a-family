using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PuzzleUIController : MonoBehaviour
{
    [SerializeField]
    private Button closeButton;
    [SerializeField]
    public Text puzzleCounter;

    [SerializeField]
    public GameObject puzzleBarFill;

//manipulated by DragDrop script and indicates there is an update in number of solved puzzles
    public static bool isUpdated = false;

    // Start is called before the first frame update
    void Start()
    {
        closeButton.onClick.AddListener(onCloseButtonClick);
        updateUIElements();

    }
    void Update()
    {
        if (isUpdated)
        {
            updateUIElements();
            isUpdated = false;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Escape key was pressed");
            SceneManager.LoadScene("HomeScene");
        }
    }

    void updateUIElements()
    {

        puzzleCounter.text = PuzzleManagement.totalSolvedPuzzles.ToString() + " /9 ";
        puzzleBarFill.transform.localScale = new Vector3(0.1309796f, 1.0141f, (0.06f * PuzzleManagement.totalSolvedPuzzles));
        puzzleBarFill.transform.localPosition = new Vector3(puzzleBarFill.transform.localPosition.x, puzzleBarFill.transform.localPosition.y, 9.24f + puzzleBarFill.transform.localScale.z);

    }

    public static void triggerPuzzleUIUpdate()
    {
        isUpdated = true;
    }
    // Update is called once per frame




    public static void onCloseButtonClick()
    {
        SceneManager.LoadScene("HomeScene");
    }
}
