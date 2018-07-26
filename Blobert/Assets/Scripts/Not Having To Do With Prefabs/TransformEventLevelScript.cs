using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TransformEventLevelScript : MonoBehaviour {
    public DialogueManager theDialogueManager;

    protected void Start() {
        
        theDialogueManager = GameMaster.getCanvas().transform.Find("DialogueBox").GetComponent<DialogueManager>();
        
    }


    public float GetXPosition() {
        return this.transform.position.x;
    }

    public abstract void DoEvent();

}
