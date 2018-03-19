using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour {

    public GameObject obj;//複製したいオブジェクト
    public int volume;//複製する数
    public float power;//強さ

    // Use this for initialization
    void Start()
    {
        //volumeがマイナスだったら0で初期化
        if (volume < 0) volume = 0;

        //オブジェクトを複製
        for (int n = 0; n < volume; n++)
        {
            Instantiate(obj);
            obj.transform.position = new Vector3(Random.insideUnitSphere.x * power + obj.transform.position.x, Random.insideUnitSphere.y * power + obj.transform.position.y, Random.insideUnitSphere.z * power + obj.transform.position.z);
        }
    }
	
	// Update is called once per frame
	void Update () {


	}
}
