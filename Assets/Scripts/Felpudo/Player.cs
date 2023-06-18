using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    private Rigidbody2D _rb2d;  //Rigidbody
    float _scaleX;              //Escala para virar Felpudo ao andar em direção oposta

    public int _speed;          //Velocidade de movimento
    private Vector2 _movement;  //Movimento em Vector2
    private float _movx;        //Movimento de Vector2 (horizontal) para float
    public int _speedlimit;     //Limite de velocidade

    private bool _ground;       //Checar se Felpudo está no chão, usando Tags
    public int _jump;           //Altura do pulo

    void Start()
    {
       _rb2d = GetComponent<Rigidbody2D>();
       _scaleX = transform.localScale.x;
    }

    private void FixedUpdate() //Movimentação aqui
    {
        Vector2 move = new(_movx, 0);

        if (_rb2d.velocity.magnitude <= _speedlimit)
        {
            _rb2d.AddForce(move * _speed);
        }
    }

    public void OnMover(InputAction.CallbackContext context) //Registrar as teclas em um float e virar Felpudo ao teclar
    {
        _movement = context.ReadValue<Vector2>();
        _movx = _movement.x;
        Flip();
    }

    public void OnPular(InputAction.CallbackContext context) //Pulo
    {
        if (_ground)
        {
            _rb2d.AddForce(Vector2.up * _jump, ForceMode2D.Impulse);
        }
    }

    public void Flip() //Virar Felpudo
    {
        if (_movement.x > 0)
        {
            transform.localScale = new Vector3(_scaleX, transform.localScale.y, transform.localScale.z);
        }
        if (_movement.x < 0)
        {
            transform.localScale = new Vector3((-1) * _scaleX, transform.localScale.y, transform.localScale.z);
        }
    }

    private void OnTriggerExit2D(Collider2D other) //Detectar não colisão com o chão
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            _ground = false;
        }
    }

    private void OnTriggerStay2D(Collider2D other) //Manter colisão com o chão
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            _ground = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Hazard"))
        {
            var enemy = other.gameObject.GetComponent<Follow>();
            enemy.Dano();
        }
    }
}
