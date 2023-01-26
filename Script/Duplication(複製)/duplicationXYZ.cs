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

                    instansObject.Add(Instantiate(originObject, pos, originObject.transform.rotation));
                }
            }
        }
    }
}
