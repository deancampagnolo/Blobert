using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FortressTransformEventLevel2Script : TransformEventLevelScript {

    // Use this for initialization
    void Start() {
        base.Start();
    }

    // Update is called once per frame
    void Update() {

    }

    public override void DoEvent() {
        theDialogueManager.SendDialogue("troblob", "Wow you have made it to level2");

    }
}
