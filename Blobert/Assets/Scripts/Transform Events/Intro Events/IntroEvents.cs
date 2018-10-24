using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroEvents : MonoBehaviour {
    [SerializeField]
    private GameObject spotlightTroblob;
    private DialogueManager theDialogueManager;
    private GameObject boy;
    private GameObject girl;
    private GameObject other;
    private string gender;
    
	// Use this for initialization
	void Start () {
        GameObject canvas = GameObject.Find("Canvas");

        theDialogueManager = canvas.transform.Find("DialogueBox").GetComponent<DialogueManager>();
        if (theDialogueManager == null) {
            throw new System.Exception("DialogueBox Never Found");

        }

        boy = canvas.transform.Find("Boy").gameObject;
        girl = canvas.transform.Find("Girl").gameObject;
        other = canvas.transform.Find("Other").gameObject;
        gender = "";

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
        StartCoroutine(RevealTroblob());

	}
	
	private IEnumerator RevealTroblob() {
        print("hi");
        while(theDialogueManager.getSentencePeek()[1] != "Hello Blobert hachi roku") {
            print("ok");
            yield return null;
        }
        spotlightTroblob.SetActive(true);
        StartCoroutine(BoyOrGirl());
        
    }

    private IEnumerator BoyOrGirl() {
        theDialogueManager.SendDialogue("troblob", "Are you a boy or a girl?");
        while(theDialogueManager.getSentencePeek()[1] != "Are you a boy or a girl?") {
            yield return null;
        }
        boy.SetActive(true);
        girl.SetActive(true);
        other.SetActive(true);
        while (gender.Equals("")) {
            yield return null;
        }
        boy.SetActive(false);
        girl.SetActive(false);
        other.SetActive(false);
        theDialogueManager.SendDialogue("blobert", "I'm " + gender + ".");
        if(gender == "Other") {
            theDialogueManager.SendDialogue("troblob", "*Oh crap is this Blobert self aware... does it know its a robot? I'll be more cautious");
            theDialogueManager.SendDialogue("troblob", "HAHA I get it LMAOOO thats funny because it isn't an actual answer");
            theDialogueManager.SendDialogue("troblob", "LOOOOL that the comedic effect XDDDDD rarzmooxd!");
        } else {
            theDialogueManager.SendDialogue("troblob", "*This blobert thinks it is a " + gender + "! Another stupid robot ugh...");
        }
        theDialogueManager.SendDialogue("troblob", "Anyways, \"" + gender + "\" blobert I'm going to put you through a series of tests ");
        theDialogueManager.SendDialogue("troblob", "You HAVE to follow ALL of my directions, or I'm going to be mad and probably disable you");
        theDialogueManager.SendDialogue("troblob", "*More than you are disabled already without your hands hehe XD");
        theDialogueManager.SendDialogue("troblob", "Alright we are going to turn you off and put you into your first test, don't blow up like the last few!");
        theDialogueManager.SendDialogue("troblob", "I'll see you in the forest!");
        StartCoroutine(ToLevelOne());

        
    }

    private IEnumerator ToLevelOne() {
        while(theDialogueManager.getSentencePeek()[1] != "I'll see you in the forest!") {
            yield return null;
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //FIXME this needs to be changed in the future to be more direct in what you are playing.


    }

    public void BoySelected() {
        gender = "Boy";
    }

    public void GirlSelected() {
        gender = "Girl";
    }

    public void OtherSelected() {
        gender = "Other";
    }
}
