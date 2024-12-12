using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherControll : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject Camera;
    public GameObject Weather;//天气全局变量
    //private GlobalSnowEffect.GlobalSnow globalSnow;

    private GameObject Windzones;//风区
    List<CableProceduralSimple> cableDanceScripts = new List<CableProceduralSimple>();
    string cablesFatherTag = "cablesFather";

    private void Start()
    {
        Windzones = Weather.transform.Find("WindZone").gameObject;
        //globalSnow = GlobalSnowEffect.GlobalSnow.instance;
        //globalSnow.enabled = false;
    }
    void initCableDanceScripts() {
        GameObject[] cablesFathers = GameObject.FindGameObjectsWithTag(cablesFatherTag);
        foreach (GameObject cablesFather in cablesFathers)
        {
            CableProceduralSimple[] cableProceduralSimpleComponents = cablesFather.GetComponentsInChildren<CableProceduralSimple>(true);

            foreach (CableProceduralSimple cableComponent in cableProceduralSimpleComponents)
            {
                cableDanceScripts.Add(cableComponent);
            }
        }
    }
    void CableDance(bool enable) {
        if (cableDanceScripts.Count == 0) {
            initCableDanceScripts();
        }
        foreach (CableProceduralSimple cs in cableDanceScripts) {
            cs.enabled = enable;
        }
    }
    public void RainWeather()
    {
        UniStormSystem.Instance.ChangeWeather(UniStormSystem.Instance.AllWeatherTypes[13]);
        Weather.GetComponent<Weather>().now_weather = 1;
        CableDance(false);
        Windzones.SetActive(false);
        EnableSnow(false);
    }

    public void SnowWeather()
    {
        UniStormSystem.Instance.ChangeWeather(UniStormSystem.Instance.AllWeatherTypes[17]);
        Weather.GetComponent<Weather>().now_weather = 2;
        CableDance(false);
        Windzones.SetActive(false);
        EnableSnow(true);
    }

    public void StormWeather()
    {
        UniStormSystem.Instance.ChangeWeather(UniStormSystem.Instance.AllWeatherTypes[22]);
        Weather.GetComponent<Weather>().now_weather = 3;
        CableDance(true);
        Windzones.SetActive(true);
        EnableSnow(false);
    }

    public void ClearWeather()
    {
        UniStormSystem.Instance.ChangeWeather(UniStormSystem.Instance.AllWeatherTypes[0]);
        Weather.GetComponent<Weather>().now_weather = 0;
        CableDance(false);
        Windzones.SetActive(false);
        EnableSnow(false);
    }

    void EnableSnow(bool enabled) {
        //globalSnow.snowfall = enabled;
        //globalSnow.enabled = enabled;
    }
    public void ChangeTime(float value) {
        UniStormSystem.Instance.ChangeTime(value);
    }
}
