using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpown : MonoBehaviour {

    public GameObject obj;

	// Use this for initialization
	void Start () {
        for (int n = 0; n < 50; n++)
        {
            for (int m = 0; m < 50; m++)
            {
                Instantiate(obj, new Vector3(Random.Range(-17.0f,17.0f), 0.0f, Random.Range(-17.0f, 17.0f)), Quaternion.identity);
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
