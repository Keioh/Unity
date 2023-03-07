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

    [SerializeField]
    List<DevelopmentResourcesType.DEVELOPMENT_RESOURCES_TYPE> developmentResourcesType = new List<DevelopmentResourcesType.DEVELOPMENT_RESOURCES_TYPE>();

    // Start is called before the first frame update
    void Start()
    {
        //産出する開拓資源のリセット
        developmentResourcesType.Clear();

        if (isCentralArea == true)//中央地なら
        {
            changeMaterial.Change((int)SoilType.SOIL_TYPES.CENTRAL);

            //それぞれのタイプを代入
            soilType = SoilType.SOIL_TYPES.CENTRAL;
            conditionType = ConditionType.CONDITION_TYPES.MEDIOCRE;

            //土地が産出するランダムな資源を3つ決める。
            int developmentResourcesTypeRandomValu = 3;

            //開拓資源の追加を3回繰り返す
            for (int count = 0; count < developmentResourcesTypeRandomValu; count++)
            {
                //ランダムな資源を決定する
                int developmentResourcesTypeRandomType = Random.Range(0, 7);

                //資源を追加
                developmentResourcesType.Add((DevelopmentResourcesType.DEVELOPMENT_RESOURCES_TYPE)developmentResourcesTypeRandomType);
            }
        }
        else//中央地でないなら
        {
            //各enum定数の総数からパラメータの種類をランダムに決める。
            int soil_rand = Random.Range(1, 8);
            int condition_rand = Random.Range(0, 8);

            changeMaterial.Change(soil_rand);

            //それぞれのタイプを代入
            soilType = (SoilType.SOIL_TYPES)soil_rand;
            conditionType = (ConditionType.CONDITION_TYPES)condition_rand;

            //土地が産出するランダムな資源を最低1つ、最大3つ決める。
            int developmentResourcesTypeRandomValu = Random.Range(1, 4);

            for (int count = 0; count < developmentResourcesTypeRandomValu; count++)
            {
                int developmentResourcesTypeRandomType = Random.Range(0, 7);

                developmentResourcesType.Add((DevelopmentResourcesType.DEVELOPMENT_RESOURCES_TYPE)developmentResourcesTypeRandomType);
            }
        }
    }



    public SoilType.SOIL_TYPES GetSoilType()
    {
        return soilType;
    }

    public ConditionType.CONDITION_TYPES GetConditionType()
    {
        return conditionType;
    }

    public List<DevelopmentResourcesType.DEVELOPMENT_RESOURCES_TYPE> GetDevelopmentResourcesTypeList()
    {
        return developmentResourcesType;
    }
}
