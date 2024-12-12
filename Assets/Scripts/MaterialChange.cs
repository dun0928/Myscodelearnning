using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialChange : MonoBehaviour
{
    public Material[] material;
    Renderer rend;
    public GameObject Weather;
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = material[0];
    }

    private void Update()
    {
        if (Weather.GetComponent<Weather>().now_weather == 0)
        {
            rend.sharedMaterial = material[0];
        }
        if (Weather.GetComponent<Weather>().now_weather==1)
        {
            rend.sharedMaterial = material[1];
        }
    }
}
