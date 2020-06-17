using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformEventLevel10Script : TransformEventLevelScript {

	// Use this for initialization
	new void Start () {
        base.Start();
	}

    public override void DoEvent() {
        theDialogueManager.SendDialogue("troblob", "wait, uh blobert, uhh please stop");
        theDialogueManager.SendDialogue("blobert", "uhh no?");
        theDialogueManager.SendDialogue("fabby", "não não não");
        theDialogueManager.SendDialogue("troblob", "I shall award you with... cake?!?!?");
        theDialogueManager.SendDialogue("fabby", "C4k3?? 1 10v3 Kak3!!!");

        theDialogueManager.SendDialogue("blobert", "Fabby don't listen to him, he is trying to trick you….");
        theDialogueManager.SendDialogue("fabby", "OOOOoooOOOOooOH OOOOoOOK Blueboort!");
        theDialogueManager.SendDialogue("blobert", "There must be something up ahead...");

        isEventFinished = true;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
