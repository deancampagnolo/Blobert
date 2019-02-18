using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FortressTransformEventTakeoffScript : TransformEventLevelScript {

    public GameObject TroblobShip;
    private float speed;

    // Use this for initialization
    void Start() {
        base.Start();
        speed = 0f;
    }

    // Update is called once per frame
    void Update() {

    }

    public override void DoEvent() {
        theDialogueManager.SendDialogue("troblob", "Gotta Blast");
        StartCoroutine(RocketLaunch());

    }

    public IEnumerator RocketLaunch() {
        float acceleration = 0f;
        float jerk = .01f;

        while (true) {
            speed += acceleration;
            acceleration += jerk;
            TroblobShip.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, speed);
            yield return new WaitForSeconds(.05f);
        }
    }


}
