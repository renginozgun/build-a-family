using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class FinalSceneScript : MonoBehaviour
{
    [SerializeField]
    GameObject hat;

    [SerializeField]
    GameObject plate;

    [SerializeField]
    GameObject broom;

    [SerializeField]
    GameObject dress;

    [SerializeField]
    GameObject tree;

    [SerializeField]
    GameObject bear;

    [SerializeField]
    GameObject necklace;

    [SerializeField]
    GameObject drawing;

    [SerializeField]
    GameObject jacket;

    [SerializeField]
    GameObject hatIcon;

    [SerializeField]
    GameObject plateIcon;

    [SerializeField]
    GameObject broomIcon;

    [SerializeField]
    GameObject dressIcon;

    [SerializeField]
    GameObject treeIcon;

    [SerializeField]
    GameObject bearIcon;

    [SerializeField]
    GameObject necklaceIcon;

    [SerializeField]
    GameObject drawingIcon;

    [SerializeField]
    GameObject jacketIcon;

    [SerializeField]
    Text putText;

    private PlayableDirector animation;

    [SerializeField]
    public GameObject timeline;

    Stack sloth = new Stack();

    // Start is called before the first frame update
    void Start()
    {
        initializeSloth();

        animation= timeline.GetComponent<PlayableDirector>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && sloth.Count != 0)
        {
            var item = sloth.Pop();

            switch (item)
            {
                case "Hat":
                    hatIcon.SetActive(false);
                    hat.SetActive(true);
                    break;
                case "Plate":
                    plateIcon.SetActive(false);
                    plate.SetActive(true);
                    break;
                case "Broom":
                    broomIcon.SetActive(false);
                    broom.SetActive(true);
                    break;
                case "Dress":
                    dressIcon.SetActive(false);
                    dress.SetActive(true);
                    break;
                case "Necklase":
                    necklaceIcon.SetActive(false);
                    necklace.SetActive(true);
                    break;
                case "Bear":
                    bearIcon.SetActive(false);
                    bear.SetActive(true);
                    break;
                case "Jacket":
                    jacketIcon.SetActive(false);
                    jacket.SetActive(true);
                    break;
                case "Tree":
                    treeIcon.SetActive(false);
                    tree.SetActive(true);
                    break;
                case "Drawing":
                    drawingIcon.SetActive(false);
                    drawing.SetActive(true);
                    break;
            }
        }


    }

    void initializeSloth()
    {
        sloth.Push("Drawing");
        sloth.Push("Plate");
        sloth.Push("Tree");
        sloth.Push("Hat");
        sloth.Push("Jacket");
        sloth.Push("Bear");
        sloth.Push("Necklase");
        sloth.Push("Dress");
        sloth.Push("Broom");
    }
}
