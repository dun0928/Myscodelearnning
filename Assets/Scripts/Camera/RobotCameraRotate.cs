using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotCameraRotate : MonoBehaviour
{

    private static RobotCameraRotate _instance;

    public static RobotCameraRotate instance { get => _instance; }

    [SerializeField]

    [Header("�Ƿ������ҿ���")]
    public bool controllable = true;

    private Vector3 mpStart;
    private Vector3 originalRotation;

    void Awake()
    {
        _instance = this;
    }

    /// <summary>
    /// ������ߵ���
    /// </summary>
    /// <param name="dir">Ŀ�귽��</param>
    /// <param name="durationInSec">������ת��Ŀ�귽������ʱ��</param>
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

            // ��y�����ת��Ϊ0��ֻ������xzƽ������ת
            transform.localEulerAngles = originalRotation + new Vector3(0f, offs.x * 360f, 0f);
        }
    }
}
