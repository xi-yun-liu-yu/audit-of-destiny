using News_Event;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class dialogue : MonoBehaviour
{
    //"UI组件"将会显示在unity中
    [Header("UI组件")]

    //对话中显示的文本
    public Text dialog;

    [Header("文本信息")]
    //文本信息索引
    int index;

    //定义列表存储每一句文本
    List<string> textList = new List<string>();

    [Header("字显示速度")]

    //每个字显示之间的时间间隔
    public float speed = 0.1f;

    //是否正在输出文字（前一句输出是否结束）
    bool isFinish = true;

    //是否直接输出（是否取消一字一字输出）
    bool cancelType = false;

    [Header("三个回复选项的按钮")]
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
        //点击鼠标左键切换下一条语句
        if (Input.GetMouseButtonUp(0))
        {
            if (index == textList.Count)//检测语句结束
            {
                index = 0;

                //激活三个按钮
                button1.SetActive(true);
                button2.SetActive(true);
                button3.SetActive(true);

                gameObject.SetActive(false);
                return;
            }
            

            if (isFinish && !cancelType)
            {
                //用协程输出一句（一字一字输出）
                StartCoroutine(SetText());
                
            }
            else if (!isFinish && !cancelType){
                cancelType = true;
            }
        }
    }

    //将文本按句子切割开分别存入list
    void GetTextToList()
    {
        //初始化列表及索引
        textList.Clear();
        index = 0;
        int i = clickOn.Instance.index;
        List<NPC.NPC> npcs = EventStream.Instance.npcs;

        //添加角色文本到字符串数组中
        string[] strings = new string[2];
        strings[0] = npcs[i].getFirstTalk();
        strings[1] = npcs[i].getSecondTalk();

        //读入列表
        foreach (var text in strings)
        {
            textList.Add(text);
        }
    }

    //一字一字输出一句文字
    IEnumerator SetText()
    {
        isFinish = false;
        dialog.text = "";//初始化文本

        int i = 0;
        while (!cancelType && i < textList[index].Length)
        {
            dialog.text += textList[index][i];//每次循环加一个字
            i++;
            yield return new WaitForSeconds(speed);//延时
        }

        //cancelType为true时，直接输出整句话
        dialog.text = textList[index];
        cancelType = false;

        isFinish = true;
        index++;
    }
}
