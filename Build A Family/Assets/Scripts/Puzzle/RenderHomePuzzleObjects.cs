using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderHomePuzzleObjects : MonoBehaviour
{
//Render only non completed puzzles in HomeScene
    void Start()
    {
        var map = PuzzleManagement.solvedItemsMap;
            foreach(Transform child in transform){
            if(map[child.gameObject.tag]){
               
                child.gameObject.SetActive(false);
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    
}
