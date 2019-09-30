using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceTransformEventsLevel1Script : SpaceEvents {

    [SerializeField] private GameObject clock;
    [SerializeField] private GameObject salad;
    [SerializeField] private float buffer = 0;
    [SerializeField] private GameObject troblobShip;
    [SerializeField] private float lateralSpeedOfTroblobShip = 10f;
    [SerializeField] private float lateralPositionTroblobShipBuffer = 2f;
    [SerializeField] private GameObject blobertShipLeftBlastPoint;
    [SerializeField] private GameObject blobertShip;
    [SerializeField] private GameObject credits;


    public override void DoEvent() {
        theDialogueManager = GameMaster.getCanvas().transform.Find("DialogueBox").GetComponent<DialogueManager>();
        theObjectiveManager = theDialogueManager.transform.parent.Find("ObjectiveBox").GetComponent<ObjectiveManager>(); //FIXME this is something wrong with the inheritance that forces me to put this code down, if you want to improve blobert, change this.


        StartCoroutine(TroblobMovement());
        blobertShipLeftBlastPoint.GetComponent<LegCannon>().SetCanFire(false);
        //FIXME Cannot access ObjectiveManager for some reason
        //print(theObjectiveManager);
        //theObjectiveManager.ObjectiveCompleted();
        //theObjectiveManager.SendObjective("Objective: Follow Troblob");
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
        theDialogueManager.SendDialogue("fabby", "Waiyt Brobert, Whai doughnt whe sh00t h!m?");
        theDialogueManager.SendDialogue("blobert", "With what fabby??");
        theDialogueManager.SendDialogue("fabby", "Use your F00t C4nn0n!");
        
        theDialogueManager.SendDialogue("blobert", "Oh crap, that is so smart! I'll just connect it to the front of the ship");
        theDialogueManager.SendDialogue("blobert", "Take this Troblob!");
        
        


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

            yield return new WaitForSeconds(.5f);
        }
    }

    private IEnumerator FirstTime() {
        while (!theDialogueManager.getSentencePeek()[1].Equals("WTF How are you still here???")) {
            yield return null;
        }
        theObjectiveManager.SendObjective("Objective: Follow Troblob");
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
        theObjectiveManager.ObjectiveCompleted();
        while (!theDialogueManager.getSentencePeek()[1].Equals("Take this Troblob!")) {
            yield return null;
        }

        theObjectiveManager.SendObjective("Objective: Shoot Troblob's Ship with the 'K' key");

        blobertShipLeftBlastPoint.GetComponent<LegCannon>().SetCanFire(true);

        StartCoroutine(FirstEngineGone());
        //sgm.AddToScrollingSpeedY(8);
        //StartCoroutine(StartSpawn(salad, "salad"));
        
    }

    private IEnumerator FirstEngineGone() {
        while (troblobShip.GetComponent<TroblobShipScript>().GetEnginesRemaining() > 5) {
            yield return null;
        }

        theObjectiveManager.ObjectiveCompleted();
        blobertShipLeftBlastPoint.GetComponent<LegCannon>().SetCanFire(false);

        sgm.AddToScrollingSpeedY(8);
        StartCoroutine(StartSpawn(salad, "salad"));
        theDialogueManager.SendDialogue("troblob", "What the heckerino??? We are going faster than the speed of light!");
        theDialogueManager.SendDialogue("blobert", "Fabby I actually don't know what is happening...");
        theDialogueManager.SendDialogue("troblob", "AGHHHHHHH");
        theDialogueManager.SendDialogue("troblob", "WTF what are these weird objects!");
        theDialogueManager.SendDialogue("fabby", "S414D!!!!!!!!!!! Yukk!");
        theDialogueManager.SendDialogue("troblob", "Blobert Please Stop Shooting Me!!! You Don't Understand What Could Happen!!");
        theDialogueManager.SendDialogue("fabby", "D0n't Lwistten TWO hEim Brobert! H35 Tricking you!");
        theDialogueManager.SendDialogue("blobert", "*Hmm what should I do...");
        theDialogueManager.SendDialogue("fabby", "SHOOT HIM!");
        theDialogueManager.SendDialogue("blobert", "Uhhh okay");
        
        StartCoroutine(FourthTime());

        
    }

    private IEnumerator FourthTime() {
        while (!theDialogueManager.getSentencePeek()[1].Equals("Uhhh okay")) {
            yield return null;
        }
        blobertShipLeftBlastPoint.GetComponent<LegCannon>().SetCanFire(true);
        theObjectiveManager.SendObjective("Objective: Blast Troblob a Few More Times");
        StartCoroutine(SecondEngineGone());

    }

    private IEnumerator SecondEngineGone() {
        while (troblobShip.GetComponent<TroblobShipScript>().GetEnginesRemaining() > 1) {
            yield return null;
        }

        theObjectiveManager.ObjectiveCompleted();
        blobertShipLeftBlastPoint.GetComponent<LegCannon>().SetCanFire(false);

        theDialogueManager.SendDialogue("troblob", "WHAT IS HAPPENING");
        StartCoroutine(StartSpawn(salad, "salad"));// this is put before speed up so that the salad falls faster
        StartCoroutine(StartSpawn(clock, "clock"));
        theDialogueManager.SendDialogue("troblob", "AHHHHHHHHHHH");
        StartCoroutine(RotateShip(troblobShip, 4f));
        for (int i = 0; i < 80; i++) {
            sgm.AddToScrollingSpeedY(i / 40);

            yield return new WaitForSeconds(.1f);
        }
        theDialogueManager.SendDialogue("blobert", "UMMM now what?");
        theDialogueManager.SendDialogue("fabby", "Don't look at me!");
        theDialogueManager.SendDialogue("fabby", "Actually now that we are this far...");
        theDialogueManager.SendDialogue("fabby", "Might as well shoot troblob down");
        theDialogueManager.SendDialogue("blobert", "Hmmm yeah probably");
        theDialogueManager.SendDialogue("troblob", "NOO Blobert you don't understand, I'm literally not the bad guy!");
        theDialogueManager.SendDialogue("fabby", "Pr3p4r3 to 3at l34d!");
        StartCoroutine(LastEngineGone());


    }

    private IEnumerator LastEngineGone() {
        while (!theDialogueManager.getSentencePeek()[1].Equals("NOO Blobert you don't understand, I'm literally not the bad guy!")) {
            yield return null;
        }
        blobertShipLeftBlastPoint.GetComponent<LegCannon>().SetCanFire(true);
        theObjectiveManager.SendObjective("Objective: Finish Troblob Off!");
        while (troblobShip.GetComponent<TroblobShipScript>().GetEnginesRemaining() < 1) {
            yield return null;
        }
        blobertShipLeftBlastPoint.GetComponent<LegCannon>().SetCanFire(false);
        StartCoroutine(RotateShip(troblobShip, 2f));
        for (int i = 0; i < 40; i++) {
            sgm.AddToScrollingSpeedY(i / 40);

            yield return new WaitForSeconds(.1f);
        }
        theDialogueManager.SendDialogue("troblob", "AHHHHHHHHHHHHHHHHHHHHHHHHHHHHHH");
        theDialogueManager.SendDialogue("fabby", "YOU FOOLS HHAHHAHAHAHAAHAHA");
        theDialogueManager.SendDialogue("blobert", "What?");
        theDialogueManager.SendDialogue("fabby", "Did you really think spoke this stupid all the time");
        theDialogueManager.SendDialogue("blobert", "I don't understand what you are saying fabby?");
        theDialogueManager.SendDialogue("fabby", "You stupid 2 Dimensional being...");
        theDialogueManager.SendDialogue("blobert", "Well yeah, we are all 2D right?");
        theDialogueManager.SendDialogue("troblob", "Oh NO!!!! Blobert Be Careful!");
        theDialogueManager.SendDialogue("fabby", "HAHAHAHHAAH you are too late Troblob!");
        theDialogueManager.SendDialogue("fabby", "Just a little bit more speed and we will reach the threshold!");
        theDialogueManager.SendDialogue("blobert", "How could you do this to me fabby...");
        StartCoroutine(StopSpeed());
    }

    private IEnumerator StopSpeed() {
        while (!theDialogueManager.getSentencePeek()[1].Equals("How could you do this to me fabby...")) {
            yield return null;
        }
        sgm.ResetScrollingSpeedY();
        theDialogueManager.SendDialogue("fabby", "Agora eu peço a vocês o deus da 3ª dimensão para abrir o portal para o mundo melhor!");
        theDialogueManager.SendDialogue("blobert", "AHhhhhhhhhh My Boness!");
        theDialogueManager.SendDialogue("troblob", "what is happennningggggg!");
        StartCoroutine(RotateShip(blobertShip, 4f));
        StartCoroutine(RotateShip(troblobShip, 2f));
        theDialogueManager.SendDialogue("fabby", "MUAHAHAHAHAHAAHAHAH");
        StartCoroutine(ShrinkShips(troblobShip, 1.05f));
        StartCoroutine(ShrinkShips(blobertShip, 1.05f));

        yield return new WaitForSeconds(4f);

        credits.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 100f);
    }


    private IEnumerator RotateShip(GameObject thing, float amount) {
        while (true) {
            thing.transform.Rotate(new Vector3(0, 0, amount));
            yield return new WaitForFixedUpdate();
        }
        
    }

    private IEnumerator ShrinkShips(GameObject thing, float amount) {
        while (true) {
            thing.transform.localScale = new Vector3(thing.transform.localScale.x / amount, thing.transform.localScale.y / amount, thing.transform.localScale.z/ amount);
            yield return new WaitForSeconds(.1f);
        }
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

            GameObject theThing;

            

            switch (tag) { //Cannot interact with 3d objects's rigidbodies when using 2d rigidbody
                case "salad":
                    theThing = Instantiate(thing, new Vector3(xPos, yPos, 0), thing.transform.rotation);
                    theThing.GetComponent<Rigidbody2D>().velocity = new Vector2(0,phasesScrollingSpeed - Random.Range(4,10));
                    yield return new WaitForSeconds(2f);
                    break;
                case "clock":
                    theThing = Instantiate(thing, new Vector3(xPos, yPos, -2), thing.transform.rotation);
                    yield return new WaitForSeconds(.5f);
                    break;
            }

        }
            
    }

}
