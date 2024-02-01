using System;

namespace ConsoleApplication1
{
    /**
     * 全局变量
     */
    internal class GlobalVariables
    {
        internal static string[] Characters = { "胆小", "正直", "蛮横", "欺软怕硬" }; //npc性格

        internal static string[] Experience =
            { "与黑龙面对面", "独自进行地牢探索并获得宝物", "与村落中最强者进行比试并获胜", "独自冒险并取得了丰硕的成果", "帮助当地居民解决了大麻烦" }; //经历

        internal static string[] place = { "高山", "雪原", "沙漠", "森林", "海岸" }; //地点
        internal static string[] time = { "三周前", "两个月前", "半年前", "一年前", "两年前" }; //时间
        internal static string[] career = { "战士", "术师", "重装", "游侠" }; //职业

        internal static string[] firstSpeakFriendly =
            { "你好！希望你在这美好的一天里找到许多值得微笑的瞬间。", "你好呀！愿你的笑容比昨天更灿烂。", "喂！愿你有个美好的一天。", "愿你每天都充满微笑和欢笑。" }; //初次友善

        internal static string[] firstSpeakNeutral = { "你好。", "上午好。", "你好，这是我的申请书。", "你好，请麻烦快一点。" }; //初次中立
        internal static string[] firstSpeakHostile = { "这是申请书。快点。", "看完了就赶紧给我通过。", "别磨蹭。", "别耽误我的时间。" }; //初次敌对

        internal static string[] secondSpeakFriendly =
            { "谢谢你的善意，让我感到温暖和欣慰。", "谢谢你的友善，让我的日子更加美好。", "非常感谢你的理解和包容。", "感谢你的慷慨和善良。" }; //二次友善

        internal static string[] secondSpeakNeutral = { "谢谢。", "嗯。", "好的。", "感谢。" }; //二次中立
        internal static string[] secondSpeakHostile = { "你敢威胁我？", "如果我没理解错的话，这是威胁？" }; //二次敌对
        internal static string[] secondSpeakScared = { "别急别急，有话好好说…", "您先别激动…" }; //二次害怕
        internal static string[] secondSpeakOther = { "额，今天天气不错哈", "您这身衣服不错", "你这一天能挣多少钱啊?", "啊哈哈…" }; //二次非正面回答
    }

    /**
     * npc类
     */
    public class NpcTemplate
    {
        private int intelligence; //智力
        private int physical; //体力
        private int mana; //魔力
        private int force; //武力
        private string experience; //经历
        private string place; //地点
        private string time; //时间
        //上述是npc真实的数据

        private int intelligenceClaim; //智力
        private int physicalClaim; //体力
        private int manaClaim; //魔力
        private int forceClaim; //武力
        private string experienceClaim; //经历
        private string placeClaim; //地点
        private string timeClaim; //时间
        //上述是npc申报的数据

        private string character; //性格
        private string Attitude; //对玩家的态度
        private string career; //职业
        private bool isPassed; //是否通过
        private bool isCompliant; //npc本身是否合规
        private bool willPay; //被勒索是否会付款
        private bool willReport; //被勒索是否会举报
        private char party; //npc意向派系
        private string firstTalk; //第一次谈话
        private string secondTalk; //第二次谈话
        //上述是npc关于博弈的数据

        private string question; //玩家针对经历问的问题
        private string answer; //npc的回答
        private double partyPowerWeight; //此npc影响势力权力点数的权重
        private double partyAttitudeWeight; //此npc影响势力对玩家态度点数的权重
        private string picture; //立绘存放地址


        //以下是getter和setter，是对应好的，每个属性都有
        //以下是真实数据的getter setter
        public int getIntelligence()
        {
            return intelligence;
        }

        public void setIntelligence(int intelligence)
        {
            this.intelligence = intelligence;
        }

        public int getPhysical()
        {
            return physical;
        }

        public void setPhysical(int physical)
        {
            this.physical = physical;
        }

        public int getMana()
        {
            return mana;
        }

        public void setMana(int mana)
        {
            this.mana = mana;
        }

        public int getForce()
        {
            return force;
        }

        public void setForce(int force)
        {
            this.force = force;
        }

        public string getExperience()
        {
            return experience;
        }

        public void setExperience(string experience)
        {
            this.experience = experience;
        }

        public string getPlace()
        {
            return place;
        }

        public void setPlace(string place)
        {
            this.place = place;
        }

        public string getTime()
        {
            return time;
        }

        public void setTime(string time)
        {
            this.time = time;
        }

