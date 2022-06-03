using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Background : MonoBehaviour
{
    public Material[] materials;

    public Text story;

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
        var item = PuzzleManagement.selectedObject;
        switch (item)
        {
            case "Plate":
                rend.sharedMaterial = materials[5];
                story.text="Umm. I don't exactly know why this one is broken. I guess Mom aciddently hit it and it fell. If I can glue it back she will be happy.";
                break;
            case "Broom":
                rend.sharedMaterial = materials[4];
                story.text="Dad broke this while trying to kill an insect that is on Mom. I need to fix it so our home can be clean again.";
                break;
            case "Dress":
                rend.sharedMaterial = materials[1];
                story.text="This one was my Mom's favorite dress that Dad bought. One day she was so upset that she cut it. I want her to wear it again because she looks so pretty again.";
                break;
            case "Necklace":
                rend.sharedMaterial = materials[2];
                story.text="Dad gifted this necklace to Mom before he quit his job. I love that it's so shiny. Maybe If I fix it I make her happy.";
                break;
            case "Jacket":
                rend.sharedMaterial = materials[0];
                story.text="Dad used to wear it everyday to work. Now that he is always home; he doesn't need it. Maybe he would go to job If I fix it.";
                break;
            case "Drawing":
                rend.sharedMaterial = materials[3];
                story.text="I did this drawing. When I showed it to Mom, first she smiled, then cried and tear it apart. Maybe she didn't like it but I wanna keep it in my room.";
                break;
            case "Hat":
                rend.sharedMaterial = materials[6];
                story.text="This hat belonged to my grandpa. They argued for so long one day, and my grandpa never came back.";
                break;
            case "Bear":
                rend.sharedMaterial = materials[6];
                story.text="Meet my bear friend, Teddy. Dad doesn't like Teddy. But Teddy is my only friend, can you fix it?";
                break;
            case "Tree":
                rend.sharedMaterial = materials[6];
                story.text="I love decorating trees. But Dad always trip and fall on it.";
                break;
        }
    }
}
