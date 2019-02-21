using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceTransformEventsLevel1Script : SpaceEvents {



    public override void DoEvent() {
        theDialogueManager.SendDialogue("blobert", "You didn't think I would let you get away with this did you?!?!?!?");
        theDialogueManager.SendDialogue("troblob", "Oh what theeeee, how did you follow me?");
        theDialogueManager.SendDialogue("fabby", "Maybe you shouldn't leave your keys in your other rocketship?? Estúpido");
    }


    // Use this for initialization
    void Start () {
        base.Start();
	}

    

	
	// Update is called once per frame
	void Update () {
		
	}
}
