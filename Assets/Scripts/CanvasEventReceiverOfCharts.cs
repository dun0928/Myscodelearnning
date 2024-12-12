using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XCharts.Runtime;

public class CanvasEventReceiverOfCharts : MonoBehaviour
{
    private CanvasController.CanvasEvent canvasEvent;
    private BaseChart baseChart;
    // Start is called before the first frame update
    void Start()
    {
        canvasEvent = CanvasController.instance.canvasEvent;
        canvasEvent += receiveEvent;
        baseChart = GetComponent<BaseChart>();
    }

    void receiveEvent(CanvasController.CanvasState state) {
        Debug.Log("wula");
        Debug.Log(baseChart);
        if (state == CanvasController.CanvasState.Main) {
            Invoke(nameof(baseChart.AnimationReset), 1f);
        }
    }
    // Update is called once per frame
    void Update() {

    }
}
