using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using News_Event;
using UnityEngine;
using UnityEngine.UI;

public class Information : MonoBehaviour
{
    [Header(" 绑定周报的表头信息对象")]
    [SerializeField] private GameObject Infromation;
    [Header("第几期")]
    [SerializeField] private int number;
    
    [Space(50)][Tooltip("期望花费的时间")]
    [SerializeField] private float costTime;

    [SerializeField] private float distance;
    [Tooltip("角度变化值")]
    [SerializeField] private float angle;
    private float velocity;
    private float acceleration;

    public Transform FoldTransform { get; set; }
    public Transform OpenTransform { get; set; }
    public GameObject gameObject;
    
    public bool isMoving=false;
    public bool isFolded=false;
    

    public void ToPrevious()
    {
        GameObject.Find("list").GetComponent<NewspaperController>().ToPrevious();
    }

    public void ToNext()
    {
        GameObject.Find("list").GetComponent<NewspaperController>().ToNext();
    }

    private void OnEnable()
    {
        if (FoldTransform==null) return;
        distance = (FoldTransform.position-OpenTransform.position).sqrMagnitude;
        velocity = distance / costTime/1000;
        acceleration = angle/costTime/0.75f;
        gameObject.transform.Find("Information").transform.Find("No.").GetComponent<Text>().text =
            "第" + GameObject.Find("list").GetComponent<NewspaperController>().index + "期";
    }

    private void Update()
    {
        if (isMoving)
        {
            float dTime = Time.deltaTime;
            if (isFolded)
            {
               gameObject.transform.Rotate(Vector3.forward * dTime*acceleration);
                gameObject.transform.position=Vector3.MoveTowards(gameObject.transform.position, OpenTransform.position, velocity *dTime);

            }

            if (!isFolded)
            {
                gameObject.transform.Rotate(Vector3.forward *dTime *(-acceleration));
                gameObject.transform.position=Vector3.MoveTowards(gameObject.transform.position, FoldTransform.position, velocity *dTime);
            }
            if(OpenTransform.position==gameObject.transform.position||FoldTransform.position==gameObject.transform.position)
            {
                isMoving =! isMoving;
                isFolded = !isFolded;
            }
        }
        
    }
}
