using UnityEngine;

public class TeamColor : MonoBehaviour
{
    private MaterialPropertyBlock materialPropertyBlock; 
    private Renderer teamRenderer;

    private void Awake() {
        materialPropertyBlock = new();
        teamRenderer = GetComponent<Renderer>();
    }

    public void SetColor(Color color)
    {
        // make this an extension method, 
        // _BaseColor is the default color property for URP
        // _Color for built-in
        materialPropertyBlock.SetColor("_BaseColor", color);
        teamRenderer.SetPropertyBlock(materialPropertyBlock);
    }
}
