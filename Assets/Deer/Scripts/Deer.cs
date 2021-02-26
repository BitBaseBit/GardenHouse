using UnityEngine;
using TMPro;
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
    
    private bool        isWalking         = false;
    private bool        shouldTurnRight_1 = false;
    private bool        shouldTurnRight_2 = false;
    private bool        turning           = false;
    private bool        shouldTurnLeft_1  = false;
    private bool        shouldTurnLeft_2  = false;
    private bool        startRunAwaySeq   = false;
    private bool        scene2Rotation    = false;
    private bool        scene3Rotation    = false;
    private bool        scene5Rotation    = false;
    private bool        scene9Rotation    = false;
    private bool        scene9Rotation_2  = false;
    private bool        scene9Rotation_3  = false;
    private bool        scene12Rotation   = false;
    private bool        scene13Rotation   = false;
    private bool        scene14Rotation   = false;

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
    private bool        state9_2          = false;
    private bool        state9_3          = false;
    private bool        state10           = false;
    private bool        state11           = false;
    private bool        state12           = false;
    private bool        state13           = false;
    private bool        state13_1         = false;
    private bool        state13_2         = false;
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

    [SerializeField]
    FoxAttackSO hasFoxStartedAttack;


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

        // This sets off the animation sequence
        state1 = true;

	}
	
	// Update is called once per frame
	void Update () 
    {
        globalTimer += Time.deltaTime;
        switch (deerID)
        {
            case 1:
                sceneTimer += Time.deltaTime;

                if (hasFoxStartedAttack.hasFoxAttackStarted)
                {

                }    

                // ------------------------------------------------------------
                // This code handles turning the deer around when it reaches the boundaries
                if (shouldTurnRight_1 && !shouldTurnRight_2)
                {
                    deerTransform.rotation = RotateOverTime(deerTransform, -120.0f, 30.0f);
                    StartCoroutine("StopTurningRight_1");
                }
                if (!shouldTurnRight_1 && shouldTurnRight_2)
                {
                    deerTransform.rotation = RotateOverTime(deerTransform, 90.0f, 30.0f);
                    StartCoroutine("StopTurningRight_2");
                }
                if (shouldTurnLeft_1 && !shouldTurnLeft_2)
                {
                    deerTransform.rotation = RotateOverTime(deerTransform, 60.0f, 30.0f);
                    StartCoroutine("StopTurningLeft_1");
                }
                if (!shouldTurnLeft_1 && shouldTurnLeft_2)
                {
                    deerTransform.rotation = RotateOverTime(deerTransform, -90.0f, 30.0f);
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

                if ((sceneTimer > 7.1f) && state1)
                {
                    state1 = false;
                    Debug.Log("scene 1");
                    sceneTimer = 0.0f;
                    deer.SetBool(eating, false);
                    deer.SetBool(_idle, true);
                    state2 = true;
                }

                if ( state2 && sceneTimer > 10 )
                {
                    deer.SetBool(walking, true);
                    deer.SetBool(_idle, false);
                    StartCoroutine(StopTurnToIdle(4.1f, 2));
                }    

                if (scene2Rotation)
                {
                    deerTransform.rotation = RotateOverTime(deerTransform, 30.0f, 30.0f);
                    //deerTransform.rotation = Quaternion.RotateTowards(transform.rotation, 
                    //    Quaternion.Euler(transform.rotation.eulerAngles.x, 30.0f, transform.rotation.eulerAngles.z), 30.0f * Time.deltaTime);
                }

                if (state3 && sceneTimer > 6)
                {
                    deer.SetBool(walking, true);
                    deer.SetBool(_idle, false);
                    StartCoroutine(StopTurnToIdle(4.1f, 3));
                }    

                if (scene3Rotation)
                {
                    deerTransform.rotation = RotateOverTime(deerTransform, -90.0f, 30.0f);
                    //deerTransform.rotation = Quaternion.RotateTowards(transform.rotation, 
                    //    Quaternion.Euler(transform.rotation.eulerAngles.x, -90.0f, transform.rotation.eulerAngles.z), 30.0f * Time.deltaTime);
                }

                if (state4)
                {
                    deer.SetBool(_idle, false);
                    deer.SetBool(eating, true);
                    StartCoroutine(SceneWait(4.0f, 4));
                }

                if (state5 && sceneTimer > 5.5)
                {
                    deer.SetBool(walking, true);
                    deer.SetBool(_idle, false);
                    StartCoroutine(StopTurnToIdle(5.1f, 5));
                }

                if (scene5Rotation)
                {
                    deerTransform.rotation = RotateOverTime(deerTransform, 60.0f, 30.0f);
                    //deerTransform.rotation = Quaternion.RotateTowards(deerTransform.rotation, 
                    //    Quaternion.Euler(deerTransform.rotation.eulerAngles.x, 60.0f, deerTransform.rotation.eulerAngles.z), 30.0f * Time.deltaTime);
                }

                if (state6)
                {
                    deer.SetBool(_idle, false);
                    deer.SetBool(eating, true);
                    StartCoroutine(SceneWait(3.0f, 6));
                }    

                //if (state7)
                //{
                //    deer.SetBool(lay, false);
                //    deer.SetBool(up, true);
                //    StartCoroutine(SceneWait(1.3f, 7));
                //}    

                if (state8)
                {
                    deer.SetBool(_idle, true);
                    deer.SetBool(eating, false);
                    StartCoroutine(StopTurnToIdle(1.2f, 8));
                }    

                if (state9)
                {
                    deer.SetBool(_idle, false);
                    deer.SetBool(walking, true);
                    StartCoroutine(SceneWait(2.1f, 9));
                }    

                if (scene9Rotation)
                {
                    deerTransform.rotation = RotateOverTime(deerTransform, 90.0f, 30.0f);
                }

                if (state10 && sceneTimer > 6)
                {
                    deer.SetBool(walking, false);
                    deer.SetBool(_idle, true);
                    StartCoroutine(SceneWait(5.5f, 10));
                }

                if (state11)
                {
                    deer.SetBool(_idle, false);
                    deer.SetBool(galloping, true);
                    StartCoroutine(SceneWait(8.5f, 11));
                }

                if (state12)
                {
                    deer.SetBool(galloping, false);
                    deer.SetBool(walking, true);
                    StartCoroutine(SceneWait(3.0f, 12));
                }

                if (state13_1)
                {
                    deer.SetBool(_idle, true);
                    deer.SetBool(walking, false);
                    StartCoroutine(SceneWait(5.4f, 131));
                }    

                if (state13_2)
                {
                    deer.SetBool(_idle, false);
                    deer.SetBool(walking, true);
                    StartCoroutine(SceneWait(2.0f, 132));
                }

                if (state13)
                {
                    StartCoroutine(SceneWait(2.1f, 13));
                }

                if (scene13Rotation)
                {
                    deerTransform.rotation = RotateOverTime(deerTransform, 150.0f, 30.0f);
                }

                if (state14)
                {
                    StartCoroutine(SceneWait(4.1f, 14));
                }
                if (scene14Rotation)
                {
                    deerTransform.rotation = RotateOverTime(deerTransform, -90.0f, 30.0f);
                }

                if (state15 && sceneTimer > 5.2)
                {
                    deer.SetBool(walking, false);
                    deer.SetBool(eating, true);
                    StartCoroutine(SceneWait(6.3f, 15));
                }

   
                break;

            case 2:
                sceneTimer += Time.deltaTime;

                if (hasFoxStartedAttack.hasFoxAttackStarted)
                {

                }    

                // ------------------------------------------------------------
                // This code handles turning the deer around when it reaches the boundaries
                if (shouldTurnRight_1 && !shouldTurnRight_2)
                {
                    deerTransform.rotation = RotateOverTime(deerTransform, -120.0f, 30.0f);
                    StartCoroutine("StopTurningRight_1");
                }
                if (!shouldTurnRight_1 && shouldTurnRight_2)
                {
                    deerTransform.rotation = RotateOverTime(deerTransform, 90.0f, 30.0f);
                    StartCoroutine("StopTurningRight_2");
                }
                if (shouldTurnLeft_1 && !shouldTurnLeft_2)
                {
                    deerTransform.rotation = RotateOverTime(deerTransform, 60.0f, 30.0f);
                    StartCoroutine("StopTurningLeft_1");
                }
                if (!shouldTurnLeft_1 && shouldTurnLeft_2)
                {
                    deerTransform.rotation = RotateOverTime(deerTransform, -90.0f, 30.0f);
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

                if ((sceneTimer > 4.8f) && state1)
                {
                    state1 = false;
                    Debug.Log("scene 1");
                    sceneTimer = 0.0f;
                    deer.SetBool(eating, false);
                    deer.SetBool(_idle, true);
                    state2 = true;
                }

                if ( state2 && sceneTimer > 10 )
                {
                    deer.SetBool(eating, true);
                    deer.SetBool(_idle, false);
                    StartCoroutine(StopTurnToIdle(6.1f, 2));
                }    

                //if (scene2Rotation)
                //{
                //    deerTransform.rotation = RotateOverTime(deerTransform, 60.0f, 30.0f);
                //    //deerTransform.rotation = Quaternion.RotateTowards(transform.rotation, 
                //    //    Quaternion.Euler(transform.rotation.eulerAngles.x, 30.0f, transform.rotation.eulerAngles.z), 30.0f * Time.deltaTime);
                //}

                if (state3 && sceneTimer > 5.3f)
                {
                    deer.SetBool(walking, true);
                    deer.SetBool(_idle, false);
                    StartCoroutine(StopTurnToIdle(4.1f, 3));
                }    

                if (scene3Rotation)
                {
                    deerTransform.rotation = RotateOverTime(deerTransform, -90.0f, 30.0f);
                    //deerTransform.rotation = Quaternion.RotateTowards(transform.rotation, 
                    //    Quaternion.Euler(transform.rotation.eulerAngles.x, -90.0f, transform.rotation.eulerAngles.z), 30.0f * Time.deltaTime);
                }

                if (state4)
                {
                    deer.SetBool(_idle, false);
                    deer.SetBool(eating, true);
                    StartCoroutine(SceneWait(5.3f, 4));
                }

                if (state5 && sceneTimer > 5.5)
                {
                    deer.SetBool(walking, true);
                    deer.SetBool(_idle, false);
                    StartCoroutine(StopTurnToIdle(3.1f, 5));
                }

                if (scene5Rotation)
                {
                    deerTransform.rotation = RotateOverTime(deerTransform, 0.0f, 30.0f);
                    //deerTransform.rotation = Quaternion.RotateTowards(deerTransform.rotation, 
                    //    Quaternion.Euler(deerTransform.rotation.eulerAngles.x, 60.0f, deerTransform.rotation.eulerAngles.z), 30.0f * Time.deltaTime);
                }

                if (state6)
                {
                    deer.SetBool(_idle, false);
                    deer.SetBool(eating, true);
                    StartCoroutine(SceneWait(3.0f, 6));
                }    

                //if (state7)
                //{
                //    StartCoroutine(SceneWait(1.3f, 7));
                //}    

                if (state8)
                {
                    StartCoroutine(StopTurnToIdle(1.2f, 8));
                }    

                if (state9)
                {
                    deer.SetBool(eating, false);
                    deer.SetBool(walking, true);
                    StartCoroutine(SceneWait(3.1f, 9));
                }    

                if (scene9Rotation)
                {
                    deerTransform.rotation = RotateOverTime(deerTransform, -90.0f, 30.0f);
                }

                if (state9_2)
                {
                    deer.SetBool(_idle, false);
                    deer.SetBool(walking, true);
                    StartCoroutine(SceneWait(2.1f, 92));
                }

                if (scene9Rotation_2)
                {
                    deerTransform.rotation = RotateOverTime(deerTransform, -150.0f, 30.0f);
                }

                if (state9_3)
                {
                    deer.SetBool(_idle, false);
                    deer.SetBool(walking, true);
                    StartCoroutine(SceneWait(4.1f, 93));
                }
                if (scene9Rotation_3)
                {
                    deerTransform.rotation = RotateOverTime(deerTransform, -270.0f, 30.0f);
                }

                if (state10)
                {
                    deer.SetBool(walking, false);
                    deer.SetBool(_idle, true);
                    StartCoroutine(SceneWait(3.5f, 10));
                }

                if (state11)
                {
                    deer.SetBool(_idle, false);
                    deer.SetBool(galloping, true);
                    StartCoroutine(SceneWait(8.5f, 11));
                }

                if (state12)
                {
                    deer.SetBool(galloping, false);
                    deer.SetBool(walking, true);
                    StartCoroutine(SceneWait(6.5f, 12));
                }

                if (state13)
                {
                    StartCoroutine(SceneWait(6.1f, 13));
                }

                if (scene13Rotation)
                {
                    deerTransform.rotation = RotateOverTime(deerTransform, 0.0f, 15.0f);
                }

                if (state14)
                {
                    StartCoroutine(SceneWait(3.1f, 14));
                }
                if (scene14Rotation)
                {
                    deerTransform.rotation = RotateOverTime(deerTransform, 240.0f, 30.0f);
                }

                if (state15) 
                {
                    deer.SetBool(walking, false);
                    deer.SetBool(eating, true);
                    StartCoroutine(SceneWait(6.3f, 15));
                }

   
                break;

            case 3:
                sceneTimer += Time.deltaTime;

                if (hasFoxStartedAttack.hasFoxAttackStarted)
                {

                }    

                // ------------------------------------------------------------
                // This code handles turning the deer around when it reaches the boundaries
                if (shouldTurnRight_1 && !shouldTurnRight_2)
                {
                    deerTransform.rotation = RotateOverTime(deerTransform, -120.0f, 30.0f);
                    StartCoroutine("StopTurningRight_1");
                }
                if (!shouldTurnRight_1 && shouldTurnRight_2)
                {
                    deerTransform.rotation = RotateOverTime(deerTransform, 90.0f, 30.0f);
                    StartCoroutine("StopTurningRight_2");
                }
                if (shouldTurnLeft_1 && !shouldTurnLeft_2)
                {
                    deerTransform.rotation = RotateOverTime(deerTransform, 60.0f, 30.0f);
                    StartCoroutine("StopTurningLeft_1");
                }
                if (!shouldTurnLeft_1 && shouldTurnLeft_2)
                {
                    deerTransform.rotation = RotateOverTime(deerTransform, -90.0f, 30.0f);
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

                if ((sceneTimer > 7.2f) && state1)
                {
                    state1 = false;
                    Debug.Log("scene 1");
                    sceneTimer = 0.0f;
                    deer.SetBool(eating, false);
                    deer.SetBool(_idle, true);
                    state2 = true;
                }

                if ( state2 && sceneTimer > 10 )
                {
                    deer.SetBool(walking, true);
                    deer.SetBool(_idle, false);
                    StartCoroutine(StopTurnToIdle(3.1f, 2));
                }    

                if (scene2Rotation)
                {
                    deerTransform.rotation = RotateOverTime(deerTransform, 0.0f, 30.0f);
                    //deerTransform.rotation = Quaternion.RotateTowards(transform.rotation, 
                    //    Quaternion.Euler(transform.rotation.eulerAngles.x, 30.0f, transform.rotation.eulerAngles.z), 30.0f * Time.deltaTime);
                }

                if (state3 && sceneTimer > 6)
                {
                    deer.SetBool(walking, true);
                    deer.SetBool(_idle, false);
                    StartCoroutine(StopTurnToIdle(4.1f, 3));
                }    

                if (scene3Rotation)
                {
                    deerTransform.rotation = RotateOverTime(deerTransform, -90.0f, 30.0f);
                    //deerTransform.rotation = Quaternion.RotateTowards(transform.rotation, 
                    //    Quaternion.Euler(transform.rotation.eulerAngles.x, -90.0f, transform.rotation.eulerAngles.z), 30.0f * Time.deltaTime);
                }

                if (state4)
                {
                    deer.SetBool(_idle, false);
                    deer.SetBool(eating, true);
                    StartCoroutine(SceneWait(4.0f, 4));
                }

                if (state5 && sceneTimer > 5.5)
                {
                    deer.SetBool(walking, true);
                    deer.SetBool(_idle, false);
                    StartCoroutine(StopTurnToIdle(5.1f, 5));
                }

                if (scene5Rotation)
                {
                    deerTransform.rotation = RotateOverTime(deerTransform, 60.0f, 30.0f);
                    //deerTransform.rotation = Quaternion.RotateTowards(deerTransform.rotation, 
                    //    Quaternion.Euler(deerTransform.rotation.eulerAngles.x, 60.0f, deerTransform.rotation.eulerAngles.z), 30.0f * Time.deltaTime);
                }

                if (state6)
                {
                    deer.SetBool(_idle, false);
                    deer.SetBool(eating, true);
                    StartCoroutine(SceneWait(3.0f, 6));
                }    

                //if (state7)
                //{
                //    deer.SetBool(lay, false);
                //    deer.SetBool(up, true);
                //    StartCoroutine(SceneWait(1.3f, 7));
                //}    

                if (state8)
                {
                    deer.SetBool(_idle, true);
                    deer.SetBool(eating, false);
                    StartCoroutine(StopTurnToIdle(1.2f, 8));
                }    

                if (state9)
                {
                    deer.SetBool(_idle, false);
                    deer.SetBool(walking, true);
                    StartCoroutine(SceneWait(2.1f, 9));
                }    

                if (scene9Rotation)
                {
                    deerTransform.rotation = RotateOverTime(deerTransform, 90.0f, 30.0f);
                }

                if (state10 && sceneTimer > 6)
                {
                    deer.SetBool(walking, false);
                    deer.SetBool(_idle, true);
                    StartCoroutine(SceneWait(4.0f, 10));
                }

                if (state11)
                {
                    deer.SetBool(_idle, false);
                    deer.SetBool(galloping, true);
                    StartCoroutine(SceneWait(8.5f, 11));
                }

                if (state12)
                {
                    deer.SetBool(galloping, false);
                    deer.SetBool(walking, true);
                    StartCoroutine(SceneWait(5.3f, 12));
                }

                if (state13)
                {
                    StartCoroutine(SceneWait(2.1f, 13));
                }

                if (scene13Rotation)
                {
                    deerTransform.rotation = RotateOverTime(deerTransform, 150.0f, 30.0f);
                }

                if (state14)
                {
                    StartCoroutine(SceneWait(12.1f, 14));
                }
                if (scene14Rotation)
                {
                    deerTransform.rotation = RotateOverTime(deerTransform, 330.0f, 15.0f);
                }

                if (state15 && sceneTimer > 1.4f)
                {
                    deer.SetBool(walking, false);
                    deer.SetBool(eating, true);
                    StartCoroutine(SceneWait(6.3f, 15));
                }

   
                break;

            case 4: 
                sceneTimer += Time.deltaTime;

                if (hasFoxStartedAttack.hasFoxAttackStarted)
                {

                }    

                // ------------------------------------------------------------
                // This code handles turning the deer around when it reaches the boundaries
                if (shouldTurnRight_1 && !shouldTurnRight_2)
                {
                    deerTransform.rotation = RotateOverTime(deerTransform, -120.0f, 30.0f);
                    StartCoroutine("StopTurningRight_1");
                }
                if (!shouldTurnRight_1 && shouldTurnRight_2)
                {
                    deerTransform.rotation = RotateOverTime(deerTransform, 90.0f, 30.0f);
                    StartCoroutine("StopTurningRight_2");
                }
                if (shouldTurnLeft_1 && !shouldTurnLeft_2)
                {
                    deerTransform.rotation = RotateOverTime(deerTransform, 60.0f, 30.0f);
                    StartCoroutine("StopTurningLeft_1");
                }
                if (!shouldTurnLeft_1 && shouldTurnLeft_2)
                {
                    deerTransform.rotation = RotateOverTime(deerTransform, -90.0f, 30.0f);
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

                if ((sceneTimer > UnityEngine.Random.Range(5.0f,10.0f)) && state1)
                {
                    state1 = false;
                    sceneTimer = 0.0f;
                    deer.SetBool(eating, false);
                    deer.SetBool(_idle, true);
                    state2 = true;
                }

                if ( state2 && sceneTimer > 10 )
                {
                    deer.SetBool(walking, true);
                    deer.SetBool(_idle, false);
                    StartCoroutine(StopTurnToIdle(4.1f, 2));
                }    

                if (scene2Rotation)
                {
                    deerTransform.rotation = RotateOverTime(deerTransform, 30.0f, 30.0f);
                    //deerTransform.rotation = Quaternion.RotateTowards(transform.rotation, 
                    //    Quaternion.Euler(transform.rotation.eulerAngles.x, 30.0f, transform.rotation.eulerAngles.z), 30.0f * Time.deltaTime);
                }

                if (state3 && sceneTimer > 6)
                {
                    deer.SetBool(walking, true);
                    deer.SetBool(_idle, false);
                    StartCoroutine(StopTurnToIdle(3.1f, 3));
                }    

                if (scene3Rotation)
                {
                    deerTransform.rotation = RotateOverTime(deerTransform, 90.0f, 30.0f);
                    //deerTransform.rotation = Quaternion.RotateTowards(transform.rotation, 
                    //    Quaternion.Euler(transform.rotation.eulerAngles.x, -90.0f, transform.rotation.eulerAngles.z), 30.0f * Time.deltaTime);
                }

                if (state4)
                {
                    deer.SetBool(_idle, false);
                    deer.SetBool(eating, true);
                    StartCoroutine(SceneWait(5.1f, 4));
                }

                if (state5 && sceneTimer > 5.5)
                {
                    deer.SetBool(_idle, true);
                    deer.SetBool(eating, false);
                    StartCoroutine(StopTurnToIdle(4.1f, 5));
                }

                //if (scene5Rotation)
                //{
                //    deerTransform.rotation = RotateOverTime(deerTransform, 60.0f, 30.0f);
                //    //deerTransform.rotation = Quaternion.RotateTowards(deerTransform.rotation, 
                //    //    Quaternion.Euler(deerTransform.rotation.eulerAngles.x, 60.0f, deerTransform.rotation.eulerAngles.z), 30.0f * Time.deltaTime);
                //}
                if (state6)
                {
                    deer.SetBool(_idle, false);
                    deer.SetBool(eating, true);
                    StartCoroutine(SceneWait(3.0f, 6));
                }    

                //if (state7)
                //{
                //    deer.SetBool(lay, false);
                //    deer.SetBool(up, true);
                //    StartCoroutine(SceneWait(1.3f, 7));
                //}    

                if (state8)
                {
                    deer.SetBool(_idle, true);
                    deer.SetBool(eating, false);
                    StartCoroutine(StopTurnToIdle(1.2f, 8));
                }    

                if (state9)
                {
                    deer.SetBool(_idle, false);
                    deer.SetBool(walking, true);
                    StartCoroutine(SceneWait(2.1f, 9));
                }    

                if (scene9Rotation)
                {
                    deerTransform.rotation = RotateOverTime(deerTransform, 90.0f, 30.0f);
                }

                if (state10 && sceneTimer > 6)
                {
                    deer.SetBool(walking, false);
                    deer.SetBool(_idle, true);
                    StartCoroutine(SceneWait(5.5f, 10));
                }

                if (state11)
                {
                    deer.SetBool(_idle, false);
                    deer.SetBool(galloping, true);
                    StartCoroutine(SceneWait(8.5f, 11));
                }

                if (state12)
                {
                    deer.SetBool(galloping, false);
                    deer.SetBool(walking, true);
                    StartCoroutine(SceneWait(3.0f, 12));
                }

                if (state13)
                {
                    StartCoroutine(SceneWait(2.1f, 13));
                }

                if (scene13Rotation)
                {
                    deerTransform.rotation = RotateOverTime(deerTransform, 150.0f, 30.0f);
                }

                if (state14)
                {
                    StartCoroutine(SceneWait(3.1f, 14));
                }
                if (scene14Rotation)
                {
                    deerTransform.rotation = RotateOverTime(deerTransform, 240.0f, 30.0f);
                }

                if (state15 && sceneTimer > 3.2)
                {
                    deer.SetBool(walking, false);
                    deer.SetBool(eating, true);
                    StartCoroutine(SceneWait(6.3f, 15));
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

    private Quaternion RotateOverTime(Transform transform, float angleTowards, float degreesPerSecond)
    {
        return Quaternion.RotateTowards(transform.rotation, 
                        Quaternion.Euler(transform.rotation.eulerAngles.x, angleTowards, transform.rotation.eulerAngles.z), 
                        degreesPerSecond * Time.deltaTime);
    }

    private void ResetAllState()
    {
        state1  = false;
        state2  = false;
        state3  = false;
        state4  = false;
        state5  = false;
        state6  = false;
        state7  = false;
        state8  = false;
        state9  = false;
        state10 = false;
        state11 = false;
        state12 = false;
        state13 = false;
        state14 = false;
        state15 = false;
        state16 = false;
        state17 = false;
        state18 = false;
        state19 = false;
        state20 = false;
        state21 = false;
        state22 = false;
        state23 = false;
        state24 = false;
        state25 = false;
        state26 = false;
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

                if (deerID == 2)
                {
                    scene2Rotation = false;

                    state2 = false;

                    yield return new WaitForSeconds(time);
                    state3 = true;

                    sceneTimer     = 0;

                    deer.SetBool(eating, false);
                    deer.SetBool(_idle, true);
                    break;
                }
                else
                {
                    scene2Rotation = true;

                    state2 = false;

                    yield return new WaitForSeconds(time);
                    state3 = true;

                    sceneTimer     = 0;
                    scene2Rotation = false;

                    deer.SetBool(walking, false);
                    deer.SetBool(_idle, true);
                    break;
                }

            case 3:
                scene3Rotation = true;
                state3         = false;

                yield return new WaitForSeconds(time);

                sceneTimer     = 0;
                scene3Rotation = false;

                deer.SetBool(walking, false);
                deer.SetBool(_idle, true);
                state4 = true;
                break;

            case 5:
                scene5Rotation = true;
                state5         = false;

                yield return new WaitForSeconds(time);

                sceneTimer     = 0;
                scene5Rotation = false;

                deer.SetBool(_idle, true);
                deer.SetBool(walking, false);

                state6 = true;

                break;

            case 8:
                state8         = false;

                if (deerID == 2 || deerID == 1)
                {
                    yield return new WaitForSeconds(time);
                    state9 = true;
                    sceneTimer = 0;
                    break;
                }
                else
                {
                    yield return new WaitForSeconds(time);
                    state9 = true;
                    deer.SetBool(_idle, true);
                    deer.SetBool(walking, false);
                    sceneTimer = 0;
                    break;
                }



        }    
    }

    IEnumerator WaitForUpToRun()
    {
        deer.SetBool(lay, false);
        deer.SetBool(up, true);
        yield return new WaitForSeconds(1.20f);
    }

    IEnumerator SceneWait(float time, int sceneNumber)
    {
        switch (sceneNumber)
        {
            case 4:
                state4 = false;

                yield return new WaitForSeconds(time);

                state5 = true;
                deer.SetBool(eating, false);
                deer.SetBool(_idle, true);
                sceneTimer = 0;
                break;

            case 6:
                state6 = false;
                yield return new WaitForSeconds(time);
            
                state8 = true;
                break;
              

            case 7:
                state7 = false;
                yield return new WaitForSeconds(time);
                state8 = true;
                break;

            case 9:
                state9         = false;
                scene9Rotation = true;

                yield return new WaitForSeconds(time);
                scene9Rotation   = false;
                if (deerID == 2)
                {
                    state9_2 = true;
                }    
                else
                {
                    state10 = true;
                }

                sceneTimer = 0.0f;
                break;

            case 92:
                state9_2         = false;
                scene9Rotation_2 = true;

                yield return new WaitForSeconds(time);
                sceneTimer       = 0;
                scene9Rotation_2 = false;
                scene9Rotation_3 = true;
                state9_3         = true;
                break;

            case 93:
                state9_3         = false;
                scene9Rotation_3 = true;

                yield return new WaitForSeconds(time);

                sceneTimer       = 0;
                scene9Rotation_3 = false;
                state10          = true;
                break;
            case 10:
                state10 = false;
                yield return new WaitForSeconds(time);
                state11 = true;
                break;

            case 11:
                state11 = false;
                yield return new WaitForSeconds(time);
                state12 = true;
                break;

            case 12:
                state12 = false;
                yield return new WaitForSeconds(time);
                state13 = true;
                break;

            case 131:
                state13_1 = false;
                yield return new WaitForSeconds(time);

                state13_2 = true;
                break;

            case 132:
                state13_2 = false;
                yield return new WaitForSeconds(time);
                state13 = true;
                break;

            case 13:
                state13 = false;

                if (deerID == 2)
                {
                    scene13Rotation = true;

                    yield return new WaitForSeconds(time);

                    scene13Rotation = false;
                    state15 = true;
                    break;

                }    
                else
                {
                    scene13Rotation = true;

                    yield return new WaitForSeconds(time);

                    scene13Rotation = false;
                    state14 = true;
                    break;

                }

            case 14:
                state14         = false;
                scene14Rotation = true;

                yield return new WaitForSeconds(time);

                sceneTimer      = 0;
                scene14Rotation = false;
                state15         = true;
                break;

            case 15:
                state15 = false;
                yield return new WaitForSeconds(time);
                state16 = true;
                break;
        }
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
