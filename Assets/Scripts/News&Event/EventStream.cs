using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace News_Event
{
    public class EventStream:MonoBehaviour
    {
        List<NPC.NPC> npcs= new List<NPC.NPC>();
        List<Event> events=new List<Event>();
        
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
            if (events.Count>0)
            {
                events[0].Run("Event_3",new object[]{"R",0.05f});
                events.RemoveAt(0);
            }
        }
    }
}
