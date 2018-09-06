using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformEventLevel10Script : TransformEventLevelScript {

	// Use this for initialization
	new void Start () {
        base.Start();
	}

    public override void DoEvent() {
        theDialogueManager.SendDialogue("troblob", "wait, uh blobert, uhh please stop continuing");
        theDialogueManager.SendDialogue("blobert", "uhh no?");
        theDialogueManager.SendDialogue("fabby", "não não não");
        theDialogueManager.SendDialogue("troblob", "I'll give you cake ?!?!?");
        theDialogueManager.SendDialogue("fabby", "C4k3?? 1 10v3 Kak3!!!");
        theDialogueManager.SendDialogue("blobert", "Fabby don't listen to him, he is trying to trick you");
        theDialogueManager.SendDialogue("blobert", "There must be something increadibly valuable coming up");
        isEventFinished = true;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
