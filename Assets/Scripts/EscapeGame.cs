using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeGame : MonoBehaviour
{    
    void Start() {DontDestroyOnLoad(this.gameObject);}

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
