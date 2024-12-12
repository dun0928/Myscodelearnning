using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotCameraRotate : MonoBehaviour
{

    private static RobotCameraRotate _instance;

    public static RobotCameraRotate instance { get => _instance; }

    [SerializeField]

    [Header("是否可由玩家控制")]
    public bool controllable = true;

    private Vector3 mpStart;
    private Vector3 originalRotation;

    void Awake()
    {
        _instance = this;
    }

    /// <summary>
    /// 相机视线调整
    /// </summary>
    /// <param name="dir">目标方向</param>
    /// <param name="durationInSec">视线旋转至目标方向所需时间</param>
    public void LookAt(Vector3 dir, float durationInSec)
    {
        Quaternion quaternion = transform.rotation;
        quaternion.SetLookRotation(dir);
        transform.DORotate(quaternion.eulerAngles, durationInSec);
    }

    void Update()
    {
        if (!controllable) { return; }

        // Rotation
        Vector3 mpEnd = Input.mousePosition;

        // Left Mouse Button Down
        if (Input.GetMouseButtonDown(0))
        {
            originalRotation = transform.localEulerAngles;
            mpStart = mpEnd;
        }

        // Left Mouse Button Hold
        if (Input.GetMouseButton(0))
        {
            Vector2 offs = new Vector2((mpEnd.x - mpStart.x) / Screen.width, (mpStart.y - mpEnd.y) / Screen.height);

            // 将y轴的旋转置为0，只允许在xz平面上旋转
            transform.localEulerAngles = originalRotation + new Vector3(0f, offs.x * 360f, 0f);
        }
    }
}
