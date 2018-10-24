using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegCannon : MonoBehaviour {

    public int damage = 10;
    public int force = 30;
    [SerializeField] private LayerMask whatToHit;
    [SerializeField] private Transform laserBeam;
    [SerializeField] private Transform muzzleFlash;
    public int distanceOfBlast = 100;
    [SerializeField] private float howLongTillDestroyLaser = .02f;//FIXME THis will probably have to be changed to a delta value or wait till the animation is done
    [SerializeField] private float howLongTillDestroyFlash = .02f;//FIXME ^^^
    Transform laserClone;
    Transform flashClone;
    bool isFireing = false;

    public void Update() {
        if(laserClone!= null) {
            laserClone.SetPositionAndRotation(transform.position, transform.rotation);
            flashClone.SetPositionAndRotation(transform.position, transform.rotation);
        }
    }

    private void FixedUpdate() {
        SetRocketBlastVelocity();
    }

    public void SetRocketBlastVelocity() {
        if (isFireing) {
            isFireing = false;
            GameMaster.SetMainCRocketBlastVelocity(new Vector2(force,0));
            
        } else {
            GameMaster.SetMainCRocketBlastVelocity(Vector2.zero);
        }
        

    }

    public void Fire(int direction) {//Should this be static?
        //to initialize

       if (direction < 0) {

            isFireing = true;
            Vector2 leftInfinity = new Vector2(transform.position.x-100, transform.position.y);
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.left, 100, whatToHit);
            RaycastHit2D hitk = Physics2D.Raycast(transform.position, Vector2.left, 100);
            Debug.DrawLine(transform.position, leftInfinity , Color.red);
            if (hit.collider != null) {
                Debug.DrawLine(transform.position, hit.point, Color.cyan);
                laserClone = Instantiate(laserBeam, transform.position, transform.rotation);
                laserClone.localScale += new Vector3((hit.distance/laserClone.GetComponent<SpriteRenderer>().bounds.size.x)-1, 0, 0);//TODO preformance can probably be increased if i can somehow save this into a variable.
                //FIXME ^^ It isn't the correct distance, I believe that it is a problem in the animation changing blobert's left blast point pos.
                flashClone = Instantiate(muzzleFlash, transform.position, transform.rotation);
                //Debug.Log("hit" + hit.collider);
                //Debug.Log(hit.distance + " vs " + laserClone.GetComponent<SpriteRenderer>().bounds.size.x);
                if (hit.collider.tag.Equals("Enemy")){
                    GameMaster.DamageEnemy(hit.collider.gameObject, damage);
                }
                
            } else {
                laserClone = Instantiate(laserBeam, transform.position, transform.rotation);
                //laserClone.localScale += new Vector3(100, 0, 0);//FIXME Im pretty sure this is hard coding.
                flashClone = Instantiate(muzzleFlash, transform.position, transform.rotation);
                //anim["LegBlastLeft"].normalizedTime = .5f;
            }


        } else{
           Destroy(flashClone.gameObject);
            Destroy(laserClone.gameObject);
        } 

    }
	
}
