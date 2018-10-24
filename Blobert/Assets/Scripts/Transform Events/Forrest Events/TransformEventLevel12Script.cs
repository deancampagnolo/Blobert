using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformEventLevel12Script : TransformEventLevelScript {

	// Use this for initialization
	new void Start () {
        base.Start();
	}

    public override void DoEvent() {
        theDialogueManager.SendDialogue("troblob", "HAHAHHA I'm Okay EHHEHEHE");
        theDialogueManager.SendDialogue("troblob", "Just don't scratch my baby <3");
        theDialogueManager.SendDialogue("troblob", "THOSE SIDE SKIRTS ARE NOT FOR STEPPING ALSO");
        theDialogueManager.SendDialogue("troblob", "OH WAIT HAHA");
        theDialogueManager.SendDialogue("troblob", "You can't drive becuase you are missing arms LOL XD");
        theDialogueManager.SendDialogue("blobert", "I WILL BITE THE WHEEL IF I HAVE TO");
        theDialogueManager.SendDialogue("troblob", "Wait please don't :(");
        theDialogueManager.SendDialogue("fabby", "1 kw411 s#w0t gwun!");
        
        //Objective manager drive the car away;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
