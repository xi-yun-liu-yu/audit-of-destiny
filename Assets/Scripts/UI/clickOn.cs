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

    public static clickOn Instance { get; private set; }

    private void Awake()
    {
        Instance = this;

        
    }

    private void Start()
    {
        //ˢ������
        refreshImage();
    }

    public void ClickButton1()
    {
        Debug.Log("����ˣ�");

        //�����¼�
        //EventStream.Instance.events.Add(new Event("Event_NPC_1", new[] { eventStream.npcs[index] }));

        //ˢ��npc����


        dialogue.Instance.button1.SetActive(false);
        dialogue.Instance.button2.SetActive(false);
        dialogue.Instance.button3.SetActive(false);
    }

    public void ClickButton2()
    {
        Debug.Log("����ˣ�");


        dialogue.Instance.button1.SetActive(false);
        dialogue.Instance.button2.SetActive(false);
        dialogue.Instance.button3.SetActive(false);

        //�����¼�
        //EventStream.Instance.events.Add(new Event("Event_NPC_2", new[] { eventStream.npcs[index] }));
    }

    public void ClickButton3()
    {
        Debug.Log("����ˣ�");


        dialogue.Instance.button1.SetActive(false);
        dialogue.Instance.button2.SetActive(false);
        dialogue.Instance.button3.SetActive(false);

        //�����¼�
        //EventStream.Instance.events.Add(new Event("Event_NPC_3", new[] { eventStream.npcs[index] }));
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
