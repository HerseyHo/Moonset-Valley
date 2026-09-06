using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TimeManager : Singleton<TimeManager>
{
    private int gameSecond, gameMinute, gameHour, gameDay, gameMonth, gameYear;

    public bool gameClockPause;

    private float tikTime;

    public TimeSpan GameTime => new TimeSpan(gameHour, gameMinute, gameSecond);

    protected override void Awake()
    {
        base.Awake();
        NewGameTime();
    }

    private void Update()
    {

        if (!gameClockPause)
        {
            tikTime += Time.deltaTime;

            if (tikTime >= Settings.secondThreshold)
            {
                tikTime -= Settings.secondThreshold;
                UpdateGameTime();
            }
        }

        if(Input.GetKeyDown(KeyCode.G))
        {
            gameDay++;
            EventHandler.CallGameDayEvent(gameDay);
            EventHandler.CallGameDateEvent(gameHour, gameDay, gameMonth, gameYear);
        }
    }

    private void NewGameTime()
    {
        gameSecond = 0;
        gameMinute = 0;
        gameHour = 7;
        gameDay = 1;
        gameMonth = 1;
        gameYear = 1;
    }

    private void UpdateGameTime()
    {
        gameSecond++;
        if (gameSecond > Settings.secondHold)
        {
            gameMinute++;
            gameSecond = 0;
            if (gameMinute > Settings.minuteHold)
            {
                gameHour++;
                gameMinute = 0;
                if (gameHour > Settings.hourHold)
                {
                    gameDay++;
                    gameHour = 0;
                    if (gameDay > Settings.dayHold)
                    {
                        gameMonth++;
                        gameDay = 1;
                        if (gameMonth > 12)
                        {
                            gameMonth = 1;
                            gameYear++;
                        }
                        //用来刷新地图和农作物生长

                    }
                    EventHandler.CallGameDateEvent(gameHour, gameDay, gameMonth,gameYear);
                }
            }
            EventHandler.CallGameMinuteEvent(gameMinute, gameHour);
        }
        //Debug.Log("Second:" + gameSecond + " Minute:" + gameMinute);
    }
}
