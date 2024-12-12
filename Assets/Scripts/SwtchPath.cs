using PathCreation;
using PathCreation.Examples;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SwtchPath : MonoBehaviour
{
    public PathCreator[] pathCreators;
    public GameObject[] pathMeshes;
    public TextMeshProUGUI textMeshPro;
    string[] titles = { "下阶段路线：路线一", "下阶段路线：路线二", "下阶段路线：路线三" };

    public GameObject robot;
    public Vector3 switchPos = new (-134.381821f, 0, -0.700130463f);
    int curIdx = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SwitchTo(int idx) {
        if (idx == curIdx) {
            return;
        }
        if (idx < 0 || idx > pathCreators.Length) {
            return;
        }

        curIdx = idx;
        textMeshPro.SetText(titles[idx]);
    }
    // Update is called once per frame
    void Update()
    {
        PathCreator creator = robot.GetComponent<PathFollower>().pathCreator;
        if (creator != pathCreators[curIdx] && Vector3.Distance(robot.transform.position, switchPos) < 0.1f) {
            robot.GetComponent<PathFollower>().ResetPathCreator(pathCreators[curIdx]);
            ResetPathMeshes();
        }
    }
    private void ResetPathMeshes() {
        for (int i = 0; i < pathMeshes.Length; i++) {
            if (i == curIdx) {
                pathMeshes[i].SetActive(true);
            } else {
                pathMeshes[i].SetActive(false);
            }
        }
    }
}
