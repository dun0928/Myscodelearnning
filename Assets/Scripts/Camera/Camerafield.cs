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
        //获取摄像头组件
        c = this.GetComponent<CinemachineFreeLook>();

    }


    private void Update()
    {

        //获取虚拟按键(鼠标中轴滚轮)
        mouseCenter = Input.GetAxis("Mouse ScrollWheel");      //鼠标滑动中键滚轮,实现摄像机的镜头放大和缩放 ,mouseCenter < 0 = 负数 往后滑动,缩放镜头
        if (mouseCenter < 0)
        {                   //滑动限制
            if (c.m_Lens.FieldOfView <= maxView)
            {
                c.m_Lens.FieldOfView += 10 * slideSpeed * Time.deltaTime;
                if (c.m_Lens.FieldOfView >= maxView)
                {
                    c.m_Lens.FieldOfView = maxView;
                }
            }
            //mouseCenter >0 = 正数 往前滑动,放大镜头
        }
        else if (mouseCenter > 0)
        {            //滑动限制
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
