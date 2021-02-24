﻿using UnityEngine;
using System.Collections;
using System;

public class Deer : MonoBehaviour
{
    public  Animator    deer;
    public  Transform   deerTransform;
    private IEnumerator coroutine;
    private int         deerID;
    
    private float       globalTimer;
    private float       sceneTimer;
    
    private bool isWalking         = false;
    private bool shouldTurnRight_1 = false;
    private bool shouldTurnRight_2 = false;
    private bool turning           = false;
    private bool shouldTurnLeft_1  = false;
    private bool shouldTurnLeft_2  = false;
    private bool startRunAwaySeq   = false;
    private bool scene2Rotation    = false;
    private bool scene3Rotation    = false;

    // ------------------------------------------------------------------------
    // Handle the transisions of state
    private bool        state1            = false;
    private bool        state2            = false;
    private bool        state3            = false;
    private bool        state4            = false;
    private bool        state5            = false;
    private bool        state6            = false;
    private bool        state7            = false;
    private bool        state8            = false;
    private bool        state9            = false;
    private bool        state10           = false;
    private bool        state11           = false;
    private bool        state12           = false;
    private bool        state13           = false;
    private bool        state14           = false;
    private bool        state15           = false;
    private bool        state16           = false;
    private bool        state17           = false;
    private bool        state18           = false;
    private bool        state19           = false;
    private bool        state20           = false;
    private bool        state21           = false;
    private bool        state22           = false;
    private bool        state23           = false;
    private bool        state24           = false;
    private bool        state25           = false;
    private bool        state26           = false;

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
    private int galloping;
    private int lay;
    private int up;

    // ------------------------------------------------------------------------
    // Random ints that deal with the first stage of the animation transisions, they are
    // the time in seconds that the state should change.
    private int stopEating;
    private int turnLeftRand;

    // ------------------------------------------------------------------------

	// Use this for initialization
	void Start () 
    {
        string deername = deer.gameObject.name;
        // 'Convert' char to int.
        deerID = deername[4] - '0';

        turnLeft  = Animator.StringToHash("turnleft");
        turnRight = Animator.StringToHash("turnright");
        walking   = Animator.StringToHash("walking");
        _idle     = Animator.StringToHash("idle");
        trotting  = Animator.StringToHash("trotting");
        eating    = Animator.StringToHash("eating");
        jumping   = Animator.StringToHash("jumping");
        trotLeft  = Animator.StringToHash("trotleft");
        trotRight = Animator.StringToHash("trotright");
        galloping = Animator.StringToHash("galloping");
        lay       = Animator.StringToHash("lay");
        up        = Animator.StringToHash("up");

        // Will always show the states that are true first, 
        // makes it faster to read what is going on.
        deer.SetBool(eating, true);
        deer.SetBool(_idle, false);
        deer.SetBool(walking, false);
        deer.SetBool(turnLeft, false);
        deer.SetBool(turnRight, false);
        deer.SetBool(trotting, false);
        deer.SetBool(trotLeft, false);
        deer.SetBool(trotRight, false);
        deer.SetBool(galloping, false);
        deer.SetBool(jumping, false);
	}
	
