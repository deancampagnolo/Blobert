using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformEventLevel8Script : TransformEventLevelScript {

	// Use this for initialization
	new void Start () {
        base.Start();	
	}

    public override void DoEvent() {
        theDialogueManager.SendDialogue("troblob", "URgh…. You're not meant to escape so easily….");
        theDialogueManager.SendDialogue("troblob", "*ERMIIGERRD HES GETTING TOO CLOSE TO MY BABY");

        theDialogueManager.SendDialogue("fabby", "U knowz u can us3 ur cann0n 2 b00st u f4ster");
        theDialogueManager.SendDialogue("blobert", "Oh thanks Fabby");
        theDialogueManager.SendDialogue("fabby", "N0 pr0omblem boobman");
        theDialogueManager.SendDialogue("blobert", "Thats not my name");
        theDialogueManager.SendDialogue("fabby", "What do u mean thats not ur name Boobert?");
        theDialogueManager.SendDialogue("blobert", ": Nevermind...");

        isEventFinished = true;
    }



    // Update is called once per frame
    void Update () {
		
	}
}
