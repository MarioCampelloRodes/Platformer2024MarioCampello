using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StompBox : MonoBehaviour
{
    private PlayerController _pCRef;
    // Start is called before the first frame update
    void Start()
    {
        _pCRef = GetComponentInParent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<EnemyDeath>().EnemyDeathController();
            _pCRef.Bounce();
        }
    }
}
