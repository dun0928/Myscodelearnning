using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Create_building : MonoBehaviour
{
    private ClickController clickController;
    public List<GameObject> building_prefab;
    public GameObject building_pos;
    private float[] offsets = {5f,2.95f,2.1f};
    private void OnEnable()
    {
        clickController=ClickController.instance;
        int building_id = clickController.nowclickobject_id;
        GameObject building = building_prefab[building_id];
        GameObject buildingmodel=Instantiate(building, building_pos.transform.position+Vector3.up * offsets[building_id], building.transform.rotation);
        buildingmodel.transform.SetParent(building_pos.transform);
    }
}
