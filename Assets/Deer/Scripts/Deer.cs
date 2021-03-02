using UnityEngine;
using TMPro;
using System.Collections;
using System;

public class Deer : MonoBehaviour
{
    public  Animator    deer;
    public  Transform   deerTransform;
    private int         deerID;

    
    private float       sceneTimer;
    
    private bool        scene2Rotation    = false;
    private bool        scene3Rotation    = false;
    private bool        scene5Rotation    = false;
    private bool        scene9Rotation    = false;
    private bool        scene9Rotation_2  = false;
    private bool        scene9Rotation_3  = false;
    private bool        scene12Rotation   = false;
    private bool        scene13Rotation   = false;
    private bool        scene14Rotation   = false;
    private bool        scene15Rotation   = false;
    private bool        scene16Rotation   = false;
    private bool        scene19Rotation   = false;
    private bool        scene20Rotation   = false;

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

    private int         turnLeft;
    private int         turnRight;
    private int         walking;
    private int         _idle;
    private int         trotting;
    private int         eating;
    private int         jumping;
    private int         trotLeft;
    private int         trotRight;
    private int         galloping;
    private int         lay;
    private int         up;

    [SerializeField]
    FoxAttackSO         hasFoxStartedAttack;

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
        switch (deerID)
        {
            case 1:
                sceneTimer += Time.deltaTime;

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
                    StartCoroutine(SceneWait(10.5f, 11));
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
                // 1min 28seconds

                if (state16)
                {
                    deer.SetBool(walking, true);
                    deer.SetBool(eating, false);
                    StartCoroutine(SceneWait(6.1f, 16));
                }

                if (scene16Rotation)
                {
                    deerTransform.rotation = RotateOverTime(deerTransform, -210.0f, 30);
                }

                if (state17)
                {
                    deer.SetBool(eating, true);
                    deer.SetBool(walking, false);
                    StartCoroutine(SceneWait(6.3f, 17));
                }

                if (state18)
                {
                    deer.SetBool(_idle, true);
                    deer.SetBool(eating, false);
                    StartCoroutine(SceneWait(21.5f, 18));
                }

                if (state19)
                {
                    StartCoroutine(SceneWait(42.0f, 19));
                }

                if (state20)
                {
                    deer.SetBool(_idle, false);
                    deer.SetBool(galloping, true);
                    StartCoroutine(SceneWait(23.2f, 20));
                }

                if (scene20Rotation)
                {
                    deerTransform.rotation = RotateOverTime(deerTransform, 180, 30.0f);
                }

                if (deerTransform.position.z > 185.0f)
                {
                    hasFoxStartedAttack.hasFoxAttackFinished = true;
                    Destroy(this.gameObject);
                }

                break;

            case 2:
                sceneTimer += Time.deltaTime;

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
                    deerTransform.rotation = RotateOverTime(deerTransform, 0.0f, 30.0f);
                }

