using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    [HideInInspector] public int currentHealth;
    public int maxHealth;

    public float invincibleCounterLength = 1;
    private float _invincibleCounter;

    private UIController _uIRef;

    private PlayerController _pCRef;

    private Rigidbody2D _rBRef;

    private SpriteRenderer _spriteRendererRef;

    private LevelManager _lMRef;

    private Animator _animRef;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;

        _uIRef = GameObject.Find("Canvas").GetComponent<UIController>();

        _pCRef = GetComponent<PlayerController>();

        _rBRef = GetComponent<Rigidbody2D>();

        _spriteRendererRef = GetComponent<SpriteRenderer>();

        _lMRef = GameObject.Find("LevelManager").GetComponent<LevelManager>();

        _animRef = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_invincibleCounter > 0)
        {
            _invincibleCounter -= Time.deltaTime;
            _spriteRendererRef.color = new Color(255f, 127f, 127f, 0.7f);
        }
        else
        {
            _spriteRendererRef.color = Color.white;
        }

        if(currentHealth <= 0)
        {
            Death();
        }
    }

    public void DealWithDamage()
    {
        if(_invincibleCounter <= 0)
        {
            currentHealth--;

            if (currentHealth <= 0)
            {
                currentHealth = 0; //Por si se queda en negativo

                Death();
            }
            else
            {
                _invincibleCounter = invincibleCounterLength;

                _spriteRendererRef.color = new Color(255f, 127f, 127f, 0.7f);

                _pCRef.Knockback();

                _pCRef.jumpNumber = 0;
            }
            _uIRef.UpdateHealth();
        }
    }

    private void Death()
    {
        StartCoroutine("DeathCO");
    }

    private IEnumerator DeathCO()
    {
        _pCRef.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, _pCRef.gameObject.GetComponent<Rigidbody2D>().velocity.y);

        yield return new WaitUntil(() =>_pCRef.isGrounded);

        _animRef.SetTrigger("IsDeath");

        yield return new WaitForSeconds(1f);

        _lMRef.RespawnPlayer();
    }
}
