using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformEventBeginningScript : TransformEventLevelScript {
    [SerializeField] private string[] dialogue;
	// Use this for initialization
	new void Start () {//honestly confused why there needs to be new keyword here.
        base.Start();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void DoEvent() {
    
        base.theDialogueManager.SendDialogue("troblob", "Hello blobert");
    }
}
