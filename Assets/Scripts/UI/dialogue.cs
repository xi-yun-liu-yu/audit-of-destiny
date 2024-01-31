using News_Event;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class dialogue : MonoBehaviour
{
    //"UI���"������ʾ��unity��
    [Header("UI���")]

    //�Ի�����ʾ���ı�
    public Text dialog;

    [Header("�ı���Ϣ")]
    //�ı���Ϣ����
    int index;

    //�����б�洢ÿһ���ı�
    List<string> textList = new List<string>();

    [Header("����ʾ�ٶ�")]

    //ÿ������ʾ֮���ʱ����
    public float speed = 0.1f;

    //�Ƿ�����������֣�ǰһ������Ƿ������
    bool isFinish = true;

    //�Ƿ�ֱ��������Ƿ�ȡ��һ��һ�������
    bool cancelType = false;

    [Header("�����ظ�ѡ��İ�ť")]
    public GameObject button1, button2, button3;

    public static dialogue Instance { get; private set; }

    
    void Awake()
    {
        Instance = this;

        button1.SetActive(false);
        button2.SetActive(false);
        button3.SetActive(false);

        
    }

    private void Start()
    {
        GetTextToList();
    }



    void Update()
    {
        //����������л���һ�����
        if (Input.GetMouseButtonUp(0))
        {
            if (index == textList.Count)//���������
            {
                index = 0;

                //����������ť
                button1.SetActive(true);
                button2.SetActive(true);
                button3.SetActive(true);

                gameObject.SetActive(false);
                return;
            }
            

            if (isFinish && !cancelType)
            {
                //��Э�����һ�䣨һ��һ�������
                StartCoroutine(SetText());
                
            }
            else if (!isFinish && !cancelType){
                cancelType = true;
            }
        }
    }

    //���ı��������и�ֱ����list
    void GetTextToList()
    {
        //��ʼ���б�����
        textList.Clear();
        index = 0;
        int i = clickOn.Instance.index;
        List<NPC.NPC> npcs = EventStream.Instance.npcs;

        //��ӽ�ɫ�ı����ַ���������
        string[] strings = new string[2];
        strings[0] = npcs[i].getFirstTalk();
        strings[1] = npcs[i].getSecondTalk();

        //�����б�
        foreach (var text in strings)
        {
            textList.Add(text);
        }
    }

    //һ��һ�����һ������
    IEnumerator SetText()
    {
        isFinish = false;
        dialog.text = "";//��ʼ���ı�

        int i = 0;
        while (!cancelType && i < textList[index].Length)
        {
            dialog.text += textList[index][i];//ÿ��ѭ����һ����
            i++;
            yield return new WaitForSeconds(speed);//��ʱ
        }

        //cancelTypeΪtrueʱ��ֱ��������仰
        dialog.text = textList[index];
        cancelType = false;

        isFinish = true;
        index++;
    }
}
