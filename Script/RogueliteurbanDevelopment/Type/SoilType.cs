using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoilType : MonoBehaviour
{
    public enum SOIL_TYPS
    {
        CENTRAL = 0,//中央（始まりの地）
        GRASSLAND,//草原
        DESERT,//砂漠
        MOUNTAIN,//山岳
        HILL,//丘陵
        ROCKY,//岩石地帯
        WETLAND,//湿原
        REMAINS,//遺跡
        OCEAN,//海（海水域）
        FRESHWATER//淡水（淡水域）
    }
}
