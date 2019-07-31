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
            Debug.Log(string.Format("changing {0}'s {1} to {2}", model.Mesh.name, model.Mesh.materials[model.MaterialIndex].name, model.NewMaterial.name));
            model.Mesh.materials[model.MaterialIndex] = model.NewMaterial;
            Debug.Log(string.Format("{0}'s new colour is {1}", model.Mesh.name, model.Mesh.materials[model.MaterialIndex].name));
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
