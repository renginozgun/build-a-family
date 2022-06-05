using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpeningScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("SetNewScene", 6f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetNewScene(){
         SceneManager.LoadScene("Informative Opening");
    }
}
