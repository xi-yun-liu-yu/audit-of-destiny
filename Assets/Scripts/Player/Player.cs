using UnityEngine;

namespace Player
{
    public class Player:MonoBehaviour
    {
        [SerializeField] public int money;
        [Header("权力平衡存档区")]
        [Range(0,1)]
        [SerializeField] public float B_R_Value;
        [Range(0,1)]
        [SerializeField] public float B_C_Value;
        [Range(0,1)]
        [SerializeField] public float B_D_Value;
        public bool _dflag1;//判断毁灭派是否登场
        public bool _dflag2; //判断毁灭派是否亮明身份
        [Header("关系存档区")]
        [Range(0,100)]
        [SerializeField] public int R_R_Value;
        [Range(0,100)]
        [SerializeField] public int R_C_Value;
        [Range(0,100)]
        [SerializeField] public int R_D_Value;
        public string factionTag;//玩家立场
        public bool _rIsLose{ get;  set; }
        public bool _cIsLose{ get;  set; }
        public bool _dIsLose{ get;  set; }
        
        public void Renewdate(Player newData)
        {
            //将newData的属性值赋给当前实例的属性值
            this.money = newData.money;
            this.B_R_Value = newData.B_R_Value;
            this.B_C_Value = newData.B_C_Value;
            this.B_D_Value = newData.B_D_Value;
            this._dflag1 = newData._dflag1;
            this._dflag2 = newData._dflag2;
            this.R_R_Value = newData.R_R_Value;
            this.R_C_Value = newData.R_C_Value;
            this.R_D_Value = newData.R_D_Value;
            this.factionTag = newData.factionTag;
            this._rIsLose = newData._rIsLose;
            this._cIsLose = newData._cIsLose;
            this._dIsLose = newData._dIsLose;
        }
    }
}