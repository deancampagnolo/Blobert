using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceTransformEventsLevel1Script : SpaceEvents {



    public override void DoEvent() {
        theDialogueManager = GameMaster.getCanvas().transform.Find("DialogueBox").GetComponent<DialogueManager>();
        theObjectiveManager = theDialogueManager.transform.parent.Find("ObjectiveBox").GetComponent<ObjectiveManager>(); //FIXME this is something wrong with the inheritance that forces me to put this code down, if you want to improve blobert, change this.


        theDialogueManager.SendDialogue("blobert", "You didn't think I would let you get away with this did you?!?!?!?");
        theDialogueManager.SendDialogue("troblob", "Oh what theeeee, how did you follow me?");
        theDialogueManager.SendDialogue("fabby", "Maybe you shouldn't leave your keys in your other rocketship?? Estúpido");
        theDialogueManager.SendDialogue("troblob", "Try Keeping up with me now!");
        theDialogueManager.SendDialogue("troblob", "WTF How are you still here???");
        theDialogueManager.SendDialogue("blobert", "*Wait fabby how are we still going his speed*");
        theDialogueManager.SendDialogue("fabby", "I dunno :DDD");
        theDialogueManager.SendDialogue("troblob", "Try keeping up with me Now!");
        theDialogueManager.SendDialogue("troblob", "WHATTTT???");
        theDialogueManager.SendDialogue("troblob", "This makes no logistical sense!!");
        theDialogueManager.SendDialogue("fabby", "Brob3rt hao fhast r whe goin?");
        theDialogueManager.SendDialogue("fabby", "I'ma bharf!");
        theDialogueManager.SendDialogue("blobert", "Fabby I actually don't know what is happening...");
        theDialogueManager.SendDialogue("troblob", "AGHHHHHHH");
        theDialogueManager.SendDialogue("troblob", "Faster!!!");
        theDialogueManager.SendDialogue("troblob", "WTF what are these weird objects!");

        print(isEventFinished);
        StartCoroutine(FirstTime());
    }

    private IEnumerator FirstTime() {
        while (!theDialogueManager.getSentencePeek()[1].Equals("WTF How are you still here???")) {
            yield return null;
        }
        isEventFinished = true;
        sgm.AddToScrollingSpeedY(10);
        StartCoroutine(SecondTime());

    }

    private IEnumerator SecondTime() {
        while (!theDialogueManager.getSentencePeek()[1].Equals("WHATTTT???")) {
            yield return null;
        }
        isEventFinished = true;
        sgm.AddToScrollingSpeedY(20);
        StartCoroutine(ThirdTime());

    }

    private IEnumerator ThirdTime() {
        while (!theDialogueManager.getSentencePeek()[1].Equals("WTF what are these weird objects!")) {
            yield return null;
        }
        isEventFinished = true;
        sgm.AddToScrollingSpeedY(40);

    }


    // Use this for initialization
    void Start () {//FIXME the weird inheritance error may have something to do with this function hiding the one higher in the hierarchy
        base.Start();
	}

}
