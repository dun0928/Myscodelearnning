using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public static ChangeScene instance;
    static bool loaded = false;
    void Awake()
    {
        instance = this;
    }
    private void Start() {
        if (!loaded) {
            DontDestroyOnLoad(gameObject);
            loaded = true;
            SceneManager.LoadScene("Login");
        }
    }
    public void ToDetail()
    {
        SceneManager.LoadScene("Building_Detail");
    }
    public void ToLogin() {
        SceneManager.LoadScene("Login");
    }
    public void ToMain()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
