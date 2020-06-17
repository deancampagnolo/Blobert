using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformEventLevel2Script : TransformEventLevelScript {

    new void Start() {
        base.Start();
    }

    public override void DoEvent() {
        if (!isEventFinished) {
            theDialogueManager.SendDialogue("troblob", "I order you to return to the facility at ONCE!");
            theDialogueManager.SendDialogue("troblob", "I hope you hit that spike over there >:)");
            theObjectiveManager.SendObjective("Objective: Keep Going Right!");
            StartCoroutine(KeepGoingRightObjective());

        }
    }

    private IEnumerator KeepGoingRightObjective() {
        while (GameMaster.GetPlayer().transform.position.x < GameMaster.GetLevels().transform.Find("Level3").position.x) {
            yield return null;
        }
        theObjectiveManager.ObjectiveCompleted();
        isEventFinished = true;
    }
}
