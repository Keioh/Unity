using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;
using static UnityEditor.PlayerSettings;

public class duplicationPosition : MonoBehaviour
{
    public GameObject originObject;//コピー元（オリジナルのオブジェクト＝アタッチされているオブジェクト）

    public Vector3 position;

    [SerializeField]
    List<GameObject> instansObject = new List<GameObject>();//複製先


    // Start is called before the first frame update
    void Start()
    {
        //オブジェクト作成
        GameObject obj = Instantiate(originObject, position, originObject.transform.rotation);

        //オブジェクトの名前を変更
        obj.name = originObject.name + position.x as string + position.y as string + position.z as string;

        //リストに追加
        instansObject.Add(obj);
    }
}
