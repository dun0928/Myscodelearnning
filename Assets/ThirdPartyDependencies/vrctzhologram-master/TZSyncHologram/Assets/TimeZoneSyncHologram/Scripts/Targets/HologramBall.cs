using System;
using UnityEngine;

public class HologramBall : MonoBehaviour
{
    [SerializeField] Vector3 axis = Vector3.up;
    [NonSerialized] public TimeSpan networkTimeOffset;
    public bool rotate = true;

    static HologramBall _instance;
    public static HologramBall instance => _instance;
    private void Awake() {
        _instance = this;
    }
    void Update() {
        var timeOfDay = (DateTime.UtcNow + networkTimeOffset).TimeOfDay;
        if (rotate) {
            transform.localRotation = Quaternion.AngleAxis((float)timeOfDay.TotalSeconds * 6, axis);
        }
    }
}
