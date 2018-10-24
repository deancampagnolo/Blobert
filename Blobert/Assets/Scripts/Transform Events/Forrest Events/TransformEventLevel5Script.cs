using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformEventLevel5Script : TransformEventLevelScript {

    public override void DoEvent() {
        theDialogueManager.SendDialogue("troblob", "Umm whats that fly thing following you");
        theDialogueManager.SendDialogue("troblob", "Anyways please stop going forward :)");
        theDialogueManager.SendDialogue("fabby", "Keep going Blobert!");
    }

    // Use this for initialization
    new void Start () {
        base.Start();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
