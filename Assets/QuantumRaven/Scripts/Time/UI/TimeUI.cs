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

    private float HP;
    private float H;
    private float W;


    private void Awake()
    {
        //初始化数值
        HP = HealthPoint.sizeDelta.x;
        H = HungryPoint.sizeDelta.x;
        W = ThirstyPoint.sizeDelta.x;
        Money.text = "500";
    }

    private void OnEnable()
    {
        EventHandler.GameMinuteEvent += OnGameMinuteEvent;
        EventHandler.GameDateEvent += OnGameDateEvent;
    }

    private void OnDisable()
    {
        EventHandler.GameMinuteEvent -= OnGameMinuteEvent;
        EventHandler.GameDateEvent -= OnGameDateEvent;
    }

    private void OnGameDateEvent(int hour, int day, int month, int year)
    {

    }

    private void OnGameMinuteEvent(int minute, int hour)
    {
        //分针转动
        Vector3 currentRotation1 = clockMinutes.localEulerAngles;
        clockMinutes.localEulerAngles = new Vector3(
            currentRotation1.x,
            currentRotation1.y,
            minute * -6f
        );
        gamePointChange("H", -0.052f);
        gamePointChange("W", -0.078f);
        //时针转动
        Vector3 currentRotation2 = clockHours.localEulerAngles;
        clockHours.localEulerAngles = new Vector3(
            currentRotation2.x,
            currentRotation2.y,
            hour * -30f + 90f
        );
        //图标切换
        if (hour >= 5 && hour < 10)
        {
            weatherImage.sprite = DayNightIcon[0];
        }
        else if (hour >= 10 && hour < 14)
        {
            weatherImage.sprite = DayNightIcon[1];
        }
        else if (hour >= 14 && hour < 17)
        {
            weatherImage.sprite = DayNightIcon[2];
        }
        else if (hour >= 17 && hour < 21)
        {
            weatherImage.sprite = DayNightIcon[3];
        }
        else if (hour >= 21 || hour < 5)
        {
            weatherImage.sprite = DayNightIcon[4];
        }
    }

    /// <summary>
    /// 控制时间指针旋转
    /// </summary>
    /// <param name="type">指针是分针还是秒针</param>
    public void clockCursorRotate(string type)
    {
        if (type == "Minute")
        {
            Vector3 currentRotation = clockMinutes.localEulerAngles;
            clockMinutes.localEulerAngles = new Vector3(
                currentRotation.x,
                currentRotation.y,
                currentRotation.z + 6f
            );
        }
        else if (type == "Hour")
        {
            Debug.Log("小时");
        }
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
    public void gamePointChange(string type, float value)
    {
        switch (type)
        {
            case "HP":
                HP += value;
                if (HP < 0.0f) return;
                HealthPoint.sizeDelta = new Vector2(HP, HealthPoint.sizeDelta.y);
                break;
            case "H":
                H += value;
                if (H < 0.0f) return;
                HungryPoint.sizeDelta = new Vector2(H, HungryPoint.sizeDelta.y);
                break;
            case "W":
                W += value;
                if (W < 0.0f) return;
                ThirstyPoint.sizeDelta = new Vector2(W, ThirstyPoint.sizeDelta.y);
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// 日夜图标转换
    /// </summary>
    /// <param name="code">图标id</param>
    public void dayNightChange(int code)
    {

    }
}
