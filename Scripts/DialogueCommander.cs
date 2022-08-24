using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueCommander : MonoBehaviour {
    public int StateCounter;
    //Enter all the triggers here
    public DialogueTrigger UncoveredDialogues;
    public DialogueTrigger Existed;
    public DialogueTrigger UncoveredVision;
    public DialogueTrigger AmIAlone;
    public DialogueTrigger UncoveredMovement;
    public DialogueTrigger IShouldMove;
    public DialogueTrigger MovementHint;

    IEnumerator Start() {
        FindObjectOfType<PlayerMovement>().MovementSpeed = 0f;
        yield return new WaitForSeconds(5);
        StateCounter++;
    }

    // Update is called once per frame
    void Update() {
        switch(StateCounter) {
            case 1:
                StateCounter++;
                UncoveredDialogues.TriggerDialogue();
                break;
            case 3:
                StateCounter++;
                Existed.TriggerDialogue();
                break;
            case 5:
                StateCounter++;
                UncoveredVision.TriggerDialogue();
                break;
            case 7:
                StateCounter++;
                AmIAlone.TriggerDialogue();
                break;
            case 9:
                StateCounter++;
                UncoveredMovement.TriggerDialogue();
                break;
            case 11:
                StateCounter++;
                IShouldMove.TriggerDialogue();
                break;
            case 13:
                StateCounter++;
                MovementHint.TriggerDialogue();
                // FindObjectOfType<AudioManager>().PlaySound("Test");
                break;

        }
    }
}
