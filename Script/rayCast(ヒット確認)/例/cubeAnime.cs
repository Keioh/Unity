using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class cubeAnime : MonoBehaviour
{
    public GameObject mainCamera;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        mousePointRayHit mousePointRayHit = mainCamera.GetComponent<mousePointRayHit>();

        if (mousePointRayHit.isHit == true)//オブジェクトに触れている時
        {
            if (mousePointRayHit.rayHit.collider.name == gameObject.name)//名前が同じなら
            {
                mousePointRayHit.rayHit.transform.localScale = new Vector3(0.5f, 1.0f, 0.5f);//スケールを変更
            }
            else
            {
                transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);//スケールを戻す
            }
        }
        else//何も触れていない時
        {
               transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }
    }
}
