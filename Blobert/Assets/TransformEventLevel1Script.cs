using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformEventLevel1Script : TransformEventLevelScript {


    public override void DoEvent() {
        theDialogueManager.SendDialogue("troblob", "UMM BLOBERT");
        theDialogueManager.SendDialogue("troblob", "WHERE DO YOU THINK YOU ARE GOING?");
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
