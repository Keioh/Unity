using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_anim : MonoBehaviour {

    public float power;
    Transform trns;

	// Use this for initialization
	void Start ()
    {
        trns = GetComponent<Transform>();
	}

    // Update is called once per frame
    void Update()
    {
        trns.Translate(Random.Range(-power, power), Random.Range(-power, power), Random.Range(-power, power));
    }
}
