using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavior : MonoBehaviour
{

    #region Public Variables


    #endregion

    #region Private Variables
    [SerializeField]
    private GameObject _player;
    [SerializeField]
    private float _speed;
    [SerializeField]
    private float _chargeShotTime;
    [SerializeField]
    private float _minMovingTime;
    [SerializeField]
    private float _maxMovingTime;
    [SerializeField]
    private GameObject _bullet;
    [SerializeField]
    private GameObject _bulletSpawn;



    #endregion

    #region Main Methods

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
            double movingTime = Random.Range(_minMovingTime, _maxMovingTime);

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
            Debug.Log("Pim");
            Fire();
            yield return new WaitForSeconds(_chargeShotTime);
            

        }
    }

    void Fire()
    {
        var bullet = (GameObject)Instantiate(_bullet,_bulletSpawn.transform.position,_bulletSpawn.transform.rotation);

        // Add velocity to the bullet
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 6;

        // Destroy the bullet after 2 seconds
        Destroy(bullet, 2.0f);
    }


    #endregion

}
