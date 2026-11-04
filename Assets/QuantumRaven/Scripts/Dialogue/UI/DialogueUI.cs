using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueUI : MonoBehaviour
{
    public GameObject dialogueBox;

    public TextMeshProUGUI dialogueText;

    public Image npcAvatar; //NPC头像

    public TextMeshProUGUI npcName;    //NPC名字

    public GameObject continueBox;  //继续提示

    private void Awake()
    {
        continueBox.SetActive(false);
    }
}