        public string getAttitude()
        {
            return Attitude;
        }

        public void setAttitude(string Attitude)
        {
            this.Attitude = Attitude;
        }

        //以下是申报的getter setter
        public int getIntelligenceClaim()
        {
            return intelligenceClaim;
        }

        public void setIntelligenceClaim(int intelligenceClaim)
        {
            this.intelligenceClaim = intelligenceClaim;
        }

        public int getPhysicalClaim()
        {
            return physicalClaim;
        }

        public void setPhysicalClaim(int physicalClaim)
        {
            this.physicalClaim = physicalClaim;
        }

        public int getManaClaim()
        {
            return manaClaim;
        }

        public void setManaClaim(int manaClaim)
        {
            this.manaClaim = manaClaim;
        }

        public int getForceClaim()
        {
            return forceClaim;
        }

        public void setForceClaim(int forceClaim)
        {
            this.forceClaim = forceClaim;
        }

        public string getExperienceClaim()
        {
            return experienceClaim;
        }

        public void setExperienceClaim(string experienceClaim)
        {
            this.experienceClaim = experienceClaim;
        }

        public string getPlaceClaim()
        {
            return placeClaim;
        }

        public void setPlaceClaim(string placeClaim)
        {
            this.placeClaim = placeClaim;
        }

        public string getTimeClaim()
        {
            return timeClaim;
        }

        public void setTimeClaim(string timeClaim)
        {
            this.timeClaim = timeClaim;
        }

        //以下是博弈相关数据的getter setter
        public string getCharacter()
        {
            return character;
        }

        public void setCharacter(string character)
        {
            this.character = character;
        }

        public string getCareer()
        {
            return career;
        }

        public void setCareer(string career)
        {
            this.career = career;
        }

        public bool getIsPassed()
        {
            return isPassed;
        }

        public void setIsPassed(bool isPassed)
        {
            this.isPassed = isPassed;
        }

        public bool getIsCompliant()
        {
            return isCompliant;
        }

        public void setIsCompliant(bool isCompliant)
        {
            this.isCompliant = isCompliant;
        }

        public bool getWillPay()
        {
            return willPay;
        }

        public void setWillPay(bool willPay)
        {
            this.willPay = willPay;
        }

        public bool getWillReport()
        {
            return willReport;
        }

        public void setWillReport(bool willReport)
        {
            this.willReport = willReport;
        }

        public char getParty()
        {
            return party;
        }

        public void setParty(char party)
        {
            this.party = party;
        }

        public string getFirstTalk()
        {
            return firstTalk;
        }

        public void setFirstTalk(string firstTalk)
        {
            this.firstTalk = firstTalk;
        }

        public string getSecondTalk()
        {
            return secondTalk;
        }

        public void setSecondTalk(string secondTalk)
        {
            this.secondTalk = secondTalk;
        }

        public double getPartyPowerWeight()
        {
            return partyPowerWeight;
        }

        public void setPartyPowerWeight(double partyPowerWeight)
        {
            this.partyPowerWeight = partyPowerWeight;
        }

        public double getPartyAttitudeWeight()
        {
            return partyAttitudeWeight;
        }

        public void setPartyAttitudeWeight(double partyAttitudeWeight)
        {
            this.partyAttitudeWeight = partyAttitudeWeight;
        }

        public string getPicture()
        {
            return picture;
        }

        public void setPicture(string picture)
        {
            this.picture = picture;
        }

        public string getQuestion()
        {
            return question;
        }

        public void setQuestion(string question)
        {
            this.question = question;
        }

        public string getAnswer()
        {
            return answer;
        }

        public void setAnswer(string answer)
        {
            this.answer = answer;
        }
    }

    /**
     * 随机npc生成器
     */
    public class RandomNpcGenerate
    {
        NpcTemplate npc = new NpcTemplate();
        private Random randomNum = new Random();

        //职业四维补正表
        private double[,] careerWeight =
        {
            {
                0.8, 1.2, 0.6, 1.5 //战士四维权重修正
            },
            {
                1.2, 0.6, 1.5, 0.8 //术师四维权重修正
            },
            {
                0.8, 1.5, 0.6, 1.2 //重装四维权重修正
            },
            {
                1.5, 1.2, 0.8, 0.6 //游侠四维权重修正
            }
        };

