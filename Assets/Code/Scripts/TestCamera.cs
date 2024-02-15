using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCamera : MonoBehaviour
{
    public Transform target;

    //Referencias a las posiciones de los fondos
    public Transform farBackground, middleBackground;

    public float minHeight, maxHeight;
    //Última posición en X que tuvo el jugador
    private float _lastXPos;

    //Última posición en X que tuvo el jugador
    private float _lastYPos;
    // Start is called before the first frame update
    void Start()
    {
        _lastXPos = target.position.x;

        _lastYPos = target.position.y;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);

        //Variable para conocer cuanto hay que moverse en X
        float _amountToMoveX = target.position.x - _lastXPos;

        //Variable para conocer cuanto hay que moverse en X
        float _amountToMoveY = target.position.y - _lastYPos;

        //Restricción entre un mínimo y un máximo para la cámara en y
        transform.position = new Vector3(target.position.x, Mathf.Clamp(transform.position.y, minHeight, maxHeight), transform.position.z);

        farBackground.position += new Vector3(_amountToMoveX, 0f, 0f);
        middleBackground.position += new Vector3(_amountToMoveX * 0.5f, _amountToMoveY * -0.01f, 0f);

        //Actualizamos la posición del jugador
        _lastXPos = target.position.x;
        _lastYPos = target.position.y;
    }
}
