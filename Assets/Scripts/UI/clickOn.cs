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

    public static clickOn Instance { get; private set; }

    private void Awake()
    {
        Instance = this;

        
    }

    private void Start()
    {
        //刷新立绘
        refreshImage();
    }

    public void ClickButton1()
    {
        Debug.Log("点击了！");

        //载入事件
        //EventStream.Instance.events.Add(new Event("Event_NPC_1", new[] { eventStream.npcs[index] }));

        //刷新npc数据


        dialogue.Instance.button1.SetActive(false);
        dialogue.Instance.button2.SetActive(false);
        dialogue.Instance.button3.SetActive(false);
    }

    public void ClickButton2()
    {
        Debug.Log("点击了！");


        dialogue.Instance.button1.SetActive(false);
        dialogue.Instance.button2.SetActive(false);
        dialogue.Instance.button3.SetActive(false);

        //载入事件
        //EventStream.Instance.events.Add(new Event("Event_NPC_2", new[] { eventStream.npcs[index] }));
    }

    public void ClickButton3()
    {
        Debug.Log("点击了！");


        dialogue.Instance.button1.SetActive(false);
        dialogue.Instance.button2.SetActive(false);
        dialogue.Instance.button3.SetActive(false);

        //载入事件
        //EventStream.Instance.events.Add(new Event("Event_NPC_3", new[] { eventStream.npcs[index] }));
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
