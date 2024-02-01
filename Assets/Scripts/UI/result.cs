using News_Event;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class result : MonoBehaviour
{
    Text intelligence;
    Text physical;
    Text mana;
    Text force;

    private void OnEnable()
    {
        //refreshResu();

    }

    public void refreshResu()
    {
        //获取当前npc索引
        int index = clickOn.Instance.index;

        //更新智力
        intelligence.text = EventStream.Instance.npcs[index].getIntelligence().ToString();
        transform.Find("intelligence/value").GetComponent<Text>().text = intelligence.text;

        //更新体力
        physical.text = EventStream.Instance.npcs[index].getPhysical().ToString();
        transform.Find("physical/value").GetComponent<Text>().text = physical.text;

        //更新魔力
        mana.text = EventStream.Instance.npcs[index].getMana().ToString();
        transform.Find("mana/value").GetComponent<Text>().text = mana.text;

        //更新武力
        force.text = EventStream.Instance.npcs[index].getForce().ToString();
        transform.Find("force/value").GetComponent<Text>().text = force.text;
    }
}
