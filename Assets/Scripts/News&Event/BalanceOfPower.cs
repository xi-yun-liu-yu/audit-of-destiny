using System;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;

namespace News_Event
{
    public class BalanceOfPower :MonoBehaviour
    {
        public static BalanceOfPower Instance{ get; private set; }
        
        [SerializeField] private GameObject R;
        [SerializeField] private GameObject C;
        [SerializeField] private GameObject D;
        [Space(5)] 
        [Range(0,1)]
        [SerializeField] public float R_Value;
        [Range(0,1)]
        [SerializeField] public float C_Value;
        [Range(0,1)]
        [SerializeField] public float D_Value;
        private Text R_Information;
        private Text C_Information;
        private Text D_Information;

        private bool _dflag1;//判断毁灭派是否登场
        private bool _dflag2{ get; set; }//判断毁灭派是否亮明身份
        
        public bool GetDflag1() => _dflag1;

        public void SetDflag1(bool value) => _dflag1 = value;
        
        public bool GetDflag2() => _dflag2;

        public void SetDflag2(bool value) => _dflag2 = value;

        private bool _rIsLose{ get;  set; }
        private bool _cIsLose{ get;  set; }
        private bool _dIsLose{ get;  set; }
        
        private void Awake()
        {
           R_Information= R.transform.Find("R_Information").GetComponent<Text>();
           C_Information= C.transform.Find("C_Information").GetComponent<Text>();
           D_Information = D.transform.Find("D_Information").GetComponent<Text>();
           R_Information.color = R.GetComponent<Annulus>().color;
           C_Information.color = C.GetComponent<Annulus>().color;
           D_Information.color = D.GetComponent<Annulus>().color;
           
           Instance = this;
        }
        
        // 重绘权力平衡环形饼图
        public void RenewBalance()
        {
            R.GetComponent<Annulus>().fillAmount = 1;
            C.GetComponent<Annulus>().fillAmount = 1 - R_Value;
            D.GetComponent<Annulus>().fillAmount = 1 - R_Value - C_Value;
            
            R_Information.text = "激进派：" + R_Value;
            C_Information.text = "保守派：" + C_Value;
            D_Information.text = "";
            if (GetDflag1())
            {
                D_Information.text = "毁灭派：" + D_Value;
            }
        }

        // 用于初始化数值
        public void SetValue(float R_Value, float C_Value, float D_Value)
        {
            this.R_Value = R_Value;
            this.C_Value = C_Value;
            this.D_Value = D_Value;
        }
        
        // 用于输入变化值
        // ！！！请自己保证 值的和 等于零！！！
        public void SetDifference(float R_Difference, float C_Difference, float D_Difference)
        {
            R_Value = R_Value + R_Difference;
            C_Value = C_Value + C_Difference;
            D_Value = D_Value + D_Difference;
        }

        // faction 派系简写 激进派-R，保守派-C，毁灭派-D
        // difference 变化值 
        public void SetDifference(String faction, float difference)
        {
            // 毁灭派未出现
            if (!GetDflag1()||_dIsLose)
            {
                switch (faction)
                {
                    case "R":
                        R_Value = R_Value + difference;
                        C_Value = C_Value - difference;
                        break;
                    case "C":
                        C_Value = C_Value + difference;
                        R_Value = R_Value - difference;
                        break;
                    default:
                        Debug.Log("faction 未使用约定的值");
                        break;
                }
                return;
            }

            if (_rIsLose)
            {
                switch (faction)
                {
                    case "D":
                        D_Value = D_Value + difference;
                        C_Value = C_Value - difference;
                        break;
                    case "C":
                        C_Value = C_Value + difference;
                        D_Value = D_Value - difference;
                        break;
                    default:
                        Debug.Log("faction 未使用约定的值或者使用了已经输掉的派系值");
                        break;
                }
                return;
            }
            
            if (_cIsLose)
            {
                switch (faction)
                {
                    case "D":
                        D_Value = D_Value + difference;
                        R_Value = R_Value - difference;
                        break;
                    case "R":
                        R_Value = R_Value + difference;
                        D_Value = D_Value - difference;
                        break;
                    default:
                        Debug.Log("faction 未使用约定的值或者使用了已经输掉的派系值");
                        break;
                }
                return;
            }
            
            if (GetDflag2())
            {
                // 毁灭派出现但未亮明身份
                switch (faction)
                {
                    case "R":
                        R_Value = R_Value + (difference / 2);
                        C_Value = C_Value - difference ;
                        D_Value = D_Value + (difference / 2);
                        break;
                    case "C":
                        C_Value = C_Value + difference- (difference / 2/2);
                        R_Value = R_Value - (difference / 2);
                        D_Value = D_Value - (difference / 2/2);
                        break;
                    default:
                        Debug.Log("faction 未使用约定的值");
                        break;
                }
            }
            else
            {
                switch (faction)
                            {
                                case "R":
                                    R_Value = R_Value + difference;
                                    C_Value = C_Value - (difference / 2);
                                    D_Value = D_Value - (difference / 2);
                                    break;
                                case "C":
                                    C_Value = C_Value + difference;
                                    R_Value = R_Value - (difference / 2);
                                    D_Value = D_Value - (difference / 2);
                                    break;
                                case "D":
                                    D_Value = D_Value + difference;
                                    R_Value = R_Value - (difference / 2);
                                    C_Value = C_Value - (difference / 2);
                                    break;
                                default:
                                    Debug.Log("faction 未使用约定的值");
                                    break;
                            }
            }
            

            if (R_Value <= 0)
            {
                _rIsLose = true;
            }

            if (C_Value <= 0)
            {
                _dIsLose = true;
            }

            if (D_Value <= 0)
            {
                _dIsLose = true;
            }
            
        }

        public void RenewDate(object[] parameters)
        {
            R_Value = (float)parameters[0];
            C_Value = (float)parameters[1];
            D_Value = (float)parameters[2];
            _dflag1 = (bool)parameters[3];
            _dflag2 = (bool)parameters[4];

        }
    }
}