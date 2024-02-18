using System;
using News_Event;
using System.Collections;
using System.Collections.Generic;
using atp;
using UnityEngine;
using UnityEngine.UI;
using 溪云;

public class clickOn : MonoBehaviour
{
    [Header("立绘")]
    public Image image;

    [Header("npc索引")]
    public int index = 0;

    [Header("对话框")]
    public GameObject dialogBox;

    [Header("三个回复选项的按钮")]
    public GameObject button1, button2, button3,button4;

    public GameObject GameObject;

    public static clickOn Instance { get; private set; }
    
    
    public GameObject Dialogue;
    public GameObject application;
    public GameObject result;
    public Button NextNPC;


    /// <summary>
    /// 跳转标记
    /// </summary>
    private bool toNextNpc;
    private bool toApplication;
    
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        //刷新立绘
        refreshImage();
    }

    private void Update()
    {
        AutoSkip();
    }

    //友善
    public void ClickButton1()
    {
        //激活对话框
        dialogBox.SetActive(true);
        //获取npc
        int i = clickOn.Instance.index;
        NpcTemplate npc = 总控制器.Instance.getNpc();

        //刷新npc数据
        atp.experienceAudit.audit(npc, "friendly");

        //将对话数据传入
        dialogue.Instance.talk = npc.getFirstTalk();

        //关闭按钮
        button1.SetActive(false);
        button2.SetActive(false);
        button3.SetActive(false);
        button4.SetActive(!button4.activeSelf);
        
    }

    //中立
    public void ClickButton2()
    {
        //激活对话框
        dialogBox.SetActive(true);
        //获取npc
        int i = clickOn.Instance.index;
        NpcTemplate npc = 总控制器.Instance.getNpc();

        //刷新npc数据
        atp.experienceAudit.audit(npc, "neutral");

        //将对话数据传入
        dialogue.Instance.talk = npc.getFirstTalk();

        //关闭按钮
        button1.SetActive(false);
        button2.SetActive(false);
        button3.SetActive(false);
        button4.SetActive(!button4.activeSelf);
        
    }

    //敌对
    public void ClickButton3()
    {
        //激活对话框
        dialogBox.SetActive(true);
        //获取npc
        int i = clickOn.Instance.index;
        NpcTemplate npc = 总控制器.Instance.getNpc();

        //刷新npc数据
        atp.experienceAudit.audit(npc, "strong");

        //将对话数据传入
        dialogue.Instance.talk = npc.getFirstTalk();

        //关闭按钮
        button1.SetActive(false);
        button2.SetActive(false);
        button3.SetActive(false);
        button4.SetActive(!button4.activeSelf);
        
    }

    public void ClickAccept()
    {

        //激活对话框
        dialogBox.SetActive(true);
        //将对话数据传入
        int i = clickOn.Instance.index;
        NpcTemplate npc = 总控制器.Instance.getNpc();
        dialogue.Instance.talk = npc.getSecondTalk();
        dialogue.Instance.Say();

        //载入事件
        EventStream.Instance.events.Add(new News_Event.Event("Event_NPC_1", new[] { npc }));

        //关闭按钮
        button1.SetActive(false);
        button2.SetActive(false);
        button3.SetActive(false);
        
        //激活对话框
        dialogBox.SetActive(true);
        ToNextNpc();

    }

    public void ClickRefuse()
    {

        //激活对话框
        dialogBox.SetActive(true);
        //将对话数据传入
        int i = clickOn.Instance.index;
        NpcTemplate npc = 总控制器.Instance.getNpc();
        dialogue.Instance.talk = npc.getSecondTalk();
        dialogue.Instance.Say();
        
        //载入事件
        EventStream.Instance.events.Add(new News_Event.Event("Event_NPC_3", new[] { npc }));


        //关闭按钮
        button1.SetActive(false);
        button2.SetActive(false);
        button3.SetActive(false);
        
        //激活对话框
        dialogBox.SetActive(true);
        ToNextNpc();
    }

    public void ClickBlackmail()
    {
        
        //激活对话框
        dialogBox.SetActive(true);
        //将对话数据传入
        int i = clickOn.Instance.index;
        NpcTemplate npc = 总控制器.Instance.getNpc();
        dialogue.Instance.talk = npc.getSecondTalk();
        dialogue.Instance.Say();

        //载入事件
        EventStream.Instance.events.Add(new News_Event.Event("Event_NPC_2", new[] { npc }));

        //关闭按钮
        button1.SetActive(false);
        button2.SetActive(false);
        button3.SetActive(false);
        
        //激活对话框
        dialogBox.SetActive(true);
        ToNextNpc();
    }

    public void changeNpc()
    {
        if (true)//判断当前npc是否结束
        {
            //切换下一个npc
            index++;
            
            //激活按钮
            button1.SetActive(true);
            button2.SetActive(true);
            button3.SetActive(true);
        }
    }
    
    //获取npc
    public NpcTemplate getThisNPC()
    {
        NpcTemplate npc = 总控制器.Instance.getNpc();
        return npc;
    }
    
    //提问时间（申请书经历）
    public void ClickTime()
    {
        //激活对话框
        dialogBox.SetActive(true);
        //获取npc
        NpcTemplate npc = getThisNPC();

        //设置回答
        atp.experienceAudit.questionAndAnswer(npc, "time");
        dialogue.Instance.talk = npc.getAnswer();
        dialogue.Instance.Say();

        //激活对话框
        dialogBox.SetActive(true);
        GoBackAppliaction();
    }

    //提问地点（申请书经历）
    public void ClickPlace()
    {
        //激活对话框
        dialogBox.SetActive(true);
        //获取npc
        NpcTemplate npc = getThisNPC();

        //设置回答
        atp.experienceAudit.questionAndAnswer(npc, "place");
        dialogue.Instance.talk = npc.getAnswer();
        dialogue.Instance.Say();

        //激活对话框
        dialogBox.SetActive(true);
        GoBackAppliaction();
    }

    //提问事件（申请书经历）
    public void ClickExperience()
    {
        //激活对话框
        dialogBox.SetActive(true);
        //获取npc
        NpcTemplate npc = getThisNPC();

        //设置回答
        atp.experienceAudit.questionAndAnswer(npc, "experience");
        dialogue.Instance.talk = npc.getAnswer();
        dialogue.Instance.Say();

        //激活对话框
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
    ///  自动控制类函数，应保持活跃
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
        //改变立绘
        //Sprite path = EventStream.Instance.npcs[index].getPicture();
        //image.sprite = Resources.Load(path, typeof(Sprite)) as Sprite;
    }


    public void Exit()
    {
        Application.Quit();//退出游戏
    }

    public void ReFresh()
    {
        总控制器.Instance.下一个npc();
    }
}
