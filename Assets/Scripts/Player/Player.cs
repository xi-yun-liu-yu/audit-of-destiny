using System;
using UnityEngine;

namespace Player
{
    public class Player:MonoBehaviour
    {
        public static Player Instance{ get; private set; }
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

        private void Awake()
        {
            Instance = this;
        }

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
        
        /// <summary>
        /// 快速取值、赋值函数
        /// </summary>
        /// <param name="parameters">对象列表，依次是B_R_Value，B_C_Value，B_D_Value</param>
        public void RenewB_FloutDate(object[] parameters)
        {
            B_R_Value = (float)parameters[0];
            B_C_Value = (float)parameters[1];
            B_D_Value = (float)parameters[2];
        }
        /// <summary>
        /// 快速取值、赋值函数
        /// </summary>
        /// <param name="parameters">对象列表，依次是B_R_Value，B_C_Value，B_D_Value</param>
        public object[] GetB_FloutDate()
        {
            return new object[] { B_R_Value, B_C_Value, B_D_Value };
        }
        /// <summary>
        /// 快速取值、赋值函数
        /// </summary>
        /// <param name="parameters">对象列表，依次是R_R_Value，R_C_Value，R_D_Value</param>
        public void RenewR_FloutDate(object[] parameters)
        {
            R_R_Value = (int)parameters[0];
            R_C_Value = (int)parameters[1];
            R_D_Value = (int)parameters[2];
        }
        /// <summary>
        /// 快速取值、赋值函数
        /// </summary>
        /// <param name="parameters">对象列表，依次是R_R_Value，R_C_Value，R_D_Value</param>
        public object[] GetR_FloutDate()
        {
            return new object[] { R_R_Value, R_C_Value, R_D_Value };
        }
        /// <summary>
        /// 快速取值、赋值函数
        /// </summary>
        /// <param name="parameters">_dflag1,_dflag2,_rIsLose,_rIsLose,_dIsLose</param>
        public void RenewBoolDate(object[] parameters)
        {
            _dflag1 = (bool)parameters[0];
            _dflag2 = (bool)parameters[1];
            _rIsLose = (bool)parameters[2];
            _cIsLose = (bool)parameters[3];
            _dIsLose = (bool)parameters[4];
        }
        
        /// <summary>
        /// 快速取值、赋值函数
        /// </summary>
        /// <param name="parameters">_dflag1,_dflag2,_rIsLose,_rIsLose,_dIsLose</param>
        public object[] GetBoolDate()
        {
            return new object[]{_dflag1,_dflag2,_rIsLose,_rIsLose,_dIsLose};
        }

    }
}