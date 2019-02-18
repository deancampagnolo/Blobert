using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FortressTransformEventBlobertTakeoffScript : TransformEventLevelScript {

    public GameObject Ship;
    public GameObject BlobertAndFabby;
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
        theDialogueManager.SendDialogue("blobert", "Lets get this party started");
        theDialogueManager.SendDialogue("fabby", "W00f W00f!");
        StartCoroutine(RocketLaunch());

    }

    public IEnumerator RocketLaunch() {
        MoveIntoShip();
        float acceleration = 0f;
        float jerk = .01f;

        while (true) {
            speed += acceleration;
            acceleration += jerk;
            Ship.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, speed);
            yield return new WaitForSeconds(.05f);
        }
    }

    private void MoveIntoShip() {
        BlobertAndFabby.SetActive(true);
        GameMaster.GetFabby().GetComponent<SpriteRenderer>().enabled = false;
        GameMaster.GetPlayer().transform.Find("Animatorz").GetComponent<SpriteRenderer>().enabled = false;
        GameMaster.GetPlayer().GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX;
    }


}
