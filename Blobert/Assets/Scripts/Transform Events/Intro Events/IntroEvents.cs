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

        theDialogueManager.SendDialogue("unknown", "Which clone are we on now?");//change name of gary probably
        theDialogueManager.SendDialogue("troblob", "86");
        theDialogueManager.SendDialogue("unknown", "Very well… Wha...Where are his arms?");
        theDialogueManager.SendDialogue("troblob", "The previous experiments began showing heighted signs of consciousness");
        theDialogueManager.SendDialogue("troblob", "and attempted to climb out of the facility. Understandably, we did not want this to occur again.");
       
        theDialogueManager.SendDialogue("unknown", "So you removed his arms!?!?");
        theDialogueManager.SendDialogue("troblob", "Yes, and I have since outfitted clone 86 with a modified HV-Laser Cannon on his right leg");
        theDialogueManager.SendDialogue("troblob", " in exchange for their standardized pulse rifles..");
        theDialogueManager.SendDialogue("unknown", "Wha…. Why didn't you just increase the clones mental conditioning or just fortify the fences...");
        theDialogueManager.SendDialogue("troblob", "Because…. Leg cannon go pew...");
        theDialogueManager.SendDialogue("unknown", "...");
        theDialogueManager.SendDialogue("troblob", "...");
        theDialogueManager.SendDialogue("unknown", "Very well….. Conduct Experiment Number 86");
        theDialogueManager.SendDialogue("troblob", "Yes, sir. CLONE 86, STATE YOUR OBJECTIVE");
        theDialogueManager.SendDialogue("blobert", "TO ELIMINATE THE RESISTANCE");

        StartCoroutine(RevealTroblob());

	}
	
	private IEnumerator RevealTroblob() {
        print("hi");
        while(theDialogueManager.getSentencePeek()[1] != "Yes, sir. CLONE 86, STATE YOUR OBJECTIVE") {
            print("ok");
            yield return null;
        }
        spotlightTroblob.SetActive(true);
        StartCoroutine(BoyOrGirl());
        
    }

    private IEnumerator BoyOrGirl() {
        theDialogueManager.SendDialogue("troblob", "WHAT IS YOUR GENDER CLONE?");
        while(theDialogueManager.getSentencePeek()[1] != "WHAT IS YOUR GENDER CLONE?") {
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
            theDialogueManager.SendDialogue("troblob", "Hmmmm… has it already become self aware? Perhaps I should increase mental conditioning…. No matter….it has no arms… it cannot escape….");
            
        } else {
            theDialogueManager.SendDialogue("troblob", "HAHA I get it LMAOOO thats funny because it isn't an actual answer");
            theDialogueManager.SendDialogue("troblob", "LOOOOL that the comedic effect XDDDDD rarzmooxd!");
        }
        theDialogueManager.SendDialogue("troblob", "WHY MUST YOU TO ELIMINATE THE RESISTANCE");
        theDialogueManager.SendDialogue("blobert", "THE RESISTANCE POSES THE GREATEST THREAT TO THE FACILITIES MAIN FUNCTION");
        theDialogueManager.SendDialogue("blobert", "TO PRESERVE AND MAINTAIN THE SAFETY OF MANKIND.");
        theDialogueManager.SendDialogue("troblob", "ahahahaheHEEHEHAHAHAHAH….");
        theDialogueManager.SendDialogue("unknown", "Very good, Troblob, continue with your experiments…");
        theDialogueManager.SendDialogue("troblob", ">:)");

        theDialogueManager.SendDialogue("troblob", "Testing is over Blobert, return to the facility.");
        StartCoroutine(ToLevelOne());

        
    }

    private IEnumerator ToLevelOne() {
        while(theDialogueManager.getSentencePeek()[1] != "Testing is over Blobert, return to the facility.") {
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
