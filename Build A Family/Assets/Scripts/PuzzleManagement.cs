using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 
using UnityEngine.UI;

public class PuzzleManagement : MonoBehaviour
{
    public static int totalSolvedPuzzles=0;

    public IDictionary<GameObject, bool> solvedItemsMap = new Dictionary<GameObject, bool>();

    [SerializeField] 
    private  Text solvedPuzzleStatus;
    
    private static bool updateBar=false;

    public static string selectedObject;


    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        if(updateBar){
              solvedPuzzleStatus.text= totalSolvedPuzzles.ToString() + "/9 Solved Puzzles";
              updateBar=false;
        }
    }

    public static void updateHomeSceneStatusBar(){

        updateBar=true;
  
    }

    void OnMouseDown()
    {         
        SceneManager.LoadScene("Puzzle Scene");
        selectedObject=this.tag;
        Debug.Log(selectedObject);
    }

}
