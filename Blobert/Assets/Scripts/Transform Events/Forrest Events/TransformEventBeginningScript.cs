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


        if (!isEventFinished) {
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

        yield return new WaitForSeconds(2f);

        theDialogueManager.SendDialogue("troblob", "Oh wow nice job Blobert");
        theDialogueManager.SendDialogue("troblob", "*Pfft I can walk back and forth its not that cool");
        theDialogueManager.SendDialogue("troblob", "Alright, why don't you try biting that sheep over there");
        
        StartCoroutine(StartObjectiveBiteSheep());

    }

    private IEnumerator StartObjectiveBiteSheep() {

        while (!theDialogueManager.getSentencePeek()[1].Equals("Alright, why don't you try biting that sheep over there")){
            yield return null;
        }
        theObjectiveManager.SendObjective("Objective: Bite the sheep using the " + GameMaster.GetPlayer().GetComponent<MainCController>().getBiteKey() + " key");
        FriendlyAnimalScript theSheep = this.transform.parent.Find("Sheep").GetComponent<FriendlyAnimalScript>();

        while (theSheep.IsAlive()) {
            yield return null;
        }
        theObjectiveManager.ObjectiveCompleted();

        theDialogueManager.SendDialogue("troblob", "ERMIGERD!!!!! U killed Sheepy :'( ");
        theDialogueManager.SendDialogue("troblob", "*wow thats pretty f'd up, I only told him to bite it...");
        theDialogueManager.SendDialogue("troblob", "*troblob 86's bite is very strong, one shots sheep");
        theDialogueManager.SendDialogue("troblob", "*wait maybe he's going to be the one to shoot it");
        theDialogueManager.SendDialogue("blobert", "Hey nerd are you going to tell me what to do next");
        theDialogueManager.SendDialogue("troblob", "ahhhh!, uhh ye ye...");
        theDialogueManager.SendDialogue("troblob", "yea yea.. ahem, yes");
        theDialogueManager.SendDialogue("troblob", "*noted that blobert is a complete ding dong door pusher");
        theDialogueManager.SendDialogue("troblob", "Alright all you have left to do is to shoot your leg cannon... its really easy");
        theDialogueManager.SendDialogue("troblob", "*I really hope that new thing that we installed into blobert 86 works");
        theDialogueManager.SendDialogue("troblob", "*And lets him shoot the bang bang pow pow thing");
        theDialogueManager.SendDialogue("troblob", "Oh and I almost forgot, due to the installation of your momentum converter when you change direction it will conserve your momentum that you had and move you in the other direction with the same force"); //This probably needs to be changed
        theDialogueManager.SendDialogue("troblob", "Alright Begin!");

        StartCoroutine(StartObjectiveShootLegCannon());

    }

    private IEnumerator StartObjectiveShootLegCannon() {
        while (!theDialogueManager.getSentencePeek()[1].Equals("Alright Begin!")) {//while it isn't
            yield return null;
        }

        theObjectiveManager.SendObjective("Objective: Shoot your Leg Cannon using the " + GameMaster.GetPlayer().GetComponent<MainCController>().getLegBlastKey() + " key");
        while (!GameMaster.GetPlayer().GetComponent<MainCController>().isLegBlastPressed()) {//I am not sure if this is the correct way to do this as it is only looking for if the key to use it is pressed, not if it actually went through
            yield return null;
        }
        theObjectiveManager.ObjectiveCompleted();
        yield return new WaitForSeconds(2f);
        theDialogueManager.SendDialogue("troblob", "...");
        theDialogueManager.SendDialogue("troblob", "..");
        theDialogueManager.SendDialogue("troblob", ".");
        theDialogueManager.SendDialogue("troblob", "UwU Hwowy Cwap dat whas so kuu!");
        theDialogueManager.SendDialogue("troblob", "Oh my God, Oh my God, Omg, oMg, omG");
        theDialogueManager.SendDialogue("troblob", "*Blobert 86 was a huge success! I can't wait to tell my boss");
        theDialogueManager.SendDialogue("troblob", "*I finally won't be the failure all the other scientists say I am");
        theDialogueManager.SendDialogue("troblob", "*maybe my nickname of superdumbcrazystupidfailure will change to legcannonjesus!");
        theDialogueManager.SendDialogue("troblob", "*I'm so excited!!!");
        theDialogueManager.SendDialogue("troblob", "Alright blobert u still there?");
        theDialogueManager.SendDialogue("troblob", "Now its time to return so I can power you down...");
        theDialogueManager.SendDialogue("troblob", "I mean.. uh... power you downtown to get a drink with me");
        theDialogueManager.SendDialogue("troblob", "heh");
        theDialogueManager.SendDialogue("troblob", "just return to the start");
        theDialogueManager.SendDialogue("blobert", "Oh don't worry troblob I'll always obey your every command");
        theDialogueManager.SendDialogue("troblob", "Yes!");
        theDialogueManager.SendDialogue("troblob", "*phew! I dodged a bullet there");
        theDialogueManager.SendDialogue("blobert", "*alright how do I escape this sorry excuse for a forest");
        theDialogueManager.SendDialogue("blobert", "*i ain't getting powered down by some loser like troblob");
        theDialogueManager.SendDialogue("blobert", "I'm comming :)");
        theDialogueManager.SendDialogue("troblob", "Alright i'm waiting for my lil munchkin :D");
        theDialogueManager.SendDialogue("blobert", "k");
        while (!theDialogueManager.getSentencePeek()[1].Equals("k")) {
            yield return null;
        }
        theObjectiveManager.SendObjective("Objective: Escape the forest by continuing to go to the right, regardless of what Troblob says");
        theDialogueManager.SendDialogue("blobert", "*time to get out of this trob-hole forrest");
        while (GameMaster.GetPlayer().transform.position.x < GameMaster.GetLevels().transform.Find("Level1").position.x) {
            yield return null;
        }

        theObjectiveManager.ObjectiveCompleted();
        isEventFinished = true;
    }
}
