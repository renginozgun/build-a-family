using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomeUIController : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    public Text puzzleCounter;
    public static bool isUpdated = false;

    void Start()
    {
        UpdateUIElements();
    }

    // Update is called once per frame
    void Update()
    {
          if (isUpdated)
        {
            UpdateUIElements();
            isUpdated = false;
        }
    }

    void UpdateUIElements()
    {

        puzzleCounter.text = PuzzleManagement.totalSolvedPuzzles.ToString() + "/9";
     
    }

    public static void TriggerHomeUIUpdate()
    {
        isUpdated = true;
    }

}
