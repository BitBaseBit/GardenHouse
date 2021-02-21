using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CoroTest : MonoBehaviour
{
    bool shouldCall = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Test();
        if (shouldCall)
        {
            Test();
            shouldCall = false;
        }
        
    }

    IEnumerator Test()
    {
        Debug.Log("Helloooooo");
        yield return new WaitForSeconds(1.0f);
        Debug.Log("Byeeeeeeee");
    }
}
