using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundWaterControll : MonoBehaviour
{
    Renderer rend;
    public GameObject Weather;

    public float targetSize = 5f;
    public float targetAlpha = 0.8f;
    public float totalFadeTime = 5f;
    private float materialAlpha = 0f;
    private float watersize = 0f;
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.material.shader = Shader.Find("Shader Graphs/GroungWaterShaderGraph");
        materialAlpha = rend.material.GetFloat("_Alpha");
        rend.material.SetFloat("_Alpha", 0f);
    }

    private void Update()
    {
        if (Weather.GetComponent<Weather>().now_weather != 1&& watersize != 0f)
        {
            watersize = 0f;
            FadeOut();
        }
        if (Weather.GetComponent<Weather>().now_weather == 1&& watersize==0f)
        {
            watersize = 5.0f;
            FadeIn();
        }
    }
    public void FadeIn() {
        StartCoroutine(FadeInCoroutine());
    }


    public void FadeOut() {
        StartCoroutine(FadeOutCoroutine());
    }

    private IEnumerator FadeInCoroutine() {
        rend.material.SetFloat("_Alpha", 0);
        float nowWaterSize = rend.material.GetFloat("_WaterSize");
        while (nowWaterSize < targetSize && watersize != 0)
        {
            nowWaterSize += Time.deltaTime / totalFadeTime;
            rend.material.SetFloat("_WaterSize", nowWaterSize);
            rend.material.SetFloat("_Alpha", Mathf.Min(nowWaterSize / targetSize * 3 * targetAlpha, targetAlpha));
            yield return null;
        }
        if (watersize == 0) {
            rend.material.SetFloat("_WaterSize", 0);
        }
    }


    private IEnumerator FadeOutCoroutine() {
        float targetWaterSize = 0f;
        float nowWaterSize = rend.material.GetFloat("_WaterSize");
        while (nowWaterSize > targetWaterSize && watersize == 0)
        {
            nowWaterSize -=  3 * Time.deltaTime / totalFadeTime;
            rend.material.SetFloat("_WaterSize", Mathf.Max(nowWaterSize, 0f));
            yield return null;
        }
        rend.material.SetFloat("_Alpha", 0f);
    }

}
