using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace MoonsetValley.Dialogue
{
    [RequireComponent(typeof(NPCmovement))]
    [RequireComponent(typeof(BoxCollider2D))]
    public class DialogueController : MonoBehaviour
    {
        private NPCmovement npc => GetComponent<NPCmovement>();

        public UnityEvent OnFinishEvent;

        public List<DialoguePiece> dialogueList = new List<DialoguePiece>();

        private Stack<DialoguePiece> dialogueStack;

        private bool canTalk;
        private bool isTalking;

        private GameObject uiSign;

        private void Awake()
        {
            uiSign = transform.GetChild(0).gameObject;
            FillDialogueStack();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                canTalk = !npc.isMoving && npc.interactable;
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                canTalk = false;
            }
        }

        private void Update()
        {
            uiSign.SetActive(canTalk);
            if(canTalk && Input.GetKeyDown(KeyCode.F) && !isTalking)
            {
                StartCoroutine(DialogueRoutine());
            }
        }

        /// <summary>
        /// 构建对话堆栈
        /// </summary>
        private void FillDialogueStack()
        {
            dialogueStack = new Stack<DialoguePiece>();

            for (int i = dialogueList.Count - 1; i > -1; i--)
            {
                dialogueList[i].isDone = false;
                dialogueStack.Push(dialogueList[i]);
            }
        }

        private IEnumerator DialogueRoutine()
        {
            isTalking = true;
            if(dialogueStack.TryPop(out DialoguePiece result))
            {
                //传到ui显示对话
                EventHandler.CallShowDialogueEvent(result);
                yield return new WaitUntil(() => result.isDone == true);
                isTalking = false;
            }
            else
            {
                EventHandler.CallShowDialogueEvent(null);
                FillDialogueStack();
                isTalking = false;

                OnFinishEvent?.Invoke();
            }
        }
    }
}

