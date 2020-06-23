using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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


        theCar = Instantiate(car, theCarSpawnPoint.transform.position, theCarSpawnPoint.transform.rotation);
        
        StartCoroutine(CameraFollowCar());

        theDialogueManager.SendDialogue("blobert", "Alright Fabby so you said that the Troblob's castle is this way right?");
        theDialogueManager.SendDialogue("fabby", "Daz rhyte B00bie XDDDD");
        theDialogueManager.SendDialogue("blobert", "What were all your memories about back there?");
        theDialogueManager.SendDialogue("troblob", "KONBANWA PEEPZ");
        theDialogueManager.SendDialogue("fabby", "Foda-se retardado, você tem células cerebrais negativas!");
        theDialogueManager.SendDialogue("blobert", "Wait a sec, troblob. How are you talking to us right now?");
        theDialogueManager.SendDialogue("troblob", "Watashi wa Suprised?? desu!");
        theDialogueManager.SendDialogue("blobert", "Oh wait you are speaking through the radio aren't you");
        theDialogueManager.SendDialogue("troblob", "Nani Baka yo! Don't do anything stupid... or else...");
        theDialogueManager.SendDialogue("blobert", "Fabby just turn off the radio we got to focus...");
        theDialogueManager.SendDialogue("blobert", "We hare so close to freedom fabby... please...");
        theDialogueManager.SendDialogue("fabby", "Oak kay D0k4y Mista!");
        theDialogueManager.SendDialogue("troblob", "NOOOOOOO DON't TURN ME O--");
        theDialogueManager.SendDialogue("blobert", "Thank god hes gone. Do you know anything about his castle?");
        theDialogueManager.SendDialogue("fabby", "Aww eye kn0w iz d4t lot of home, b00by traps (he he), and a SPACE PORT :)))");
        theDialogueManager.SendDialogue("blobert", "Yeah thats pretty odd...");
        theDialogueManager.SendDialogue("fabby", "...");
        theDialogueManager.SendDialogue("blobert", "...");
        theDialogueManager.SendDialogue("blobert", "well...");
        theDialogueManager.SendDialogue("blobert", "I'm feeling a bit awkward now");
        theDialogueManager.SendDialogue("fabby", "yare yare daze");


        StartCoroutine(WaitForDialogueToEnd());

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

    private IEnumerator WaitForDialogueToEnd() {
        while (!theDialogueManager.getSentencePeek()[1].Equals("yare yare daze")){
            yield return null;
        }
        theCamera.GetComponent<camera>().FreezeCamera();

        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);//not sure if this should be LoadSceneAsync


    }


}
