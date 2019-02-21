using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpaceEvents : TransformEventLevelScript {
    protected float scrollingSpeedX;

    protected void Start() {

        base.Start();
        scrollingSpeedX = 10;
    }

    //public abstract bool SpaceFinished();
}
