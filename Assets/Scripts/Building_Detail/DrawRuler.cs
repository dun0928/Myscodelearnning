using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawRuler : MonoBehaviour
{
    public GameObject equipment;
    public int[] usepoint;
    public Vector3 dire;
    public bool changedir;//true时为垂直模型，false平行
    private LineRenderer line;
    void Start()
    {
        Vector3[] vect=equipment.GetComponent<Data_Ruler>().veces;
        line = gameObject.GetComponent<LineRenderer>();
        line.positionCount = 2;
        if (changedir)
        {
            line.SetPosition(0, vect[usepoint[0]] );
            line.SetPosition(1, vect[usepoint[1]] + dire * 3f);
        }
        else
        {
            line.SetPosition(0, vect[usepoint[0]] + dire * 1.5f);
            line.SetPosition(1, vect[usepoint[1]] + dire * 1.5f);
        }
    }

}
