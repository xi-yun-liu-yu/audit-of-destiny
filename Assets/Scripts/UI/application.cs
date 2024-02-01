using News_Event;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class application : MonoBehaviour
{
    Text intelligence;
    Text physical;
    Text mana;
    Text force;
    Text experience;

    private void OnEnable()
    {
        //refreshAppl();

    }

    public void refreshAppl()
    {
        //获取当前npc索引
        int index = clickOn.Instance.index;

        //更新智力
        intelligence.text = EventStream.Instance.npcs[index].getIntelligenceClaim().ToString();
        transform.Find("intelligence/value").GetComponent<Text>().text = intelligence.text;

        //更新体力
        physical.text = EventStream.Instance.npcs[index].getPhysicalClaim().ToString();
        transform.Find("physical/value").GetComponent<Text>().text = physical.text;

        //更新魔力
        mana.text = EventStream.Instance.npcs[index].getManaClaim().ToString();
        transform.Find("mana/value").GetComponent<Text>().text = mana.text;

        //更新武力
        force.text = EventStream.Instance.npcs[index].getForceClaim().ToString();
        transform.Find("force/value").GetComponent<Text>().text = force.text;

        //更新经历
        experience.text = EventStream.Instance.npcs[index].getExperienceClaim().ToString();
        transform.Find("experience").GetComponent<Text>().text = experience.text;
    }
}
