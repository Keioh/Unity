using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Load : MonoBehaviour
{
    public Object attack_object;


    // Start is called before the first frame update
    void Start()
    {
        //�U���I�u�W�F�N�g��ǂݍ��ށB
        attack_object = Resources.Load("Prefab/attack_object");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
