using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderingSettings : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        OVRPlugin.fixedFoveatedRenderingLevel = OVRPlugin.FixedFoveatedRenderingLevel.Low; 
        OVRPlugin.useDynamicFixedFoveatedRendering = false;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
