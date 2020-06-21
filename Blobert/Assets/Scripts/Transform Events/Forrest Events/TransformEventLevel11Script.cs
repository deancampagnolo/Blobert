using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformEventLevel11Script : TransformEventLevelScript {

	// Use this for initialization
	new void Start () {
        base.Start();
	}

    public override void DoEvent() {
        theDialogueManager.SendDialogue("blobert", "Is this a village");
        theDialogueManager.SendDialogue("fabby", "Vais queimar tudo e nunca olhar para trás!");
        
        theDialogueManager.SendDialogue("troblob", "Yes this is Village De Troblobian");
        theDialogueManager.SendDialogue("fabby", "OOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOH YEAHHHHHHHHHHHHHHHHHHHHh");

		theDialogueManager.SendDialogue("fabby", "I, I remember...");
        theDialogueManager.SendDialogue("fabby", "Yes, I do…..I see…. Bright lights…. Clouds…. Hundreds of people…..Gunshots! ?? !Then darkness…… ");
		theDialogueManager.SendDialogue("blobert", ".....");
		theDialogueManager.SendDialogue("fabby", "Ooooh D0nt W0rry bout me Blueboort!");
		theDialogueManager.SendDialogue("fabby", "I cant believe what this monster did to us….");
		theDialogueManager.SendDialogue("fabby", "We’ll find him and show him who's the real monster….");

		StartCoroutine(FindTroblobsHouseComplete());
    }

    // Update is called once per frame
    void Update () {
		
	}
    private IEnumerator FindTroblobsHouseComplete() {
        theObjectiveManager.SendObjective("Objective: Find Troblob's House");
        while (GameMaster.GetPlayer().transform.position.x < GameMaster.GetLevels().transform.Find("Level12").position.x) {
            yield return null;
        }
        theObjectiveManager.ObjectiveCompleted();
        isEventFinished = true;
    }
}
