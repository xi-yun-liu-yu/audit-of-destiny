using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;
using atp;
using News_Event;
using Random = UnityEngine.Random;

namespace 溪云
{
    public class 总控制器 : MonoBehaviour
    {
        public static 总控制器 Instance{ get; private set; }
        public GameObject npcAction;

        private Animator npcAnimator;
        
        public GameObject  image;

        public GameObject 空背景;

        public Sprite[] imageOptions;
        private bool isRExist = true;//激进派
        private bool isCExist = true;//保守派
        private bool isDExist = false;//毁灭派
        private bool 当前审核完成 = true;
        private bool 已展示npc图片 = false;
        private int[] npcNumber = new int[10];
        private int 当前npc下标 = 0;
        private NpcTemplate temp;
        public List<NpcTemplate> npcs;

        public Button 新游戏;
        public Button 新闻;
        public int 计数器 = 0;
        public void 计数器自增()
        {
            计数器++;
        }
        void 第一回合初始化()
        {
            EventStream.Instance.TrunStart();
        }
        
        public void SetImage(Sprite sprite)
        {
            image.GetComponent<SpriteRenderer>().sprite = sprite;
        }

        private void Awake()
        {
            Instance = this;
        }
        void Start()
        {
            for (int i = 0; i < 10; i++)
            {
                npcNumber[i] =Random.Range(3, 3);
            }
            npcAnimator = npcAction.GetComponent<Animator>();
            
            npc生成(npcs);
            开始游戏();
        }

        List<NpcTemplate> npc生成(List<NpcTemplate> npcs)
        {
            for (int j = 0; j < npcNumber[EventStream.Instance.Turn]; j++)
            {
                temp = new atp.RandomNpcGenerate().Generate(isRExist, isCExist, isDExist);
                
                switch (temp.getCareer())
                {
                    case "战士":
                        temp.setPicture(imageOptions[Random.Range(0, 3)]);
                        break;
                    case "术师":
                        temp.setPicture(imageOptions[Random.Range(3, 6)]);
                        break;
                    case "重装":
                        temp.setPicture(imageOptions[Random.Range(6, 9)]);
                        break;
                    case "游侠":
                        temp.setPicture(imageOptions[Random.Range(9, 12)]);
                        break;
                }
                npcs.Add(temp); 
                Debug.Log(temp.getCareer());
            }
            return npcs;
        }
        

        void 开门动画开启()
        {
            SetImage(null);
            空背景.gameObject.SetActive(false);
            npcAction.gameObject.SetActive(true);
        }
        void 开门动画关闭()
        {
            AnimatorStateInfo stateInfo = npcAnimator.GetCurrentAnimatorStateInfo(0);
            if (stateInfo.normalizedTime >= 1f)
            {
                if (当前npc下标 < npcNumber[EventStream.Instance.Turn])
                {
                    Debug.LogWarning("EventStream.Instance.Turn"+EventStream.Instance.Turn+"\n"+"npcNumber："+npcNumber[EventStream.Instance.Turn]+"\n"+"当前npc下标记"+当前npc下标+"\n"+"npc总数为："+npcs.Count);
                    temp=npcs[当前npc下标];
                    
                    SetImage(temp.getPicture());
                    npcAction.gameObject.SetActive(false);
                    image.gameObject.SetActive(true);
                }
            }
        }

        public NpcTemplate getNpc()
        {
            return temp;
        }

        void 开始游戏()
        {
            新游戏.onClick.Invoke();
        }

        public void 下一个npc()
        {
            当前审核完成 = true;
            当前npc下标++;
        }

        void 新npc上场()
        {
            if (!NewspaperController.isShow)
            {
                if (当前审核完成)
                {
                    开门动画开启();
                    当前审核完成 = false;
                }

                开门动画关闭();
            }
        }

        public void 下一回合()
        {
            当前npc下标 = -1;
            Debug.Log("npc下标 = 0");
            EventStream.Instance.TrunEnd();
            EventStream.Instance.Run();
            EventStream.Instance.TrunStart();
        }
        
        // Update is called once per frame
        void Update()
        {
            新npc上场();
            
            if ((EventStream.Instance.events.Count - 1 == npcNumber[EventStream.Instance.Turn])&&
                (当前npc下标 == npcNumber[EventStream.Instance.Turn] - 1))
            {
                下一回合();
            }
            
            if (计数器 == 2)
            {
                第一回合初始化();
                计数器++;
            }

        }

    }
}