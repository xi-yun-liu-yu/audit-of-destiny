using News_Event;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using 溪云;

public class result : MonoBehaviour
{
    Text intelligence;
    Text physical;
    Text mana;
    Text force;

    private void OnEnable()
    {
        refreshResu();

    }

    public void refreshResu()
    {
        //??????npc????
        int index = clickOn.Instance.index;

        //????????
        transform.Find("intelligence/value").GetComponent<Text>().text = 总控制器.Instance.getNpc().getIntelligence().ToString();

        //????????
        transform.Find("physical/value").GetComponent<Text>().text = 总控制器.Instance.getNpc().getPhysical().ToString();

        //???????
        transform.Find("mana/value").GetComponent<Text>().text = 总控制器.Instance.getNpc().getMana().ToString();

        //????????
        transform.Find("force/value").GetComponent<Text>().text = 总控制器.Instance.getNpc().getForce().ToString();
    }
}
