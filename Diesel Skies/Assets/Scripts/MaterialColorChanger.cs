using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialColorChanger : MonoBehaviour
{
    private Renderer objRenderer;
    private MaterialPropertyBlock propBlock;

    void Start()
    {
        // Get the Renderer component of the object
        objRenderer = GetComponent<Renderer>();

        // Initialize MaterialPropertyBlock
        propBlock = new MaterialPropertyBlock();
    }

    public void SetColor(Color color)
    {
        // Get the current property block from the renderer
        objRenderer.GetPropertyBlock(propBlock);

        // Set the new color on the "_Color" property
        propBlock.SetColor("_Color", color);

        // Apply the modified property block to the renderer
        objRenderer.SetPropertyBlock(propBlock);
    }
}
