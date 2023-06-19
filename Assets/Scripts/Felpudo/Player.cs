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
    [HideInInspector]   public Rigidbody2D _rb2d;       //
                        SpriteRenderer _spriteRenderer; //

    [SerializeField]    float _speed;                     //Velocidade de movimento
                        Vector2 _movement;              //Movimento em Vector2
                        float _movx;                    //Movimento de Vector2 (horizontal) para float
    [SerializeField]    float _speedlimit;                //Limite de velocidade

                        bool _ground;                   //Checar se Felpudo est� no ch�o
    [SerializeField]    float _jump;                      //Altura do pulo

    public GameObject _prefab;

    Animator _animator;
    void Start()
    {
       _rb2d = GetComponent<Rigidbody2D>();
       _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }

    private void FixedUpdate() //Movimenta��o aqui
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

        switch (context.phase)
        {
            case InputActionPhase.Performed: //Enquanto a segurar o clique, ative
                _animator.SetTrigger("Mover");
                break;
            case InputActionPhase.Started: //Quando clicar, ative
                _animator.SetTrigger("Mover");
                break;
            case InputActionPhase.Canceled: //Quando n�o estiver clicando, desative
                _animator.SetTrigger("Idle");
                break;
        }
    }

    public void OnPular(InputAction.CallbackContext context) //Pulo
    {
        if (_ground)
        {
            _rb2d.AddForce(Vector2.up * _jump, ForceMode2D.Impulse);
            switch (context.phase)
            {
                case InputActionPhase.Performed: //Enquanto a segurar o clique, ative
                    _animator.SetTrigger("Jump");
                    break;
                case InputActionPhase.Started: //Quando clicar, ative
                    _animator.SetTrigger("Jump");
                    break;
                case InputActionPhase.Canceled: //Quando n�o estiver clicando, desative
                    _animator.SetTrigger("Idle");
                    break;
            }

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

    private void OnTriggerExit2D(Collider2D other) //Detectar n�o colis�o com o ch�o
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            _ground = false;
        }
    }

    private void OnTriggerStay2D(Collider2D other) //Manter colis�o com o ch�o
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            _ground = true;
        }
    }
}
