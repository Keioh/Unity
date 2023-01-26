using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class duplicationXZ : MonoBehaviour
{
    public GameObject originObject;//コピー元（オリジナルのオブジェクト＝アタッチされているオブジェクト）

    public int x;//複製する数（X方向）
    public int z;//複製する数（Z方向）

    [SerializeField]
    List<GameObject> instansObject = new List<GameObject>();//複製先


    // Start is called before the first frame update
    void Start()
    {
        Vector3 pos = Vector3.zero;

        for (int count_x = 0; count_x < x; count_x++)
        {
            pos.x = count_x * originObject.transform.localScale.x;

            for (int count_z = 0; count_z < z; count_z++)
            {
                pos.z = count_z * originObject.transform.localScale.z;

                //オブジェクト作成
                GameObject obj = Instantiate(originObject, pos, originObject.transform.rotation);
                    
                //オブジェクトの名前を変更
                obj.name = originObject.name + count_x as string + count_z as string;

                //リストに追加
                instansObject.Add(obj);
            }
        }
    }
}