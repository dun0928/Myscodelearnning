using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    private Camera mCamera;
    private Transform mCameraNode;
    private float mX = 0;
    private float mY = 0;
    public float mXSpeed = 1;
    public float mYSpeed = 1;
    private float mYAngle = 0;
    private float mXAngle = 0;
    void Update()
    {
        if (Input.GetMouseButton(0))
        {

            mX = Input.GetAxis("Mouse X");
            mY = Input.GetAxis("Mouse Y");
        }
        else
        {

            mX = Mathf.Lerp(mX, 0, Time.deltaTime);
            mY = Mathf.Lerp(mY, 0, Time.deltaTime);

        }
        mYAngle += mY * mYSpeed;
        mXAngle += mX * mXSpeed;
        mYAngle = ClampAngle(mYAngle, -90, 90);

        transform.rotation = Quaternion.Euler(-mYAngle, mXAngle, 0);
    }
    public float ClampAngle(float Angle, float minAngle, float maxAngle)
    {

        return Mathf.Clamp(Angle, minAngle, maxAngle);
    }

}
