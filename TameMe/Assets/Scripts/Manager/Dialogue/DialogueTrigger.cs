using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    public GameObject next_btn;

    public Image btn;

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        btn.enabled = false;

    }
    public void EndDialogue()
    {
        next_btn.SetActive(true);
        Destroy(gameObject);
    }
}
