using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceTransformEventsLevel1Script : SpaceEvents {

    [SerializeField] private GameObject salad;
    [SerializeField] private float buffer = 0;
    [SerializeField] private GameObject troblobShip;
    [SerializeField] private float lateralSpeedOfTroblobShip = 10f;
    [SerializeField] private float lateralPositionTroblobShipBuffer = 2f;


    public override void DoEvent() {
        theDialogueManager = GameMaster.getCanvas().transform.Find("DialogueBox").GetComponent<DialogueManager>();
        theObjectiveManager = theDialogueManager.transform.parent.Find("ObjectiveBox").GetComponent<ObjectiveManager>(); //FIXME this is something wrong with the inheritance that forces me to put this code down, if you want to improve blobert, change this.


        StartCoroutine(TroblobMovement());

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

    private IEnumerator TroblobMovement() {
        Camera cam = GameMaster.GetCamera().GetComponent<Camera>();

        float xPosLeftBound = cam.transform.position.x + (-1 * cam.aspect * cam.orthographicSize) + lateralPositionTroblobShipBuffer; //aspect times orthographic size give you half width of screen
        float xPosRightBound = cam.transform.position.x + (cam.aspect * cam.orthographicSize) - lateralPositionTroblobShipBuffer; //aspect times orthographic size give you half width of screen
        print(xPosLeftBound);


        while (true) {
            float direction = Random.value;
            if (direction < .5 && troblobShip.transform.position.x >xPosLeftBound) {//will be going left
                troblobShip.GetComponent<Rigidbody2D>().velocity = new Vector2(lateralSpeedOfTroblobShip * -1, troblobShip.GetComponent<Rigidbody2D>().velocity.y);
            } else if(troblobShip.transform.position.x < xPosRightBound) {
                troblobShip.GetComponent<Rigidbody2D>().velocity = new Vector2(lateralSpeedOfTroblobShip, troblobShip.GetComponent<Rigidbody2D>().velocity.y);
            } else {
                troblobShip.GetComponent<Rigidbody2D>().velocity = new Vector2(0, troblobShip.GetComponent<Rigidbody2D>().velocity.y);
            }

            yield return new WaitForSeconds(.25f);
        }
    }

    private IEnumerator FirstTime() {
        while (!theDialogueManager.getSentencePeek()[1].Equals("WTF How are you still here???")) {
            yield return null;
        }
        sgm.AddToScrollingSpeedY(2);
        StartCoroutine(SecondTime());

    }

    private IEnumerator SecondTime() {
        while (!theDialogueManager.getSentencePeek()[1].Equals("WHATTTT???")) {
            yield return null;
        }
        sgm.AddToScrollingSpeedY(4);
        StartCoroutine(ThirdTime());

    }

    private IEnumerator ThirdTime() {
        while (!theDialogueManager.getSentencePeek()[1].Equals("WTF what are these weird objects!")) {
            yield return null;
        }
        sgm.AddToScrollingSpeedY(8);
        StartCoroutine(StartSpawn(salad, "salad"));
        
    }


    // Use this for initialization
    void Start () {//FIXME the weird inheritance error may have something to do with this function hiding the one higher in the hierarchy
        base.Start();
	}

    private IEnumerator StartSpawn(GameObject thing, string tag) {
        float phasesScrollingSpeed = sgm.GetScrollingSpeedY();// so that we get the scrolling speed of space when this method is first called.

        while (true) {
            Camera cam = GameMaster.GetCamera().GetComponent<Camera>();

            float xPos = cam.transform.position.x + Random.Range(-1 * cam.aspect * (cam.orthographicSize-buffer), cam.aspect * (cam.orthographicSize-buffer)); //aspect times orthographic size give you half width of screen
            float yPos = cam.transform.position.y + cam.orthographicSize + Random.Range(1,20);//orthographic size gives you half height



            GameObject theThing = Instantiate(thing, new Vector3(xPos, yPos, 0), thing.transform.rotation);

            switch (tag) {
                case "salad":
                    theThing.GetComponent<Rigidbody2D>().velocity = new Vector2(0,phasesScrollingSpeed - Random.Range(4,10));
                    break;
            }

            yield return new WaitForSeconds(2);
        }
            
    }

}
