using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float speed;

    private Vector3 velocity;
    private int n = 0;

    void Awake()
    {
        velocity = this.transform.forward;
        speed = 10;
    }


    void Update()
    {
        this.transform.position += velocity * Time.deltaTime * speed;
    }


    void OnCollisionEnter(Collision info)
    {
        Debug.Log(info.gameObject.tag);
        if ((info.gameObject.tag == "Player" || (info.gameObject.tag == "Room")) && (n < 10))
        {
            n++;
            foreach (var contact in info.contacts)
            {
                velocity = Quaternion.AngleAxis(180, contact.normal) * transform.forward * -1;
            }
        }
        else
            Destroy(gameObject);
    }
}
