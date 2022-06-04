using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Gameplay_in : MonoBehaviour
{

    [SerializeField]
    private Button closeButton;
    
    void Start()
    {
        closeButton.onClick.AddListener(setNewScene);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void setNewScene(){
         SceneManager.LoadScene("HomeScene");
    }
}
