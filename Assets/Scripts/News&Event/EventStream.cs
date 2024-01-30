using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace News_Event
{
    public class EventStream:MonoBehaviour
    {
        public List<NPC.NPC> npcs= new List<NPC.NPC>();//NPC列表
        public List<Event> events=new List<Event>();
        public List<NPC.NPC> ErrorNpcs = new List<NPC.NPC>();//存在的有风险npc暴雷的数量
        public List<NPC.NPC> RightNpcs = new List<NPC.NPC>();//本周期拒绝的证件正确的人的数量
        public int Turn=0;//周期数
        public int index;
        public int turnviolation = 0;//单周期违规次数
        
        public static EventStream Instance{ get; private set; }

        /// <summary>
        /// 开启新的周期
        /// </summary>
        public void NewTrun()
        {
            turnviolation = 0;
            npcs.Clear();
            npcs.Add(new NPC.NPC());//随机添加一定数量的NPC
            events.Clear();
            RightNpcs.Clear();
            Event e = new Event("Event_GenerateNewspaper");//创建一张空白的报纸等待数据
            e.Run();
            events.Add(new Event("Load"));
            
            EventStream.Instance.events.Add(new Event("Event_NPC_1"));// 例子： 玩家选择让npc进入
            
            events.Add(new Event("Event_2"));
            if (Turn==4|| (Player.Player.Instance.B_R_Value <= 0.3f && Turn <= 4))
            {
                Debug.Log(BalanceOfPower.Instance.R_Value);
                events.Add(new Event("Event_3"));//载入大清洗事件
            }
            events.Add(new Event("Event_4"));
            events.Add(new Event("Event_Random"));
            events.Add(new Event("Event_End"));
            events.Add(new Event("Save"));
            Turn++;

        }

        private void Awake()
        {
            Instance = this;
        }
        
        
        // 开始游戏
        public void FirstGame()
        {
            events.Add(new Event("Event_FirstGame"));
            events[0].Run();
        }
        
        // 测试用方法3
        public void Run()
        {
            foreach (var variaEvent in events)
            {
                variaEvent.Run();
            }
        }
    }
}
