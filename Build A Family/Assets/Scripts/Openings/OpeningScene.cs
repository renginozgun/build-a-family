using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpeningScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("setNewScene", 5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void setNewScene(){
         SceneManager.LoadScene("Informative Opening");
    }
}
