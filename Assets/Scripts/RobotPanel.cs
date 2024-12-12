using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotPanel : MonoBehaviour
{
    public Material wireFrameMat;
    public float rotateSpeed = 10f;
    // Start is called before the first frame update
    Vector3 rotateDelta = new();
    void Start()
    {
        initWireFrame(transform);
    }
    void initWireFrame(Transform ts) {
        foreach (Transform child in ts) {
            MeshRenderer meshRenderer = child.GetComponent<MeshRenderer>();
            if (meshRenderer != null) {
                meshRenderer.material = wireFrameMat;
            }
            initWireFrame(child);
        }
    }

    // Update is called once per frame
    void Update() {
        rotateDelta.y = rotateSpeed * Time.deltaTime;
        transform.Rotate(rotateDelta);
    }
}
