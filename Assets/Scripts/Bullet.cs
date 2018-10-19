using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float speed;
    public GameObject _bulletHole;

    private Vector3 velocity;

    private AudioSource sound;
    private AudioController audioController;

    void Awake()
    {
        sound = GetComponent<AudioSource>();
        audioController = FindObjectOfType<AudioController>();

        sound.clip = audioController.SaberStrike;
        sound.volume = sound.volume * audioController.masterVolume;

        velocity = this.transform.forward;
    }


    void Update()
    {
        this.transform.position += velocity * Time.deltaTime * speed;
    }


    void OnCollisionEnter(Collision info)
    {
        if (info.gameObject.tag.Equals("Room"))
        {
            Instantiate(_bulletHole, transform.position, Quaternion.FromToRotation(Vector3.up, info.contacts[0].normal));
            Destroy(gameObject);
        }else if(info.gameObject.tag.Equals("Sword"))
        {

            foreach (var contact in info.contacts)
            {
                velocity = Quaternion.AngleAxis(180, contact.normal) * transform.forward * -1;
            }

            if (info.collider.gameObject.name == "Lightsaber_R")
            {
                StartCoroutine(Vibrate(true));
            }
            else if (info.collider.gameObject.name == "Lightsaber_L")
            {
                StartCoroutine(Vibrate(false));
            }

            sound.Play();
        }
    }

    IEnumerator Vibrate(bool v)
    {
        if (v)
        {
            OVRInput.SetControllerVibration(0.4f, 0.4f, OVRInput.Controller.RTouch);
            yield return new WaitForSeconds(0.2f);
            OVRInput.SetControllerVibration(0.0f, 0.0f, OVRInput.Controller.RTouch);
        }
        else
        {
            OVRInput.SetControllerVibration(0.4f, 0.4f, OVRInput.Controller.LTouch);
            yield return new WaitForSeconds(0.2f);
            OVRInput.SetControllerVibration(0.0f, 0.0f, OVRInput.Controller.LTouch);
        }
    }
}
