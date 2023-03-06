using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class instans : MonoBehaviour
{
    public GameObject instansObject;
    public GameObject Object;

    duplicationPosition dPosion;

    // Start is called before the first frame update
    void Start()
    {
        dPosion = instansObject.GetComponent<duplicationPosition>();

        Object.GetComponent<TerrainInfomation>().isCentralArea = false;//中央地フラグをオフにしてランダムな土地にする。

        dPosion.Add(Object, new Vector3(0.5f, 0.0f, 0.0f));
        dPosion.Add(Object, new Vector3(-0.5f, 0.0f, 0.0f));
        dPosion.Add(Object, new Vector3(0.0f, 0.0f, 0.5f));
        dPosion.Add(Object, new Vector3(0.0f, 0.0f, -0.5f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateFiled()
    {
        //マウスカーソルがヒットしたオブジェクト（この処理はクリックを考慮してない。クリックを考慮する場合はEventTriggerを用いる）
        GameObject obj = GameObject.Find("Main Camera").GetComponent<mousePointRayHit>().rayHit.collider.gameObject;

        Object.GetComponent<TerrainInfomation>().isCentralArea = false;//中央地フラグをオフにしてランダムな土地にする。

        RaycastHit hit;

        //+X
        Ray ray = new Ray(obj.transform.position, new Vector3(1, 0, 0));

        if(Physics.Raycast(ray, out hit, 0.6f) == false)
        {
            dPosion.Add(Object, new Vector3(obj.transform.position.x + 0.5f, 0.0f, obj.transform.position.z + 0.0f));
        }

        //-X
        ray = new Ray(obj.transform.position, new Vector3(-1, 0, 0));

        if (Physics.Raycast(ray, out hit, 0.6f) == false)
        {
            dPosion.Add(Object, new Vector3(obj.transform.position.x + -0.5f, 0.0f, obj.transform.position.z + 0.0f));
        }

        //+Z
        ray = new Ray(obj.transform.position, new Vector3(0, 0, 1));

        if (Physics.Raycast(ray, out hit, 0.6f) == false)
        {
            dPosion.Add(Object, new Vector3(obj.transform.position.x + 0.0f, 0.0f, obj.transform.position.z + 0.5f));
        }

        //-Z
        ray = new Ray(obj.transform.position, new Vector3(0, 0, -1));

        if (Physics.Raycast(ray, out hit, 0.6f) == false)
        {
            dPosion.Add(Object, new Vector3(obj.transform.position.x + 0.0f, 0.0f, obj.transform.position.z + -0.5f));    
        }
    }
}
