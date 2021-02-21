using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderingSettings : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        OVRManager.gpuLevel = 4; 
        OVRManager.fixedFoveatedRenderingLevel = OVRManager.FixedFoveatedRenderingLevel.HighTop; // it's the maximum foveation level
        OVRManager.useDynamicFixedFoveatedRendering = false;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
