using System;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using Random = UnityEngine.Random;

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
        
        
        // 随机事件区
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////
        // 随机事件区
        
        // 激进派事件区域
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////
        // 激进派事件区域

        /// <summary>
        /// 探险队侵吞公会战果
        /// </summary>
        public void Event_R_1()
        {
            int r = Random.Range(0, 9);
            string content = " 最近有个探险队的队员突然变得出手阔绰。这与他的收入情况严重不符。经过核查，其所在的探险队最近上交的战利品数额出现了";
            if (r <= 4)
            {
                content += "小幅";
                BalanceOfPower.Instance.SetDifference("R",-0.05f);
            }
            else if (r <= 7 )
            {
                content += "一定程度的";
                BalanceOfPower.Instance.SetDifference("R",-0.1f);
            }
            else if (r <= 9)
            {
                content += "严重的";
                BalanceOfPower.Instance.SetDifference("R",-0.15f);
            }
            content += "下滑，公会对此事进行了严肃处理，最终使得该探险队集体侵吞战利品的行为得以曝光。据悉，激进派有人为此负责";
            NewsListConroller.Instance.AddNews("探险队侵吞公会战果",content);
        }

        /// <summary>
        /// 在邪神祭坛附件发现有其他探险队的踪迹
        /// </summary>
        public void Event_R_2()
        {
            BalanceOfPower.Instance.SetDifference("R",0.05f);
            NewsListConroller.Instance.AddNews("在邪神祭坛附件发现有其他探险队的踪迹","据在邪神祭坛附件驻守的人员报告称，他们在巡逻时发现了一支陌生队伍经过的痕迹。目前还不知道是否有其他人已经发现了祭坛，但公会应当做好最坏的准备。");
        }

        /// <summary>
        /// 与敌对公会的冲突
        /// </summary>
        public void Event_R_3()
        {
            int r = Random.Range(0, 1);
            if (r==0)
            {
                BalanceOfPower.Instance.SetDifference("R",0.1f);
                NewsListConroller.Instance.AddNews("与敌对公会的冲突","最近的一次探险行动中，我们的探险队碰上了另一只隶属敌对公会的探险队。双方为了一处营地的使用权大打出手。我方人员在冲突中展现了极高的作战素养，最终在给予敌方重大杀伤后胜利转进");
            }
            else
            {
                BalanceOfPower.Instance.SetDifference("R",0.15f);
                NewsListConroller.Instance.AddNews("与敌对公会的冲突",
                    "最近的一次探险行动中，我们的探险队碰上了另一只隶属敌对公会的探险队。双方为了一处营地的使用权大打出手。我方人员在冲突中展现了极高的作战素养，最终敌方人员仓皇逃离");
            }
        }

        /// <summary>
        /// 公会受到挑衅
        /// </summary>
        public void Event_R_4()
        {
            BalanceOfPower.Instance.SetDifference("R",0.05f);
            NewsListConroller.Instance.AddNews("公会受到挑衅","由于公会的实力下降，近期不断有敌对公会的人在各种场合挑衅我们的人员，大家都对此感到气愤。");
        }
        
        // 保守派事件
        ////////////////////////////////////////////////////////////////////////////////////////////////
        // 保守派事件

        /// <summary>
        /// 帝国宗教裁判所处死邪神信徒
        /// </summary>
        public void Event_C_1()
        {
            BalanceOfPower.Instance.SetDifference("C",0.15f);
            NewsListConroller.Instance.AddNews("帝国宗教裁判所处死邪神信徒","帝国宗教裁判所最近判决了一起利用邪神力量对抗教廷的案件。那些邪神信徒纠集了几千暴徒，试图摧毁当地的教堂，最终被赶来的帝国军队镇压。为首的那些狂热邪神信徒在判决后被当众处以火刑。");
        }

        /// <summary>
        /// 祭祀典礼上的错误
        /// </summary>
        public void Event_C_2()
        {
            int r = Random.Range(0, 9);
            string content = "在一次探险归来后，安葬与纪念牺牲的探险队员的祭祀仪式上，负责主持的大祭司将一名牺牲的探险队员的名字";
            if (r <= 4)
            {
                content += "念错了。";
                BalanceOfPower.Instance.SetDifference("C",-0.05f);
            }
            else if (r <= 7 )
            {
                content += "念成了另一位活着的队员的名字。";
                BalanceOfPower.Instance.SetDifference("C",-0.1f);
            }
            else if (r <= 9)
            {
                content += "念成了一个侮辱性词汇";
                BalanceOfPower.Instance.SetDifference("C",-0.15f);
            }
            content += "听闻此事的探险队员们大怒，对这名祭司展开了声势浩大的谴责。";
            NewsListConroller.Instance.AddNews("祭祀典礼上的错误",content);
        }

        /// <summary>
        /// 公会收到贵族资助
        /// </summary>
        public void Event_C_3()
        {
            BalanceOfPower.Instance.SetDifference("C",0.1f);
            NewsListConroller.Instance.AddNews("公会收到贵族资助","公会近期的行动让一名贵族十分欣赏我们，他给我们送来了一批财宝，希望我们能够做大做强，成为他手中的一柄利剑。这笔雪中送炭的礼物大大缓解了公会的财政危机，对于祭坛的探索也显得不是那么紧迫了。");
        }
                
        // 毁灭派事件
        ////////////////////////////////////////////////////////////////////////////////////////////////
        // 毁灭派事件
        
        /// <summary>
        /// 探险队成员与牧师发生暴力冲突
        /// </summary>
        public void Event_D_1()
        {
            int r = Random.Range(0, 9);
            if (r<=7)
            {
                BalanceOfPower.Instance.SetDifference("D",0.1f);
            }else
            {
                BalanceOfPower.Instance.SetDifference("D",0.2f);
            }
            
        }
        
    }
}