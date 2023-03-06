using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;
using static UnityEditor.PlayerSettings;

//指定した位置に1つオブジェクトを複製する。
//複製したオブジェクトはListに格納される。

public class duplicationPosition : MonoBehaviour
{
    public GameObject originObject;//コピー元（オリジナルのオブジェクト＝アタッチされているオブジェクト）

    public Vector3 position;

    //public bool activeOriginal = true;//trueでコピー元のオブジェクトを表示状態（Unity的にはActiveの値）にする。

    [SerializeField]
    List<GameObject> instansObject = new List<GameObject>();//複製先

    public void Add(GameObject obj, Vector3 pos, bool activeObje = true)
    {
        //オブジェクト作成
        GameObject ins_obj = Instantiate(obj, pos, obj.transform.rotation);

        //オブジェクトの名前を変更
        ins_obj.name = obj.name + pos.x as string + pos.y as string + pos.z as string;

        //リストに追加
        instansObject.Add(ins_obj);

        originObject.SetActive(activeObje);//オリジナルのオブジェクトをアクティブ状態の設定。

        Debug.Log(ins_obj.name + "Added List");
    }
}
