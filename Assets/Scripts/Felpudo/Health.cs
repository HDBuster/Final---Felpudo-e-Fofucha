using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
                        //Variáveis para Felpudo
    [HideInInspector]   public byte _health = 3;                                            //Vida
    [SerializeField]    TextMeshProUGUI _healthbar;                                         //Mostrar vida na UI

                        //Variáveis para pintar Felpudo
                        SpriteRenderer _spriteRenderer;                                     //SpriteRenderer
                        float _flashTime = .15f;                                            //Tempo para mudar a cor
                        Color _origColor;                                                   //Cor original

                        //Variáveis para controla tempo entre cada dano
    [SerializeField]    float _cooldownTime;                                                //Tempo configurável do temporizador
                        float _nextFireTime;
                        bool _isCoolingDown => Time.time < _nextFireTime;                   //Verifica se temporizador está ativo
                        void _startCooldown() => _nextFireTime = Time.time + _cooldownTime; //Recomeçar temporizador

    [SerializeField]    GameObject _vida1;
    [SerializeField]    GameObject _vida2;
    [SerializeField]    GameObject _vida3;
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
            _startCooldown();                                                       //Reiniciar temporizador
            Vida();
        }
        if ((other.CompareTag("Uruca") && _isCoolingDown == false) && _health > 0) // Verificar Tag, temporizador e se Felpudo ainda tem vidas
        {
            _health -= 3;                                                           //Diminuir vida
            FlashStart();                                                           //Piscar vermelho
            _healthbar.text = _health.ToString();                                   //Atualizar vida na UI
            SceneManager.LoadScene(2);
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

    private void Vida()
    {
        if (_health == 2)
        {
            _vida3.SetActive(false);
        }
        if (_health == 1)
        {
            _vida2.SetActive(false);
        }
        if (_health == 0)
        {
            SceneManager.LoadScene(2);
        }
    }
}
