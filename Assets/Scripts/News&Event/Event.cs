using System;
using UnityEngine;

namespace News_Event
{
    // 自定义事件，通过载入EventStream来执行
    public class Event
    {
        private String funName{ get;  set; }
        
        // 初始执行事件
        public Event(string funName)
        {
            this.funName = funName;
        }

        // 执行函数
        // funName 方法名
        // parameters 参数
        public void Run(String funName,object[] parameters=null)
        {
            var type = typeof(Event);
            var method = type.GetMethod(funName);
            if (method == null)
                throw new NullReferenceException("方法" + funName + "不存在");
            Event obj = new Event(funName);
            //执行方法
            method.Invoke(obj, parameters);
        }
        
        public void Run(object[] parameters = null)
        {
            var type = typeof(Event);
            var method = type.GetMethod(funName);
            Debug.Log(method == null);
            if (method == null)
                throw new NullReferenceException("方法" + funName + "不存在");
            Event obj = new Event(funName);
            //执行方法
            method.Invoke(obj, parameters);
        }
        
        // 自定义函数区域
        
        // 大清洗 事件
        public void Event_1()
        {
            BalanceOfPower.Instance.SetDifference("C",-(BalanceOfPower.Instance.C_Value/3));
            BalanceOfPower.Instance.SetDflag(true);
        }
        
        // 测试事件
        public void Event_2()
        {
            BalanceOfPower.Instance.SetDifference("R",0.05f);
        }
        
        // 测试事件
        public void Event_3(String s,float f)
        {
            BalanceOfPower.Instance.SetDifference(s,f);
        }
    }
}