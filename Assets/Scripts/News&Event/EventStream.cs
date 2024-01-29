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
        public int Turn;//周期数
        public int index;
        
        public static EventStream Instance{ get; private set; }

        /// <summary>
        /// 开启新的周期
        /// </summary>
        public void NewTrun()
        {
            npcs.Clear();
            npcs.Add(new NPC.NPC());//随机添加一定数量的NPC
            events.Clear();
            RightNpcs.Clear();
            events.Add(new Event("Event_GenerateNewspaper"));
            events.Add(new Event("Load"));
        }

        private void Awake()
        {
            Instance = this;
        }

        // 测试用方法1
        public void AddEvent_2()
        {
            events.Add(new Event("Event_2"));
        }
        
        // 测试用方法2
        public void AddEvent_1()
        {
            events.Add(new Event("Event_1"));
        }
        
        // 测试用方法3
        public void Run()
        {
            events.Add(new Event("Event_FirstGame"));
            events[0].Run();
        }
    }
}
