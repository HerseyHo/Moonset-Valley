using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

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

    private void OnEnable()
    {
        EventHandler.ShowDialogueEvent += OnShowDialogueEvent;
    }

    private void OnDisable()
    {
        EventHandler.ShowDialogueEvent -= OnShowDialogueEvent;
    }

    private void OnShowDialogueEvent(DialoguePiece piece)
    {
        StartCoroutine(ShowDialogue(piece));
    }

    private IEnumerator ShowDialogue (DialoguePiece piece)
    {
        if(piece != null)
        {
            piece.isDone = false;

            dialogueBox.SetActive(true);
            continueBox.SetActive(false);

            dialogueText.text = string.Empty;
            if(piece.name != string.Empty)
            {
                npcAvatar.gameObject.SetActive(true);
                npcAvatar.sprite = piece.faceImage;
                dialogueText.text = piece.dialogueText;
                npcName.text = piece.name;
            }
            else
            {
                npcAvatar.gameObject.SetActive(false);
                npcName.gameObject.SetActive(false);
            }

            //yield return dialogueText.DOText(piece.dialogueText, 1f).WaitForCompletion(); 

            piece.isDone = true;

            if(piece.hasToPause && piece.isDone)
                continueBox.SetActive(true);
        }
        else
        {
            dialogueBox.SetActive(false);
            yield break;
        }
    }
}
