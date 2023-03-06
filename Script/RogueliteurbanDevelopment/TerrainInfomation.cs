using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainInfomation : MonoBehaviour
{
    public bool isCentralArea;//中央地ならtrueに設定

    public ChangeMaterial changeMaterial;//マテリアルを変更するスクリプト

    [SerializeField]
    SoilType.SOIL_TYPES soilType;

    [SerializeField]
    ConditionType.CONDITION_TYPES conditionType;


    // Start is called before the first frame update
    void Start()
    {
        if(isCentralArea == true)
        {
            changeMaterial.Change((int)SoilType.SOIL_TYPES.CENTRAL);

            soilType = SoilType.SOIL_TYPES.CENTRAL;
            conditionType = ConditionType.CONDITION_TYPES.MEDIOCRE;

        }
        else
        {
            float soil_rand = Random.Range(0.1f, 0.9f) * 10;
            float condition_rand = Random.Range(0.0f, 0.8f) * 10;

            changeMaterial.Change((int)soil_rand);

            soilType = (SoilType.SOIL_TYPES)soil_rand;
            conditionType = (ConditionType.CONDITION_TYPES)condition_rand;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public SoilType.SOIL_TYPES GetSoilType()
    {
        return soilType;
    }

    public ConditionType.CONDITION_TYPES GetConditionType()
    {
        return conditionType;
    }

}
