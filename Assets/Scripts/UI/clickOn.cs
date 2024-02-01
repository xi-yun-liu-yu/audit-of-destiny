using News_Event;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class clickOn : MonoBehaviour
{
    [Header("立绘")]
    public Image image;

    [Header("npc索引")]
    public int index = 0;

    [Header("对话框")]
    public GameObject dialogBox;

    [Header("三个回复选项的按钮")]
    public GameObject button1, button2, button3;

    public static clickOn Instance { get; private set; }

    private void Awake()
    {
        Instance = this;

        
    }

    private void Start()
    {
        //刷新立绘
        //refreshImage();
    }

    //友善
    public void ClickButton1()
    {
        //刷新npc数据

        //将对话数据传入
        int i = clickOn.Instance.index;
        NPC.NPC npc = EventStream.Instance.npcs[i];
        dialogue.Instance.talk = npc.getFirstTalk();

        //关闭按钮
        button1.SetActive(false);
        button2.SetActive(false);
        button3.SetActive(false);

        //激活对话框
        dialogBox.SetActive(true);
    }

    //中立
    public void ClickButton2()
    {
        //刷新npc数据

        
        //将对话数据传入
        int i = clickOn.Instance.index;
        NPC.NPC npc = EventStream.Instance.npcs[i];
        dialogue.Instance.talk = npc.getFirstTalk();

        //关闭按钮
        button1.SetActive(false);
        button2.SetActive(false);
        button3.SetActive(false);


        //激活对话框
        dialogBox.SetActive(true);
    }

    //敌对
    public void ClickButton3()
    {
        //刷新npc数据

        //将对话数据传入
        int i = clickOn.Instance.index;
        NPC.NPC npc = EventStream.Instance.npcs[i];
        dialogue.Instance.talk = npc.getFirstTalk();

        //关闭按钮
        button1.SetActive(false);
        button2.SetActive(false);
        button3.SetActive(false);

        //激活对话框
        dialogBox.SetActive(true);
    }

    public void ClickAccept()
    {
        //载入事件
        //EventStream.Instance.events.Add(new Event("Event_NPC_1", new[] { eventStream.npcs[index] }));

        //将对话数据传入
        int i = clickOn.Instance.index;
        NPC.NPC npc = EventStream.Instance.npcs[i];
        dialogue.Instance.talk = npc.getSecondTalk();

        //关闭按钮
        button1.SetActive(false);
        button2.SetActive(false);
        button3.SetActive(false);

        //激活对话框
        dialogBox.SetActive(true);
    }

    public void ClickRefuse()
    {
        //载入事件
        //EventStream.Instance.events.Add(new Event("Event_NPC_2", new[] { eventStream.npcs[index] }));

       

        //将对话数据传入
        int i = clickOn.Instance.index;
        NPC.NPC npc = EventStream.Instance.npcs[i];
        dialogue.Instance.talk = npc.getSecondTalk();

        //关闭按钮
        button1.SetActive(false);
        button2.SetActive(false);
        button3.SetActive(false);

        //激活对话框
        dialogBox.SetActive(true);
    }

    public void ClickBlackmail()
    {
        //载入事件
        //EventStream.Instance.events.Add(new Event("Event_NPC_3", new[] { eventStream.npcs[index] }));

        //将对话数据传入
        int i = clickOn.Instance.index;
        NPC.NPC npc = EventStream.Instance.npcs[i];
        dialogue.Instance.talk = npc.getSecondTalk();

        //关闭按钮
        button1.SetActive(false);
        button2.SetActive(false);
        button3.SetActive(false);

        //激活对话框
        dialogBox.SetActive(true);
    }

    public void changeNpc()
    {
        if (true)//判断当前npc是否结束
        {
            //切换下一个npc
            index++;

            //刷新立绘
            refreshImage();
        }
    }

    public void refreshImage()
    {
        //改变立绘
        string path = EventStream.Instance.npcs[index].getPicture();
        image.sprite = Resources.Load(path, typeof(Sprite)) as Sprite;
    }


    public void Exit()
    {
        Application.Quit();//退出游戏
    }
}
