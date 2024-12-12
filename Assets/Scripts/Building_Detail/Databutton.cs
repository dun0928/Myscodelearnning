using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Databutton : MonoBehaviour
{
    GameObject equipment_data;
    bool nowstate=false;
    void Start()
    {
        equipment_data = FindChildInTransform(gameObject.transform, "equipment_data").gameObject;
    }
    private Transform FindChildInTransform(Transform parent, string child)
    {
        Transform childTF = parent.Find(child);
        if (childTF != null)
        {
            return childTF;
        }
        for (int i = 0; i < parent.childCount; i++)
        {
            childTF = FindChildInTransform(parent.GetChild(i), child);
        }
        return childTF;
    }
    public void Data_change()
    {
        nowstate = !nowstate;
        equipment_data.SetActive(nowstate);
    }
}
