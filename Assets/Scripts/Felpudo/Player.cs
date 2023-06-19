using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
                        Rigidbody2D _rb2d;  //Rigidbody
                        SpriteRenderer _spriteRenderer;
                        float _scaleX;      //Escala para virar Felpudo ao andar em direção oposta

    [SerializeField]    int _speed;         //Velocidade de movimento
                        Vector2 _movement;  //Movimento em Vector2
                        float _movx;        //Movimento de Vector2 (horizontal) para float
    [SerializeField]    int _speedlimit;    //Limite de velocidade

                        bool _ground;       //Checar se Felpudo está no chão
    [SerializeField]    int _jump;          //Altura do pulo

    [SerializeField] TextMeshProUGUI _UIPontos;

    public GameObject _prefab;
    void Start()
    {
       _rb2d = GetComponent<Rigidbody2D>();
       _scaleX = transform.localScale.x;
       _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate() //Movimentação aqui
    {
        Vector2 move = new(_movx, 0);

        if (_rb2d.velocity.magnitude <= _speedlimit)
        {
            _rb2d.AddForce(move * _speed);
        }

        _UIPontos.text = _prefab.GetComponentInChildren<KIll>()._points.ToString();
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
            //transform.localScale = new Vector3(_scaleX, transform.localScale.y, transform.localScale.z);
            _spriteRenderer.flipX = false;
        }
        if (_movement.x < 0)
        {
            //transform.localScale = new Vector3((-1) * _scaleX, transform.localScale.y, transform.localScale.z);
            _spriteRenderer.flipX = true;
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
}
