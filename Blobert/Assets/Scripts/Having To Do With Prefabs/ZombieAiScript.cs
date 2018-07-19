using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding; //This is also imported;

[RequireComponent (typeof(Rigidbody2D))]
[RequireComponent (typeof(Seeker))]
public class ZombieAiScript : MonoBehaviour {

    public Transform target;
    [SerializeField] private LayerMask whatToHit;
    public float updateRate = 2f;
    public int power = 10;
    public float secondsBetweenAttacks = 1f;
    private bool directionIsReversed = false;

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



    private int health;

    void Start () {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        health = 10;

        if(target == null) {
            if (!searchingForPlayer) {
                searchingForPlayer = true;
                StartCoroutine(SearchForPlayer());
            }
        }
        seeker.StartPath(transform.position, target.position, OnPathComplete);
		
	}

    private void IsInAttackingRange() {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, target.position, Mathf.Infinity, whatToHit);
        Debug.DrawLine(transform.position, target.position);
        
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.Equals(GameObject.FindGameObjectWithTag("Player"))) {
            GameMaster.DamagePlayer(power);
            StartCoroutine(RechargingForAttack());

        }
    }

    // Update is called once per frame
    void Update () {
        print(health);
        if (IsDead()) {//I have no idea how this doesn't work.
            Destroy(gameObject.transform.parent.gameObject);
        }
    }

    public bool IsDead() {
        if (health <= 0) {
            return true;
        } else {
            return false;
        }
    }

    public void Damage(int amount) {
        health -= amount;
    }

    public void Heal(int amount) {
        health += amount;
    }

    private IEnumerator RechargingForAttack() {

        directionIsReversed = true;
        yield return new WaitForSeconds(secondsBetweenAttacks);
        directionIsReversed = false;
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
        if (directionIsReversed) {
            dir *= -1;
        }
        dir *= speed * Time.fixedDeltaTime;

        rb.AddForce(dir, fMode);

        float dist = Vector3.Distance(transform.position, path.vectorPath[currentWaypoint]);
        if (dist < nextWaypointDistance) {
            currentWaypoint++;
            return;
        }
        print(health);
        //IsInAttackingRange();

    }
    


}
