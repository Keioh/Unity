using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;

//マウスからレイを飛ばしてオブジェクトがヒットするかを見るスクリプト
//このスクリプトはMainCmaeraにつけるとよい。
public class mousePointRayHit : MonoBehaviour
{
    public string isHitName = "none";

    RaycastHit rayHit;
    Ray ray;


    // Update is called once per frame
    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());//スクリーン座標変換

        if(Physics.Raycast(ray, out rayHit, Mathf.Infinity))//レイを飛ばす
        {
            isHitName = rayHit.collider.name;
        }
        else
        {
            isHitName = "none";
        }
    }

    //レイがオブジェクトにヒットかの確認関数
    RaycastHit GetRaycastHit()
    {
        return rayHit;
    }
}
