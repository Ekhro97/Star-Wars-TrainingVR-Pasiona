using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavior : MonoBehaviour
{
    #region Public Variables

    public float Damage
    {
        get { return _damage; }
        set { _damage = value; }
    }

    #endregion

    #region Private Variables

    [SerializeField]
    private GameObject _player;

    [SerializeField]
    private float _speed;

    [SerializeField]
    private float _minMovingTime;

    [SerializeField]
    private float _maxMovingTime;

    [SerializeField]
    private GameObject _bullet;

    [SerializeField]
    private GameObject _bulletSpawn;

    [SerializeField]
    private float _damage;

    private AudioController audioController;

    private RealSpace3D.RealSpace3D_AudioSource sound;

    #endregion

    #region Main Methods

    private void Awake()
    {

        audioController = FindObjectOfType<AudioController>();

        sound = GetComponent<RealSpace3D.RealSpace3D_AudioSource>();

        sound.rsAudioClips.Insert(0,audioController.DroneShot);

    }

    private void Start()
    {

        StartCoroutine(RandomWait());

    }

    IEnumerator RandomWait()
    {
        while (true)
        {

            float elapsedTime = 0f;

            System.Random random = new System.Random();

            int orientation = (random.Next(0, 2));

            double movingTime = UnityEngine.Random.Range(_minMovingTime, _maxMovingTime);

            while (elapsedTime < movingTime)
            {

                if(orientation == 1)
                {

                    transform.RotateAround(_player.transform.position, Vector3.up, _speed * Time.fixedDeltaTime);

                }
                else
                {

                    transform.RotateAround(_player.transform.position, Vector3.down, _speed * Time.fixedDeltaTime);

                }

                elapsedTime += Time.deltaTime;

                yield return null;

            }

            PlaySound();

            yield return new WaitForSeconds(GetComponent<RealSpace3D.RealSpace3D_AudioSource>().rs3d_GetClipLength() - 0.5f);

            Fire();

        }

    }

    private void PlaySound()
    {

        GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.red * 0.5f);

        sound.rs3d_AdjustVolume(sound.rs3d_GetVolume() * audioController.masterVolume);

        sound.rs3d_PlaySound(0);

    }

    void Fire()
    {
        
        var bullet = (GameObject)Instantiate(_bullet,_bulletSpawn.transform.position,_bulletSpawn.transform.rotation);

        // Add velocity to the bullet
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 6;

        // Destroy the bullet after 2 seconds
        Destroy(bullet, 10.0f);

        GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.red * 0);

    }


    #endregion

}
