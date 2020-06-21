using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformEventLevel9Script : TransformEventLevelScript {

	// Use this for initialization
	new void Start () {
        base.Start();
	}

    public override void DoEvent() {
        theDialogueManager.SendDialogue("troblob", "Well I hope you like Mushrooms and Trees XD LOL");
        theDialogueManager.SendDialogue("troblob", "YOU WILL UNDER STAND WHY THIS JOKE IS SO FUNNY SOON XDDDDDDDDDD");
        theDialogueManager.SendDialogue("blobert", "You are so fucking annoying");
        theDialogueManager.SendDialogue("troblob", ">:( *At least im not some stupid robot");
        theDialogueManager.SendDialogue("fabby", "I Rove MUSHr00m :D");
        StartCoroutine(WeirdMushroomTreeThingComplete());
    }

    // Update is called once per frame
    void Update () {
		
	}

    private IEnumerator WeirdMushroomTreeThingComplete() {
        theObjectiveManager.SendObjective("Objective: Complete Weird Mushroom Tree Thing");
        while (GameMaster.GetPlayer().transform.position.x < GameMaster.GetLevels().transform.Find("Level10").position.x) {
            yield return null;
        }
        theObjectiveManager.ObjectiveCompleted();
        isEventFinished = true;
    }
}
