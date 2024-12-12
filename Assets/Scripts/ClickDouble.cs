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
        if (Input.GetMouseButtonDown(0))//�����������1���Ҽ���2���м�
        {
            RaycastHit hit;
            //���������λ�÷���һ������ && ���߼�⵽�������ǵ�ǰ���Ÿýű�������
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit) && hit.transform == transform&&myOutlineEffect.enabled==true)
            {
                //�����ʱ������0.2s��
                if ((Time.realtimeSinceStartup - time) < 0.2f)
                {
                    //Ҫ˫����������һ��Ҫ����ײ����������ײ���ͱ��ű�����ͬһ��������
                    ChangeSceneInstance.ToDetail();
                }
                else
                    time = Time.realtimeSinceStartup;
            }
        }
    }
}
