using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed = 3f;

    //La barrabaja indica que la variable es privada
    private Rigidbody2D _playerRB;

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
        _playerRB.velocity = new Vector2(Input.GetAxis("Horizontal") * playerSpeed, _playerRB.velocity.y) ;
    }
}
