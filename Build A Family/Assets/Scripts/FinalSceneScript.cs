using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalSceneScript : MonoBehaviour
{
    [SerializeField] GameObject hat;
    [SerializeField] GameObject plate;
    [SerializeField] GameObject broom;

    [SerializeField] GameObject hatIcon;
    [SerializeField] GameObject plateIcon;
    [SerializeField] GameObject broomIcon;

    Stack sloth = new Stack();

    // Start is called before the first frame update
    void Start()
    {
        initializeSloth();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P) && sloth!=null){

            var item =sloth.Pop();

            switch (item){
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
            }
            
        }
    }

    void initializeSloth()
    {
        sloth.Push("Broom");
        sloth.Push("Plate");
        sloth.Push("Hat");
    }


}
