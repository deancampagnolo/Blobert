using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour{

    private Queue<string[]> sentence;
    bool sendDialogueToScreenIsRunning = false;
    private Text theText;//the Text class can only be obtained here by importing UnityEngine.UI
    private Image theImage;
    [SerializeField] private Sprite blobertFace;
    [SerializeField] private Sprite troblobFace;
	// Use this for initialization
	void Start () {
	    sentence = new Queue<string[]>();
        theText = GameMaster.getCanvas().transform.Find("DialogueBox").Find("Text").GetComponent<Text>();
        theImage = GameMaster.getCanvas().transform.Find("DialogueBox").Find("Face").GetComponent<Image>();
       
        // theImage.sprite;
    }

    public void SendDialogue(string author, string lines) {//this is what other methods would be typing.
        sentence.Enqueue(new string[] { author, lines });
        if(sendDialogueToScreenIsRunning == false) {
            StartCoroutine(SendDialogueToScreen());
        }
        
    }

    private void FixedUpdate() {
        if(sentence.Count!= 0) {
            //SendDialogueToScreen()
        }
    }

    private IEnumerator SendDialogueToScreen() {
        while (sentence.Count != 0) { 
            sendDialogueToScreenIsRunning = true;
            ChangePicture(sentence.Peek()[0]);
            ChangeText(sentence.Dequeue()[1]);
            yield return new WaitForSeconds(2f);//placeholder value possibly wait until audio is done if i choose to do voice acting.
        }
        sendDialogueToScreenIsRunning = false;
    }

    private void ChangePicture(string author) {
        switch (author) {
            case "blobert":
                theImage.sprite = blobertFace;
                break;
            case "troblob":
                theImage.sprite = troblobFace;
                break;
            default:
                throw new System.Exception("ChangePicture Is called but the author does not exist");
            //case ""
        }
    }

    private void ChangeText(string text) {
        theText.text = text;
    }

}
