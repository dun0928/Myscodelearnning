using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Safe_Button : MonoBehaviour
{
    GameObject Safe;
    bool nowstate = false;
    void Start()
    {
        Safe = FindChildInTransform(gameObject.transform, "Safe").gameObject;
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
    public void safe_change()
    {
        nowstate = !nowstate;
        Safe.SetActive(nowstate);
    }
}
