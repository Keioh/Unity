using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour {

    public GameObject obj;
    //public int volume;

	// Use this for initialization
	void Start () {
        //volum = 1;

        Transform pos = GetComponent<Transform>();
        for(int n = 0; n < 1; n++)
        {
            for (int u = 0; u < 200; u++)
            {
                Instantiate(obj, obj.transform.position = new Vector3(n + pos.transform.position.x, u + pos.transform.position.y), Quaternion.identity);
            }
        }
    }
	
	// Update is called once per frame
	void Update () {

	}
}
