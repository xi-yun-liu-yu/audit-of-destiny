using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour
{
    private int saving { set; get; }

    public void RenewMoney()
    {
        transform.Find("Saving").GetComponent<Text>().text = ""+saving;
    }
    
}
