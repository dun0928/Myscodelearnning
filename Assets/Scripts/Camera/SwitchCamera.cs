using Cinemachine;
using DG.Tweening;
using PathCreation.Examples;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCamera : MonoBehaviour
{
    private static SwitchCamera _instance;
    public static SwitchCamera instance { get => _instance; }
    public Camera main;
    public Camera robot;
    public Camera god;
    public PathFollower pathFollwer;
    public GameObject Maincamera;
    public GameObject Godcinemachine;
    public GameObject Godcamera;
    public GameObject Robotcamera;

    private void Awake()
    {
        _instance = this;
        main.enabled = true;
        robot.enabled = false;
        god.enabled = false;
    }
    private void SwitchFromAToB(Camera A, Camera B) {
        float durationInSec = 1;
        Vector3 oriPosition = B.transform.position;
        Quaternion nowRotation = A.transform.rotation;
        nowRotation.SetLookRotation(B.transform.forward);
        B.transform.position = A.transform.position;
        B.transform.rotation = A.transform.rotation;
        A.enabled = false;
        B.enabled = true;
        if (B == robot) {
            float oriSpeed = pathFollwer.speed;
            pathFollwer.speed = 0;
            B.transform.DOMove(oriPosition, durationInSec).OnComplete(() => pathFollwer.speed = oriSpeed); 
        } else {
            B.transform.DOMove(oriPosition, durationInSec).OnKill(()=> Godcinemachine.GetComponent<CinemachineBrain>().enabled = true); 
        }
        B.transform.DORotate(nowRotation.eulerAngles, durationInSec);
    }
    public void MainToRobot() {
        Maincamera.GetComponent<CameraMove>().enabled = false;
        Robotcamera.GetComponent<RobotCameraRotate>().enabled = true;
        SwitchFromAToB(main, robot);
    }
    public void RobotToMain() {
        Maincamera.GetComponent<CameraMove>().enabled = true;
        Robotcamera.GetComponent<RobotCameraRotate>().enabled = false;
        SwitchFromAToB(robot, main);
    }
    public void MainToGod()
    {
        Maincamera.GetComponent<CameraMove>().enabled = false;
        Godcamera.GetComponent<Godcamera>().enabled = true;
        SwitchFromAToB(main, god);
    }
    public void GodToMain()
    {
        Maincamera.GetComponent<CameraMove>().enabled = true;
        Godcamera.GetComponent<Godcamera>().enabled = false;
        SwitchFromAToB(god, main);
    }
    public void GodToRobot()
    {
        Robotcamera.GetComponent<RobotCameraRotate>().enabled = true;
        Godcamera.GetComponent<Godcamera>().enabled = false;
        SwitchFromAToB(god, robot);
    }
    public void RobotToGod()
    {
        Godcamera.GetComponent<Godcamera>().enabled = true;
        Robotcamera.GetComponent<RobotCameraRotate>().enabled = false;
        SwitchFromAToB(robot, god);
    }

    public void SwitchToRobot() {
        CanvasController.instance.CanvasToRobot();
        if (robot.enabled == true) return;
        if (robot.enabled==false) 
        {
            if (main.enabled == true)
            {
                MainToRobot();
            }
            else 
            {
                GodToRobot();
            }
        }
    }
    public void SwitchToMain()
    {
        CanvasController.instance.CanvasToMain();
        if (main.enabled == true) return;
        if (main.enabled == false)
        {
            if (robot.enabled == true)
            {
                RobotToMain();
            }
            else
            {
                GodToMain();
            }
        }
    }
    public void SwitchToGod()
    {
        if (god.enabled == true) return;
        if (god.enabled == false)
        {
            Godcinemachine.GetComponent<CinemachineBrain>().enabled = false;
            if (main.enabled == true)
            {
                MainToGod();
            }
            else
            {
                RobotToGod();
            }
        }
    }
}
