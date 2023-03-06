using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instans : MonoBehaviour
{
    public GameObject instansObject;
    public GameObject Object;

    duplicationPosition dPosion;

    // Start is called before the first frame update
    void Start()
    {
        dPosion = instansObject.GetComponent<duplicationPosition>();

        dPosion.Add(Object, new Vector3(0.5f, 0.0f, 0.0f));
        dPosion.Add(Object, new Vector3(-0.5f, 0.0f, 0.0f));
        dPosion.Add(Object, new Vector3(0.0f, 0.0f, 0.5f));
        dPosion.Add(Object, new Vector3(0.0f, 0.0f, -0.5f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateFiled()
    {
        Debug.Log("OK");
    }
}
