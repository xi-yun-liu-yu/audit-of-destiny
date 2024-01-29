namespace NPC
{
   public class NPC
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
            private bool isCompliant; //是否合规
            private bool willPay; //被勒索是否会付款
            private bool willReport; //被勒索是否会举报
            //上述是npc关于博弈的数据
    
            //以下是getter和setter，是对应好的，每个属性都有
            //以下是真实数据的getter setter
            public int getIntelligence()
            {
                return intelligence;
            }
    
            public void setIntelligence(int Intelligence)
            {
                this.intelligence = Intelligence;
            }
    
            public int getPhysical()
            {
                return physical;
            }
    
            public void setPhysical(int Physical)
            {
                this.physical = Physical;
            }
    
            public int getMana()
            {
                return mana;
            }
    
            public void setMana(int Mana)
            {
                this.mana = Mana;
            }
    
            public int getForce()
            {
                return force;
            }
    
            public void setForce(int Force)
            {
                this.force = Force;
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
            public string getCharcater()
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
        }
}
     
