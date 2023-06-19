using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sair : MonoBehaviour
{
    Button _button;
    // Start is called before the first frame update
    void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(Atuar);
    }

    void Atuar()
    {
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