                if (state14)
                {
                    StartCoroutine(SceneWait(8.1f, 14));
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

                if (state16)
                {
                    deer.SetBool(eating, false);
                    deer.SetBool(walking, true);
                    StartCoroutine(SceneWait(4.1f, 16));
                }

                if (scene16Rotation)
                {
                    deerTransform.rotation = RotateOverTime(deerTransform, 180.0f, 15.0f);
                }

                if (state17)
                {
                    deer.SetBool(eating, true);
                    deer.SetBool(walking, false);
                    StartCoroutine(SceneWait(28.3f, 17));
                }

                if (state18)
                {
                    deer.SetBool(_idle, true);
                    deer.SetBool(eating, false);
                    StartCoroutine(SceneWait(40.2f, 18));
                }

                if (state19)
                {

                    deer.SetBool(galloping, true);
                    deer.SetBool(_idle, false);
                    StartCoroutine(SceneWait(25.2f, 19));
                }    

                if (scene19Rotation)
                {
                    deerTransform.rotation = RotateOverTime(deerTransform, 180.0f, 20.0f);
                }

                if (deerTransform.position.z > 185.0f)
                {
                    hasFoxStartedAttack.hasFoxAttackFinished = true;
                    Destroy(this.gameObject);
                }

                break;

            case 3:
                sceneTimer += Time.deltaTime;

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

                if (state16 && sceneTimer > 3.2f)
                {
                    deer.SetBool(eating, false);
                    deer.SetBool(walking, true);
                    StartCoroutine(SceneWait(4.1f, 16));
                }

                if (scene16Rotation)
                {
                    deerTransform.rotation = RotateOverTime(deerTransform, -150.0f, 30.0f);
                }

                if (state17)
                {
                    deer.SetBool(eating, true);
                    deer.SetBool(walking, false);
                    StartCoroutine(SceneWait(28.2f, 17));
                }

                if (state18)
                {
                    deer.SetBool(_idle, true);
                    deer.SetBool(eating, false);
                    StartCoroutine(SceneWait(36.2f, 18));
                }

                if (state19)
                {
                    Debug.Log("State19 from deer3");
                    deer.SetBool(galloping, true);
                    deer.SetBool(_idle, false);
                    StartCoroutine(SceneWait(21.0f, 19));
                }

                if (scene19Rotation)
                {
                    deerTransform.rotation = RotateOverTime(deerTransform, 180.0f, 30.0f);
                }

                if (deerTransform.position.z > 185.0f)
                {
                    hasFoxStartedAttack.hasFoxAttackFinished = true;
                    Destroy(this.gameObject);
                }

                break;

            case 4: 
                sceneTimer += Time.deltaTime;

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
                if (state16)
                {
                    deer.SetBool(eating, false);
                    deer.SetBool(walking, true);
                    StartCoroutine(SceneWait(4.1f, 16));
                }

                if (scene16Rotation)
                {
                    deerTransform.rotation = RotateOverTime(deerTransform, 150.0f, 15.0f);
                }

                if (state17)
                {
                    deer.SetBool(eating, true);
                    deer.SetBool(walking, false);
                    StartCoroutine(SceneWait(37.3f, 17));
                }

                if (state18)
                {
                    deer.SetBool(_idle, true);
                    deer.SetBool(eating, false);
                    StartCoroutine(SceneWait(40.2f, 18));
                }

                if (state19)
                {

                    deer.SetBool(galloping, true);
                    deer.SetBool(_idle, false);
                    StartCoroutine(SceneWait(25.2f, 19));
                }    

                if (scene19Rotation)
                {
                    deerTransform.rotation = RotateOverTime(deerTransform, 180.0f, 30.0f);
                }

                if (deerTransform.position.z > 185.0f)
                {
                    hasFoxStartedAttack.hasFoxAttackFinished = true;
                    Destroy(this.gameObject);
                }

                break;

            default:
                Debug.LogError("Something went wrong with this deer's deerID, it did not match any of the switch cases in the update loop." +
                    " Deer: " + this.gameObject.name + "'s deerID is" + deerID);
                break;
        }    
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
                state13         = false;
                scene13Rotation = true;

                yield return new WaitForSeconds(time);

                scene13Rotation = false;
                state14         = true;
                break;


            case 14:
                state14         = false;
                scene14Rotation = true;

                yield return new WaitForSeconds(time);

                sceneTimer      = 0;
                scene14Rotation = false;
                state15         = true;
                break;

            case 15:
                state15    = false;
                yield return new WaitForSeconds(time);
                sceneTimer = 0;
                state16    = true;
                break;

            case 16:
                state16         = false;
                scene16Rotation = true;
                yield return new WaitForSeconds(time);
                scene16Rotation = false;
                state17         = true;
                break;
            case 17:
                state17 = false;
                yield return new WaitForSeconds(time);
                state18 = true;
                break;
            case 18:
                state18 = false;
                yield return new WaitForSeconds(time);
                state19 = true;
                break;
            case 19:
                state19         = false;
                scene19Rotation = true;
                yield return new WaitForSeconds(time);
                scene19Rotation = false;
                state20         = true;
                break;
            case 20:
                state20         = false;
                scene20Rotation = true;
                yield return new WaitForSeconds(time);
                scene20Rotation = false;
                state21         = true;
                break;
            case 21:
                break;
        }
    }
}
