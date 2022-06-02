using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gameplay : MonoBehaviour
{
    void Start()
    {
        Invoke("setNewScene", 5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void setNewScene(){
         SceneManager.LoadScene("HomeScene");
    }
}
