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
    [SerializeField] private bool inSpaceShip = false;//This is really terrible practice, but will cut down the time to make this.
    Transform laserClone;
    Transform flashClone;
    bool isFireing = false;
    [SerializeField] private bool canFire = true; //this is only so that the spaceship can work

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

        if (canFire) {

            if (direction < 0) {

                RaycastHit2D hit;
                RaycastHit2D hitk;

                if (!inSpaceShip) {
                    isFireing = true;
                    Vector2 leftInfinity = new Vector2(transform.position.x - 100, transform.position.y);
                    hit = Physics2D.Raycast(transform.position, Vector2.left, 100, whatToHit);
                    hitk = Physics2D.Raycast(transform.position, Vector2.left, 100);
                    Debug.DrawLine(transform.position, leftInfinity, Color.red);
                } else {
                    isFireing = true;
                    hit = Physics2D.Raycast(transform.position, Vector2.up, 100, whatToHit);
                    hitk = Physics2D.Raycast(transform.position, Vector2.up, 100);
                    Debug.DrawLine(transform.position, new Vector2(transform.position.x - .2f, transform.position.y + 100), Color.red);
                }

                if (hit.collider != null) {
                    Debug.DrawLine(transform.position, hit.point, Color.cyan);
                    laserClone = Instantiate(laserBeam, transform.position, transform.rotation);

                    if (!inSpaceShip) {
                        laserClone.localScale += new Vector3((hit.distance / laserClone.GetComponent<SpriteRenderer>().bounds.size.x) - 1, 0, 0);//TODO preformance can probably be increased if i can somehow save this into a variable.
                    } else {
                        laserClone.localScale += new Vector3(100, 0, 0);// just bc i dont want to do calculations TODO
                    }

                    //FIXME ^^ It isn't the correct distance, I believe that it is a problem in the animation changing blobert's left blast point pos.
                    flashClone = Instantiate(muzzleFlash, transform.position, transform.rotation);
                    //Debug.Log("hit" + hit.collider);
                    //Debug.Log(hit.distance + " vs " + laserClone.GetComponent<SpriteRenderer>().bounds.size.x);
                    StartCoroutine(DestroyTheLaser(laserClone.gameObject, flashClone.gameObject));
                    if (hit.collider.tag.Equals("Enemy")) {
                        GameMaster.DamageEnemy(hit.collider.gameObject, damage);
                    } else if (hit.collider.tag.Equals("SpaceShip")) {
                        GameMaster.DamageShip(hit.collider.gameObject);
                    }


                } else {
                    laserClone = Instantiate(laserBeam, transform.position, transform.rotation);
                    laserClone.localScale += new Vector3(100, 0, 0);
                    //laserClone.localScale += new Vector3(100, 0, 0);//FIXME Im pretty sure this is hard coding.
                    flashClone = Instantiate(muzzleFlash, transform.position, transform.rotation);
                    //anim["LegBlastLeft"].normalizedTime = .5f;
                    StartCoroutine(DestroyTheLaser(laserClone.gameObject, flashClone.gameObject));
                }


            } /*else{
           Destroy(flashClone.gameObject);
           Destroy(laserClone.gameObject);
        } 
           */
        }
    }

    public void SetCanFire(bool value) {
        canFire = value;
    }

    private IEnumerator DestroyTheLaser(GameObject initLaserClone, GameObject initFlashClone) {
        yield return new WaitForSeconds(.1f);
        Destroy(initFlashClone.gameObject);
        Destroy(initLaserClone.gameObject);

    }
	
}
