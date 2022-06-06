using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Close", 17f);
    }

   
   void Close(){
       Application.Quit();
   }
}
