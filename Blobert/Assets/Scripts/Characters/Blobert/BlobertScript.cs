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

    public void BiteRight(int i) {
        if(i == 0) {
            transform.Find("rightBite").gameObject.GetComponent<BoxCollider2D>().enabled = true;
            print("aha");
        }
        StartCoroutine(deleteBite("rightBite"));
        
    }

    public void BiteLeft(int i) {
        if (i == 0) {
            transform.Find("leftBite").gameObject.GetComponent<BoxCollider2D>().enabled = true;
            print("aha");
        }
        StartCoroutine(deleteBite("leftBite"));
    }

    private IEnumerator deleteBite(string typeOfBite) {
        yield return new WaitForSeconds(.1f);
        transform.Find(typeOfBite).gameObject.GetComponent<BoxCollider2D>().enabled = false;
    }


}
