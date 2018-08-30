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
    [SerializeField] private Sprite questionMark;
    [SerializeField] private Sprite fabbyFace;

    // Use this for initialization
    private void Awake() {
        sentence = new Queue<string[]>();
        theText = this.transform.Find("Text").GetComponent<Text>();
        theImage = this.transform.Find("Face").GetComponent<Image>();
    }

    void Start () { 
        
       
        // theImage.sprite;
    }

    public void SendDialogue(string author, string lines) {//this is what other methods would be typing.
        if (sentence == null) {
            print("oh fuck");
        }
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
            ChangeText(sentence.Peek()[1]);
            yield return new WaitForSeconds(2f);//placeholder value possibly wait until audio is done if i choose to do voice acting.
            sentence.Dequeue();
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
            case "unknown":
                theImage.sprite = questionMark;
                break;
            case "fabby":
                theImage.sprite = fabbyFace;
                break;
            default:
                throw new System.Exception("ChangePicture Is called but the author does not exist");
            //case ""
        }
    }

    private void ChangeText(string text) {
        theText.text = text;
    }

    public string[] getSentencePeek() {

        return sentence.Peek();
    }

}
