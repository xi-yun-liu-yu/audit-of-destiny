using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Information : MonoBehaviour
{
    [Header(" 绑定周报的表头信息对象")]
    [SerializeField] private GameObject Infromation;
    [Header("第几期")]
    [SerializeField] private int number;
    
    [Space(50)]
    [SerializeField] private float costTime;

    [SerializeField] private float distance;

    [SerializeField] private float angle;
    private float velocity;
     private float acceleration;

    public GameObject testobject1;
    public GameObject testobject2;
    public GameObject testobject3;

    public bool isMoving;
    public bool isFolded;

    public void ToPrevious()
    {
        isFolded = false;
        isMoving = true;
    }

    public void ToNext()
    {
        isFolded = true;
        isMoving = true;
    }

    private void Awake()
    {
        distance = (testobject1.transform.position - testobject3.transform.position).sqrMagnitude;
        velocity = distance / costTime;
        acceleration = 60;
        Debug.Log(velocity+"   "+acceleration);
    }

    private void Update()
    {
        if (isMoving)
        {
            if (isFolded)
            {
                testobject2.transform.Rotate(Vector3.forward * Time.deltaTime*acceleration);
                testobject2.transform.position=Vector3.MoveTowards(testobject2.transform.position, testobject3.transform.position, velocity * Time.deltaTime);
            }

            if (!isFolded)
            {
                testobject2.transform.Rotate(Vector3.forward * Time.deltaTime*(-acceleration));
                testobject2.transform.position=Vector3.MoveTowards(testobject2.transform.position, testobject1.transform.position, velocity * Time.deltaTime);

            }
            if( testobject1.transform.position==testobject2.transform.position||testobject3.transform.position==testobject2.transform.position)
            {
                isMoving =! isMoving;
            }
        }
        
    }
}
