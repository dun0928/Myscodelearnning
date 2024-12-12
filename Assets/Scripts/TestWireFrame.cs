using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestWireFrame : MonoBehaviour
{
    public Material[] wireFrameMats;
    public GameObject[] gameObjects;
    WeatherControll weatherControll = new WeatherControll();
    public Terrain terrain;
    Dictionary<int, Material[]> materialMap = new();
    int curIndex = 0;
    void Save(int id, Material[] mats) {
        if (!materialMap.ContainsKey(id)) {
            materialMap.Add(id, mats);
        }
    }
    void SetWireFrameMat(Transform obj) {
        MeshRenderer meshRenderer = obj.GetComponent<MeshRenderer>();
        if (meshRenderer == null) return;
        Material[] materials = meshRenderer.materials;
        Save(obj.GetInstanceID(), materials);
        meshRenderer.materials = wireFrameMats;
    }
    void SetOriMat(Transform obj) {
        if (terrain != null) {
            terrain.enabled = true;
        }
        MeshRenderer meshRenderer = obj.GetComponent<MeshRenderer>();
        if (meshRenderer == null) return;
        int id = obj.GetInstanceID();
        if (materialMap.ContainsKey(id)) {
            Material[] materials;
            materialMap.TryGetValue(id, out materials);
            meshRenderer.materials = materials;
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    void SetToNormal() {
        object[] obj = FindObjectsOfType(typeof(GameObject));
        foreach (object o in obj) {
            GameObject g = (GameObject)o;
            SetOriMat(g.transform);
        }
        if (terrain != null && !terrain.enabled) {
            terrain.enabled = true;
        }
        weatherControll.ChangeTime(0.5f);
        GetComponent<Light>().enabled = false;
    }

    // Update is called once per frame
    void LateUpdate() {
        if (Input.GetKeyDown(KeyCode.K)) {
            object[] obj = FindObjectsOfType(typeof(GameObject));
            foreach (object o in obj) {
                GameObject g = (GameObject)o;
                SetWireFrameMat(g.transform);
            }
            curIndex = curIndex % gameObjects.Length;
            GameObject selected = gameObjects[curIndex];
            curIndex++;
            SetOriMat(selected.transform);

            foreach (Transform child in selected.transform) {
                SetOriMat(child);
            }
            if (terrain != null && terrain.enabled) {
                terrain.enabled = false;
            }
            GetComponent<Light>().enabled = true;
            weatherControll.ChangeTime(0);
        }
        if (Input.GetKeyDown(KeyCode.J)) {
            SetToNormal();
        }
    }
}
