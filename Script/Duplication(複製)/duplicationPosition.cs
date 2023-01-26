using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class duplicationPosition : MonoBehaviour
{
    public GameObject originObject;//コピー元（オリジナルのオブジェクト＝アタッチされているオブジェクト）

    public Vector3 position;

    [SerializeField]
    List<GameObject> instansObject = new List<GameObject>();//複製先


    // Start is called before the first frame update
    void Start()
    {
        instansObject.Add(Instantiate(originObject, position, originObject.transform.rotation));
    }
}
