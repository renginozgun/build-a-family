using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PuzzleDragDrop : MonoBehaviour
{
    private GameObject selectedObject;

    Rigidbody rb;

    private int correctPosition = 0;

    private int numberOfPieces;

    [SerializeField]
    private GameObject successMessage;

    [SerializeField]
    private GameObject brokenModel;

    [SerializeField]
    private GameObject completedModel;

    [SerializeField]
    private Text puzzleCounterText;

    [SerializeField]
    private Button closeButton;

    //hold the puzzle piece with correct position status
    private IDictionary<GameObject, bool>
        puzzleMap = new Dictionary<GameObject, bool>();

    private int solvedPuzzles = 0;

    void Start()
    {
        numberOfPieces = brokenModel.transform.childCount;
        var children = brokenModel.transform.root.GetComponentsInChildren<Transform>();

        foreach (var child in children)
        {
            puzzleMap.Add(child.gameObject, false);
        }

        //for close the scene button
        closeButton.onClick.AddListener (sceneTransition);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Sol mouse basıldı
            if (selectedObject == null)
            {
                RaycastHit hit = CastRay();

                if (hit.collider != null)
                {
                    if (!hit.collider.CompareTag("Draggable"))
                    {
                        return;
                    }

                    selectedObject = hit.collider.gameObject;
                    // puzzleMap.Add(selectedObject,false);
                }
            }
            else
            {
                setObjectPosition(0f);

                if (
                    correctPosition != numberOfPieces &&
                    !puzzleMap[selectedObject]
                )
                {
                    checkCompletionStatus(selectedObject
                        .transform
                        .localPosition
                        .x,
                    selectedObject.transform.localPosition.z);
                }

                selectedObject = null;
            }
        }

        if (selectedObject != null)
        {
            setObjectPosition(.25f);
        }

        if (correctPosition == numberOfPieces)
        {
            solvedPuzzles++;
            Debug.Log("GAME ENDED");
            setFinalScene();
        }
    }

    /* Get the object on mouse click */
    private RaycastHit CastRay()
    {
        Vector3 screenMousePosFar =
            new Vector3(Input.mousePosition.x,
                Input.mousePosition.y,
                Camera.main.farClipPlane);
        Vector3 screenMousePosNear =
            new Vector3(Input.mousePosition.x,
                Input.mousePosition.y,
                Camera.main.nearClipPlane);

        Vector3 worldMousePosFar =
            Camera.main.ScreenToWorldPoint(screenMousePosFar);
        Vector3 worldMousePosNear =
            Camera.main.ScreenToWorldPoint(screenMousePosNear);

        RaycastHit hit;
        Physics
            .Raycast(worldMousePosNear,
            worldMousePosFar - worldMousePosNear,
            out hit);

        return hit;
    }

    /* Sets position of selected object on drag and drop */
    private void setObjectPosition(float yPos)
    {
        if (!puzzleMap[selectedObject])
        {
            Vector3 position =
                new Vector3(Input.mousePosition.x,
                    Input.mousePosition.y,
                    Camera
                        .main
                        .WorldToScreenPoint(selectedObject.transform.position)
                        .z);
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(position);
            selectedObject.transform.position =
                new Vector3(worldPosition.x, yPos, worldPosition.z);
        }
    }

    /* Check whether the puzzle is solved
    @params 
    xValue local x position of the selected object
    yValue local y position of the selected object */
    private void checkCompletionStatus(float xValue, float zValue)
    {
        {
            if (
                (xValue < -0.1 && xValue > -0.5) &&
                (zValue < -0.1 && zValue > -0.5)
            )
            {
                correctPosition++;

                Debug.Log (correctPosition);

                Debug.Log (selectedObject);

                puzzleMap[selectedObject] = true;
            }
        }
    }

    /* Sets the final scene of the puzzle */
    private void setFinalScene()
    {
        successMessage.SetActive(true);
        brokenModel.SetActive(false);
        completedModel.SetActive(true);
        puzzleCounterText.text = solvedPuzzles.ToString() + "/9 Solved Puzzles";
       // sceneTransition();
       
    }

    private void sceneTransition()
    {
        SceneManager.LoadScene("HomeScene");
    }

//delay of the scene transition after a puzzle is completed

}
