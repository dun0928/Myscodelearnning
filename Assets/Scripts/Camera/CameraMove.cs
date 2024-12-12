using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    //private static CameraMove _instance;

    /// <summary>
    /// ����
    /// </summary>
    public static CameraMove instance;

    [SerializeField]
    [Header("�˶��ٶ�")]
    private float speed = 6f;

    [Header("�Ƿ������ҿ���")]
    public bool controllable = true;


    private Vector3 mpStart;
    private Vector3 originalRotation;

    void Awake()
    {
        instance = this;
    }

    /// <summary>
    /// ����ƶ����޹���ʱ�䣩
    /// </summary>
    /// <param name="distance">�ƶ�����</param>
    public void move(Vector3 distance)
    {
        transform.localPosition += distance;
    }

    /// <summary>
    /// ����ƶ�
    /// </summary>
    /// <param name="destination">Ŀ��λ��</param>
    /// <param name="durationInSec">�ƶ�ʱ��</param>
    public TweenerCore<Vector3, Vector3, VectorOptions> moveTo(Vector3 destination, float durationInSec)
    {
        return transform.DOMove(destination, durationInSec);
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
        // Movement
        float forward = 0f;
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) { forward += 1f; }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) { forward -= 1f; }

        float right = 0f;
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) { right += 1f; }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) { right -= 1f; }

        float up = 0f;
        if (Input.GetKey(KeyCode.E) || Input.GetKey(KeyCode.Space)) { up += 1f; }
        if (Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.C)) { up -= 1f; }


        Vector3 distance = transform.TransformDirection(new Vector3(right, up, forward) * speed * (Input.GetKey(KeyCode.LeftShift) ? 2f : 1f) * Time.deltaTime);
        move(distance);

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
            transform.localEulerAngles = originalRotation + new Vector3(offs.y * 360f, offs.x * 360f, 0f);
        }
    }
}