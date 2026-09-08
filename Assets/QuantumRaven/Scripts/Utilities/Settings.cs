using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings
{
    public const float fadeDuration = 0.35f;
    public const float targetAlpha = 0.45f;
    //时间相关
    public const float secondThreshold = 0.04f;   //数值越小时间越快

    public const int secondHold = 59;

    public const int minuteHold = 59;

    public const int hourHold = 59;

    public const int dayHold = 30;

    //Transition
    public const float sceneFadeDuration = 0.8f;

    //NPC网格移动
    public const float gridCellSize = 1;
    public const float gridCellDiagonalSize = 1.41f;

    public const float pixelSize = 0.05f;   //20*20 占1个unit

    public const float animationBreakTime = 5f; //动画时间间隔

    public const int maxGridSize = 9999;

}
