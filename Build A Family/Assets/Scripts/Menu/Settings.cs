using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
      if(Input.GetKey(KeyCode.Escape)){
          onButtonClick();
      }
    }

    void onButtonClick()
    {
        SceneManager.LoadScene("Pause Menu");
    }
}
