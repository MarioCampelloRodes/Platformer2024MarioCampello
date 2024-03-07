using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    private PlayerHealthController _pCHRef;
    private LevelManager _lMRef;

    private void Start()
    {
        _pCHRef = GameObject.Find("Player").GetComponent<PlayerHealthController>();
        _lMRef = GameObject.Find("LevelManager").GetComponent<LevelManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _pCHRef.currentHealth = 0;
            _pCHRef.DealWithDamage();
            _lMRef.RespawnPlayer();
        }
    }
}
