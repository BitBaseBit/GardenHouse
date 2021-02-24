using UnityEngine;
using System.Collections;
using System;

public class Deer : MonoBehaviour
{
    public Animator deer;
    public Transform deerTransform;
    private IEnumerator coroutine;
    private int deerID;

    private float timer;

    private const double epsilon = 0.0001;

    private bool isWalking = false;
    private bool shouldTurnRight_1 = false;
    private bool shouldTurnRight_2 = false;

    private bool shouldTurnLeft_1 = false;
    private bool shouldTurnLeft_2 = false;
    private int turnCount = 0;

    // hashed keys for SetBool

    private int turnLeft;
    private int turnRight;
    private int walking;
    private int _idle;
    private int trotting;
    private int eating;
    private int jumping;
    private int trotLeft;
    private int trotRight;

	// Use this for initialization
	void Start () 
    {
        string deername = deer.gameObject.name;
        // 'Convert' char to int.
        deerID = deername[4] - '0';
        Debug.Log(deerID);

        if (deerID == 1)
            deer.SetBool("walking", true);

        turnLeft = Animator.StringToHash("turnLeft");
        turnRight = Animator.StringToHash("turnRight");
        walking = Animator.StringToHash("walk");
        _idle = Animator.StringToHash("idle");
        trotting = Animator.StringToHash("trotting");
        eating = Animator.StringToHash("eating");
        jumping = Animator.StringToHash("jumping");
        trotLeft = Animator.StringToHash("trotleft");
        trotRight = Animator.StringToHash("trotright");

	
	}
	