        //npc生成方法
        //需要的参数：三个派系是否存在（例：毁灭派未出现，则视为不存在；某派系影响力掉至0，则该派系不再存在）
        public NpcTemplate Generate(bool isRExist, bool isCExist, bool isDExist)
        {
            int[] realValue = new int[4];
            int[] claimValue = new int[4];
            //生成npc职业
            npc.setCareer(GlobalVariables.career[randomNum.Next(GlobalVariables.career.Length - 1)]);
            //生成四维（真实的和申报的），并根据职业做相应的补正
            switch (npc.getCareer())
            {
                case "战士":
                    for (int i = 0; i < 4; i++)
                    {
                        realValue[i] = Convert.ToInt32(randomNum.Next(0, 101) * careerWeight[0, i]);
                        if (realValue[i] < 0)
                        {
                            realValue[i] = 0;
                        }
                        else if (realValue[i] > 100)
                        {
                            realValue[i] = 100;
                        }

                        claimValue[i] = realValue[i] + randomNum.Next(-12, 12);
                        if (claimValue[i] < 0)
                        {
                            claimValue[i] = 0;
                        }
                        else if (claimValue[i] > 100)
                        {
                            claimValue[i] = 100;
                        }
                    }

                    npc.setIntelligence(realValue[0]);
                    npc.setIntelligenceClaim(claimValue[0]);
                    npc.setPhysical(realValue[1]);
                    npc.setPhysicalClaim(claimValue[1]);
                    npc.setMana(realValue[2]);
                    npc.setManaClaim(claimValue[2]);
                    npc.setForce(realValue[3]);
                    npc.setForceClaim(claimValue[3]);
                    break;
                case "术师":
                    for (int i = 0; i < 4; i++)
                    {
                        realValue[i] = Convert.ToInt32(randomNum.Next(0, 101) * careerWeight[0, i]);
                        if (realValue[i] < 0)
                        {
                            realValue[i] = 0;
                        }
                        else if (realValue[i] > 100)
                        {
                            realValue[i] = 100;
                        }

                        claimValue[i] = realValue[i] + randomNum.Next(-12, 12);
                        if (claimValue[i] < 0)
                        {
                            claimValue[i] = 0;
                        }
                        else if (claimValue[i] > 100)
                        {
                            claimValue[i] = 100;
                        }
                    }

                    npc.setIntelligence(realValue[0]);
                    npc.setIntelligenceClaim(claimValue[0]);
                    npc.setPhysical(realValue[1]);
                    npc.setPhysicalClaim(claimValue[1]);
                    npc.setMana(realValue[2]);
                    npc.setManaClaim(claimValue[2]);
                    npc.setForce(realValue[3]);
                    npc.setForceClaim(claimValue[3]);
                    break;
                case "重装":
                    for (int i = 0; i < 4; i++)
                    {
                        realValue[i] = Convert.ToInt32(randomNum.Next(0, 101) * careerWeight[0, i]);
                        if (realValue[i] < 0)
                        {
                            realValue[i] = 0;
                        }
                        else if (realValue[i] > 100)
                        {
                            realValue[i] = 100;
                        }

                        claimValue[i] = realValue[i] + randomNum.Next(-12, 12);
                        if (claimValue[i] < 0)
                        {
                            claimValue[i] = 0;
                        }
                        else if (claimValue[i] > 100)
                        {
                            claimValue[i] = 100;
                        }
                    }

                    npc.setIntelligence(realValue[0]);
                    npc.setIntelligenceClaim(claimValue[0]);
                    npc.setPhysical(realValue[1]);
                    npc.setPhysicalClaim(claimValue[1]);
                    npc.setMana(realValue[2]);
                    npc.setManaClaim(claimValue[2]);
                    npc.setForce(realValue[3]);
                    npc.setForceClaim(claimValue[3]);
                    break;
                case "游侠":
                    for (int i = 0; i < 4; i++)
                    {
                        realValue[i] = Convert.ToInt32(randomNum.Next(0, 101) * careerWeight[0, i]);
                        if (realValue[i] < 0)
                        {
                            realValue[i] = 0;
                        }
                        else if (realValue[i] > 100)
                        {
                            realValue[i] = 100;
                        }

                        claimValue[i] = realValue[i] + randomNum.Next(-12, 12);
                        if (claimValue[i] < 0)
                        {
                            claimValue[i] = 0;
                        }
                        else if (claimValue[i] > 100)
                        {
                            claimValue[i] = 100;
                        }
                    }

                    npc.setIntelligence(realValue[0]);
                    npc.setIntelligenceClaim(claimValue[0]);
                    npc.setPhysical(realValue[1]);
                    npc.setPhysicalClaim(claimValue[1]);
                    npc.setMana(realValue[2]);
                    npc.setManaClaim(claimValue[2]);
                    npc.setForce(realValue[3]);
                    npc.setForceClaim(claimValue[3]);
                    break;
            }

            //生成npc的经历
            //可以新加东西，但需保证experience，place，time三个数组大小相同
            for (int i = 0; i < 3; i++)
            {
                realValue[i] = randomNum.Next(GlobalVariables.Experience.Length - 1);
                claimValue[i] = randomNum.Next(GlobalVariables.Experience.Length - 1);
            }

            if (randomNum.Next(1, 6) % 6 != 0) //如果不是六的倍数，那么该npc申报的经历一定是对的，否则有可能错误
            {
                npc.setExperience(GlobalVariables.Experience[realValue[0]]);
                npc.setExperienceClaim(GlobalVariables.Experience[realValue[0]]); //what
                npc.setPlace(GlobalVariables.place[realValue[1]]);
                npc.setPlaceClaim(GlobalVariables.place[realValue[1]]); //where
                npc.setTime(GlobalVariables.time[realValue[2]]);
                npc.setTimeClaim(GlobalVariables.time[realValue[2]]); //when
            }
            else
            {
                npc.setExperience(GlobalVariables.Experience[realValue[0]]);
                npc.setExperienceClaim(GlobalVariables.Experience[claimValue[0]]); //what
                npc.setPlace(GlobalVariables.place[realValue[1]]);
                npc.setPlaceClaim(GlobalVariables.place[claimValue[1]]); //where
                npc.setTime(GlobalVariables.time[realValue[2]]);
                npc.setTimeClaim(GlobalVariables.time[claimValue[2]]); //when
            }

            //生成npc性格
            npc.setCharacter(GlobalVariables.Characters[randomNum.Next(GlobalVariables.Characters.Length - 1)]);
            //生成对权力平衡影响权重
            npc.setPartyPowerWeight((npc.getIntelligence() + npc.getPhysical() + npc.getMana() + npc.getForce()) /
                                    100.0); //四维加和除以100
            //生成对派系看法影响权重
            npc.setPartyAttitudeWeight(npc.getPartyPowerWeight() * 1.2); //权力影响权重的1.2倍
            //生成npc派系倾向,1--R（激进派） 2--C（保守派） 3--D（毁灭派）
            while (true)
            {
                int r = randomNum.Next(1, 3);
                //若随机到不存在的派系，则重新随机
                if ((isRExist == false && r == 1) || (isCExist == false && r == 2) || (isDExist == false && r == 3))
                {
                }
                else
                {
                    switch (r)
                    {
                        case 1:
                            npc.setParty('R');
                            break;
                        case 2:
                            npc.setParty('C');
                            break;
                        case 3:
                            npc.setParty('D');
                            break;
                    }

                    break;
                }
            }

            //根据性格生成初始对话（偏友善/中立/敌对）
            switch (npc.getCharacter())
            {
                case "胆小": //性格为胆小的npc初始对话为友善
                    npc.setFirstTalk(
                        GlobalVariables.firstSpeakFriendly[
                            randomNum.Next(GlobalVariables.firstSpeakFriendly.Length - 1)]);
                    break;
                case "正直": //性格为正直的npc初始对话为中立
                    npc.setFirstTalk(
                        GlobalVariables.firstSpeakNeutral[
                            randomNum.Next(GlobalVariables.firstSpeakNeutral.Length - 1)]);
                    break;
                case "欺软怕硬": //性格为欺软怕硬和蛮横的npc初始对话为敌对
                case "蛮横":
                    npc.setFirstTalk(
                        GlobalVariables.firstSpeakHostile[
                            randomNum.Next(GlobalVariables.firstSpeakHostile.Length - 1)]);
                    break;
            }
            //判断npc本身是否合规
            if (Math.Abs(npc.getForce() - npc.getForceClaim()) <= 10 &&
                Math.Abs(npc.getMana() - npc.getManaClaim()) <= 10 &&
                Math.Abs(npc.getPhysical() - npc.getPhysicalClaim()) <= 10 &&
                Math.Abs(npc.getIntelligence() - npc.getIntelligenceClaim()) <= 10)
            {
                if (npc.getExperience() == npc.getExperienceClaim() && npc.getPlace() == npc.getPlaceClaim() &&
                    npc.getTime() == npc.getTimeClaim())
                {
                    npc.setIsCompliant(true);
                }
            }
            return npc;
        }
    }

