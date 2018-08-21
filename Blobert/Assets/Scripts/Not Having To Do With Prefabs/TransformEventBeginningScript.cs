using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class TransformEventBeginningScript : TransformEventLevelScript {
    // Use this for initialization
    private bool objectiveLeftRightComplete;

    new void Start () {//honestly confused why there needs to be new keyword here.
        base.Start();
        objectiveLeftRightComplete = false;
	}
	

    public override void DoEvent() {
    
        theDialogueManager.SendDialogue("troblob", "Hello Blobert");
        theDialogueManager.SendDialogue("troblob", "Welcome to my favorite place in the whole world");
        theDialogueManager.SendDialogue("troblob", "Troblobian forest, named after yours truely");
        theDialogueManager.SendDialogue("troblob", "I often take long walks and take joy rides though the forest in my cool 80's car");
        theDialogueManager.SendDialogue("troblob", "And then I hide behind trees to ja...");
        theDialogueManager.SendDialogue("blobert", "Cut to the chase, its hot");
        theDialogueManager.SendDialogue("troblob", "Oh... *note to self make next blobert not able to talk*");
        theDialogueManager.SendDialogue("troblob", "Why don't we start by moving around a bit to see that everything is working.");
        theDialogueManager.SendDialogue("blobert", "Aite");
        StartCoroutine(StartObjectiveLeftRight());

    
        
    }

    private IEnumerator StartObjectiveLeftRight() {
        bool hasGoneLeft = false;
        bool hasGoneRight = true;
        while (!theDialogueManager.getSentencePeek()[1].Equals("Aite")) {// while !=
            yield return null;
        }
        theObjectiveManager.SendObjective("Objective: Walk Left and Right");


        yield return new WaitForSeconds(2f);
        while (!objectiveLeftRightComplete) {// while not complete
            if (hasGoneLeft == false) {
                print(GameMaster.GetPlayer().GetComponent<MainCController>().isWalkingLeft());
                if (GameMaster.GetPlayer().GetComponent<MainCController>().isWalkingLeft()) {
                    hasGoneLeft = true;
                }
            }
            if (hasGoneRight == false) {
                print(GameMaster.GetPlayer().GetComponent<MainCController>().isWalkingRight());
                if (GameMaster.GetPlayer().GetComponent<MainCController>().isWalkingRight()) {
                    hasGoneRight = true;
                }
            }
            if( hasGoneLeft && hasGoneRight) {
                objectiveLeftRightComplete = true;
            }
            yield return null;
        }
        
        theObjectiveManager.ObjectiveCompleted();

    }
    


}
