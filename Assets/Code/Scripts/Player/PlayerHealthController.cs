using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    [HideInInspector] public int currentHealth;
    public int maxHealth;

    private UIController _uIRef;

    private PlayerController _pCRef;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;

        _uIRef = GameObject.Find("Canvas").GetComponent<UIController>();

        _pCRef = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DealWithDamage()
    {
        currentHealth--;

        if (currentHealth <= 0)
        {
            currentHealth = 0; //Por si se queda en negativo
            gameObject.SetActive(false);
        }
        else
            _pCRef.Knockback();

        _uIRef.UpdateHealth();
    }
}
