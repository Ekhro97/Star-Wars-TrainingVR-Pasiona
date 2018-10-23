using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthBehavior : MonoBehaviour {

    [SerializeField]
    private float _maxHealth;

    [SerializeField]
    private float _currentHealth;

    [SerializeField]
    private float damageBloodAmount = 3; //amount of blood when taking damage (relative to damage taken (relative to HP remaining))
    [SerializeField]
    private float maxBloodIndication = 0.5f; //max amount of blood when not taking damage (relative to HP lost)

    private void Awake()
    {

        _currentHealth = _maxHealth;

    }

    void Update()
    {

            //BleedBehavior.minBloodAmount = maxBloodIndication * (_maxHealth - _currentHealth) / _maxHealth;
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

            BleedBehavior.BloodAmount += Mathf.Clamp01(damageBloodAmount * damage / _currentHealth);

        }

        if(_currentHealth == 0 || _currentHealth < 0)
        {

            SceneManager.LoadScene("Menu_Scene");

            BleedBehavior.BloodAmount = 0;

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
