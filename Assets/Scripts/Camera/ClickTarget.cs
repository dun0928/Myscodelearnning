using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider), typeof(OutlineEffect))]
public class ClickTarget : MonoBehaviour
{
    public enum targetType  {BUILDING, ROBOT};
    [Header("���ͣ�Ѳ�ӻ����ˡ�������")]
    public targetType type = targetType.BUILDING;
    [Header("���λ�þ���ý������ƫ��ֵ")]
    public Vector3 offset = new(0, 15, 15);
    [Header("����������ľ���ý�����ʵ��λ�õ�ƫ��ֵ")]
    public Vector3 lookTargetOffset = new(0, 0, 0);

    private void Start() {
        OutlineEffect outlineEffect = gameObject.GetComponent<OutlineEffect>();
        if (outlineEffect != null) {
            outlineEffect.enabled = false;
        }
    }
}
