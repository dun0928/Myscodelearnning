using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Init : MonoBehaviour
{
    static bool loaded = false;
    // Start is called before the first frame update
    void Start()
    {
        if (!loaded) {
            DontDestroyOnLoad(gameObject);
            loaded = true;
            SceneManager.LoadScene("Login");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
