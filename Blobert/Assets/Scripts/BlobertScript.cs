using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlobertScript : MonoBehaviour {
    [SerializeField]
    public class PlayerStats {
        private int Health = 100;
    }

    public int fallOffMap;

    // Use this for initialization
    private void Awake() {
        //GameObject.Find("_GM");
    }

    void Start () {
        
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void FireLegCannonLeft(int i) {

        transform.Find("leftBlastPoint").gameObject.GetComponent<LegCannon>().Fire(i);

    }
}
