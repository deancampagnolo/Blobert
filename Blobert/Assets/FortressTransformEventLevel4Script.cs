using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FortressTransformEventLevel4Script : TransformEventLevelScript {

    // Use this for initialization
    void Start() {
        base.Start();
    }

    // Update is called once per frame
    void Update() {

    }

    public override void DoEvent() {
        theDialogueManager.SendDialogue("troblob", "Wow you have made it to level4");
        theDialogueManager.SendDialogue("blobert", ": ARGGHHHHH, you bastard….");
        theDialogueManager.SendDialogue("fabby", "yare yare daze..");
        theDialogueManager.SendDialogue("troblob", ": Gotta Blast");
        theDialogueManager.SendDialogue("blobert", ": Let's get this party started");
        theDialogueManager.SendDialogue("fabby", "W00f! W00f!");


    }
}
