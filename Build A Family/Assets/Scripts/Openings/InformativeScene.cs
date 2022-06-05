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
        btn.onClick.AddListener(SetNewScene);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetNewScene(){
         SceneManager.LoadScene("Opening Menu");
    }
}
