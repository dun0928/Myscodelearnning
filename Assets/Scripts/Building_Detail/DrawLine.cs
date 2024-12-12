using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XCharts.Runtime;

public class DrawLine : MonoBehaviour
{
    public GameObject labelpoint;
    public GameObject equipmentpoint;

    private LineRenderer line;
    void Start()
    {
        line = gameObject.GetComponent<LineRenderer>();

        line.positionCount = 2;
        line.SetPosition(0, labelpoint.transform.position);
        line.SetPosition(1, equipmentpoint.transform.position);
    }

}
