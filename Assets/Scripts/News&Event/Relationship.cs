using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Relationship : MonoBehaviour
{
    public static Relationship Instance{ get; private set; }
    [SerializeField] private GameObject R;
    [SerializeField] private GameObject C;
    [SerializeField] private GameObject D;
    
    [Space(5)] 
    [Range(0,100)]
    [SerializeField] public int R_Value;
    [Range(0,100)]
    [SerializeField] public int C_Value;
    [Range(0,100)]
    [SerializeField] public int D_Value;
    /// <summary>
    /// //////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// </summary>
    [Space(5)] [Range(0, 100)] [SerializeField]
    private int THRESHOLD=80;//阈值
    [Range(0, 100)] [SerializeField]
    private int MAGNIFICATION=3;//倍率
    /// <summary>
    /// ///////////////////////////////////////////////////////////////////////////////////////////////////////
    /// </summary>
    private Text R_Information;
    private Text C_Information;
    private Text D_Information;
    
    private bool _dflag1;//判断D是否启用
    private bool _dflag2{ get; set; }//判断毁灭派是否亮明身份
    public string factionTag { get; set; }
        
    public bool GetDflag() => _dflag1;

    public void SetDflag(bool value) => _dflag1 = value;

    private bool _rIsLose{ get;  set; }
    private bool _cIsLose{ get;  set; }
    private bool _dIsLose{ get;  set; }
    
    private void Awake()
    {
        R_Information= R.transform.Find("R_Information").GetComponent<Text>();
        C_Information= C.transform.Find("C_Information").GetComponent<Text>();
        D_Information = D.transform.Find("D_Information").GetComponent<Text>();
        R_Information.color = R.transform.Find("R_Fill").GetComponent<Image>().color;
        C_Information.color = C.transform.Find("C_Fill").GetComponent<Image>().color;
        D_Information.color = D.transform.Find("D_Fill").GetComponent<Image>().color;
           
        Instance = this;
    }
    
    // 重绘好感度条状图
    public void RenewRelationship()
    {
        R.GetComponent<Slider>().value = (float)R_Value;
        C.GetComponent<Slider>().value = (float)C_Value;
        D.GetComponent<Slider>().value = 0;
        R_Information.text = "激进派态度：" + R_Value;
        C_Information.text = "保守派态度：" + C_Value;
        D_Information.text = "";
        if (GetDflag())
        {
            D_Information.text = "毁灭派态度：" + D_Value;
            D.GetComponent<Slider>().value = (float)D_Value;
        }
    }
    
    // 用于初始化数值
    public void SetValue(int R_Value, int C_Value, int D_Value)
    {
        this.R_Value = R_Value;
        this.C_Value = C_Value;
        this.D_Value = D_Value;
    }
    
    // 设置变化值
    // faction 派系简写 激进派-R，保守派-C，毁灭派-D
    // difference 变化值 
    public void SetDifference(string faction, int difference)
    {
        switch (faction)
        {
            case "R":
                if (R_Value>=THRESHOLD)
                {
                    R_Value += MAGNIFICATION * difference;
                }
                else
                {
                    R_Value += difference;
                }
                break;
            case "C": 
                if (C_Value>=THRESHOLD)
                {
                    C_Value += MAGNIFICATION * difference;
                }
                else
                {
                    C_Value += difference;
                }
                break;
            case "D": if (D_Value>=THRESHOLD)
                {
                    D_Value += MAGNIFICATION * difference;
                }
                else
                {
                    D_Value += difference;
                }
                break;
            default:
                Debug.Log("Error");
                break;
        }

        if (R_Value>80)
        {
            factionTag = "R";
        }
        if (C_Value>80)
        {
            factionTag = "C";
        }
        if (D_Value>80)
        {
            factionTag = "D";
        }
    }
    
    /// <summary>
    /// 快速取值、赋值函数
    /// </summary>
    /// <param name="parameters">对象列表，依次是R_Value，C_Value，D_Value</param>
    public void RenewFloutDate(object[] parameters)
    {
        R_Value = (int)parameters[0];
        C_Value = (int)parameters[1];
        D_Value = (int)parameters[2];
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
    /// <param name="parameters">对象列表，依次是R_Value，C_Value，D_Value</param>
    public object[] GetFloutDate()
    {
        return new object[]{R_Value,C_Value,D_Value};
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
