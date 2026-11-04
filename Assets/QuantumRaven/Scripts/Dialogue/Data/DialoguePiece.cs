using UnityEngine;

[System.Serializable]
public class DialoguePiece
{
    [Header("对话详情")]
    public Sprite faceImage; //头像

    public bool onLeft; //是否在左边

    public string name; //名字

    [TextArea]
    public string dialogueText; //对话内容

    public bool hasToPause; //是否需要暂停

    public bool isDone; //是否是最后一句话
}
