using News_Event;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using 溪云;

public class application : MonoBehaviour
{
    Text intelligence;
    Text physical;
    Text mana;
    Text force;
    Text experience;

    private void OnEnable()
    {
        refreshAppl();

    }

    public void refreshAppl()
    {
        //获取当前npc索引
        int index = clickOn.Instance.index;

        //更新智力
        transform.Find("intelligence/value").GetComponent<Text>().text =总控制器.Instance.getNpc().getIntelligenceClaim().ToString();

        //更新体力
        transform.Find("physical/value").GetComponent<Text>().text = 总控制器.Instance.getNpc().getPhysicalClaim().ToString();

        //更新魔力
        transform.Find("mana/value").GetComponent<Text>().text = 总控制器.Instance.getNpc().getManaClaim().ToString();

        //更新武力
        transform.Find("force/value").GetComponent<Text>().text = 总控制器.Instance.getNpc().getForceClaim().ToString();

        //更新经历
        transform.Find("experience").GetComponent<Text>().text = 总控制器.Instance.getNpc().getExperienceClaim().ToString();
    }
}
