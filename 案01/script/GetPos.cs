using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPos : MonoBehaviour {

    public Transform pos;
    Transform getcomp_pos;
	// Use this for initialization
	void Start () {
        getcomp_pos = GetComponent<Transform>();
        getcomp_pos.position = pos.position;
    }
	
	// Update is called once per frame
	void Update () {
	}
}
