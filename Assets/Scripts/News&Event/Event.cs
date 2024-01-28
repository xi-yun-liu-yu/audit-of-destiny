using System;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
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

        /// <summary>
        /// 执行函数
        /// </summary>
        /// <param name="funName">方法名</param>
        /// <param name="parameters">参数列表</param>
        /// <exception cref="NullReferenceException">方法名不存在</exception>

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
        
        /// <summary>
        /// 执行函数
        /// </summary>
        /// <param name="funName">方法名</param>
        /// <param name="parameters">参数列表</param>
        /// <exception cref="NullReferenceException">方法名不存在</exception>
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
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // 自定义函数区域
        
        // 周期性、固定性函数区域
        ///////////////////////////////////////////////////////////////////////////////////////////////////
        // 周期性、固定性函数区域
        
        /// <summary>
        /// 周期性保存数据到player中
        /// </summary>
        public void Save()
        {
            Player.Player.Instance.RenewB_FloutDate(BalanceOfPower.Instance.GetFloutDate());
            Player.Player.Instance.RenewR_FloutDate(Relationship.Instance.GetFloutDate());
            Player.Player.Instance.RenewBoolDate(BalanceOfPower.Instance.GetBoolDate());
            Player.Player.Instance.money = Money.Instance.saving;
            Player.Player.Instance.factionTag = Relationship.Instance.factionTag;
        }
        
        /// <summary>
        /// 周期性保存从player中读取
        /// </summary>
        public void Load()
        {
            BalanceOfPower.Instance.RenewFloutDate(Player.Player.Instance.GetB_FloutDate());
            Relationship.Instance.RenewFloutDate(Player.Player.Instance.GetR_FloutDate());
            BalanceOfPower.Instance.RenewFloutDate(Player.Player.Instance.GetBoolDate());
            Relationship.Instance.RenewFloutDate(Player.Player.Instance.GetBoolDate());
            Money.Instance.saving = Player.Player.Instance.money;
            Relationship.Instance.factionTag = Player.Player.Instance.factionTag;
        }
        /// <summary>
        /// 结局 事件
        /// 每个周期结束之后均应判定一次结局事件
        /// </summary>
        public void Event_End()
        {
            switch (Relationship.Instance.factionTag)
            {
                case "R":
                    if (BalanceOfPower.Instance.R_Value>=0.9)
                    {
                        Event_End_R();
                    }
                    break;
                case "C":
                    if (BalanceOfPower.Instance.C_Value>=0.9)
                    {
                        Event_End_C();
                    }
                    break;
                case "D":
                    if (BalanceOfPower.Instance.C_Value>=0.9)
                    {
                        Event_End_D();
                    }
                    break;
            }
        }
        
        // 激进派结局事件
        public void Event_End_R()
        {
            NewsListConroller.Instance.AddNews("邪神之祭","经过残酷的政治斗争后获得了绝对的权力，他兴致勃勃的带领着自己最狂热的支持者进入祭坛，获得了令人恐惧的力量。随着时间的推移，祭坛中蕴含的邪恶力量开始波及整个帝国。这些力量逐渐失控，带来了一系列灾难性的后果。魔法森林变得异常不稳定，导致了大规模的自然灾害和生态破坏。许多城镇和村庄受到了毁灭性的打击，数以万计的人们丧生。帝国的经济也受到了严重的影响。饥荒与叛乱接踵而至，整个帝国陷入了混乱和动荡之中。");

        }
        
        //保守派结结局事件
        private void Event_End_C()
        {
            NewsListConroller.Instance.AddNews("至高教权","保守派的元老们依靠老练的政治手腕成功将会长逼出了权力中心，会长在意识到自己失败后便黯然离去，投靠了另一个与哈苏特公会敌对的公会。很快，那个公会就派人占领了祭坛获得了其中的邪恶力量。在会长的胁迫下，作为其在哈苏特公会失败的主要推手的你被元老们抛弃，交给了会长。会长将你关在地窖里终日折磨，而你的妻女被卖到了奴隶市场，下落不明。最终你在痛苦中死亡。");
        }
        
        // 毁灭派结局事件
        private void Event_End_D()
        {
            NewsListConroller.Instance.AddNews("分崩离析", "在毁灭派的挑拨离间下，激进派与保守派的矛盾终于无法隐藏，全公会上下都被派系斗争所割裂。毁灭派利用未暴露的人员不断的出卖公会利益去打击反对派。在一次元老会议上，会长与大祭司当场决裂，双方大打出手。公会高层伤亡惨重，会长被毒杀，双方控制的探险队也在火并中遭受重创。随后大祭司带着所有的神职人员和支持他们的探险队出逃，而群龙无首的激进派则一哄而散，各奔前程。作为内奸的你和毁灭派诸人前往敌对公会希望得到庇护。结果在被细节完财物后，你们被关进了敌对公会的矿井中当苦工。曾许诺你们荣华富贵的敌对公会联络人表示，没有人喜欢叛徒，哪怕是背叛敌人的人。你在矿井中得知妻子为了活命，带着女儿改嫁给了隔壁老王，而你也在不久之后的一次塌方中被活埋。");
        }
        
        // 平庸结局
        private void Event_End_N()
        {
            NewsListConroller.Instance.AddNews("平平淡淡打工人","会在长久的政治斗争之后，各派直接达成了微妙的平衡，使得哈苏特公会得以平稳的运行下去。由于在这场斗争中你并未发挥什么作用，你很快就被边缘化，重新回到档案室管理文件，最后在一次裁员中被开除。身无所长的你找不到工作，一家人流落街头冻饿而死。");
        }

        /// <summary>
        /// 入会成员证件作假
        /// </summary>
        public void Event_1()
        {
            foreach (var npc in EventStream.Instance.ErrorNpcs)
            {
                
            }
        }

        /// <summary>
        /// 每周工作报告
        /// </summary>
        public void Event_2()
        {
            int Errors = 0;//本周存在的有风险npc暴雷的数量
            int Rights = 0;//本周期拒绝的证件正确的人的数量
            foreach (var variabErrorNpc in EventStream.Instance.ErrorNpcs)
            {
                // 未写完，等待NPC
                Errors += 1;
            }
            foreach (var variabRightNpc in EventStream.Instance.RightNpcs)
            {
                // 未写完，等待NPC
                Rights += 1;
            }

            string str ="";
            if (Errors>0)
            {
                str += "本周发生了" + Errors + "起事故，经组织查明是由不称职者混入了组织，有人会为此付出代价的。";
                str += "/n";
                Money.Instance.saving -= (Errors * 200);
            }

            if (Rights>0)
            {
                str += "经小道消息，有" + Rights + "个人跑到了敌对公会，审计人员要对人才流失负责！";
                Money.Instance.saving -= (Errors * 100);
            }
            
            NewsListConroller.Instance.AddNews("工作报告",str);

        }
        
        /// <summary>
        /// 大清洗事件
        /// </summary>
        public void Event_3()
        {
            BalanceOfPower.Instance.SetDifference("C",-(BalanceOfPower.Instance.C_Value/3));
            BalanceOfPower.Instance.SetDflag1(true);
            BalanceOfPower.Instance.SetValue(BalanceOfPower.Instance.R_Value*0.75f,BalanceOfPower.Instance.C_Value,BalanceOfPower.Instance.R_Value*0.25f);
            NewsListConroller.Instance.AddNews("大清洗","我去，是大清洗，太哈人了");
        }

        /// <summary>
        /// 阴谋分裂公会的内奸？（毁灭派显身事件）
        /// </summary>
        public void Event_4()
        {
            if (BalanceOfPower.Instance.D_Value>=50)
            {
                BalanceOfPower.Instance.SetDflag2(true);
                NewsListConroller.Instance.AddNews("阴谋分裂公会的内奸？","啊，有内鬼？！");
            }
        }
        
    }
}