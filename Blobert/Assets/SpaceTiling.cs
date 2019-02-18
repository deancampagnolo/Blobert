using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceTiling : MonoBehaviour {

    //[SerializeField] private GameObject tilingPicture;
    private float tilingYValue;
    [SerializeField] private int buffer;
    //private float tilingValue;
    private GameObject background;
    [SerializeField] string whatToFind;
    private float length;
    public GameObject BlobetShip;
    // Use this for initialization
    void Start() {
        background = GameObject.Find(whatToFind);
        length = background.GetComponent<SpriteRenderer>().bounds.size.y;
        tilingYValue = background.transform.position.y + (length / 2);//becaue transform pos x is the middle of the picture

    }

    // Update is called once per frame
    void FixedUpdate() {
        if (BlobetShip.transform.position.y + buffer > tilingYValue) {

            Instantiate(background, new Vector2(background.transform.position.x, tilingYValue + (length / 2)), background.transform.rotation);
            tilingYValue += length;

        }
    }
}
