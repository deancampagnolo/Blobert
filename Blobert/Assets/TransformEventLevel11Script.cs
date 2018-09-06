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
        theDialogueManager.SendDialogue("troblob", "HAHHA if you dare tresspass there is a huge spike pit leading to my house...");
        theDialogueManager.SendDialogue("troblob", "Oh crap.");
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
