using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public float rota_speed = 10.0f;
    public GameObject mid;
    public GameObject front;

    Ray gear_ray;
    RaycastHit gear_hit;

    bool flag;

    // Use this for initialization
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        //Mouse position and position transform
        float mouseX_buf = 0.0f;
        float mouse_x = Input.mousePosition.x;
        float mouse_y= Input.mousePosition.y;
        Vector3 mouse_pos = Camera.main.ScreenToWorldPoint(new Vector3(mouse_x, mouse_y, 0.0f));

        //Transform
        Transform gear_transform = GetComponent<Transform>();

        //collision
        Collider gear_collider = GetComponent<Collider>();

        gear_ray.origin = new Vector3(mouse_pos.x, mouse_pos.y, mouse_pos.z);
        gear_ray.direction = new Vector3(0.0f, 0.0f, 1.0f);


        mouseX_buf += -Input.GetAxis("MouseX") * rota_speed;

        if (gear_collider.Raycast(gear_ray, out gear_hit, 100F) == true)
        {
            if (Input.GetMouseButton(0))
            {
                Debug.Log("Gear click");
                flag = true;
            }
            else
            {
                flag = false;
            }
        }else if((gear_collider.Raycast(gear_ray, out gear_hit, 100F) == false) && (Input.GetMouseButton(0) == false))
        {
            flag = false;
        }

        if (flag == true)
        {
            gear_transform.Rotate(0.0f, 0.0f, mouseX_buf);
            mid.transform.Rotate(0.0f, 0.0f, mouseX_buf);
            front.transform.Rotate(0.0f, 0.0f, mouseX_buf);
        }
    }
}