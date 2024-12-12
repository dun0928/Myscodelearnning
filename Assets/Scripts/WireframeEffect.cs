using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireframeEffect : MonoBehaviour
{
    public Material[] wireFrameMats;
    public GameObject[] wireframeObjects;
    public GameObject wireframeObjectsFather;
    public GameObject substationForWireFrame;
    WeatherControll weatherControll = new WeatherControll();
    public Terrain terrain;
    public GameObject substationNormal;
    Dictionary<int, Material[]> materialMap = new();
    bool terrainEnabled = true;
    public Vector3[] cameraMoveTargetPos;
    public Vector3[] cameraLookDir;
    private void LateUpdate() {
        CameraMove cameraMoveInstance = CameraMove.instance;
        if (Input.GetKeyDown(KeyCode.Tab)) {
            Debug.LogError(cameraMoveInstance.transform.forward);
        }
        if (terrain != null && terrain.enabled != terrainEnabled) {
            terrain.enabled = terrainEnabled;
        }
    }
    void Save(int id, Material[] mats) {
        if (!materialMap.ContainsKey(id)) {
            materialMap.Add(id, mats);
        }
    }
    void SetWireFrameMat(Transform obj) {
        MeshRenderer meshRenderer = obj.GetComponent<MeshRenderer>();
        if (meshRenderer != null) {
            Material[] materials = meshRenderer.materials;
            Save(obj.GetInstanceID(), materials);
            meshRenderer.materials = wireFrameMats;
        }
        foreach (Transform child in obj) {
            SetWireFrameMat(child);
        }
    }
    void MoveCamera(int idx) {
        float cameraMoveInSec = 1f;
        CameraMove cameraMoveInstance = CameraMove.instance;
        cameraMoveInstance.moveTo(cameraMoveTargetPos[idx], cameraMoveInSec);
        cameraMoveInstance.LookAt(cameraLookDir[idx], cameraMoveInSec);
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
    void Start() {

    }
    public void SetToNormal() {
        weatherControll.ChangeTime(0.5f);
        GetComponent<Light>().enabled = false;
        SwitchWireFrameEffect(false);
    }
    void SwitchWireFrameEffect(bool flag) {
        substationForWireFrame.SetActive(flag);
        wireframeObjectsFather.SetActive(flag);
        substationNormal.SetActive(!flag);
        GetComponent<Light>().enabled = flag;
        terrainEnabled = !flag;
    }
    public void SetToWireFrame(int idx) {
        if (idx == 0) {
            SetToNormal();
            ClickController.instance.enableClick = true;
            return;
        }
        ClickController.instance.enableClick = false;
        idx -= 1;
        MoveCamera(idx);
        SetWireFrameMat(substationForWireFrame.transform);
        SetWireFrameMat(wireframeObjectsFather.transform);
        GameObject selected = wireframeObjects[idx];
        SetOriMat(selected.transform);
        foreach (Transform child in selected.transform) {
            SetOriMat(child);
        }
        weatherControll.ChangeTime(0);
        SwitchWireFrameEffect(true);
    }
}
