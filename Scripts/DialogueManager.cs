using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour {
    public Queue<string> Sentences;
    public Image Portrait;
    public TextMeshProUGUI DialogueText;

    //Start is called before the first frame update
    void Start() {
        Sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue) {
        //Clear the previous dialogue
        Sentences.Clear();

        //Enqueue the next sentences of a dialogue
        foreach(string Sentence in dialogue.Sentences) {
            Sentences.Enqueue(Sentence);
        }

        Portrait.sprite = dialogue.Portrait;
        DisplayNextSentence();
    }

    public void DisplayNextSentence() {
        //Reached the end of the queue
        if(Sentences.Count == 0) {
            EndDialogue();
            return;
        }

        string Sentence = Sentences.Dequeue();
        DialogueText.text = Sentence;
    }

    void EndDialogue() {
        Debug.Log("End of this dialogue");
    }
}