	// Update is called once per frame
	void Update () 
    {
        timer += Time.deltaTime;
        switch (deerID)
        {
            case 1:
                if (shouldTurnRight_1)
                {
                    deerTransform.rotation = Quaternion.RotateTowards(transform.rotation, 
                        Quaternion.Euler(transform.rotation.eulerAngles.x, 90.0f, transform.rotation.eulerAngles.z), 30.0f * Time.deltaTime);
                    StartCoroutine("StopTurningRight");
                }
                if (shouldTurnLeft_1)
                {
                    deerTransform.rotation = Quaternion.RotateTowards(transform.rotation, 
                        Quaternion.Euler(transform.rotation.eulerAngles.x, -90.0f, transform.rotation.eulerAngles.z), 30.0f * Time.deltaTime);
                    StartCoroutine("StopTurningLeft");
                }
                if (this.transform.position.z > -25.0f || this.transform.position.x > 41.0f)
                {
                    shouldTurnLeft_1 = true;
                    deer.SetBool("idle", false);
                    deer.SetBool("walking", true);
                    deer.SetBool("turnleft", false);
                    deer.SetBool("turnright", false);
                    deer.SetBool("trotting", false);
                    deer.SetBool("trotleft", false);
                    deer.SetBool("trotright", false);
                    deer.SetBool("galloping", false);
                    deer.SetBool("eating", false);
                    deer.SetBool("jumping", false);
                    return;
                } 
                if (this.transform.position.x < -41.0f || this.transform.position.z < -52.0f )
                    shouldTurnRight_1 = true;
                    deer.SetBool("idle", false);
                    deer.SetBool("walking", true);
                    deer.SetBool("turnleft", false);
                    deer.SetBool("turnright", false);
                    deer.SetBool("trotting", false);
                    deer.SetBool("trotleft", false);
                    deer.SetBool("trotright", false);
                    deer.SetBool("galloping", false);
                    deer.SetBool("eating", false);
                    deer.SetBool("jumping", false);
                    return;
               {

                }
   
                //if (!isWalking && shouldTurn)
                //{
                //    deer.SetBool("idle", false);
                //    deer.SetBool("walking", false);
                //    if (turnCount < 3)
                //    {
                //        deer.SetBool("turnleft", true);
                //        turnCount++;
                //    }

                //    deer.SetBool("turnright", false);
                //    deer.SetBool("trotting", false);
                //    deer.SetBool("trotleft", false);
                //    deer.SetBool("trotright", false);
                //    deer.SetBool("galloping", false);
                //    deer.SetBool("eating", false);
                //    deer.SetBool("jumping", false);
                //    deer.SetBool("galloping", false);
                //    isWalking = true;
                //}    
                break;

            case 2:
                if (this.transform.position.z > -25.0f || this.transform.position.x > 41.0f
                    || this.transform.position.z < -52.0f || this.transform.position.x < -48.0f)
                {
                    deer.SetBool("idle", true);
                    deer.SetBool("walking", false);
                    deer.SetBool("turnleft", false);
                    deer.SetBool("turnright", false);
                    deer.SetBool("trotting", false);
                    deer.SetBool("trotleft", false);
                    deer.SetBool("trotright", false);
                    deer.SetBool("galloping", false);
                    deer.SetBool("eating", false);
                    deer.SetBool("jumping", false);
                    deer.SetBool("galloping", false);
                    return;
                }    
                if (!isWalking)
                {
                    deer.SetBool("idle", false);
                    deer.SetBool("walking", true);
                    deer.SetBool("turnleft", false);
                    deer.SetBool("turnright", false);
                    deer.SetBool("trotting", false);
                    deer.SetBool("trotleft", false);
                    deer.SetBool("trotright", false);
                    deer.SetBool("galloping", false);
                    deer.SetBool("eating", false);
                    deer.SetBool("jumping", false);
                    deer.SetBool("galloping", false);
                    isWalking = true;
                }    
                break;

            case 3:
                if (this.transform.position.z > -25.0f || this.transform.position.x > 41.0f
                    || this.transform.position.z < -52.0f || this.transform.position.x < -48.0f)
                {
                    deer.SetBool("idle", true);
                    deer.SetBool("walking", false);
                    deer.SetBool("turnleft", false);
                    deer.SetBool("turnright", false);
                    deer.SetBool("trotting", false);
                    deer.SetBool("trotleft", false);
                    deer.SetBool("trotright", false);
                    deer.SetBool("galloping", false);
                    deer.SetBool("eating", false);
                    deer.SetBool("jumping", false);
                    deer.SetBool("galloping", false);
                    return;

                }    
                if (!isWalking)
                {
                    deer.SetBool("idle", false);
                    deer.SetBool("walking", true);
                    deer.SetBool("turnleft", false);
                    deer.SetBool("turnright", false);
                    deer.SetBool("trotting", false);
                    deer.SetBool("trotleft", false);
                    deer.SetBool("trotright", false);
                    deer.SetBool("galloping", false);
                    deer.SetBool("eating", false);
                    deer.SetBool("jumping", false);
                    deer.SetBool("galloping", false);
                    isWalking = true;
                }    
                break;

            case 4: 
                if (this.transform.position.z > -25.0f || this.transform.position.x > 41.0f
                    || this.transform.position.z < -52.0f || this.transform.position.x < -48.0f)
                {
                    deer.SetBool("idle", true);
                    deer.SetBool("walking", false);
                    deer.SetBool("turnleft", false);
                    deer.SetBool("turnright", false);
                    deer.SetBool("trotting", false);
                    deer.SetBool("trotleft", false);
                    deer.SetBool("trotright", false);
                    deer.SetBool("galloping", false);
                    deer.SetBool("eating", false);
                    deer.SetBool("jumping", false);
                    deer.SetBool("galloping", false);
                    return;
                }    
                if (!isWalking)
                {
                    deer.SetBool("idle", false);
                    deer.SetBool("walking", true);
                    deer.SetBool("turnleft", false);
                    deer.SetBool("turnright", false);
                    deer.SetBool("trotting", false);
                    deer.SetBool("trotleft", false);
                    deer.SetBool("trotright", false);
                    deer.SetBool("galloping", false);
                    deer.SetBool("eating", false);
                    deer.SetBool("jumping", false);
                    deer.SetBool("galloping", false);
                    isWalking = true;
                }    
                break;

            default:
                Debug.LogError("Something went wrong with this deer's deerID, it did not match any of the switch cases in the update loop." +
                    " Deer: " + this.gameObject.name + "'s deerID is" + deerID);
                break;
        }    
        //var dustEmission = GetComponent<ParticleSystem>().emission;
        //dustEmission.enabled = false;
        //dustgallop.GetComponent<ParticleSystem>().enableEmission = false;
        //var dustgallopEmission = GetComponent<ParticleSystem>().emission;
        //dustgallopEmission.enabled = false;
        
        //if (Input.GetKey(KeyCode.W))
        //{
        //    deer.SetBool("walking", true);
        //    deer.SetBool("backward", false);
        //    deer.SetBool("trotting", false);
        //    deer.SetBool("galloping", false);
        //    deer.SetBool("eating", false);
        //    deer.SetBool("up", false);
        //    deer.SetBool("idle", false);
        //    deer.SetBool("jumping", false);
        //    //dust.GetComponent<ParticleSystem>().enableEmission = false;
        //    //dustgallop.GetComponent<ParticleSystem>().enableEmission = false;
        //    var dustEmission = GetComponent<ParticleSystem>().emission;
        //    dustEmission.enabled = false;
        //    //dust.GetComponent<ParticleSystem>().enableEmission = false;
        //    //dustgallop.GetComponent<ParticleSystem>().enableEmission = false;
        //    var dustgallopEmission = GetComponent<ParticleSystem>().emission;
        //    dustgallopEmission.enabled = false;
        //}
        //if (Input.GetKey(KeyCode.A))
        //{
        //    deer.SetBool("turnleft", true);
        //    deer.SetBool("walking", false);
        //    deer.SetBool("idle", false);
        //    deer.SetBool("jumping", false);
        //    deer.SetBool("eating", false);
        //    StartCoroutine("walk");
        //    var dustEmission = GetComponent<ParticleSystem>().emission;
        //    dustEmission.enabled = false;
        //    //dust.GetComponent<ParticleSystem>().enableEmission = false;
        //    //dustgallop.GetComponent<ParticleSystem>().enableEmission = false;
        //    var dustgallopEmission = GetComponent<ParticleSystem>().emission;
        //    dustgallopEmission.enabled = false;
        //    //dust.GetComponent<ParticleSystem>().enableEmission = false;
        //    //dustgallop.GetComponent<ParticleSystem>().enableEmission = false;
        //    walk();
        //}
        //if (Input.GetKey(KeyCode.D))
        //{
        //    deer.SetBool("turnright", true);
        //    deer.SetBool("walking", false);
        //    deer.SetBool("idle", false);
        //    deer.SetBool("jumping", false);
        //    deer.SetBool("eating", false);
        //    StartCoroutine("walk");
        //    var dustEmission = GetComponent<ParticleSystem>().emission;
        //    dustEmission.enabled = false;
        //    //dust.GetComponent<ParticleSystem>().enableEmission = false;
        //    //dustgallop.GetComponent<ParticleSystem>().enableEmission = false;
        //    var dustgallopEmission = GetComponent<ParticleSystem>().emission;
        //    dustgallopEmission.enabled = false;
        //    //dust.GetComponent<ParticleSystem>().enableEmission = false;
        //    //dustgallop.GetComponent<ParticleSystem>().enableEmission = false;
        //    //dustgallopEmission.enabled = false;
        //    walk();
        //}
        //if (Input.GetKey(KeyCode.Space))
        //{
        //    deer.SetBool("jumping", true);
        //    deer.SetBool("idle", false);
        //    deer.SetBool("walking", false);
        //    deer.SetBool("turnleft", false);
        //    deer.SetBool("turnright", false);
        //    deer.SetBool("trotting", false);
        //    deer.SetBool("trotleft", false);
        //    deer.SetBool("trotright", false);
        //    var dustEmission = GetComponent<ParticleSystem>().emission;
        //    dustEmission.enabled = true;
        //    //dust.GetComponent<ParticleSystem>().enableEmission = false;
        //    //dustgallop.GetComponent<ParticleSystem>().enableEmission = false;
        //    var dustgallopEmission = GetComponent<ParticleSystem>().emission;
        //    dustgallopEmission.enabled = false;
        //    //dust.GetComponent<ParticleSystem>().enableEmission = true;
        //    //dustgallop.GetComponent<ParticleSystem>().enableEmission = false;
        //}
        //if (Input.GetKey(KeyCode.B))
        //{
        //    deer.SetBool("backward", true);
        //    deer.SetBool("walking", false);
        //    var dustEmission = GetComponent<ParticleSystem>().emission;
        //    dustEmission.enabled = false;
        //    //dust.GetComponent<ParticleSystem>().enableEmission = false;
        //    //dustgallop.GetComponent<ParticleSystem>().enableEmission = false;
        //    var dustgallopEmission = GetComponent<ParticleSystem>().emission;
        //    dustgallopEmission.enabled = false;
        //}
        //if (Input.GetKey(KeyCode.E))
        //{
        //    deer.SetBool("eating", true);
        //    deer.SetBool("walking", false);
        //    deer.SetBool("turnleft", false);
        //    deer.SetBool("turnright", false);
        //    deer.SetBool("idle", false);
        //    var dustEmission = GetComponent<ParticleSystem>().emission;
        //    dustEmission.enabled = false;
        //    //dust.GetComponent<ParticleSystem>().enableEmission = false;
        //    //dustgallop.GetComponent<ParticleSystem>().enableEmission = false;
        //    var dustgallopEmission = GetComponent<ParticleSystem>().emission;
        //    dustgallopEmission.enabled = false;
        //}
        //if (Input.GetKey(KeyCode.F))
        //{
        //    deer.SetBool("idle", false);
        //    deer.SetBool("attack", true);
        //    deer.SetBool("galloping", false);
        //    var dustEmission = GetComponent<ParticleSystem>().emission;
        //    dustEmission.enabled = false;
        //    //dust.GetComponent<ParticleSystem>().enableEmission = false;
        //    //dustgallop.GetComponent<ParticleSystem>().enableEmission = false;
        //    var dustgallopEmission = GetComponent<ParticleSystem>().emission;
        //    dustgallopEmission.enabled = true;
        //    StartCoroutine("idle");
        //    idle();
        //}
        //if (Input.GetKey(KeyCode.Alpha1))
        //{
        //    deer.SetBool("lay", true);
        //    deer.SetBool("idle", false);
        //    var dustEmission = GetComponent<ParticleSystem>().emission;
        //    dustEmission.enabled = false;
        //    //dust.GetComponent<ParticleSystem>().enableEmission = false;
        //    //dustgallop.GetComponent<ParticleSystem>().enableEmission = false;
        //    var dustgallopEmission = GetComponent<ParticleSystem>().emission;
        //    dustgallopEmission.enabled = false;
        //}
        //if (Input.GetKey(KeyCode.Alpha2))
        //{
        //    deer.SetBool("lay", false);
        //    deer.SetBool("up", true);
        //    StartCoroutine("idle");
        //    idle();
        //    var dustEmission = GetComponent<ParticleSystem>().emission;
        //    dustEmission.enabled = false;
        //    //dust.GetComponent<ParticleSystem>().enableEmission = false;
        //    //dustgallop.GetComponent<ParticleSystem>().enableEmission = false;
        //    var dustgallopEmission = GetComponent<ParticleSystem>().emission;
        //    dustgallopEmission.enabled = false;
        //}
        //if (Input.GetKey(KeyCode.Alpha6))
        //{
        //    deer.SetBool("jumping", false);
        //    deer.SetBool("died", true);
        //    var dustEmission = GetComponent<ParticleSystem>().emission;
        //    dustEmission.enabled = false;
        //    //dust.GetComponent<ParticleSystem>().enableEmission = false;
        //    //dustgallop.GetComponent<ParticleSystem>().enableEmission = false;
        //    var dustgallopEmission = GetComponent<ParticleSystem>().emission;
        //    dustgallopEmission.enabled = false;
        //}
        //if (Input.GetKey("down"))
        //{
        //    deer.SetBool("trotting", true);
        //    deer.SetBool("backward", false);
        //    deer.SetBool("walking", false);
        //    deer.SetBool("galloping", false);
        //    deer.SetBool("jumping", false);
        //    deer.SetBool("idle", false);
        //    var dustEmission = GetComponent<ParticleSystem>().emission;
        //    dustEmission.enabled = true;
        //    //dust.GetComponent<ParticleSystem>().enableEmission = false;
        //    //dustgallop.GetComponent<ParticleSystem>().enableEmission = false;
        //    var dustgallopEmission = GetComponent<ParticleSystem>().emission;
        //    dustgallopEmission.enabled = false;
        //}
        //if (Input.GetKey("up"))
        //{
        //    deer.SetBool("galloping", true);
        //    deer.SetBool("trotting", false);
        //    deer.SetBool("trotleft", false);
        //    deer.SetBool("trotright", false);
        //    deer.SetBool("walking", false);
        //    deer.SetBool("jumping", false);
        //    deer.SetBool("idle", false);
        //    deer.SetBool("attack", false);
        //    var dustEmission = GetComponent<ParticleSystem>().emission;
        //    dustEmission.enabled = false;
        //    //dust.GetComponent<ParticleSystem>().enableEmission = false;
        //    //dustgallop.GetComponent<ParticleSystem>().enableEmission = false;
        //    var dustgallopEmission = GetComponent<ParticleSystem>().emission;
        //    dustgallopEmission.enabled = true;
        //}
        //if (Input.GetKey("left"))
        //{
        //    deer.SetBool("trotleft", true);
        //    deer.SetBool("trotting", false);
        //    deer.SetBool("jumping", false);
        //    deer.SetBool("idle", false);
        //    deer.SetBool("galloping", false);
        //    var dustEmission = GetComponent<ParticleSystem>().emission;
        //    dustEmission.enabled = true;
        //    //dust.GetComponent<ParticleSystem>().enableEmission = false;
        //    //dustgallop.GetComponent<ParticleSystem>().enableEmission = false;
        //    var dustgallopEmission = GetComponent<ParticleSystem>().emission;
        //    dustgallopEmission.enabled = false;
        //    StartCoroutine("trot");
        //    trot();
        //}
        //if (Input.GetKey("right"))
        //{
        //    deer.SetBool("trotright", true);
        //    deer.SetBool("trotting", false);
        //    deer.SetBool("jumping", false);
        //    deer.SetBool("idle", false);
        //    deer.SetBool("galloping", false);
        //    var dustEmission = GetComponent<ParticleSystem>().emission;
        //    dustEmission.enabled = true;
        //    //dust.GetComponent<ParticleSystem>().enableEmission = false;
        //    //dustgallop.GetComponent<ParticleSystem>().enableEmission = false;
        //    var dustgallopEmission = GetComponent<ParticleSystem>().emission;
        //    dustgallopEmission.enabled = false;
        //    StartCoroutine("trot");
        //    trot();
        //}
        //if (Input.GetKey(KeyCode.Keypad0))
        //{
        //    deer.SetBool("died", true);
        //    deer.SetBool("idle",false);
        //}
    }
    IEnumerator StopTurningLeft_1()
    {
        yield return new WaitForSeconds(1.05f);
        shouldTurnLeft_1 = false;
    }

    IEnumerator StopTurningRight_1()
    {
        yield return new WaitForSeconds(1.05f);
        shouldTurnRight_1 = false;
    }
    IEnumerator StopTurningLeft_2()
    {
        yield return new WaitForSeconds(5.1f);
        shouldTurnLeft_2 = false;
    }

    IEnumerator StopTurningRight_2()
    {
        yield return new WaitForSeconds(5.1f);
        shouldTurnRight_2 = false;
    }

    IEnumerator walk()
    {
        yield return new WaitForSeconds(1.4f);
        deer.SetBool("walking", true);
        deer.SetBool("turnleft", false);
        deer.SetBool("turnright", false);
    }
    IEnumerator trot()
    {
        yield return new WaitForSeconds(0.4f);
        deer.SetBool("trotting", true);
        deer.SetBool("trotleft", false);
        deer.SetBool("trotright", false);
    }
    IEnumerator idle()
    {
        yield return new WaitForSeconds(0.1f);
        deer.SetBool("attack", false);
        deer.SetBool("idle", true);
        deer.SetBool("up", false);
    }

}
