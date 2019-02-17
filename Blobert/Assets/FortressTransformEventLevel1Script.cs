using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FortressTransformEventLevel1Script : TransformEventLevelScript {

	// Use this for initialization
	void Start () {
        base.Start();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void DoEvent() {
        theDialogueManager.SendDialogue("troblob", "Wow you have made it to level1");

    }
}
