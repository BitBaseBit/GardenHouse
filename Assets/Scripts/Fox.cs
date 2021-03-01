using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : MonoBehaviour
{
    public  Animator    fox;
    public  Transform   foxTransform;
    
    private int         idle;
    private int         idleLookLeft;
    private int         jumpTrot;
    private int         sneak;
    private int         trot;
    private int         walk;
    private int         walkLeft;
    private int         walkRight;
    private int         walkSlow;
    
    [SerializeField]
    private FoxAttackSO hasFoxStartedAttack;
    
    private bool        state1         = false;
    private bool        state2         = false;
    private bool        state3         = false;
    private bool        state4         = false;
    private bool        state5         = false;
    private bool        state6         = false;
    private bool        state7         = false;
    private bool        state8         = false;
    private bool        state9         = false;
    private bool        state10        = false;
    
    private bool        state2Rotation = false;
    private bool        state6Rotation = false;
    private bool        state7Rotation = false;

    int randInt;

    private void Awake()
    {
        idle         = Animator.StringToHash("idle");
        idleLookLeft = Animator.StringToHash("idleLookLeft");
        sneak        = Animator.StringToHash("sneak");
        trot         = Animator.StringToHash("trot");
        walk         = Animator.StringToHash("walk");
        walkLeft     = Animator.StringToHash("walkLeft");
        walkRight    = Animator.StringToHash("walkRight");
        walkSlow     = Animator.StringToHash("walkSlow");
    }
    // Start is called before the first frame update
    void Start()
    {
        // Fox should walk straight for about 40 seconds
        // All deer are at final eating state at around 1min 31secs
        fox.SetBool(walk, true);
        fox.SetBool(idle, false);

        state1 = true;
    }

    // Update is called once per frame
    void Update()
    {

        if (state1)
        {
            StartCoroutine(SceneWait(40.2f, 1));
        }

        if (state2)
        {
            StartCoroutine(SceneWait(6.15f, 2));
        }

        if (state2Rotation)
        {
            foxTransform.rotation = RotateOverTime(foxTransform, -180.0f, 15.0f);
        }

        if (state3)
        {
            StartCoroutine(SceneWait(5.7f, 3));
        }

        if (state4)
        {
            fox.SetBool(idle, false);
            fox.SetBool(walkSlow, true);
            StartCoroutine(SceneWait(21.3f, 4));
        }

        if (state5)
        {
            fox.SetBool(walkSlow, false);
            fox.SetBool(idle, true);
            StartCoroutine(SceneWait(7.2f, 5));
        }

        if (state6)
        {
            fox.SetBool(walkSlow, true);
            fox.SetBool(idle, false);
            StartCoroutine(SceneWait(13.2f, 6));
        }

        if (state6Rotation)
        {
            foxTransform.rotation = RotateOverTime(foxTransform, -220.0f, 10.0f);
        }    

        if (state7)
        {
            fox.SetBool(sneak, true);
            fox.SetBool(walkSlow, false);
            StartCoroutine(SceneWait(46.8f, 7));
        }
        // 2min20seconds

        if (state7Rotation)
        {
            foxTransform.rotation = RotateOverTime(foxTransform, -250.0f, 5.0f);
        }

        if (state8)
        {

        }

    }

    IEnumerator SceneWait(float time, int stateNumber)
    {
        switch (stateNumber)
        {
            case 1:
                state1 = false;
                yield return new WaitForSeconds(time);
                state2 = true;
                break;
            case 2:
                state2         = false;
                state2Rotation = true;
                yield return new WaitForSeconds(time);
                state2Rotation = false;
                fox.SetBool(walk, false);
                fox.SetBool(idle, true);
                state3         = true;
                break;
            case 3:
                state3 = false;
                yield return new WaitForSeconds(time);
                state4 = true;
                break;
            case 4:
                state4 = false;
                yield return new WaitForSeconds(time);
                state5 = true;
                break;
            case 5:
                state5 = false;
                yield return new WaitForSeconds(time);
                state6 = true;
                break;
            case 6:
                state6         = false;
                state6Rotation = true;
                yield return new WaitForSeconds(time);
                state6Rotation = false;
                state7         = true;
                break;
            case 7:
                state7         = false;
                state7Rotation = true;
                yield return new WaitForSeconds(time);
                state7Rotation = false;
                state8         = true;
                break;
            case 8:
                break;

            default:
                Debug.LogError("Supplied incorrect stateNumber in SceneWait, the stateNumber supplied was"
                    + stateNumber);
                break; 
        }
    }
    private Quaternion RotateOverTime(Transform transform, float angleTowards, float degreesPerSecond)
    {
        return Quaternion.RotateTowards(transform.rotation, 
                        Quaternion.Euler(transform.rotation.eulerAngles.x, angleTowards, transform.rotation.eulerAngles.z), 
                        degreesPerSecond * Time.deltaTime);
    }

    IEnumerator Walk()
    {
        Debug.Log("Got here 2");
        fox.SetBool(walk, true);
        fox.SetBool(idle, false);
        yield return new WaitForSeconds(5.0f);
        fox.SetBool(walk, false);
        fox.SetBool(idle, true);
    }
    IEnumerator WalkLeft()
    {
        yield return new WaitForSeconds(5.0f);
        fox.SetBool(walkRight, false);
        fox.SetBool(walk, true);
        fox.SetBool(walkLeft, true);
        fox.SetBool(idle, false);
    }

}
