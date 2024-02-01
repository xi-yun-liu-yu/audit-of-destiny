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
        //��ȡ��ǰnpc����
        int index = clickOn.Instance.index;

        //��������
        intelligence.text = EventStream.Instance.npcs[index].getIntelligence().ToString();
        transform.Find("intelligence/value").GetComponent<Text>().text = intelligence.text;

        //��������
        physical.text = EventStream.Instance.npcs[index].getPhysical().ToString();
        transform.Find("physical/value").GetComponent<Text>().text = physical.text;

        //����ħ��
        mana.text = EventStream.Instance.npcs[index].getMana().ToString();
        transform.Find("mana/value").GetComponent<Text>().text = mana.text;

        //��������
        force.text = EventStream.Instance.npcs[index].getForce().ToString();
        transform.Find("force/value").GetComponent<Text>().text = force.text;
    }
}
