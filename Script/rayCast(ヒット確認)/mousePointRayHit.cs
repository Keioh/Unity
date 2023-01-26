using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;

//マウスからレイを飛ばしてオブジェクトがヒットするかを見るスクリプト
//このスクリプトはMainCmaeraにつけるとよい。
public class mousePointRayHit : MonoBehaviour
{
    public bool isHit;

    public RaycastHit rayHit;

    // Update is called once per frame
    void Update()
    {
      Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());//スクリーン座標変換

        isHit = Physics.Raycast(ray, out rayHit);//レイを飛ばす
    }
}
