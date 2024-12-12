using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickDouble : MonoBehaviour
{
    private float time;
    private ChangeScene ChangeSceneInstance;
    private OutlineEffect myOutlineEffect;
    private void Start()
    {
        ChangeSceneInstance=ChangeScene.instance;
        myOutlineEffect=gameObject.GetComponent<OutlineEffect>();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))//鼠标左键点击，1：右键；2：中键
        {
            RaycastHit hit;
            //向鼠标点击的位置发射一条射线 && 射线检测到的物体是当前挂着该脚本的物体
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit) && hit.transform == transform&&myOutlineEffect.enabled==true)
            {
                //点击的时间间隔在0.2s内
                if ((Time.realtimeSinceStartup - time) < 0.2f)
                {
                    //要双击的物体上一定要有碰撞器，并且碰撞器和本脚本挂在同一个物体上
                    ChangeSceneInstance.ToDetail();
                }
                else
                    time = Time.realtimeSinceStartup;
            }
        }
    }
}
