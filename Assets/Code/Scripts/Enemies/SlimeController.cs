using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeController : MonoBehaviour
{
    public float slimeSpeed;
    public Transform maxLeft, maxRight;
    public bool movingRight;

    private Rigidbody2D _rBRef;
    private SpriteRenderer _sRRef;
    // Start is called before the first frame update
    void Start()
    {
        _rBRef = GetComponent<Rigidbody2D>();
        _sRRef = GetComponentInChildren<SpriteRenderer>();

        maxLeft.parent = null;
        maxRight.parent = null;

        movingRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (movingRight)
        {
            _rBRef.velocity = new Vector2(slimeSpeed, _rBRef.velocity.y);
            _sRRef.flipX = true;

            if (transform.position.x >= maxRight.position.x)
            {
                movingRight = false;
            }
        }
        else
        {
            _rBRef.velocity = new Vector2(-slimeSpeed, _rBRef.velocity.y);
            _sRRef.flipX = false;

            if (transform.position.x <= maxLeft.position.x)
            {
                movingRight = true;
            }
        }

        
    }
}
