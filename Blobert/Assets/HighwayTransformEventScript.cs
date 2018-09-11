using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighwayTransformEventScript : MonoBehaviour {

    private DialogueManager theDialogueManager;
    private GameObject theCamera;
    [SerializeField] private GameObject car;
    [SerializeField] private float speed;
    GameObject theCarSpawnPoint;
    GameObject theCar;

    void Start() {
        GameObject canvas = GameObject.Find("Canvas");
        theCamera = GameObject.Find("Main Camera");
        theCarSpawnPoint = GameObject.Find("Car Spawn Point");

        theCamera.GetComponent<camera>().FreezeCamera();

        theDialogueManager = canvas.transform.Find("DialogueBox").GetComponent<DialogueManager>();
        if (theDialogueManager == null) {
            throw new System.Exception("DialogueBox Never Found");

        }


        theCar = Instantiate(car, theCarSpawnPoint.transform.position, theCarSpawnPoint.transform.rotation);
        

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

    private void FixedUpdate() {
        theCar.GetComponent<Rigidbody2D>().velocity = new Vector2(speed, theCar.GetComponent<Rigidbody2D>().velocity.y);
    }

    private IEnumerator CameraFollowCar() {
        while (true) {
            if(theCar.transform.position.x > this.transform.position.x) {
                theCamera.GetComponent<camera>().UnFreezeCamera();
                theCamera.GetComponent<camera>().Follow(theCar);
                break;
            }
            yield return null;
        }
    }


}
