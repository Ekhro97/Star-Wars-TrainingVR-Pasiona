using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float speed;
    public GameObject _bulletHole;

    private Vector3 velocity;
    private int n = 0;

    void Awake()
    {
        velocity = this.transform.forward;
    }


    void Update()
    {
        this.transform.position += velocity * Time.deltaTime * speed;
    }


    void OnCollisionEnter(Collision info)
    {
        //Debug.Log(info.gameObject.tag);
        //if ((info.gameObject.tag == "Player" || (info.gameObject.tag == "Room")) && (n < 10))
        //{
        //    n++;
        //    foreach (var contact in info.contacts)
        //    {
        //        velocity = Quaternion.AngleAxis(180, contact.normal) * transform.forward * -1;
        //    }
        //}
        //else
        //    Destroy(gameObject);
        if (info.gameObject.tag.Equals("Room"))
        {
            Instantiate(_bulletHole, transform.position, Quaternion.FromToRotation(Vector3.up, info.contacts[0].normal));
            Destroy(gameObject);
        }else if(info.gameObject.tag.Equals("Sword"))
        {
            n++;
            foreach (var contact in info.contacts)
            {
                velocity = Quaternion.AngleAxis(180, contact.normal) * transform.forward * -1;
            }
        }
    }
}
