using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class InformativeScene : MonoBehaviour
{

    private Button btn;
    // Start is called before the first frame update
    void Start()
    {
        btn= GetComponent<Button>();
        btn.onClick.AddListener(setNewScene);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void setNewScene(){
         SceneManager.LoadScene("Opening Menu");
    }
}
