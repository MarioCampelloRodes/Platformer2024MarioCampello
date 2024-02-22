using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed = 3f;

    public float playerJumpForce = 10f;

    public float knockbackForce = 3f;

    public float knockbackCounterLength;
    private float _knockbackCounter;

    //La barrabaja indica que la variable es privada
    private bool _isGrounded;

    private bool _isWalledLeft, _isWalledRight;

    private int _jumpNumber = 0;
    
    private Rigidbody2D _playerRB;

    public Transform groundPoint;

    public Transform wallPointLeft, wallPointRight;

    public LayerMask whatIsGround;

    public LayerMask whatIsWall;

    //Referencia al Sprite Rendeder
    private SpriteRenderer _playerSpriteRenderer;
    //Referencia al Animator
    private Animator _anim;

    // Start is called before the first frame update
    void Start()
    {
        //Inicializamos el Rigidbody
        _playerRB = GetComponent<Rigidbody2D>();

        //Inicializamos el animator del jugador y el Sprite Renderer
        _anim = GetComponent<Animator>();

        _playerSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //Si el contador de knockback se ha vaciado, el jugador recupera el control
        if (_knockbackCounter <= 0)
        {
            //Movimiento
            _playerRB.velocity = new Vector2(Input.GetAxis("Horizontal") * playerSpeed, _playerRB.velocity.y);

            //¿Está en el suelo?
            _isGrounded = Physics2D.OverlapCircle(groundPoint.position, 0.2f, whatIsGround);

            //¿Está tocando la pared?
            _isWalledLeft = Physics2D.OverlapCircle(wallPointLeft.position, 0.2f, whatIsWall);

            _isWalledRight = Physics2D.OverlapCircle(wallPointRight.position, 0.2f, whatIsWall);

            //Modo Dios
            //_playerRB.velocity = new Vector2(Input.GetAxis("Horizontal") * playerSpeed, Input.GetAxis("Vertical") * playerSpeed);

            //Salto
            if (Input.GetButtonDown("Jump") && _isGrounded)
            {
                _playerRB.velocity = new Vector2(_playerRB.velocity.x, playerJumpForce);
            }
            //Doble Salto
            else if (Input.GetButtonDown("Jump") && _jumpNumber == 0)
            {
                _playerRB.velocity = new Vector2(_playerRB.velocity.x, playerJumpForce);
                _jumpNumber++;
            }
            //Salto de Pared
            if (Input.GetButtonDown("Jump") && _isWalledRight)
            {
                _playerRB.velocity = new Vector2(-10f * playerJumpForce, 5f * playerJumpForce);
            }
            if (Input.GetButtonDown("Jump") && _isWalledLeft)
            {
                _playerRB.velocity = new Vector2(10f * playerJumpForce, 2f * playerJumpForce);
            }

            //Cambio de dirección del sprite
            if (_playerRB.velocity.x < 0)
            {
                _playerSpriteRenderer.flipX = false;
            }
            else if (_playerRB.velocity.x > 0)
            {
                _playerSpriteRenderer.flipX = true;
            }
        }
        else
        {
            _knockbackCounter -= Time.deltaTime;

            if (!_playerSpriteRenderer.flipX)
            {
                _playerRB.velocity = new Vector2(knockbackForce, _playerRB.velocity.y);
            }
            else
            {
                _playerRB.velocity = new Vector2(-knockbackForce, _playerRB.velocity.y);
            }
        }
        //Reseteo de Saltos
        if (_isGrounded)
        {
            _jumpNumber = 0;
        }

        //Animaciones
        _anim.SetBool("isGrounded", _isGrounded);

        //Math.Abs devuelve el absoluto de una variable
        _anim.SetFloat("MoveSpeed", Mathf.Abs(_playerRB.velocity.x));
    }

    public void Knockback()
    {
        _knockbackCounter = knockbackCounterLength;

        _playerRB.velocity = new Vector2(0f, knockbackForce);
        _anim.SetTrigger("IsHurt");
    }
}
