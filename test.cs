using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour {

    public GameObject obj;
    //public int volume;

	// Use this for initialization
	void Start () {
        //volum = 1;
        for(int n = 0; n < 20; n++)
        {
            for (int u = 0; u < 110; u++)
            {
                Instantiate(obj, obj.transform.position = new Vector3(-10 + n, u), Quaternion.identity);
            }
        }
    }
	
	// Update is called once per frame
	void Update () {

	}
}
