using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilingForHighway : MonoBehaviour {

    //[SerializeField] private GameObject tilingPicture;
    private float tilingXValue;
    [SerializeField] private int buffer;
    //private float tilingValue;
    private GameObject background;
    [SerializeField] string whatToFind;
    private float width;
    // Use this for initialization
    void Start() {
        background = GameObject.Find(whatToFind);
        width = background.GetComponent<SpriteRenderer>().bounds.size.x;
        tilingXValue = background.transform.position.x + (width / 2);//becaue transform pos x is the middle of the picture

    }

    // Update is called once per frame
    void FixedUpdate() {
        if (this.transform.position.x + buffer > tilingXValue) {

            Instantiate(background, new Vector2(tilingXValue + (width / 2), background.transform.position.y), background.transform.rotation);
            tilingXValue += width;

        }
    }
}
