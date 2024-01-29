using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace News_Event
{
    public class EventStream:MonoBehaviour
    {
        List<NPC.NPC> npcs= new List<NPC.NPC>();//NPC列表
        List<Event> events=new List<Event>();
        public List<NPC.NPC> ErrorNpcs = new List<NPC.NPC>();//存在的有风险npc暴雷的数量
        public List<NPC.NPC> RightNpcs = new List<NPC.NPC>();//本周期拒绝的证件正确的人的数量
        
        public static EventStream Instance{ get; private set; }

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
            events.Add(new Event("Event_R_1"));
            events[0].Run();
        }
    }
}
