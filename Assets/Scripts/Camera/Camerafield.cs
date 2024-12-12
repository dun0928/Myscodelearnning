using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camerafield : MonoBehaviour
{
    private CinemachineFreeLook c;
    private float mouseCenter;
    private int maxView = 60;
    private int minView = 35;
    private float slideSpeed = 20;

    private void Start()
    {
        //��ȡ����ͷ���
        c = this.GetComponent<CinemachineFreeLook>();

    }


    private void Update()
    {

        //��ȡ���ⰴ��(����������)
        mouseCenter = Input.GetAxis("Mouse ScrollWheel");      //��껬���м�����,ʵ��������ľ�ͷ�Ŵ������ ,mouseCenter < 0 = ���� ���󻬶�,���ž�ͷ
        if (mouseCenter < 0)
        {                   //��������
            if (c.m_Lens.FieldOfView <= maxView)
            {
                c.m_Lens.FieldOfView += 10 * slideSpeed * Time.deltaTime;
                if (c.m_Lens.FieldOfView >= maxView)
                {
                    c.m_Lens.FieldOfView = maxView;
                }
            }
            //mouseCenter >0 = ���� ��ǰ����,�Ŵ�ͷ
        }
        else if (mouseCenter > 0)
        {            //��������
            if (c.m_Lens.FieldOfView >= minView)
            {
                c.m_Lens.FieldOfView -= 10 * slideSpeed *
              Time.deltaTime;
                if (c.m_Lens.FieldOfView <= minView)
                {
                    c.m_Lens.FieldOfView = minView;
                }
            }
        }
    }
}
