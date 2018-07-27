using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroEvents : MonoBehaviour {
    public GameObject spotlightTroblob;
    private DialogueManager theDialogueManager;
    
	// Use this for initialization
	void Start () {
        theDialogueManager = GameObject.Find("Canvas").transform.Find("DialogueBox").GetComponent<DialogueManager>();
        theDialogueManager.SendDialogue("unknown", "Alrighty what number is this one Gary?");//change name of gary probably
        theDialogueManager.SendDialogue("unknown", "This is Blobert number...");
        theDialogueManager.SendDialogue("unknown", "86");
        theDialogueManager.SendDialogue("unknown", "Where the hell are his arms?");
        theDialogueManager.SendDialogue("unknown", "Well you see, the last one climbed over the tree stump and ran away.");
        theDialogueManager.SendDialogue("unknown", "So if he doesn't have arms, how can he run away???");
        theDialogueManager.SendDialogue("unknown", "....");
        theDialogueManager.SendDialogue("unknown", "...");
        theDialogueManager.SendDialogue("unknown", "Ah screw it, lets see what he does");
        theDialogueManager.SendDialogue("troblob", "Hello Blobert hachi roku");//chain this with an event (the spotlight) TODO probably create something that lets me put something like an animation event but for speech, perhaps using overloaded methods is the way? GLHF
        theDialogueManager.SendDialogue("unknown", ">:(");
        theDialogueManager.SendDialogue("troblob", "I mean 86 haha...");
        theDialogueManager.SendDialogue("troblob", "*gosh I gotta stop being such a weeb");
        theDialogueManager.SendDialogue("troblob", "anyways, lets start OwO"); //TODO change this
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
