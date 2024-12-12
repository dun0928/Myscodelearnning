using UnityEngine;
using Cinemachine;

public class GodPlayerMove : MonoBehaviour
{
    public CinemachineFreeLook freeLookCamera;
    public Transform followTarget;
    public float moveSpeed = 10f;

    private bool isDragging = false;
    private Vector3 lastMousePosition;

    void Start()
    {
        if (freeLookCamera == null)
        {
            freeLookCamera = GetComponent<CinemachineFreeLook>();
        }

        if (followTarget == null && freeLookCamera != null)
        {
            followTarget = freeLookCamera.Follow;
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            isDragging = true;
            lastMousePosition = Input.mousePosition;
        }
        if (Input.GetMouseButtonUp(1))
        {
            isDragging = false;
        }

        if (isDragging)
        {
            Vector3 mouseDelta = Input.mousePosition - lastMousePosition;
            Vector3 move = new Vector3(mouseDelta.x, 0, mouseDelta.y) * moveSpeed * Time.deltaTime;

            if (followTarget != null)
            {
                followTarget.position += move;
            }

            lastMousePosition = Input.mousePosition;
        }
    }
}
