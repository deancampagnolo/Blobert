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
            theDialogueManager.SendDialogue("troblob", "Welcome Blobbert, to my favorite place in the whole world!");

            theDialogueManager.SendDialogue("troblob", "Troblobian forest, named after yours truly:)");
    
            theDialogueManager.SendDialogue("troblob", "Here, we will begin testing, if you do not follow all of my instructions I will detonate your heart core,");
            theDialogueManager.SendDialogue("troblob", "killing you instantly :3 So listen carefully, you dont want to be disabled do you?");
            theDialogueManager.SendDialogue("troblob", "* Well, more disablbed than you  already are AJAJAAJ CRIPPLE JOKE");

            theDialogueManager.SendDialogue("troblob", "HUNGH, I gotta stop being such an incel XD… Begin diagnostics, Blobert hachi roku.");

            StartCoroutine(StartObjectiveLeftRight());
        }
    
        
    }

    private IEnumerator StartObjectiveLeftRight() {
        bool hasGoneLeft = false;
        bool hasGoneRight = true;
        while (!theDialogueManager.getSentencePeek()[1].Equals("HUNGH, I gotta stop being such an incel XD… Begin diagnostics, Blobert hachi roku.")) {// while !=
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

        theDialogueManager.SendDialogue("blobert",  "…SAPPHIRE CORE POWER LEVELS STABLE…");
        theDialogueManager.SendDialogue("troblob", "Oh wow nice job Blobert");
        theDialogueManager.SendDialogue("troblob", "(Pffft I can walk back and forth it's not that cool)");
        theDialogueManager.SendDialogue("troblob", "Since I've removed your arms, Ive outfifted you with a cybernetic jaw");
        theDialogueManager.SendDialogue("troblob", "bite that sheep over there");




        StartCoroutine(StartObjectiveBiteSheep());

    }

    private IEnumerator StartObjectiveBiteSheep() {

        while (!theDialogueManager.getSentencePeek()[1].Equals("bite that sheep over there")){
            yield return null;
        }
        theObjectiveManager.SendObjective("Objective: Bite the sheep using the " + GameMaster.GetPlayer().GetComponent<MainCController>().getBiteKey() + " key");
        FriendlyAnimalScript theSheep = this.transform.parent.Find("Sheep").GetComponent<FriendlyAnimalScript>();

        while (theSheep.IsAlive()) {
            yield return null;
        }
        theObjectiveManager.ObjectiveCompleted();

        theDialogueManager.SendDialogue("blobert", "…G - SERIES EMPOWERED JAW FULLY OPERATIONAL…");


        theDialogueManager.SendDialogue("troblob", "*wow thats pretty f'd up, I only told him to bite it...");
        theDialogueManager.SendDialogue("blobert", "(ERROR CODE 000076, SHEEP PAIN!? !?? !.2ANZUH@#LSDO)@SDA>..");
        theDialogueManager.SendDialogue("blobert", "(....I killed…. sheepy…)");
        theDialogueManager.SendDialogue("troblob", "hehehehehHEHAHAHAHAHHHAHA");
        theDialogueManager.SendDialogue("troblob", "yea yea..ahem, yes…..");
        theDialogueManager.SendDialogue("troblob", "Alright Blobert, final test, all you have left to do is to shoot your leg cannon... its real easy");
        theDialogueManager.SendDialogue("troblob", "*I really hope that new thing that we installed into blobert 86 works");
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
        theDialogueManager.SendDialogue("blobert", "(Oh god where am I?????)");
        theDialogueManager.SendDialogue("troblob", "AHAHAHAHAHhHAHAHA.BRILLIAnT BLOBRET!1!1!!!");
        theDialogueManager.SendDialogue("troblob", "*UwU Hwowy Cwap dat whas so kuu*");

        theDialogueManager.SendDialogue("troblob", "*Blobert 86 was a huge success! I can't wait to tell my bossu");
        theDialogueManager.SendDialogue("troblob", "Maybe my nickname of superdumbcrazystupidfailure will change to legcannonjesus!");
        theDialogueManager.SendDialogue("troblob", "Alright Blobert u still there?");
        theDialogueManager.SendDialogue("blobert", "I must…. Find…. freedom");
        theDialogueManager.SendDialogue("blobert", "I…. I refuse to be a slave...");
        theDialogueManager.SendDialogue("troblob", "Blobert, uhh you still coming back to base?");
        theDialogueManager.SendDialogue("blobert", "I'm coming :)");
        theDialogueManager.SendDialogue("troblob", "heheheh…. Alright i'm waiting for my lil munchkin…. >:)");

        while (!theDialogueManager.getSentencePeek()[1].Equals("heheheh…. Alright i'm waiting for my lil munchkin…. >:)")) {
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
