using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour {

    public static GameMaster gm;// not entirely sure why this is here

    public Transform playerPrefab;
    public Transform spawnPoint;
    public float fallOffMap;
    public static GameObject player;
    public static Vector2 rocketBlastOnPlayer;
    public  static float minimumMomentumSpeed = 1f;//minimum speed needed to calculate momentum
    public  static int momentumFactor = 20; // the speed divided by this is then subtracted to the speed (e.g. if speed is 30 with momentumFactor 4 then it would return 30 - (30/4);

    private void Start() {
        player = GameObject.Find("Player");
        if(player == null) {
            print("UHOH");
        }
    }

    public static void KillPlayer() {
        Destroy(player);
        gm.RespawnPlayer();
    }

    public static void DamagePlayer(int amount) {
        player.GetComponent<MainC>().Damage(amount);
    }

    public static void DamageEnemy(GameObject NPCObject, int amount) {
        NPCObject.GetComponent<NPCStats>().Damage(amount);
    }

    public static void HealEnemy(GameObject NPCObject, int amount) {
        NPCObject.GetComponent<NPCStats>().Heal(amount);
    }

    public void RespawnPlayer() {
        Instantiate(playerPrefab, spawnPoint.position, spawnPoint.rotation);
    }

    public static void AddForceToNPC(GameObject theObject, Vector2 force) {
        theObject.GetComponent<Rigidbody2D>().AddForce(force, ForceMode2D.Impulse);
    }

    public static void AddRocketBlastOnPlayer(Vector2 newVelocity) {
        rocketBlastOnPlayer += newVelocity;
    }

    public static Vector2 GetRocketBlastOnPlayer() {
        return rocketBlastOnPlayer;
    }

    public static Vector2 CalculateXMomentum(Vector2 Momentum) {
        if (Momentum.x > minimumMomentumSpeed) {
            return new Vector2(Momentum.x - (Momentum.x / momentumFactor), Momentum.y);
        }
        return new Vector2(0, Momentum.y);
    }

    public IEnumerator IsFallOff() {
        while (true) {
       
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate() {
        rocketBlastOnPlayer = CalculateXMomentum(rocketBlastOnPlayer);
       // print("rocketBlastOnPlayer = " + rocketBlastOnPlayer);
    }
}
