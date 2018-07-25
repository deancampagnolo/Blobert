using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformEventLevel4Script : TransformEventLevelScript {

    private Transform evilMoopSpawner;
    public void Start() {
        evilMoopSpawner = this.transform.Find("EvilMoopSpawner");
    }

    public override void DoEvent() {
        Instantiate(GameMaster.GetEvilMoop(), evilMoopSpawner.position, evilMoopSpawner.rotation);
    }
}
