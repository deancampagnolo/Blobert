using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class transformEvents : MonoBehaviour {
    [HideInInspector]
    public Queue<Transform> events;
    [HideInInspector]
    public GameMaster gm;
    public GameObject evilMoop;
    private Transform pointOfNoReturn;
    private DialogueManager dialogueManager;
	// Use this for initialization
	void Start () {
        dialogueManager = GameObject.Find("Canvas").GetComponent<DialogueManager>();
        
        events = new Queue<Transform>();
        pointOfNoReturn = GameObject.Find("Level3").transform.Find("Point of No Return");
        if(pointOfNoReturn == null) {
            print("ohno");
        }
        events.Enqueue(pointOfNoReturn);
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (events.Count != 0) {
            if ((events.Peek()).position.x < GameMaster.GetPlayer().transform.position.x) {
                DoEvent();
                events.Dequeue();
            }
        }
	}

    public void PointOfNoReturnEvent(Transform position) {
        Instantiate(evilMoop, position);
    }
    public void DoEvent() {
        if ((events.Peek()) == (pointOfNoReturn)) {//im pretty sure i can use ==
            print("doing point of no return");
            PointOfNoReturnEvent(events.Peek().parent.Find("MoopSpawner"));
        }

    }
    public void TriggerDialogoue() {
       // dialogueManager.
    }
}
