using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformEventLevelMeetFairyScript : TransformEventLevelScript {

    private GameObject fairySpawnPoint;
    [SerializeField] private GameObject fabbyFairyPrefab;
    new void Start() {
        base.Start();
        fairySpawnPoint = this.transform.parent.Find("FairySpawnPoint").gameObject;
    }

    public override void DoEvent() {
        if (GameObject.Find("FabbyTheFairy") == null) {
            Instantiate(fabbyFairyPrefab, fairySpawnPoint.transform.position, fairySpawnPoint.transform.rotation);
        }

    } 

    // Use this for initialization
   
	
	// Update is called once per frame
	void Update () {
		
	}
}
