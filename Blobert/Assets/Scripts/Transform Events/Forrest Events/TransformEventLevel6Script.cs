using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformEventLevel6Script : TransformEventLevelScript {

	// Use this for initialization
    new void Start () {
        base.Start();
	}

    public override void DoEvent() {

        theDialogueManager.SendDialogue("blobert", "Hmm this looks hard");
        theDialogueManager.SendDialogue("troblob", "HAHAHA try getting past Poison Swampy Meadows XD");
        theDialogueManager.SendDialogue("fabby", "OwO AJAJAJA isso vai ser fácil");
        theDialogueManager.SendDialogue("fabby", "AHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHhh");
        theDialogueManager.SendDialogue("fabby", " Oooooh!!, Wowza, my h3ads A SPINNIN");
        theDialogueManager.SendDialogue("blobert", "Fabby, what the fuck is wrong with you?");
        theDialogueManager.SendDialogue("fabby", "1 ThINK DATS My M3MORIES!!!!");
        theDialogueManager.SendDialogue("blobert", "Fabby….");
        theDialogueManager.SendDialogue("fabby", "1tz alright!!!Lets g3t the rest of my m3mroies:)");


        StartCoroutine(PoisonSwampyMeadowsComplete());
    }

    // Update is called once per frame
    void Update () {
		
	}

    private IEnumerator PoisonSwampyMeadowsComplete() {
        theObjectiveManager.SendObjective("Objective: Complete Poison Swampy Meadows");
        while (GameMaster.GetPlayer().transform.position.x < GameMaster.GetLevels().transform.Find("Level7").position.x) {
            yield return null;
        }
        theObjectiveManager.ObjectiveCompleted();
        isEventFinished = true;
    }
}
