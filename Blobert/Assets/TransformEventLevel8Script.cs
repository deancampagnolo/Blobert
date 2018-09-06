using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformEventLevel8Script : TransformEventLevelScript {

	// Use this for initialization
	new void Start () {
        base.Start();	
	}

    public override void DoEvent() {
        theDialogueManager.SendDialogue("troblob", "I thought this was a bit harder than you make it seem :/");
        theDialogueManager.SendDialogue("troblob", "*ERMIIGERRD HES GETTING TOO CLOSE TO MY BABY");
        isEventFinished = true;
    }



    // Update is called once per frame
    void Update () {
		
	}
}
