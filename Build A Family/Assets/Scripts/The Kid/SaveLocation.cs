using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLocation : MonoBehaviour
{
    public static SaveLocation Instance;
    public Vector3 SpawnLocation = new Vector3(0.01659607f, -1.01769f, -0.0008964922f);

    public Vector3 SpawnRotation = new Vector3(0, 0, 0);

    public float timeValue = 660;

    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
