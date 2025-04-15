using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
public class DialogueManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;

    public Animator animator;
    
    // lifo ou fifo ??
    private Queue<string> sentences; 

    public static DialogueManager instanceDialogueManager;

    public void Awake()
    {
        if (instanceDialogueManager != null)
        {
            Debug.LogWarning("Il a plus d'une instance de DialogueManager dans la scene");
            return;
        }
        instanceDialogueManager = this;
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue) {

        animator.SetBool("isOpen", true);
    
        nameText.text = dialogue.name;
        
        sentences.Clear();

        foreach (string sentence in dialogue.sentences) { 
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

   public  void DisplayNextSentence() {
        if (sentences.Count == 0) {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    
    }

    IEnumerator TypeSentence(string sentence) {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray()) { 
            dialogueText.text += letter;
            //yield return null;
            yield return new WaitForSeconds(0.1f);
        }
    
    }

    public void EndDialogue() {

        Debug.Log("Fin du dialogue");
        animator.SetBool("isOpen", false);
    }
}