	// Update is called once per frame
	void Update () 
    {
        globalTimer += Time.deltaTime;
        switch (deerID)
        {
            case 1:
                sceneTimer += Time.deltaTime;
                // Should the deer run away from the player?
                // TODO HANDLE RUNNING AWAY FROM PLAYER
                //if (startRunAwaySeq)
                //{
                //    // Which way to run
                //    if (deerTransform.position.x > -3.0f)
                //    {
                //        if (deer.GetBool(lay))
                //        {
                //            deer.SetBool(lay, false);
                //            deer.SetBool(up, true);

                //        }
                //    }

                //}

                // ------------------------------------------------------------
                // This code handles turning the deer around when it reaches the boundaries
                if (shouldTurnRight_1 && !shouldTurnRight_2)
                {
                    deerTransform.rotation = Quaternion.RotateTowards(transform.rotation, 
                        Quaternion.Euler(transform.rotation.eulerAngles.x, -120.0f, transform.rotation.eulerAngles.z), 30.0f * Time.deltaTime);
                    StartCoroutine("StopTurningRight_1");
                }
                if (!shouldTurnRight_1 && shouldTurnRight_2)
                {
                    deerTransform.rotation = Quaternion.RotateTowards(transform.rotation, 
                        Quaternion.Euler(transform.rotation.eulerAngles.x, 90.0f, transform.rotation.eulerAngles.z), 30.0f * Time.deltaTime);
                    StartCoroutine("StopTurningRight_2");
                }
                if (shouldTurnLeft_1 && !shouldTurnLeft_2)
                {
                    deerTransform.rotation = Quaternion.RotateTowards(transform.rotation, 
                        Quaternion.Euler(transform.rotation.eulerAngles.x, 60.0f, transform.rotation.eulerAngles.z), 30.0f * Time.deltaTime);
                    StartCoroutine("StopTurningLeft_1");
                }
                if (!shouldTurnLeft_1 && shouldTurnLeft_2)
                {
                    deerTransform.rotation = Quaternion.RotateTowards(transform.rotation, 
                        Quaternion.Euler(transform.rotation.eulerAngles.x, -90.0f, transform.rotation.eulerAngles.z), 30.0f * Time.deltaTime);
                    Debug.Log("Got here 2");
                    StartCoroutine("StopTurningLeft_2");
                }
                if ((this.transform.position.z > -25.0f || this.transform.position.x > 41.0f) && !turning)
                {
                    shouldTurnLeft_1 = true;

                    deer.SetBool(_idle, false);
                    deer.SetBool(walking, true);
                    deer.SetBool(turnLeft, false);
                    deer.SetBool(turnRight, false);
                    deer.SetBool(trotting, false);
                    deer.SetBool(trotLeft, false);
                    deer.SetBool(trotRight, false);
                    deer.SetBool(galloping, false);
                    deer.SetBool(eating, false);
                    deer.SetBool(jumping, false);
                    return;
                } 
                if ((this.transform.position.x < -41.0f || this.transform.position.z < -52.0f ) && !turning)
                {
                    shouldTurnRight_1 = true;
                    deer.SetBool(_idle, false);
                    deer.SetBool(walking, true);
                    deer.SetBool(turnLeft, false);
                    deer.SetBool(turnRight, false);
                    deer.SetBool(trotting, false);
                    deer.SetBool(trotLeft, false);
                    deer.SetBool(trotRight, false);
                    deer.SetBool(galloping, false);
                    deer.SetBool(eating, false);
                    deer.SetBool(jumping, false);
                    return;
                }
                // End of boundary handling code.
                // ------------------------------------------------------------

                if ((sceneTimer > UnityEngine.Random.Range(2,7)) && !state1)
                {
                    state1 = true;
                    Debug.Log("scene 1");
                    sceneTimer = 0.0f;
                    deer.SetBool(eating, false);
                    deer.SetBool(_idle, true);
                    state2 = true;
                }

                if ( state2 && sceneTimer > 10 )
                {
                    state2 = true;
                    deer.SetBool(walking, true);
                    deer.SetBool(_idle, false);
                    StartCoroutine(StopTurnToIdle(4.1f, 2));
                }    

                if (scene2Rotation)
                {
                    deerTransform.rotation = Quaternion.RotateTowards(transform.rotation, 
                        Quaternion.Euler(transform.rotation.eulerAngles.x, 30.0f, transform.rotation.eulerAngles.z), 30.0f * Time.deltaTime);
                }

                if (state3 && sceneTimer > 6)
                {

                }    

   
                break;

            case 2:
                // ------------------------------------------------------------
                // This code handles turning the deer around when it reaches the boundaries
                if (shouldTurnRight_1 && !shouldTurnRight_2)
                {
                    deerTransform.rotation = Quaternion.RotateTowards(transform.rotation, 
                        Quaternion.Euler(transform.rotation.eulerAngles.x, -120.0f, transform.rotation.eulerAngles.z), 30.0f * Time.deltaTime);
                    StartCoroutine("StopTurningRight_1");
                }
                if (!shouldTurnRight_1 && shouldTurnRight_2)
                {
                    deerTransform.rotation = Quaternion.RotateTowards(transform.rotation, 
                        Quaternion.Euler(transform.rotation.eulerAngles.x, 90.0f, transform.rotation.eulerAngles.z), 30.0f * Time.deltaTime);
                    StartCoroutine("StopTurningRight_2");
                }
                if (shouldTurnLeft_1 && !shouldTurnLeft_2)
                {
                    deerTransform.rotation = Quaternion.RotateTowards(transform.rotation, 
                        Quaternion.Euler(transform.rotation.eulerAngles.x, 60.0f, transform.rotation.eulerAngles.z), 30.0f * Time.deltaTime);
                    StartCoroutine("StopTurningLeft_1");
                }
                if (!shouldTurnLeft_1 && shouldTurnLeft_2)
                {
                    deerTransform.rotation = Quaternion.RotateTowards(transform.rotation, 
                        Quaternion.Euler(transform.rotation.eulerAngles.x, -90.0f, transform.rotation.eulerAngles.z), 30.0f * Time.deltaTime);
                    Debug.Log("Got here 2");
                    StartCoroutine("StopTurningLeft_2");
                }
                if ((this.transform.position.z > -25.0f || this.transform.position.x > 41.0f) && !turning)
                {
                    shouldTurnLeft_1 = true;

                    deer.SetBool(_idle, false);
                    deer.SetBool(walking, true);
                    deer.SetBool(turnLeft, false);
                    deer.SetBool(turnRight, false);
                    deer.SetBool(trotting, false);
                    deer.SetBool(trotLeft, false);
                    deer.SetBool(trotRight, false);
                    deer.SetBool(galloping, false);
                    deer.SetBool(eating, false);
                    deer.SetBool(jumping, false);
                    return;
                } 
                if ((this.transform.position.x < -41.0f || this.transform.position.z < -52.0f ) && !turning)
                {
                    shouldTurnRight_1 = true;
                    deer.SetBool(_idle, false);
                    deer.SetBool(walking, true);
                    deer.SetBool(turnLeft, false);
                    deer.SetBool(turnRight, false);
                    deer.SetBool(trotting, false);
                    deer.SetBool(trotLeft, false);
                    deer.SetBool(trotRight, false);
                    deer.SetBool(galloping, false);
                    deer.SetBool(eating, false);
                    deer.SetBool(jumping, false);
                    return;
                }
                // End of boundary handling code.
                // ------------------------------------------------------------
                break;

            case 3:
                // ------------------------------------------------------------
                // This code handles turning the deer around when it reaches the boundaries
                if (shouldTurnRight_1 && !shouldTurnRight_2)
                {
                    deerTransform.rotation = Quaternion.RotateTowards(transform.rotation, 
                        Quaternion.Euler(transform.rotation.eulerAngles.x, -120.0f, transform.rotation.eulerAngles.z), 30.0f * Time.deltaTime);
                    StartCoroutine("StopTurningRight_1");
                }
                if (!shouldTurnRight_1 && shouldTurnRight_2)
                {
                    deerTransform.rotation = Quaternion.RotateTowards(transform.rotation, 
                        Quaternion.Euler(transform.rotation.eulerAngles.x, 90.0f, transform.rotation.eulerAngles.z), 30.0f * Time.deltaTime);
                    StartCoroutine("StopTurningRight_2");
                }
                if (shouldTurnLeft_1 && !shouldTurnLeft_2)
                {
                    deerTransform.rotation = Quaternion.RotateTowards(transform.rotation, 
                        Quaternion.Euler(transform.rotation.eulerAngles.x, 60.0f, transform.rotation.eulerAngles.z), 30.0f * Time.deltaTime);
                    StartCoroutine("StopTurningLeft_1");
                }
                if (!shouldTurnLeft_1 && shouldTurnLeft_2)
                {
                    deerTransform.rotation = Quaternion.RotateTowards(transform.rotation, 
                        Quaternion.Euler(transform.rotation.eulerAngles.x, -90.0f, transform.rotation.eulerAngles.z), 30.0f * Time.deltaTime);
                    Debug.Log("Got here 2");
                    StartCoroutine("StopTurningLeft_2");
                }
                if ((this.transform.position.z > -25.0f || this.transform.position.x > 41.0f) && !turning)
                {
                    shouldTurnLeft_1 = true;

                    deer.SetBool(_idle, false);
                    deer.SetBool(walking, true);
                    deer.SetBool(turnLeft, false);
                    deer.SetBool(turnRight, false);
                    deer.SetBool(trotting, false);
                    deer.SetBool(trotLeft, false);
                    deer.SetBool(trotRight, false);
                    deer.SetBool(galloping, false);
                    deer.SetBool(eating, false);
                    deer.SetBool(jumping, false);
                    return;
                } 
                if ((this.transform.position.x < -41.0f || this.transform.position.z < -52.0f ) && !turning)
                {
                    shouldTurnRight_1 = true;
                    deer.SetBool(_idle, false);
                    deer.SetBool(walking, true);
                    deer.SetBool(turnLeft, false);
                    deer.SetBool(turnRight, false);
                    deer.SetBool(trotting, false);
                    deer.SetBool(trotLeft, false);
                    deer.SetBool(trotRight, false);
                    deer.SetBool(galloping, false);
                    deer.SetBool(eating, false);
                    deer.SetBool(jumping, false);
                    return;
                }
                // End of boundary handling code.
                // ------------------------------------------------------------
                break;

            case 4: 
                // ------------------------------------------------------------
                // This code handles turning the deer around when it reaches the boundaries
                if (shouldTurnRight_1 && !shouldTurnRight_2)
                {
                    deerTransform.rotation = Quaternion.RotateTowards(transform.rotation, 
                        Quaternion.Euler(transform.rotation.eulerAngles.x, -120.0f, transform.rotation.eulerAngles.z), 30.0f * Time.deltaTime);
                    StartCoroutine("StopTurningRight_1");
                }
                if (!shouldTurnRight_1 && shouldTurnRight_2)
                {
                    deerTransform.rotation = Quaternion.RotateTowards(transform.rotation, 
                        Quaternion.Euler(transform.rotation.eulerAngles.x, 90.0f, transform.rotation.eulerAngles.z), 30.0f * Time.deltaTime);
                    StartCoroutine("StopTurningRight_2");
                }
                if (shouldTurnLeft_1 && !shouldTurnLeft_2)
                {
                    deerTransform.rotation = Quaternion.RotateTowards(transform.rotation, 
                        Quaternion.Euler(transform.rotation.eulerAngles.x, 60.0f, transform.rotation.eulerAngles.z), 30.0f * Time.deltaTime);
                    StartCoroutine("StopTurningLeft_1");
                }
                if (!shouldTurnLeft_1 && shouldTurnLeft_2)
                {
                    deerTransform.rotation = Quaternion.RotateTowards(transform.rotation, 
                        Quaternion.Euler(transform.rotation.eulerAngles.x, -90.0f, transform.rotation.eulerAngles.z), 30.0f * Time.deltaTime);
                    Debug.Log("Got here 2");
                    StartCoroutine("StopTurningLeft_2");
                }
                if ((this.transform.position.z > -25.0f || this.transform.position.x > 41.0f) && !turning)
                {
                    shouldTurnLeft_1 = true;

                    deer.SetBool(_idle, false);
                    deer.SetBool(walking, true);
                    deer.SetBool(turnLeft, false);
                    deer.SetBool(turnRight, false);
                    deer.SetBool(trotting, false);
                    deer.SetBool(trotLeft, false);
                    deer.SetBool(trotRight, false);
                    deer.SetBool(galloping, false);
                    deer.SetBool(eating, false);
                    deer.SetBool(jumping, false);
                    return;
                } 
                if ((this.transform.position.x < -41.0f || this.transform.position.z < -52.0f ) && !turning)
                {
                    shouldTurnRight_1 = true;
                    deer.SetBool(_idle, false);
                    deer.SetBool(walking, true);
                    deer.SetBool(turnLeft, false);
                    deer.SetBool(turnRight, false);
                    deer.SetBool(trotting, false);
                    deer.SetBool(trotLeft, false);
                    deer.SetBool(trotRight, false);
                    deer.SetBool(galloping, false);
                    deer.SetBool(eating, false);
                    deer.SetBool(jumping, false);
                    return;
                }
                // End of boundary handling code.
                // ------------------------------------------------------------
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
        turning = true;
        yield return new WaitForSeconds(1.05f);
        shouldTurnLeft_1 = false;
        shouldTurnLeft_2 = true;
    }

    IEnumerator StopTurningRight_1()
    {
        turning = true;
        yield return new WaitForSeconds(1.05f);
        shouldTurnRight_1 = false;
        shouldTurnRight_2 = true;
    }
    IEnumerator StopTurningLeft_2()
    {
        yield return new WaitForSeconds(5.1f);
        shouldTurnLeft_2 = false;
        turning          = false;
    }

    IEnumerator StopTurningRight_2()
    {
        yield return new WaitForSeconds(5.1f);
        shouldTurnRight_2 = false;
        turning           = false;
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
        scene2Rotation = false;
    }

    IEnumerator WaitForTurn()
    {
        yield return new WaitForSeconds(1.54f);
        deer.SetBool(_idle, true);
        deer.SetBool(turnLeft, false);
        deer.SetBool(turnRight, false);
    }

    IEnumerator StopTurnToIdle(float time, int stateNumber)
    {
        switch (stateNumber)
        {
            case 2:
                scene2Rotation = true;

                yield return new WaitForSeconds(time);
                state3 = true;

                sceneTimer     = 0;
                scene2Rotation = false;

                deer.SetBool(walking, false);
                deer.SetBool(_idle, true);
                break;
            case 3:
                break;

        }    
    }

    IEnumerator WaitForUpToRun()
    {
        deer.SetBool(lay, false);
        deer.SetBool(up, true);
        yield return new WaitForSeconds(1.20f);
    }

    IEnumerator StartRunAway()
    {
        if (deer.GetBool(lay))
        {
            Coroutine waitForUp = StartCoroutine(WaitForUpToRun());
            yield return waitForUp; 
        }
        else
        {
            yield return new WaitForSeconds(1.0f);
        }
    }

    IEnumerator Idle()
    {
        yield return new WaitForSeconds(0.1f);
        deer.SetBool("attack", false);
        deer.SetBool("idle", true);
        deer.SetBool("up", false);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Got Close to The Deer, RUN MOTHER FUCKERS!!!!");
        //startRunAwaySeq = true;
    }

}
