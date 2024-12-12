using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ??????????????????????¦æ??
/// </summary>
public class ClickController : MonoBehaviour
{
    private static ClickController _instance;
    public static ClickController instance => _instance;

    public int nowclickobject_id;
    private OutlineEffect preClicked;
    private CameraMove cameraMoveInstance;
    private SwitchCamera SwitchCameraInstance;
    private float cameraMoveInSec = 1.0f;
    const int maxRayCastDistance = 500;
    public bool enableClick = true;
    // Start is called before the first frame update
    private void Awake()
    {
        _instance = this;
    }
    void Start()
    {
        cameraMoveInstance = CameraMove.instance;
        SwitchCameraInstance = SwitchCamera.instance;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && enableClick)
        {
            Detect();
        }
    }

    void Detect()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, maxRayCastDistance))
        {
            ClickTarget target = hit.transform.GetComponent<ClickTarget>();
            if (target != null && cameraMoveInstance.controllable)
            {
                switch (target.type)
                {
                    case ClickTarget.targetType.BUILDING:
                        if (hit.collider.gameObject.GetComponent<Building_name>() != null) nowclickobject_id = hit.collider.gameObject.GetComponent<Building_name>().building_id;
                        SwitchCameraInstance.SwitchToMain();
                        ClickOnBuilding(hit);
                        break;
                    case ClickTarget.targetType.ROBOT:
                        SwitchCameraInstance.SwitchToRobot();
                        break;
                }
            }
            else if (preClicked != null)
            {
                preClicked.enabled = false;
            }
        }
    }
    void ClickOnBuilding(RaycastHit hit)
    {
        ClickTarget target = hit.transform.GetComponent<ClickTarget>();

        cameraMoveInstance.controllable = false;

        Vector3 targetPosition = hit.transform.position + target.offset;
        cameraMoveInstance.moveTo(targetPosition, cameraMoveInSec);
        cameraMoveInstance.LookAt(target.lookTargetOffset - target.offset, cameraMoveInSec);

        OutlineEffect outlineEffect = hit.transform.GetComponent<OutlineEffect>();

        if (outlineEffect != null)
        {
            if (preClicked != null)
            {
                preClicked.enabled = false;
            }
            outlineEffect.enabled = true;
            preClicked = outlineEffect;
        }


        cameraMoveInstance.controllable = true;
    }
}
