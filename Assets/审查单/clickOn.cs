using System;
using News_Event;
using System.Collections;
using System.Collections.Generic;
using atp;
using UnityEngine;
using UnityEngine.UI;
using Ϫ��;

public class clickOn : MonoBehaviour
{
    [Header("����")]
    public Image image;

    [Header("npc����")]
    public int index = 0;

    [Header("�Ի���")]
    public GameObject dialogBox;

    [Header("�����ظ�ѡ��İ�ť")]
    public GameObject button1, button2, button3,button4;

    public GameObject GameObject;

    public static clickOn Instance { get; private set; }
    
    
    public GameObject Dialogue;
    public GameObject application;
    public GameObject result;
    public Button NextNPC;


    /// <summary>
    /// ��ת���
    /// </summary>
    private bool toNextNpc;
    private bool toApplication;
    
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        //ˢ������
        refreshImage();
    }

    private void Update()
    {
        AutoSkip();
    }

    //����
    public void ClickButton1()
    {
        //����Ի���
        dialogBox.SetActive(true);
        //��ȡnpc
        int i = clickOn.Instance.index;
        NpcTemplate npc = �ܿ�����.Instance.getNpc();

        //ˢ��npc����
        atp.experienceAudit.audit(npc, "friendly");

        //���Ի����ݴ���
        dialogue.Instance.talk = npc.getFirstTalk();

        //�رհ�ť
        button1.SetActive(false);
        button2.SetActive(false);
        button3.SetActive(false);
        button4.SetActive(!button4.activeSelf);
        
    }

    //����
    public void ClickButton2()
    {
        //����Ի���
        dialogBox.SetActive(true);
        //��ȡnpc
        int i = clickOn.Instance.index;
        NpcTemplate npc = �ܿ�����.Instance.getNpc();

        //ˢ��npc����
        atp.experienceAudit.audit(npc, "neutral");

        //���Ի����ݴ���
        dialogue.Instance.talk = npc.getFirstTalk();

        //�رհ�ť
        button1.SetActive(false);
        button2.SetActive(false);
        button3.SetActive(false);
        button4.SetActive(!button4.activeSelf);
        
    }

    //�ж�
    public void ClickButton3()
    {
        //����Ի���
        dialogBox.SetActive(true);
        //��ȡnpc
        int i = clickOn.Instance.index;
        NpcTemplate npc = �ܿ�����.Instance.getNpc();

        //ˢ��npc����
        atp.experienceAudit.audit(npc, "strong");

        //���Ի����ݴ���
        dialogue.Instance.talk = npc.getFirstTalk();

        //�رհ�ť
        button1.SetActive(false);
        button2.SetActive(false);
        button3.SetActive(false);
        button4.SetActive(!button4.activeSelf);
        
    }

    public void ClickAccept()
    {

        //����Ի���
        dialogBox.SetActive(true);
        //���Ի����ݴ���
        int i = clickOn.Instance.index;
        NpcTemplate npc = �ܿ�����.Instance.getNpc();
        dialogue.Instance.talk = npc.getSecondTalk();
        dialogue.Instance.Say();

        //�����¼�
        EventStream.Instance.events.Add(new News_Event.Event("Event_NPC_1", new[] { npc }));

        //�رհ�ť
        button1.SetActive(false);
        button2.SetActive(false);
        button3.SetActive(false);
        
        //����Ի���
        dialogBox.SetActive(true);
        ToNextNpc();

    }

    public void ClickRefuse()
    {

        //����Ի���
        dialogBox.SetActive(true);
        //���Ի����ݴ���
        int i = clickOn.Instance.index;
        NpcTemplate npc = �ܿ�����.Instance.getNpc();
        dialogue.Instance.talk = npc.getSecondTalk();
        dialogue.Instance.Say();
        
        //�����¼�
        EventStream.Instance.events.Add(new News_Event.Event("Event_NPC_3", new[] { npc }));


        //�رհ�ť
        button1.SetActive(false);
        button2.SetActive(false);
        button3.SetActive(false);
        
        //����Ի���
        dialogBox.SetActive(true);
        ToNextNpc();
    }

    public void ClickBlackmail()
    {
        
        //����Ի���
        dialogBox.SetActive(true);
        //���Ի����ݴ���
        int i = clickOn.Instance.index;
        NpcTemplate npc = �ܿ�����.Instance.getNpc();
        dialogue.Instance.talk = npc.getSecondTalk();
        dialogue.Instance.Say();

        //�����¼�
        EventStream.Instance.events.Add(new News_Event.Event("Event_NPC_2", new[] { npc }));

        //�رհ�ť
        button1.SetActive(false);
        button2.SetActive(false);
        button3.SetActive(false);
        
        //����Ի���
        dialogBox.SetActive(true);
        ToNextNpc();
    }

    public void changeNpc()
    {
        if (true)//�жϵ�ǰnpc�Ƿ����
        {
            //�л���һ��npc
            index++;
            
            //���ť
            button1.SetActive(true);
            button2.SetActive(true);
            button3.SetActive(true);
        }
    }
    
    //��ȡnpc
    public NpcTemplate getThisNPC()
    {
        NpcTemplate npc = �ܿ�����.Instance.getNpc();
        return npc;
    }
    
    //����ʱ�䣨�����龭����
    public void ClickTime()
    {
        //����Ի���
        dialogBox.SetActive(true);
        //��ȡnpc
        NpcTemplate npc = getThisNPC();

        //���ûش�
        atp.experienceAudit.questionAndAnswer(npc, "time");
        dialogue.Instance.talk = npc.getAnswer();
        dialogue.Instance.Say();

        //����Ի���
        dialogBox.SetActive(true);
        GoBackAppliaction();
    }

    //���ʵص㣨�����龭����
    public void ClickPlace()
    {
        //����Ի���
        dialogBox.SetActive(true);
        //��ȡnpc
        NpcTemplate npc = getThisNPC();

        //���ûش�
        atp.experienceAudit.questionAndAnswer(npc, "place");
        dialogue.Instance.talk = npc.getAnswer();
        dialogue.Instance.Say();

        //����Ի���
        dialogBox.SetActive(true);
        GoBackAppliaction();
    }

    //�����¼��������龭����
    public void ClickExperience()
    {
        //����Ի���
        dialogBox.SetActive(true);
        //��ȡnpc
        NpcTemplate npc = getThisNPC();

        //���ûش�
        atp.experienceAudit.questionAndAnswer(npc, "experience");
        dialogue.Instance.talk = npc.getAnswer();
        dialogue.Instance.Say();

        //����Ի���
        dialogBox.SetActive(true);
        GoBackAppliaction();
    }

    
    
    public void GoBackAppliaction()
    {
        toApplication = true;
    }
    public void ToNextNpc()
    {
        toNextNpc = true;
    }

    /// <summary>
    ///  �Զ������ຯ����Ӧ���ֻ�Ծ
    /// </summary>
    private void AutoSkip()
    {
        if (Dialogue.GetComponent<dialogue>().isFinish&&Dialogue.activeSelf)
        {
            if (toApplication)
            {
                application.SetActive(true);
                result.SetActive(true);
                toApplication = !toApplication;
            }

            if (toNextNpc)
            {
                NextNPC.onClick.Invoke();
                toNextNpc = !toNextNpc;
            }
        }
    }
    public void refreshImage()
    {
        //�ı�����
        //Sprite path = EventStream.Instance.npcs[index].getPicture();
        //image.sprite = Resources.Load(path, typeof(Sprite)) as Sprite;
    }


    public void Exit()
    {
        Application.Quit();//�˳���Ϸ
    }

    public void ReFresh()
    {
        �ܿ�����.Instance.��һ��npc();
    }
}
