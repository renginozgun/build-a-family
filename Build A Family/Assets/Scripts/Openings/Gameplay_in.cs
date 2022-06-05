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
        closeButton.onClick.AddListener(SetNewScene);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetNewScene(){
         SceneManager.LoadScene("HomeScene");
    }
}
