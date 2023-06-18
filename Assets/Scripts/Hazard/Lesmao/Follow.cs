using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class Follow : MonoBehaviour
{
    public float _speed;                                //Velocidade
    private Transform _target;                          //Alvo

    private Rigidbody2D _rb2d;                          //Rigidbody

    [SerializeField] SpriteRenderer spriteRenderer;     //Renderizador do sprite
    void Start()
    {
        _target = FindObjectOfType<Player>().transform; //Pegar posição do player
        _rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 position = new(_target.position.x, transform.position.y);
        _rb2d.position = Vector2.MoveTowards(transform.position, position, _speed * Time.deltaTime);//Mover-se até player

        Vector2 direction = (_target.position - transform.position).normalized;
        spriteRenderer.flipX = direction.x < 0;                                                     //Virar-se ao player
    }

    public void Dano()
    {
        Destroy(this.gameObject);
    }
}
