using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformEventPlaceHolderScript : TransformEventLevelScript {
    public override void DoEvent() {
        print("DONT GO THIS FAR");
        throw new System.IndexOutOfRangeException();//this is at the end of the array
    }
}
