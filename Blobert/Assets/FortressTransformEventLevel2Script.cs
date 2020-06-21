using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FortressTransformEventLevel2Script : TransformEventLevelScript {

    // Use this for initialization
    void Start() {
        base.Start();
    }

    // Update is called once per frame
    void Update() {

    }

    public override void DoEvent() {
        theDialogueManager.SendDialogue("unknown", "CLONE 86, SUCH A PROMISING DEVELOPMENT YOU HAVE BECOME");
        theDialogueManager.SendDialogue("blobert", "What was that?");
        theDialogueManager.SendDialogue("fabby", "iudnnno blowjob!!!Bu77 da77 wuzz scary");
        theDialogueManager.SendDialogue("troblob", "You fools…..");
        theDialogueManager.SendDialogue("blobert", "So what do fairies do?");
        theDialogueManager.SendDialogue("fabby", "What do u mean Blabart");
        theDialogueManager.SendDialogue("blobert", "Do you have a fairy family? Do fairies live in some fairy society or do you all roam freely one with nature?");
        theDialogueManager.SendDialogue("fabby", "Quite the complex question Blowbert!!!Fairies are magix, so you cant really see us at all, but yes do we live one with nature, but there is still some societal structure. ");
        theDialogueManager.SendDialogue("blobert", "Hmmm?");
        theDialogueManager.SendDialogue("fabby", "There are king fairies and queen fairies, there's worker fairies, artist fairies, even slave fairies!");
        theDialogueManager.SendDialogue("blobert", "What kind of fairy were you, you know, before troblob enslaved you.");
        theDialogueManager.SendDialogue("fabby", "Hmmmm… I dont really remember…..");


    }
}
