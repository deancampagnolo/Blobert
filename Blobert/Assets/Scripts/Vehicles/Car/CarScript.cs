using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarScript : MonoBehaviour {
    [SerializeField] GameObject carGoingRight;

    public void Activate() {

        GameObject theCar = Instantiate(carGoingRight, this.transform.position, this.transform.rotation);
        GameMaster.GetCamera().GetComponent<camera>().Follow(theCar);
        theCar.transform.GetComponent<CarGoingRightScript>().GoRight();
        Destroy(this.gameObject);
    }
}