    /**
     * 经历审查
     */
    public static class experienceAudit
    {
        private static Random randomNum = new Random();

        /**
         * 回答玩家的问题的函数
         * questionType:问题类型，time为提问时间，place为提问地点，experience为提问经历
         */
        public static void questionAndAnswer(NpcTemplate npc, string questionType)
        {
            switch (questionType)
            {
                case "time":
                    npc.setQuestion("你是在什么时候在" + npc.getPlaceClaim() + npc.getExperienceClaim() + "的？");
                    npc.setAnswer("我是在" + npc.getTimeClaim() + "在" + npc.getPlaceClaim() + npc.getExperienceClaim() +
                                  "的。");
                    break;
                case "place":
                    npc.setQuestion("你是在什么地方的" + npc.getTimeClaim() + npc.getExperienceClaim() + "的？");
                    npc.setAnswer("我是在" + npc.getPlaceClaim() + "的" + npc.getTimeClaim() + npc.getExperienceClaim() +
                                  "的。");
                    break;
                case "experience":
                    npc.setQuestion("你在" + npc.getTimeClaim() + "的" + npc.getPlaceClaim() + "干了什么？");
                    npc.setAnswer(
                        "我在" + npc.getTimeClaim() + "的" + npc.getPlaceClaim() + npc.getExperienceClaim() + "。");
                    break;
                default: //如果npc本来就不合格，npc有九分之一的概率顾左右而言他
                    //判断npc是否不正面回答问题
                    if ((randomNum.Next(1, 9) % 9 == 0) && (npc.getIsCompliant() == false))
                    {
                        npc.setAnswer(
                            GlobalVariables.secondSpeakOther[
                                randomNum.Next(GlobalVariables.secondSpeakOther.Length - 1)]);
                    }

                    break;
            }
        }

