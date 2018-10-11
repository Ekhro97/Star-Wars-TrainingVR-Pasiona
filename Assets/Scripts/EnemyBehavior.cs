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
            StartCoroutine(Move(elapsedTime));

            yield return new WaitForSeconds(_chargeShotTime);


            Debug.Log("Pim");
        }
        
        


    }

    IEnumerator Move(float elapsedTime)
    {
        System.Random random = new System.Random();
        int orientation = random.Next(0, 2);
        while (elapsedTime < Random.Range(_minMovingTime, _maxMovingTime))
        {
            

            OrbitAround(orientation);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }

    private void OrbitAround(int orientation)
    {
        System.Random random = new System.Random();
        if(orientation == 1)
        {
            transform.RotateAround(_player.transform.position, Vector3.up, _speed * Time.deltaTime);
        }
        else
        {
            transform.RotateAround(_player.transform.position, Vector3.down, _speed * Time.deltaTime);
        }
            
    }

    #endregion

}
