using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour {

    private GameObject player;
	// Use this for initialization
	void Start () {
       player =  GameMaster.GetPlayer();
	}

    // Update is called once per frame
    void Update() {
        if (player == null) {
            player = GameMaster.GetPlayer();//FIXME I fell like there is a better way of doing this.
        }
        this.transform.Translate(new Vector3(player.transform.position.x - this.transform.position.x, 0));
    }
}
