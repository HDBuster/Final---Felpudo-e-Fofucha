using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Health : MonoBehaviour
{
                        //Vari�veis para Felpudo
    [HideInInspector]   public byte _health = 3;                                            //Vida
    [SerializeField]    TextMeshProUGUI _healthbar;                                         //Mostrar vida na UI

                        //Vari�veis para pintar Felpudo
                        SpriteRenderer _spriteRenderer;                                     //SpriteRenderer
                        float _flashTime = .15f;                                            //Tempo para mudar a cor
                        Color _origColor;                                                   //Cor original

                        //Vari�veis para controla tempo entre cada dano
    [SerializeField]    float _cooldownTime;                                                //Tempo configur�vel do temporizador
                        float _nextFireTime;
                        bool _isCoolingDown => Time.time < _nextFireTime;                   //Verifica se temporizador est� ativo
                        void _startCooldown() => _nextFireTime = Time.time + _cooldownTime; //Recome�ar temporizador

    [HideInInspector]   public int _points;                                                 //Pontos
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();

        _origColor = _spriteRenderer.color;

        _healthbar.text = _health.ToString();
}

    private void OnTriggerStay2D(Collider2D other)
    {
        if ((other.CompareTag("Hazard") && _isCoolingDown == false) && _health > 0) // Verificar Tag, temporizador e se Felpudo ainda tem vidas
        {
            _health -= 1;                                                           //Diminuir vida
            FlashStart();                                                           //Piscar vermelho
            _healthbar.text = _health.ToString();                                   //Atualizar vida na UI
            _points += 10;
            _startCooldown();                                                       //Reiniciar temporizador
        }
    }

    void FlashStart()                                                               //Piscar vermelho
    {
        _spriteRenderer.color = Color.red;
        Invoke("FlashStop", _flashTime);
    }

    void FlashStop()                                                                //Parar de piscar, voltar a cor original
    {
        _spriteRenderer.color = _origColor;        
    }
}
