using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class TimeUI : MonoBehaviour
{
    public RectTransform clockMinutes;  //分针

    public RectTransform clockHours;    //时针

    public Image weatherImage;  //昼夜图标
    //5-10day,10-14dawn,14-17noon,17-21lightning,21-5night

    public TextMeshProUGUI Money;  //金钱

    public RectTransform HealthPoint;  //血量

    public RectTransform HungryPoint;    //饥饿

    public RectTransform ThirstyPoint;    //口渴

    public Sprite[] DayNightIcon;   //所有昼夜图标


    /// <summary>
    /// 控制时间指针旋转
    /// </summary>
    /// <param name="type">指针是分针还是秒针</param>
    public static void clockCursorRotate()
    {
        Debug.Log("yes");
    }

    /// <summary>
    /// 变更余额
    /// </summary>
    /// <param name="value">变化的值</param>
    public void MoneyChange(int value)
    {
        
    }

    /// <summary>
    /// 3个状态值的变化
    /// </summary>
    /// <param name="type">变更哪个值</param>
    /// <param name="value"></param>
    public void gamePointChange(string type, int value)
    {

    }

    /// <summary>
    /// 日夜图标转换
    /// </summary>
    /// <param name="code">图标id</param>
    public void dayNightChange(int code)
    {

    }
}
