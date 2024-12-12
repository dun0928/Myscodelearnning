using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider), typeof(OutlineEffect))]
public class ClickTarget : MonoBehaviour
{
    public enum targetType  {BUILDING, ROBOT};
    [Header("类型（巡视机器人、建筑）")]
    public targetType type = targetType.BUILDING;
    [Header("相机位置距离该建筑物的偏离值")]
    public Vector3 offset = new(0, 15, 15);
    [Header("相机视线中心距离该建筑物实际位置的偏离值")]
    public Vector3 lookTargetOffset = new(0, 0, 0);

    private void Start() {
        OutlineEffect outlineEffect = gameObject.GetComponent<OutlineEffect>();
        if (outlineEffect != null) {
            outlineEffect.enabled = false;
        }
    }
}
