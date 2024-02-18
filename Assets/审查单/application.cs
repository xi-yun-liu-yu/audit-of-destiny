using News_Event;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ϫ��;

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
        //��ȡ��ǰnpc����
        int index = clickOn.Instance.index;

        //��������
        transform.Find("intelligence/value").GetComponent<Text>().text =�ܿ�����.Instance.getNpc().getIntelligenceClaim().ToString();

        //��������
        transform.Find("physical/value").GetComponent<Text>().text = �ܿ�����.Instance.getNpc().getPhysicalClaim().ToString();

        //����ħ��
        transform.Find("mana/value").GetComponent<Text>().text = �ܿ�����.Instance.getNpc().getManaClaim().ToString();

        //��������
        transform.Find("force/value").GetComponent<Text>().text = �ܿ�����.Instance.getNpc().getForceClaim().ToString();

        //���¾���
        transform.Find("experience").GetComponent<Text>().text = �ܿ�����.Instance.getNpc().getExperienceClaim().ToString();
    }
}
