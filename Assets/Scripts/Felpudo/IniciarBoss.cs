using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class IniciarBoss : MonoBehaviour
{
    [SerializeField]    GameObject _portao;
                        int _lesmas;
    [SerializeField]    GameObject _hazard;

    // Start is called before the first frame update
    void Start()
    {
        _portao.SetActive(true);
    }

    void Update()
    {
        _lesmas = _hazard.transform.childCount;

        Vector2 pos = new Vector2(60, transform.position.y);

        if (_lesmas == 0)
        {
            _portao.SetActive(false);
        }
    }
}
