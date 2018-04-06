using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParticle : MonoBehaviour
{

    public GameObject particle_object;
    List<GameObject> copy = new List<GameObject>();

    Transform transform;
    Vector3 began_position, ended_position, object_position;

    // Use this for initialization
    void Start()
    {
        transform = GetComponent<Transform>();
        began_position = ended_position = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        copy.Add(Instantiate(particle_object, transform.position, Quaternion.identity) as GameObject);
    }
}

