using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DragDrop : MonoBehaviour
{

    private Vector3 mOffset;

    private float mZCoord;
//Contains the correct pieces and boundry values of each puzzle object by their tags.
//Boundry values determines the acceptable boundries that user places items on
    private IDictionary<string, PuzzleObject> puzzleByTag = new Dictionary<string, PuzzleObject>();
    private PuzzleObject item;

    //isInRight place indicates the selected puzzle piece is placed in the correct position and disables moving again
    private bool isInRightPlace = false;

    //correctedPieces holds the total number of corrected puzzle pieces 
    private static int correctedPieces = 0;

    double tempX;
    double tempY;

    private bool flag = true;
    private void Awake()
    {


//Initialize puzzle values 
        if (flag)
        {
            puzzleByTag.Add("Plate", new PuzzleObject(new Vector3(0, 0, 0), new Boundries(-0.2, 0.2), new Boundries(-0.2, 0.2), new Boundries(-0.2, 0.2)));
            puzzleByTag.Add("Hat", new PuzzleObject(new Vector3(1.64f, 3.7f, -0.6f), new Boundries(1, 2), new Boundries(-0.9, -0.5)));
            puzzleByTag.Add("Jacket", new PuzzleObject(new Vector3(0, 0, 0), new Boundries(-0.3, 0.4), new Boundries(-0.3, 0.4)));
            puzzleByTag.Add("Dress", new PuzzleObject(new Vector3(0, 0, 0), new Boundries(-0.3, 0.4), new Boundries(-0.3, 0.4)));
            puzzleByTag.Add("Bear", new PuzzleObject(new Vector3(0, 0, 0), new Boundries(-0.2, 0.2), new Boundries(-0.1, 0.2)));
            puzzleByTag.Add("Drawing", new PuzzleObject(new Vector3(0, 0, 0), new Boundries(-0.2, 0.2), new Boundries(-0.1, 0.2)));
            puzzleByTag.Add("Necklace", new PuzzleObject(new Vector3(0, 0, 0), new Boundries(-0.2, 0.2), new Boundries(-0.1, 0.2)));
            puzzleByTag.Add("Tree", new PuzzleObject(new Vector3(-43.57f, -19.48f, 11.228f), new Boundries(-45, -41), new Boundries(9, 14)));
            puzzleByTag.Add("Broom", new PuzzleObject(new Vector3(0, 0, 0), new Boundries(-0.2, 0.2), new Boundries(-0.1, 0.2)));
            flag = false;
        }
    }

//Get the item based on its tag
    private void Start()
    {
        item = puzzleByTag[tag];
        item.setCorrectedPieces(0);
    }

    private void Update()
    {
//Update the number of total solved puzzles when correct pieces reach 4
        if (item.getCorrectedPieces() == 4)
        {
            PuzzleManagement.UpdateTotalSolvedPuzzles();

            PuzzleUIController.onCloseButtonClick();
            item.setCorrectedPieces(0); 
        }
       
    }


    private void OnMouseDown()
    {
//If the piece is not in correct place, allow on mouse down
        if (!isInRightPlace)
        {
            mZCoord = Camera.main.WorldToScreenPoint(this.gameObject.transform.position).z;
            mOffset = this.gameObject.transform.position - GetMouseWorldPos();

        }


    }
//If the piece is not in correct place, allow on mouse drag
    private void OnMouseDrag()
    {
        if (!isInRightPlace)
        {
            this.transform.position = GetMouseWorldPos() + mOffset;

        }
    }
//If the piece is not in correct place, allow on mouse up
    private void OnMouseUp()
    {
        //Check for corectness when user drops the piece
        if (!isInRightPlace)
        {
            CheckSuccessStatus(this.transform.localPosition.x, this.transform.localPosition.z);
        }


    }
//Get the mouse click item on 3d world
    private Vector3 GetMouseWorldPos()
    {

        Vector3 mousePoint = Input.mousePosition;

        mousePoint.z = mZCoord;

        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

//Check the corectness based on boundry values
    private void CheckSuccessStatus(float xValue, float zValue)
    {
        item = puzzleByTag[tag];

        if (
            (xValue < item.x.max && xValue > item.x.min) &&
            (zValue < item.z.max && zValue > item.z.min)
        )
        {
            //Correct the piece
            this.transform.localPosition = item.correctPosition;
            this.GetComponent<Renderer>().material.SetColor("_Color", Color.white);
            isInRightPlace = true;

            if (tag == "Hat" || tag== "Tree") item.increaseCorrectedPieces(4); // Hat puzzle containts only one piece to solve. We handle the exception by marking it as completed at one call. 
            else item.increaseCorrectedPieces();

            Debug.Log("Succes= " + item.getCorrectedPieces());

        }

    }



}


