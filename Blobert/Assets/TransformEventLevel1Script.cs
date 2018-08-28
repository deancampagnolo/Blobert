using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformEventLevel1Script : TransformEventLevelScript {

  

    new void Start() {//honestly confused why there needs to be new keyword here.
        base.Start();
    }

    public override void DoEvent() {

        if (!isEventFinished) {
            theDialogueManager.SendDialogue("troblob", "YO DABBA DABBA BLOBERT");
            theDialogueManager.SendDialogue("troblob", "WHERE DO YOU THINK YOU ARE GOING?");
            theObjectiveManager.SendObjective("Objective: Continue going right");
            StartCoroutine(ContinueGoingRightObjective());
        }

    }

    private IEnumerator ContinueGoingRightObjective() {
        while (GameMaster.GetPlayer().transform.position.x < GameMaster.GetLevels().transform.Find("Level2").position.x) {
            yield return null;
        }
        theObjectiveManager.ObjectiveCompleted();
    }
}