using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour {

    [SerializeField]
    private float speed;

    [SerializeField]
    private GameObject _bulletHole;

    private Vector3 _velocity;

    private HealthBehavior _healthBehavior;

    private EnemyBehavior _enemyBehavior;

    private AudioSource _audioSource;

    private AudioController _audioController;

    void Awake()
    {

        _audioSource = GetComponent<AudioSource>();

        _audioController = FindObjectOfType<AudioController>();

        _audioSource.clip = _audioController.SaberStrike;

        _audioSource.volume = _audioSource.volume * _audioController.masterVolume;

        _velocity = this.transform.forward;

        _healthBehavior = FindObjectOfType<HealthBehavior>();

        _enemyBehavior = FindObjectOfType<EnemyBehavior>();

    }


    void Update()
    {

        this.transform.position += _velocity * Time.deltaTime * speed;

    }


    void OnCollisionEnter(Collision info)
    {
        if (info.gameObject.tag.Equals("Room"))
        {

            Instantiate(_bulletHole, new Vector3(transform.position.x, transform.position.y - 0.35f, transform.position.z), Quaternion.FromToRotation(Vector3.up, info.contacts[0].normal));

            Destroy(gameObject);

        }
        else if(info.gameObject.tag.Equals("Sword"))
        {

            foreach (var contact in info.contacts)
            {

                _velocity = Quaternion.AngleAxis(180, contact.normal) * transform.forward * -1;

            }

            if (info.collider.gameObject.name == "Lightsaber_R")
            {

                StartCoroutine(Vibrate(true));

            }
            else if (info.collider.gameObject.name == "Lightsaber_L")
            {

                StartCoroutine(Vibrate(false));

            }

            _audioSource.Play();

        }
        else
        {

            Destroy(gameObject);

            _healthBehavior.DecreaseHealth(_enemyBehavior.Damage);
            
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

