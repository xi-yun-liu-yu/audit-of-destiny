using News_Event;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class clickOn : MonoBehaviour
{
    [Header("����")]
    public Image image;

    [Header("npc����")]
    public int index = 0;

    [Header("�Ի���")]
    public GameObject dialogBox;

    [Header("�����ظ�ѡ��İ�ť")]
    public GameObject button1, button2, button3;

    public static clickOn Instance { get; private set; }

    private void Awake()
    {
        Instance = this;

        
    }

    private void Start()
    {
        //ˢ������
        //refreshImage();
    }

    //����
    public void ClickButton1()
    {
        //ˢ��npc����

        //���Ի����ݴ���
        int i = clickOn.Instance.index;
        NPC.NPC npc = EventStream.Instance.npcs[i];
        dialogue.Instance.talk = npc.getFirstTalk();

        //�رհ�ť
        button1.SetActive(false);
        button2.SetActive(false);
        button3.SetActive(false);

        //����Ի���
        dialogBox.SetActive(true);
    }

    //����
    public void ClickButton2()
    {
        //ˢ��npc����

        
        //���Ի����ݴ���
        int i = clickOn.Instance.index;
        NPC.NPC npc = EventStream.Instance.npcs[i];
        dialogue.Instance.talk = npc.getFirstTalk();

        //�رհ�ť
        button1.SetActive(false);
        button2.SetActive(false);
        button3.SetActive(false);


        //����Ի���
        dialogBox.SetActive(true);
    }

    //�ж�
    public void ClickButton3()
    {
        //ˢ��npc����

        //���Ի����ݴ���
        int i = clickOn.Instance.index;
        NPC.NPC npc = EventStream.Instance.npcs[i];
        dialogue.Instance.talk = npc.getFirstTalk();

        //�رհ�ť
        button1.SetActive(false);
        button2.SetActive(false);
        button3.SetActive(false);

        //����Ի���
        dialogBox.SetActive(true);
    }

    public void ClickAccept()
    {
        //�����¼�
        //EventStream.Instance.events.Add(new Event("Event_NPC_1", new[] { eventStream.npcs[index] }));

        //���Ի����ݴ���
        int i = clickOn.Instance.index;
        NPC.NPC npc = EventStream.Instance.npcs[i];
        dialogue.Instance.talk = npc.getSecondTalk();

        //�رհ�ť
        button1.SetActive(false);
        button2.SetActive(false);
        button3.SetActive(false);

        //����Ի���
        dialogBox.SetActive(true);
    }

    public void ClickRefuse()
    {
        //�����¼�
        //EventStream.Instance.events.Add(new Event("Event_NPC_2", new[] { eventStream.npcs[index] }));

       

        //���Ի����ݴ���
        int i = clickOn.Instance.index;
        NPC.NPC npc = EventStream.Instance.npcs[i];
        dialogue.Instance.talk = npc.getSecondTalk();

        //�رհ�ť
        button1.SetActive(false);
        button2.SetActive(false);
        button3.SetActive(false);

        //����Ի���
        dialogBox.SetActive(true);
    }

    public void ClickBlackmail()
    {
        //�����¼�
        //EventStream.Instance.events.Add(new Event("Event_NPC_3", new[] { eventStream.npcs[index] }));

        //���Ի����ݴ���
        int i = clickOn.Instance.index;
        NPC.NPC npc = EventStream.Instance.npcs[i];
        dialogue.Instance.talk = npc.getSecondTalk();

        //�رհ�ť
        button1.SetActive(false);
        button2.SetActive(false);
        button3.SetActive(false);

        //����Ի���
        dialogBox.SetActive(true);
    }

    public void changeNpc()
    {
        if (true)//�жϵ�ǰnpc�Ƿ����
        {
            //�л���һ��npc
            index++;

            //ˢ������
            refreshImage();
        }
    }

    public void refreshImage()
    {
        //�ı�����
        string path = EventStream.Instance.npcs[index].getPicture();
        image.sprite = Resources.Load(path, typeof(Sprite)) as Sprite;
    }


    public void Exit()
    {
        Application.Quit();//�˳���Ϸ
    }
}
