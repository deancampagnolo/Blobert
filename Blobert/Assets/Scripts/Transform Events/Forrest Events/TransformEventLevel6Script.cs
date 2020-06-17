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
        theDialogueManager.SendDialogue("fabby", "Try utilizing ur momentum converter owo");
        theDialogueManager.SendDialogue("blobert", "Whats this ?");
        theDialogueManager.SendDialogue("fabby", " oooooophohhOOoh, 13t m3 s33!!!!");
        theDialogueManager.SendDialogue("blobert", "Hold on…");
        theDialogueManager.SendDialogue("fabby", "AHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHhh");
        theDialogueManager.SendDialogue("blobert", "Fabby! ? !!");
        theDialogueManager.SendDialogue("fabby", " Oooooh!!, Wowza, my h3ads A SPINNIN");
        theDialogueManager.SendDialogue("blobert", "Fabby, what was that?");
        theDialogueManager.SendDialogue("fabby", "1 ThINK DATS My M3MORIES!!!!");
        theDialogueManager.SendDialogue("blobert", "????");
        theDialogueManager.SendDialogue("fabby", "1 Didn’t say but I’m Troblobs prisoner too, he wiped my memory and experimented on m3! I escaped and ran into the forest and then found u!!!");
        theDialogueManager.SendDialogue("blobert", "Fabby….");
        theDialogueManager.SendDialogue("fabby", "1tz alright!!!I d0nt feel much pain anymore…. Lets g3t the rest of my m3mroies:)");
        theDialogueManager.SendDialogue("blobert", "Lets….");


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
