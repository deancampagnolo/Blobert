using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraForSpaceScene : MonoBehaviour {

    public GameObject ship;
    bool freeze = false;
    [SerializeField] float translation = 0;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (!freeze) {
            this.transform.Translate(new Vector3(0, ship.transform.position.y - this.transform.position.y - translation));
        }
    }

    public void FreezeCamera() {
        freeze = true;
    }

    public void UnFreezeCamera() {
        freeze = false;
    }

    public void Follow(GameObject thingToFollow) {
        ship = thingToFollow;

    }
}
