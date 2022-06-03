using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class InformativeScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("setNewScene", 30f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void setNewScene(){
         SceneManager.LoadScene("Opening Menu");
    }
}
