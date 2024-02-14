using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed = 3f;

    public float playerJumpForce = 10f;

    private bool _isGrounded = false;

    //La barrabaja indica que la variable es privada
    private Rigidbody2D _playerRB;

    public Transform groundPoint;

    public LayerMask whatIsGround;

    Vector2 direction;
    // Start is called before the first frame update
    void Start()
    {
        //Inicializamos el Rigidbody
        _playerRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Movimiento
        _playerRB.velocity = new Vector2(Input.GetAxis("Horizontal") * playerSpeed, _playerRB.velocity.y);


        //¿Está en el suelo?
        _isGrounded = Physics2D.OverlapCircle(groundPoint.position, 0.2f, whatIsGround);
        //Modo Dios
        //_playerRB.velocity = new Vector2(Input.GetAxis("Horizontal") * playerSpeed, Input.GetAxis("Vertical") * playerSpeed);

        //Salto
        if (Input.GetButtonDown("Jump") && _isGrounded)
        {
            _playerRB.velocity = new Vector2(_playerRB.velocity.x, playerJumpForce);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}
