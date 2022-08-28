using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueCommander : MonoBehaviour {
    public int StateCounter;
    public GameObject Player;
    Settings settings;
    SpriteRenderer PlayerSprite;
    // PlayerMovement playerMOv 
    //Enter all the triggers here
    public DialogueTrigger UncoveredDialogues;
    public DialogueTrigger Existed;
    public DialogueTrigger UncoveredVision;
    public DialogueTrigger AmIAlone;
    public DialogueTrigger UncoveredMovement;
    public DialogueTrigger IShouldMove;
    public DialogueTrigger MovementHint;
    public DialogueTrigger UncoveredFriend;
    public DialogueTrigger FriendHi;
    public DialogueTrigger PlayerHi;
    public DialogueTrigger YouLookBad;
    public DialogueTrigger IAmAlone;
    public DialogueTrigger YouAreNotAlone;
    public DialogueTrigger DiesFromFriendliness;
    public DialogueTrigger Rant;

    IEnumerator Start() {
        PlayerSprite = Player.GetComponent<SpriteRenderer>();
        PlayerSprite.enabled = false;

        Player.GetComponent<PlayerMovement>().MovementSpeed = 0f;

        settings = FindObjectOfType<Settings>();
        settings.SetMasterVolume(-80f);

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
                PlayerSprite.enabled = true;
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
                break;
            case 22:
                // Pla
                break;
            case 23:
                StateCounter++;
                FriendHi.TriggerDialogue();
                break;
            case 25:
                StateCounter++;
                PlayerHi.TriggerDialogue();
                break;
            case 27:
                StateCounter++;
                YouLookBad.TriggerDialogue();
                break;
            case 29:
                StateCounter++;
                IAmAlone.TriggerDialogue();
                break;
            case 31:
                StateCounter++;
                YouAreNotAlone.TriggerDialogue();
                break;
            case 33:
                StateCounter++;
                DiesFromFriendliness.TriggerDialogue();
                break;
            case 35:
                StateCounter++;
                Rant.TriggerDialogue();
                settings.SetMasterVolume(-80f);
                PlayerSprite.enabled = false;
                break;
            case 37:
                Application.Quit();
                break;
        }
    }
}
