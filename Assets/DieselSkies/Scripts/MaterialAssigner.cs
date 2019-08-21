using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialAssigner : MonoBehaviour
{
    public List<MaterialAssignmentModel> Objects;

    public void AssignAllMaterials()
    {
        foreach (MaterialAssignmentModel model in Objects)
        {
            // Unity doesn't allow you to change a single material index
            // instead copy the entire array, change the right index and copy the entire array back
            Material[] materials = model.Mesh.materials;
            materials[model.MaterialIndex] = model.NewMaterial;
            model.Mesh.materials = materials;
        }
    }

    private void Start()
    {
        AssignAllMaterials();
    }
}

[Serializable]
public class MaterialAssignmentModel
{
    public MeshRenderer Mesh;
    public int MaterialIndex;
    public Material NewMaterial;
}
