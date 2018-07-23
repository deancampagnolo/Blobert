using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour{

    private Queue<string[]> sentence;
	// Use this for initialization
	void Start () {
	    sentence = new Queue<string[]>();	
	}

    public void SendDialogue(string author, string lines) {
        sentence.Enqueue(new string[] { author, lines });
    }

    private void FixedUpdate() {
        if(sentence.Count!= 0) {
            //SendDialogueToScreen()
        }
    }

    private void SendDialogueToScreen() {

    }

}
