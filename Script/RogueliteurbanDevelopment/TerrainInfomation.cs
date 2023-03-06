using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainInfomation : MonoBehaviour
{
    public bool isCentralArea;//中央地ならtrueに設定

    public ChangeMaterial changeMaterial;//マテリアルを変更するスクリプト

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
