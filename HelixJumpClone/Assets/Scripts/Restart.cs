using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(500, 100, true);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0)
        {
            print("Restart");
            SceneManager.LoadScene(0);
        }
    }
}
