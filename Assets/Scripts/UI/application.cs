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
        //��ȡ��ǰnpc����
        int index = clickOn.Instance.index;

        //��������
        intelligence.text = EventStream.Instance.npcs[index].getIntelligenceClaim().ToString();
        transform.Find("intelligence/value").GetComponent<Text>().text = intelligence.text;

        //��������
        physical.text = EventStream.Instance.npcs[index].getPhysicalClaim().ToString();
        transform.Find("physical/value").GetComponent<Text>().text = physical.text;

        //����ħ��
        mana.text = EventStream.Instance.npcs[index].getManaClaim().ToString();
        transform.Find("mana/value").GetComponent<Text>().text = mana.text;

        //��������
        force.text = EventStream.Instance.npcs[index].getForceClaim().ToString();
        transform.Find("force/value").GetComponent<Text>().text = force.text;

        //���¾���
        experience.text = EventStream.Instance.npcs[index].getExperienceClaim().ToString();
        transform.Find("experience").GetComponent<Text>().text = experience.text;
    }
}
