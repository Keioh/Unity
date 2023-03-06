using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//複製スクリプト

public class duplicationXYZ : MonoBehaviour
{
    public GameObject originObject;//コピー元（オリジナルのオブジェクト＝アタッチされているオブジェクト）

    public int x;//複製する数（X方向）
    public int y;//複製する数（Y方向）
    public int z;//複製する数（Z方向）

    public bool activeOriginal = true;//trueでコピー元のオブジェクトを表示状態（Unity的にはActive）にする。


    [SerializeField]
    List<GameObject> instansObject = new List<GameObject>();//複製先


    // Start is called before the first frame update
    void Start()
    {
        Vector3 pos = Vector3.zero;

        for (int count_x = 0; count_x < x; count_x++)
        {
            pos.x = count_x * originObject.transform.localScale.x;

            for (int count_y = 0; count_y < y; count_y++)
            {
                pos.y = count_y * originObject.transform.localScale.y;

                for (int count_z = 0; count_z < z; count_z++)
                {
                    pos.z = count_z * originObject.transform.localScale.z;

                    //オブジェクト作成
                    GameObject obj = Instantiate(originObject, pos, originObject.transform.rotation);

                    //オブジェクトの名前を変更
                    obj.name = originObject.name + count_x as string + count_y as string + count_z as string;

                    //リストに追加
                    instansObject.Add(obj);
                }
            }
        }

        originObject.SetActive(activeOriginal);//オリジナルのオブジェクトを非アクティブに設定。
    }

    private void Update()
    {
        originObject.SetActive(activeOriginal);//オリジナルのオブジェクトを非アクティブに設定。
    }
}
