using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XCharts.Runtime;

public class Data_Ruler : MonoBehaviour
{

    public Vector3[] veces;
    //��Ҫ��ȡBoxcollier����Ķ���
    private BoxCollider cube;
    void Start()
    {
        cube = gameObject.GetComponent<BoxCollider>();
        //����ֻ�ܵ���λ�ã� ���ܵ�����ת�����š�
        Transform parent = cube.transform.parent;
        while (parent != null)
        {
            parent.localRotation = Quaternion.Euler(Vector3.zero);
            parent.localScale = Vector3.one;
            parent = parent.parent;
        }

        veces = GetBoxColliderVertexPositions(cube);
    }


    Vector3[] GetBoxColliderVertexPositions(BoxCollider boxcollider)
    {
        var vertices = new Vector3[8];
        //����4����
        vertices[0] = boxcollider.transform.TransformPoint(boxcollider.center + new Vector3(boxcollider.size.x, -boxcollider.size.y, boxcollider.size.z) * 0.5f);
        vertices[1] = boxcollider.transform.TransformPoint(boxcollider.center + new Vector3(-boxcollider.size.x, -boxcollider.size.y, boxcollider.size.z) * 0.5f);
        vertices[2] = boxcollider.transform.TransformPoint(boxcollider.center + new Vector3(-boxcollider.size.x, -boxcollider.size.y, -boxcollider.size.z) * 0.5f);
        vertices[3] = boxcollider.transform.TransformPoint(boxcollider.center + new Vector3(boxcollider.size.x, -boxcollider.size.y, -boxcollider.size.z) * 0.5f);
        //����4����
        vertices[4] = boxcollider.transform.TransformPoint(boxcollider.center + new Vector3(boxcollider.size.x, boxcollider.size.y, boxcollider.size.z) * 0.5f);
        vertices[5] = boxcollider.transform.TransformPoint(boxcollider.center + new Vector3(-boxcollider.size.x, boxcollider.size.y, boxcollider.size.z) * 0.5f);
        vertices[6] = boxcollider.transform.TransformPoint(boxcollider.center + new Vector3(-boxcollider.size.x, boxcollider.size.y, -boxcollider.size.z) * 0.5f);
        vertices[7] = boxcollider.transform.TransformPoint(boxcollider.center + new Vector3(boxcollider.size.x, boxcollider.size.y, -boxcollider.size.z) * 0.5f);

        return vertices;
    }

}
