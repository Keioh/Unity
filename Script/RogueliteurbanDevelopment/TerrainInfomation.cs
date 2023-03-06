using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainInfomation : MonoBehaviour
{
    public bool isCentralArea;//�����n�Ȃ�true�ɐݒ�

    public ChangeMaterial changeMaterial;//�}�e���A����ύX����X�N���v�g

    [SerializeField]
    SoilType.SOIL_TYPS soilType;


    // Start is called before the first frame update
    void Start()
    {
        if(isCentralArea == true)
        {
            changeMaterial.Change((int)SoilType.SOIL_TYPS.CENTRAL);

            soilType = SoilType.SOIL_TYPS.CENTRAL;

        }
        else
        {
            float rand = Random.Range(0.1f, 0.9f) * 10;

            changeMaterial.Change((int)rand);

            soilType = (SoilType.SOIL_TYPS)rand;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
