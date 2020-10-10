using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackObjectMove : MonoBehaviour
{
    //飛翔速度
    public float velocity = 25.0f;

    bool flag = true;

    //プレイヤーオブジェクト
    GameObject player;

    Rigidbody2D rigidbody_2d;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");

        rigidbody_2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (flag == true)
        {
            if (player.transform.eulerAngles.y == 0)
            {
                rigidbody_2d.velocity = new Vector2(velocity, 0.0f);
            }

            if (player.transform.eulerAngles.y == 180)
            {
                rigidbody_2d.velocity = new Vector2(-velocity, 0.0f);
            }

            flag = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            Destroy(this.gameObject);
        }
    }
}
