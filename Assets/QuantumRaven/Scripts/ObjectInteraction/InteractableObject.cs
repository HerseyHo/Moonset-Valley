using UnityEngine;
using UnityEngine.UI;

public class InteractableObject : MonoBehaviour
{
    [Header("Interaction Settings")]
    public string interactAction = "Interact"; // 在Input Manager中定义的输入名称，默认为F键

    [Header("UI Prompt")]
    public GameObject promptUI; // 提示UI（比如一个Text或Panel），初始为关闭状态

    private bool playerInRange = false;

    private void Start()
    {
        if (promptUI != null)
            promptUI.SetActive(false);
    }

    private void Update()
    {
        // 如果玩家在范围内且按下了交互键
        if (playerInRange && Input.GetKeyDown(KeyCode.F))
        {
            Interact();
        }
    }

    // 当玩家进入触发器范围
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // 确保是玩家
        {
            playerInRange = true;
            if (promptUI != null)
                promptUI.SetActive(true);
        }
    }

    // 当玩家离开触发器范围
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            if (promptUI != null)
                promptUI.SetActive(false);
        }
    }

    // 交互行为（可重写或通过事件扩展）
    protected virtual void Interact()
    {
        Debug.Log("与 " + gameObject.name + " 交互了！");

        // 在这里实现具体交互逻辑，例如开门、对话、拾取等
    }
}
