using Cinemachine;
using UnityEngine;

public class Godcamera : MonoBehaviour
{


    public float X_sensitivity = 10f;
    public float Y_sensitivity = 10f;

    [Header("加速的惯性")]
    public float celeration = 100f;

    Vector2 speedEased = new Vector2(-100, 0);
    Vector2 mouseSpeed = Vector2.zero;


    private CinemachineFreeLook freeLookCamera;

    void Start()
    {
        freeLookCamera = GetComponent<CinemachineFreeLook>();
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            mouseSpeed.x = Input.GetAxis("Mouse X") * X_sensitivity;
            mouseSpeed.y = Input.GetAxis("Mouse Y") * Y_sensitivity;
        }
        if (Input.GetMouseButtonUp(0))
        {
            mouseSpeed.x = mouseSpeed.y = 0;
        }
        speedEased += (mouseSpeed * celeration - speedEased) * Time.deltaTime;
        freeLookCamera.m_XAxis.Value += speedEased.x * Time.deltaTime;
        freeLookCamera.m_YAxis.Value -= speedEased.y * Time.deltaTime;
    }
}