using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarCalculators : MonoBehaviour {

    private GameObject healthBar;
    private GameObject bloodLustBar;
    private MainC mainC;
    private Vector3 healthBarScale;
    private Vector3 bloodLustBarScale;

	// Use this for initialization
	void Start () {
        
        healthBar = this.transform.Find("HealthBarBackground").Find("HealthBar").gameObject;
        bloodLustBar = this.transform.Find("BloodLustBarBackground").Find("BloodLustBar").gameObject;

        healthBarScale = healthBar.transform.localScale;
        bloodLustBarScale = bloodLustBar.transform.localScale;
        mainC = GameMaster.GetPlayer().GetComponent<MainC>();
	}
	
	// Update is called once per frame
	void Update () {
        if(mainC == null) {
            mainC = GameMaster.GetPlayer().GetComponent<MainC>();
        }
        healthBarScale.x = mainC.GetHealth()/(float)mainC.GetMaxHealth();//to make it a float number
        bloodLustBarScale.x = mainC.GetBloodLust() /(float) mainC.GetMaxBloodLust();//to make it a float number

        healthBar.transform.localScale = healthBarScale;
        bloodLustBar.transform.localScale = bloodLustBarScale;
		
	}
}
