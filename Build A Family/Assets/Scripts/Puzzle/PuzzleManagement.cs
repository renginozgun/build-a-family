using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PuzzleManagement : MonoBehaviour
{
    public static int totalSolvedPuzzles = 0;

    public static IDictionary<string, bool>
        solvedItemsMap = new Dictionary<string, bool>();

    public static bool tempFlag = true;

    // [SerializeField]

    // private  Text solvedPuzzleStatus;
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

    public static void updateTotalSolvedPuzzles()
    {
        totalSolvedPuzzles++;

        PuzzleUIController.triggerPuzzleUIUpdate();
        HomeUIController.triggerHomeUIUpdate();

        solvedItemsMap[selectedObject] = true;
    }

    void OnMouseDown()
    {
        SceneManager.LoadScene("Puzzle Scene");
        selectedObject = this.tag;
    }

    public static void setPuzzleObjectMap()
    {
    }

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
