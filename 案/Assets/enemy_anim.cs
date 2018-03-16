using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_anim : MonoBehaviour {

    Transform trns;

	// Use this for initialization
	void Start () {
        trns = GetComponent<Transform>();
	}

    // Update is called once per frame
    void Update()
    {
        trns.position += new Vector3(Random.Range(-0.01f, 0.01f), Random.Range(-0.01f, 0.01f), Random.Range(-0.01f, 0.01f));
    }
}
