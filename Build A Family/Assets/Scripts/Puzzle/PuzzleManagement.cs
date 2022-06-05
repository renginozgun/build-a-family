using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//Puzzle management manages  completed vs not completed puzzles and hold information of completed puzzles.
public class PuzzleManagement : MonoBehaviour
{
    
    public static int totalSolvedPuzzles = 0;

    public static IDictionary<string, bool>
        solvedItemsMap = new Dictionary<string, bool>();

    public static bool tempFlag = true;

    private static bool updateBar = false;

    public static string selectedObject;

    void Awake()
    {
        if (tempFlag)
        {
            solvedItemsMap.Add("Hat", false);
            solvedItemsMap.Add("Necklace", false);
            solvedItemsMap.Add("Broom", false);

            solvedItemsMap.Add("Plate", false);
            solvedItemsMap.Add("Jacket", false);
            solvedItemsMap.Add("Dress", false);

            solvedItemsMap.Add("Drawing", false);
            solvedItemsMap.Add("Bear", false);
            solvedItemsMap.Add("Tree", false);
            tempFlag = false;
        }
    }

    void Start()
    {
    }

//When a puzzle is complete trigger the game UI to refresh itself
    public static void UpdateTotalSolvedPuzzles()
    {
        totalSolvedPuzzles++;

        PuzzleUIController.triggerPuzzleUIUpdate();
        HomeUIController.TriggerHomeUIUpdate();

        solvedItemsMap[selectedObject] = true;
    }
//When a puzzle object is clicked load puzzle scene
    void OnMouseDown()
    { 
        selectedObject = this.tag;
        SceneManager.LoadScene("Puzzle Scene");
       
    }
//Reset puzzle object only on RETRY
    public static void resetPuzzleObjectMap()
    {
        solvedItemsMap["Hat"] = false;
        solvedItemsMap["Necklace"] = false;
        solvedItemsMap["Broom"] = false;
        solvedItemsMap["Plate"] = false;
        solvedItemsMap["Jacket"] = false;
        solvedItemsMap["Dress"] = false;
        solvedItemsMap["Drawing"] = false;
        solvedItemsMap["Bear"] = false;
        solvedItemsMap["Tree"] = false;
    }
}
