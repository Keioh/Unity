using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SoilType;

public class ChangeMaterial : MonoBehaviour
{
    //public SoilType.SOIL_TYPS soilType;

    //�}�e���A���Ǘ��p���X�g
    public List<Material> materials = new List<Material>();

    public void Change(int soil_type)
    {
        MeshRenderer mr = GetComponent<MeshRenderer>();

        mr.material = materials[soil_type];
    }
}
