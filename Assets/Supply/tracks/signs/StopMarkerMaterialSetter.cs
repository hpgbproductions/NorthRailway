using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopMarkerMaterialSetter : MonoBehaviour
{
    // Forward: Sign that is seen when travelling in the relative +Z direction
    [SerializeField] private int ForwardNum = 0;
    [SerializeField] private Renderer ForwardRenderer;
    [SerializeField] private Renderer ForwardRendererOther;

    [SerializeField] private int BackwardNum = 0;
    [SerializeField] private Renderer BackwardRenderer;
    [SerializeField] private Renderer BackwardRendererOther;

    [SerializeField] private StopMarkerMaterialHolder MaterialHolder;

    private void Start()
    {
        bool ShowForward = ForwardNum >= 0 && ForwardNum < MaterialHolder.materials.Length;
        if (ShowForward)
        {
            ForwardRenderer.material = MaterialHolder.materials[ForwardNum];
        }
        else 
        {
            ForwardRenderer.enabled = false;
            ForwardRendererOther.enabled = false;
        }

        bool ShowBackward = BackwardNum >= 0 && BackwardNum < MaterialHolder.materials.Length;
        if (ShowBackward)
        {
            BackwardRenderer.material = MaterialHolder.materials[BackwardNum];
        }
        else
        {
            BackwardRenderer.enabled = false;
            BackwardRendererOther.enabled = false;
        }
    }

}
