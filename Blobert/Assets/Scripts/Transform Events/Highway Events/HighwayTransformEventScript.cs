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
        theDialogueManager.SendDialogue("blobert", "Alright Fabby so you said that the Troblob's castle is this way right?");
        theDialogueManager.SendDialogue("blobert", "Alright Fabby so you said that the Troblob's castle is this way right?");
        theDialogueManager.SendDialogue("blobert", "Alright Fabby so you said that the Troblob's castle is this way right?");
        theDialogueManager.SendDialogue("blobert", "Alright Fabby so you said that the Troblob's castle is this way right?");
        theDialogueManager.SendDialogue("blobert", "Alright Fabby so you said that the Troblob's castle is this way right?");
        theDialogueManager.SendDialogue("blobert", "Alright Fabby so you said that the Troblob's castle is this way right?");
        theDialogueManager.SendDialogue("blobert", "Alright Fabby so you said that the Troblob's castle is this way right?");
        theDialogueManager.SendDialogue("blobert", "Alright Fabby so you said that the Troblob's castle is this way right?");
        theDialogueManager.SendDialogue("blobert", "Alright Fabby so you said that the Troblob's castle is this way right?");
        theDialogueManager.SendDialogue("blobert", "Alright Fabby so you said that the Troblob's castle is this way right?");
        theDialogueManager.SendDialogue("blobert", "Alright Fabby so you said that the Troblob's castle is this way right?");
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
