using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiling : MonoBehaviour {

    //[SerializeField] private GameObject tilingPicture;
    private float tilingXValue;
    [SerializeField]private int buffer;
    //private float tilingValue;
    private GameObject background;
    private float width;
	// Use this for initialization
	void Start () {
        background = GameObject.Find("forestOriginal");
        width = background.GetComponent<SpriteRenderer>().bounds.size.x;
        tilingXValue = background.transform.position.x + (width/2);//becaue transform pos x is the middle of the picture
        tilingXValue -= buffer;
        
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (GameMaster.GetPlayer().transform.position.x > tilingXValue) {

            Instantiate(background, new Vector2(tilingXValue + (width / 2), background.transform.position.y), background.transform.rotation);
            tilingXValue += width;
            
        }
	}
}
