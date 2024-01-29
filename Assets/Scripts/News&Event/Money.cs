using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour
{
    public int saving { set; get; }
    public static Money Instance{ get; private set; }
    public void RenewMoney()
    {
        transform.Find("Saving").GetComponent<Text>().text = ""+saving;
    }

    public void Awake()
    {
        Instance = this;
    }
}
