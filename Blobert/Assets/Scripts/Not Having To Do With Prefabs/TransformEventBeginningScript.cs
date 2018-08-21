using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class TransformEventBeginningScript : TransformEventLevelScript {
	// Use this for initialization
	new void Start () {//honestly confused why there needs to be new keyword here.
        base.Start();
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
        while (!theDialogueManager.getSentencePeek()[1].Equals("Aite")) {// while !=
            yield return null;
        }
        theObjectiveManager.SendObjective("Objective: Walk Left and Right");
    }


}
