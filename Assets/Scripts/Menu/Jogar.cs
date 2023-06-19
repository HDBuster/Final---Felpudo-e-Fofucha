using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Jogar : MonoBehaviour
{

    Button _button;
    void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(Cena);
    }
    private void Cena()
    {
        SceneManager.LoadScene(1);
    }
}
