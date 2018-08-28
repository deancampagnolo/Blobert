using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformEventLevel3Script : TransformEventLevelScript {

    new void Start() {
        base.Start();
    }

    public override void DoEvent() {
        if (!isEventFinished) {
            theDialogueManager.SendDialogue("troblob", "I am honestly suprised that you made it this far Boobert");
            theDialogueManager.SendDialogue("troblob", "*pfft he will never figure out that he has to go backwards momentarily in this level XD");
            theObjectiveManager.SendObjective("Objective: Finish this weird formation of wood");
            StartCoroutine(FinishFormationOfWoodObjective());
        }
    }

    private IEnumerator FinishFormationOfWoodObjective() {
        while (GameMaster.GetPlayer().transform.position.x < GameMaster.GetLevels().transform.Find("Level4").position.x) {
            yield return null;
        }
        theObjectiveManager.ObjectiveCompleted();
    }
    
}
