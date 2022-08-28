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

    Settings settings;

    public Animator PortraitBoxAnimator;
    public Animator PortraitImageAnimator;
    public Animator DialogueBoxAnimator;
    public Animator DialogueTextAnimator;

    void Start() {
        ContinueButton.SetActive(false);
        Sentences = new Queue<string>();
        settings = FindObjectOfType<Settings>();
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
        UpdatePortraitImage(dialogue);
        DialogueBoxAnimator.SetBool("IsOpen", true);
        DialogueTextAnimator.SetBool("IsOpen", true);

        DisplayNextSentence();
    }

    void UpdatePortraitImage(Dialogue dialogue) {
        switch(dialogue.Portrait) {
            default:
                PortraitImageAnimator.SetInteger("Portrait", 0);
                Debug.LogWarning(
                    "Portrait \"" + dialogue.Portrait + "\" of dialogue \"" + dialogue.DialogueName + "\" is not found."
                );
                break;
            case "Dialogue":
                PortraitImageAnimator.SetInteger("Portrait", 1);
                break;
            case "Player":
                PortraitImageAnimator.SetInteger("Portrait", 2);
                break;
            case "Friend":
                PortraitImageAnimator.SetInteger("Portrait", 3);
                break;
        }
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
            FindObjectOfType<AudioManager>().PlaySound("Button hover");
            yield return new WaitForSeconds(1 / settings.textSpeed);
        }

        ContinueButton.SetActive(true);
    }

    void EndDialogue() {
        //Restore player's movement
        FindObjectOfType<PlayerMovement>().MovementSpeed = 5f;

        PortraitBoxAnimator.SetBool("IsOpen", false);
        PortraitImageAnimator.SetInteger("Portrait", 0);
        DialogueBoxAnimator.SetBool("IsOpen", false);
        DialogueTextAnimator.SetBool("IsOpen", false);

        FindObjectOfType<DialogueCommander>().StateCounter++;
    }
}
