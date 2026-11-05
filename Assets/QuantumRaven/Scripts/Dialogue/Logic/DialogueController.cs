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
    }
}

