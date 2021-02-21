using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderingSettings : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        OVRPlugin.fixedFoveatedRenderingLevel = OVRPlugin.FixedFoveatedRenderingLevel.Medium; // it's the maximum foveation level
        OVRPlugin.useDynamicFixedFoveatedRendering = false;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
