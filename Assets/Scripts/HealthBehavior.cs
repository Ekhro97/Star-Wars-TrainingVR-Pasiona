using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthBehavior : MonoBehaviour {

    [SerializeField]
    private float _maxHealth;

    [SerializeField]
    private float _currentHealth;

    private void Awake()
    {

        _currentHealth = _maxHealth;

    }

    /// <summary>
    /// Disminuye la vida actual.
    /// </summary>
    /// <param name="damage">P que reducir</param>
    public void DecreaseHealth(float damage)
    {

        if (_currentHealth > 0)
        {

            _currentHealth -= damage;

        }

        if(_currentHealth == 0)
        {

            SceneManager.LoadScene("Menu_Scene");

        }

    }

    /// <summary>
    /// Recupera vida.
    /// </summary>
    /// <param name="hpToIncrease">Vida que aumentar</param>
    public void IncreaseHealth(float hpToIncrease)
    {

        _currentHealth = Mathf.Min(_currentHealth + hpToIncrease, _maxHealth);

    }

}
