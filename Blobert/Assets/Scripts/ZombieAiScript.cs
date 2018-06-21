using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding; //This is also imported;

[RequireComponent (typeof(Rigidbody2D))]
[RequireComponent (typeof(Seeker))]
public class ZombieAiScript : MonoBehaviour {

    public Transform target;

    public float updateRate = 2f;

    private Seeker seeker;
    private Rigidbody2D rb;

    public Path path;

    public float speed = 300f;
    public ForceMode2D fMode;

    [HideInInspector]
    public bool pathIsEnded = false;

    public float nextWaypointDistance = 3;

    private bool searchingForPlayer = false;

    //public float nextWaypointDistance = 3

    private int currentWaypoint = 0;
	// Use this for initialization

	void Start () {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        if(target == null) {
            if (!searchingForPlayer) {
                searchingForPlayer = true;
                StartCoroutine(SearchForPlayer());
            }
        }
        seeker.StartPath(transform.position, target.position, OnPathComplete);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator SearchForPlayer() {
        GameObject sResult = GameObject.FindGameObjectWithTag("Player");
        if(sResult == null) {
           
            yield return new WaitForSeconds(.5f);
            StartCoroutine(SearchForPlayer());
        } else {
            target = sResult.transform;
            searchingForPlayer = false;
            StartCoroutine(UpdatePath());
            yield return null;
        }
    }

    IEnumerator UpdatePath() {
        while(!searchingForPlayer) {
            seeker.StartPath(transform.position, target.position, OnPathComplete);

            yield return new WaitForSeconds(1 / updateRate);
        }
    }

    public void OnPathComplete(Path p) {
        if (!p.error) {
            path = p;
            currentWaypoint = 0;//?
        } else {
            Debug.LogError("ERROR WITH PATH" + p.error);
        }
    }

    private void FixedUpdate() {
        if(target == null) {
            if (!searchingForPlayer) {
                searchingForPlayer = true;
                StartCoroutine(SearchForPlayer());
            }
        }
        if(path == null) {//i think because of chance with it not working
            return;
        }

        if(currentWaypoint>= path.vectorPath.Count) {
            if (pathIsEnded){
                return;
            }
           
            pathIsEnded = true;
            return;
        }
        pathIsEnded = false;

        Vector3 dir = (path.vectorPath[currentWaypoint] - transform.position).normalized;
        dir *= speed * Time.fixedDeltaTime;

        rb.AddForce(dir, fMode);

        float dist = Vector3.Distance(transform.position, path.vectorPath[currentWaypoint]);
        if (dist < nextWaypointDistance) {
            currentWaypoint++;
            return;
        }

    }











}
