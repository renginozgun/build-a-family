using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Bar : MonoBehaviour
{
    public Sprite[] sprites;
    public Image img;
    // Start is called before the first frame update
    void Start()
    {
        img= GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        var number = PuzzleManagement.totalSolvedPuzzles;
        img.sprite= sprites[number];
    }
}
