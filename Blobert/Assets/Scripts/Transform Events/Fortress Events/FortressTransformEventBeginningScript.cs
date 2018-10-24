using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FortressTransformEventBeginningScript : TransformEventLevelScript {

    new void Start() {
        base.Start();
    }

    public override void DoEvent() {
        theDialogueManager.SendDialogue("troblob", "Hey uhhhh Blobert...");
        theDialogueManager.SendDialogue("blobert", "What turd?");
        theDialogueManager.SendDialogue("troblob", "Umm im sorry for everything i've done so far :/");
        theDialogueManager.SendDialogue("troblob", "So uhhhhhh, you can stop chasing me lol");
        theDialogueManager.SendDialogue("fabby", "¡¡¡¡¡¡I aM gOiNg To EaT YoU!!!!!");
    }

}
