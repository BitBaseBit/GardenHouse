using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : MonoBehaviour
{
    public Animator fox;
    private IEnumerator coroutine;
    bool shouldWalk = true;
    bool shouldTurn = false;

    int idle;
    int walk;
    int walkLeft;
    int walkRight;
    int walkSlow;

    int randInt;

    private void Awake()
    {
        idle = Animator.StringToHash("idle");
        walk = Animator.StringToHash("walk");
        walkLeft = Animator.StringToHash("walkLeft");
        walkRight = Animator.StringToHash("walkRight");
        walkSlow = Animator.StringToHash("walkSlow");
    }
    // Start is called before the first frame update
    void Start()
    {
        fox.SetBool(walk, true);
        fox.SetBool(idle, false);
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator Test()
    {
        Debug.Log("hello");
        yield return new WaitForSeconds(25.0f);
        Debug.Log("world");
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
