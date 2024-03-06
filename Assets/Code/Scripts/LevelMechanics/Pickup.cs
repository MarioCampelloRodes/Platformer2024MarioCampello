using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public bool isGem, isHeal;

    private bool _isCollected;

    public GameObject pickupEffect;

    private LevelManager _lMRef;
    private UIController _uIRef;
    private PlayerHealthController _pHCRef;
    // Start is called before the first frame update
    private void Start()
    {
        _lMRef = GameObject.Find("LevelManager").GetComponent<LevelManager>();

        _uIRef = GameObject.Find("Canvas").GetComponent<UIController>();

        _pHCRef = GameObject.Find("Player").GetComponent<PlayerHealthController>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !_isCollected)
        {
            if (isGem)
            {
                _lMRef.gemCount += 100;
                _uIRef.UpdateGemCount();
                _isCollected = true;
                Instantiate(pickupEffect, transform.position, transform.rotation);
                Destroy(gameObject);
            }

            if (isHeal && _pHCRef.currentHealth < _pHCRef.maxHealth)
            {
                _pHCRef.HealPlayer();
                Destroy(gameObject);
            }
        }
    }
}
