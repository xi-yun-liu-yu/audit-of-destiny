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
    private int THRESHOLD;//阈值
    [Range(0, 100)] [SerializeField]
    private int MAGNIFICATION;//倍率
    /// <summary>
    /// ///////////////////////////////////////////////////////////////////////////////////////////////////////
    /// </summary>
    private Text R_Information;
    private Text C_Information;
    private Text D_Information;
    
    private bool _dflag;//判断D是否启用
    public string factionTag { get; set; }
        
    public bool GetDflag() => _dflag;

    public void SetDflag(bool value) => _dflag = value;

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
        R.GetComponent<Slider>().value = R_Value;
        C.GetComponent<Slider>().value = C_Value;
        D.GetComponent<Slider>().value = 0;
        R_Information.text = "激进派态度：" + R_Value;
        C_Information.text = "保守派态度：" + C_Value;
        D_Information.text = "";
        if (GetDflag())
        {
            D_Information.text = "毁灭派态度：" + D_Value;
            D.GetComponent<Slider>().value = D_Value;
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
    public void SetDifference(String faction, int difference)
    {
        switch (faction)
        {
            case "R":
                R_Value += R_Value >= THRESHOLD ? MAGNIFICATION * difference : difference;
                break;
            case "C": C_Value += C_Value >= THRESHOLD ? MAGNIFICATION * difference : difference;
                break;
            case "D": C_Value += C_Value >= THRESHOLD ? MAGNIFICATION * difference : difference;
                break;
        }
    }
}
