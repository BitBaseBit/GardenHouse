using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : MonoBehaviour
{
    public Animator fox;
    private IEnumerator coroutine;
    bool shouldWalk = true;
    bool shouldTurn = false;

    private int idle;
    private int idleTurnL;
    private int walk;
    private int walkLeft;
    private int walkRight;
    private int walkSlow;

    [SerializeField]
    FoxAttackSO hasFoxStartedAttack;

    private bool state1 = false;
    private bool state2 = false;
    private bool state3 = false;
    private bool state4 = false;
    private bool state5 = false;
    private bool state6 = false;
    private bool state7 = false;
    private bool state8 = false;

    int randInt;

    private void Awake()
    {
        idle = Animator.StringToHash("idle");
        idleTurnL = Animator.StringToHash("idleTurnL");
        walk = Animator.StringToHash("walk");
        walkLeft = Animator.StringToHash("walkLeft");
        walkRight = Animator.StringToHash("walkRight");
        walkSlow = Animator.StringToHash("walkSlow");
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
            StartCoroutine(SceneWait(3.2f, 1));
        }

        if (state2)
        {
            StartCoroutine(SceneWait(2.2f, 2));
        }

    }

    IEnumerator SceneWait(float time, int stateNumber)
    {
        switch (stateNumber)
        {
            case 1:
                state1 = false;
                yield return new WaitForSeconds(time);
                fox.SetBool(idle, true);
                fox.SetBool(walk, false);
                state2 = true;
                break;
            case 2:
                state2 = false;
                fox.SetBool(idle, false); ;
                fox.SetBool(idleTurnL, true);
                yield return new WaitForSeconds(time);
                fox.SetBool(idleTurnL, false);
                fox.SetBool(idle, true);
                state3 = true;
                break;
            case 3:
                state3 = false;
                Debug.Log("In state3");
                yield return new WaitForSeconds(time);
                state4 = true;
                break;

            default:
                Debug.LogError("Supplied incorrect stateNumber in SceneWait, the stateNumber supplied was"
                    + stateNumber);
                break; 
        }
    }

    IEnumerator Walk()
    {
        Debug.Log("Got here 2");
        fox.SetBool(walk, true);
        fox.SetBool(idle, false);
        yield return new WaitForSeconds(5.0f);
        fox.SetBool(walk, false);
        fox.SetBool(idle, true);
        shouldTurn = true;
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
