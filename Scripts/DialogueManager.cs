using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour {
    public Queue<string> Sentences;
    public Image Portrait;
    public TextMeshProUGUI DialogueText;
    public GameObject ContinueButton;
    [RangeAttribute(1f, 50f)]
    public float TypingSpeed = 25f;

    public Animator PortraitBoxAnimator;
    public Animator PortraitImageAnimator;
    public Animator DialogueBoxAnimator;
    public Animator DialogueTextAnimator;

    //Start is called before the first frame update
    void Start() {
        Sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue) {
        //Freezes player's movement
        FindObjectOfType<PlayerMovement>().MovementSpeed = 0f;

        //Clear the previous dialogue
        Sentences.Clear();

        //Enqueue the next sentences of a dialogue
        foreach(string Sentence in dialogue.Sentences) {
            Sentences.Enqueue(Sentence);
        }

        PortraitBoxAnimator.SetBool("IsOpen", true);
        PortraitImageAnimator.SetBool("IsOpen", true);
        DialogueBoxAnimator.SetBool("IsOpen", true);
        DialogueTextAnimator.SetBool("IsOpen", true);

        Portrait.sprite = dialogue.Portrait;
        DisplayNextSentence();
    }

    public void DisplayNextSentence() {
        ContinueButton.SetActive(false);

        //Reached the end of the queue
        if(Sentences.Count == 0) {
            EndDialogue();
            return;
        }

        string Sentence = Sentences.Dequeue();
        StartCoroutine(TypeSentence(Sentence));
    }

    IEnumerator TypeSentence(string Sentence) {
        DialogueText.text = "";
        foreach(char Letter in Sentence.ToCharArray()) {
            DialogueText.text += Letter;
            yield return new WaitForSeconds(1 / TypingSpeed);
        }

        ContinueButton.SetActive(true);
    }

    void EndDialogue() {
        //Restore player's movement
        FindObjectOfType<PlayerMovement>().MovementSpeed = 5f;

        PortraitBoxAnimator.SetBool("IsOpen", false);
        PortraitImageAnimator.SetBool("IsOpen", false);
        DialogueBoxAnimator.SetBool("IsOpen", false);
        DialogueTextAnimator.SetBool("IsOpen", false);

        FindObjectOfType<DialogueCommander>().StateCounter++;
    }
}
