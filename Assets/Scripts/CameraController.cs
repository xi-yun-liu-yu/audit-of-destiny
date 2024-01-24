using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    GameObject camera;
    [SerializeField] private float max_velocity;
    [SerializeField] private float velocity;
    [SerializeField] private float max_angular_velocity;
    [SerializeField] private float acceleration;
    [SerializeField] private float angular_acceleration;
    private bool b;
    private Vector3 aimVector3;

    protected void Awake()
    {
        camera = GameObject.Find("Main Camera");
    }

    private void Update()
    {
        if (!b) return;
        if (velocity <= max_velocity)
        {
            velocity = velocity + (acceleration * Time.deltaTime);
        }
        else
        {
            b = !b;
            velocity = 0f;
        }

        if (camera != null)
        {
            camera.transform.position =
                Vector3.MoveTowards(camera.transform.position, aimVector3, velocity * Time.deltaTime);
        }

        if (GameObject.Find("UI").GetComponent<Canvas>().worldCamera == null)
        {
            camera = GameObject.Find("Main Camera");
            GameObject.Find("UI").GetComponent<Canvas>().worldCamera = camera.GetComponent<Camera>();
        }
    }


    //将视角对准目标(target)游戏对象
    public void MoveTarget(GameObject target)
    {
        aimVector3 = target.transform.position;
        b = true;
    }

    //将居中视角
    public void MoveCenter()
    {
        aimVector3 = new Vector3(0f, 0f, 0f);
        b = true;
    }

    //将上移视角
    public void MoveUp()
    {
        aimVector3 = new Vector3(0f, 1080f, 0f);
        b = true;
    }

    //将下移视角
    public void MoveDown()
    {
        aimVector3 = new Vector3(0f, -1080f, 0f);
        b = true;
    }

    //将左移视角
    public void MoveLift()
    {
        aimVector3 = new Vector3(-1920f, 0f, 0f);
        b = true;
    }

    //将右移视角
    public void MoveRight()
    {
        aimVector3 = new Vector3(1920f, 0f, 0f);
        b = true;
    }
}