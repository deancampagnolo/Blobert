﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformEventLevel7Script : TransformEventLevelScript {
    
	// Use this for initialization
	new void Start () {
        base.Start();
	}

    public override void DoEvent() {
        theDialogueManager.SendDialogue("troblob", "Hmm that was quite the display of skill, but you basically have to take damage here!");
        theDialogueManager.SendDialogue("fabby", "seja idiota quieta");
        theDialogueManager.SendDialogue("blobert", "Yeah what she said");
        theDialogueManager.SendDialogue("fabby", "Exactorrily OwO brobert <3");
        isEventFinished = true;

    }

    // Update is called once per frame
    void Update () {
		
	}
}
