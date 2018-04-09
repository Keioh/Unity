using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpown : MonoBehaviour {

    public GameObject obj;

	// Use this for initialization
	void Start () {
        for (int n = 0; n < 10; n++)
        {
            for (int m = 0; m < 10; m++)
            {
                Instantiate(obj, new Vector3(Random.Range(2.0f,5.0f), 0.0f, Random.Range(2.0f, 5.0f)), Quaternion.identity);
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
