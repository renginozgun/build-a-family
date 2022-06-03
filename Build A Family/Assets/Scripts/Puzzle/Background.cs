using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public Material[] materials;
    Renderer rend;
    // Start is called before the first frame update
    void Start()
    {
        //Access to renderer of background panel
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        var item= PuzzleManagement.selectedObject;
         switch (item)
            {
                case "Plate":
                    rend.sharedMaterial=materials[5];
                    break;
                case "Broom":
                    rend.sharedMaterial=materials[4];
                    break;
                case "Dress":
                    rend.sharedMaterial=materials[1];
                    break;
                case "Necklase":
                    rend.sharedMaterial=materials[2];
                    break;
                case "Jacket":
                    rend.sharedMaterial=materials[0];
                    break;
                case "Drawing":
                    rend.sharedMaterial=materials[3];
                    break;
                default:
                   rend.sharedMaterial=materials[6];
                    break;

            }
    }
}
