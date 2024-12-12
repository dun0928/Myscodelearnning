using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour
{
    private static CanvasController _instance;
    public static CanvasController instance => _instance;
    public enum CanvasState { Main, Robot, MainCharts, RoadSelect };
    public delegate void CanvasEvent(CanvasState state);
    public CanvasEvent canvasEvent;
    private CanvasState pre = CanvasState.Main;
    private CanvasState now = CanvasState.Main;
    private void Awake() {
        _instance = this;
    }
    public void SwitchCanvas(CanvasState state) {
        pre = now;
        now = state;
        this.canvasEvent?.Invoke(now);
    }
    public void CanvasToMain() {
        SwitchCanvas(CanvasState.Main);
    }
    public void CanvasToRobot() {
        SwitchCanvas(CanvasState.Robot);
    }
    public void CanvasToMainCharts() {
        SwitchCanvas(CanvasState.MainCharts);
    }
    public void CanvasToRoadSelect() {
        SwitchCanvas(CanvasState.RoadSelect);
    }
    public void CanvasToPre() {
        SwitchCanvas(pre);
    }
    // Start is called before the first frame update
    void Start()
    {
        Invoke(nameof(CanvasToMain), 0.5f);
    }

    // Update is called once per frame
}