        /**
         * 审查npc的函数
         * playerAttitude: strong--强势 friendly--友善 neutral--中立
         */
        public static void audit(NpcTemplate npc, string playerAttitude)
        {
            Random randomNum = new Random();
            switch (npc.getCharacter())
            {
                case "胆小": //性格为胆小的一定接受勒索
                    npc.setWillPay(true);
                    npc.setWillReport(false);
                    if (playerAttitude == "strong")
                    {
                        npc.setSecondTalk(
                            GlobalVariables.secondSpeakScared[
                                randomNum.Next(GlobalVariables.secondSpeakScared.Length - 1)]);
                    }
                    else
                    {
                        npc.setSecondTalk(
                            GlobalVariables.secondSpeakFriendly[
                                randomNum.Next(GlobalVariables.secondSpeakFriendly.Length - 1)]);
                    }

                    break;
                case "正直": //性格为正直的npc一定不接受勒索
                    npc.setWillPay(false);
                    npc.setWillReport(true);
                    if (playerAttitude == "friendly")
                    {
                        npc.setSecondTalk(
                            GlobalVariables.secondSpeakFriendly[
                                randomNum.Next(GlobalVariables.secondSpeakFriendly.Length - 1)]);
                    }
                    else
                    {
                        npc.setSecondTalk(
                            GlobalVariables.secondSpeakNeutral[
                                randomNum.Next(GlobalVariables.secondSpeakNeutral.Length - 1)]);
                    }

                    break;
                case "蛮横": //性格为蛮横的npc一定不接受勒索
                    npc.setWillPay(false);
                    npc.setWillReport(true);
                    if (playerAttitude == "strong")
                    {
                        npc.setSecondTalk(
                            GlobalVariables.secondSpeakHostile[
                                randomNum.Next(GlobalVariables.secondSpeakHostile.Length - 1)]);
                    }

                    break;
                case "欺软怕硬": //性格为欺软怕硬的npc
                    if (playerAttitude == "strong") //如果玩家采取强势态度则接受勒索
                    {
                        npc.setAttitude("scared");
                        npc.setWillPay(true);
                        npc.setWillReport(false);
                        npc.setSecondTalk(
                            GlobalVariables.secondSpeakScared[
                                randomNum.Next(GlobalVariables.secondSpeakScared.Length - 1)]);
                    }
                    else //否则不接受勒索
                    {
                        npc.setWillPay(false);
                        npc.setWillReport(true);
                    }

                    break;
            }
        }
    }

    /**
     * 测试类
     * 默认勒索npc
     */
    internal class ProgramTest
    {
        public static void Main(string[] args)
        {
            RandomNpcGenerate randomNpcGenerate = new RandomNpcGenerate();
            NpcTemplate npcTemplate = randomNpcGenerate.Generate(true, true, false);
            experienceAudit.audit(npcTemplate, "strong");
            Console.WriteLine(npcTemplate.ToString());
        }
    }
}