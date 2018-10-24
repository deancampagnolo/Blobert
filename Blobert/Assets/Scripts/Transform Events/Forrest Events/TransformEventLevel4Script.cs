using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformEventLevel4Script : TransformEventLevelScript {

    private Transform evilMoopSpawner;
    new public void Start() {
        base.Start();
        evilMoopSpawner = this.transform.Find("EvilMoopSpawner");
    }

    public override void DoEvent() {
        //Instantiate(GameMaster.GetEvilMoop(), evilMoopSpawner.position, evilMoopSpawner.rotation);
        theDialogueManager.SendDialogue("troblob", "WAIIIIITTTTTTTTTT!");
        theDialogueManager.SendDialogue("troblob", "DOOON't CONTINUE!!!");
        theDialogueManager.SendDialogue("troblob", "IT'S DANGEROUS, ACTUALLY");
        theDialogueManager.SendDialogue("troblob", "YOU ARE ENTERING THE WILD ZONE, WHAT GOES IN THERE");
        theDialogueManager.SendDialogue("troblob", "NEVER COMES OUT!!!!");
        theDialogueManager.SendDialogue("blobert", "Aite see you on the other side!");
        StartCoroutine(OverTheBushObjective());
        

    }

    private IEnumerator OverTheBushObjective() {
        theObjectiveManager.SendObjective("Objective: Cross over the bush to the right");
        while (GameMaster.GetPlayer().transform.position.x < GameMaster.GetLevels().transform.Find("LevelMeetFairy").position.x) {
            yield return null;
        }
        theObjectiveManager.ObjectiveCompleted();
        isEventFinished = true;
    }
}
