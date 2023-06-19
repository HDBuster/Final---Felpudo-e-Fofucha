using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controles : MonoBehaviour
{
    [SerializeField]    GameObject _controles;
    [SerializeField]    GameObject _principal;
                        Button _button;

    // Start is called before the first frame update
    void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(Atuar);
    }

    private void Atuar()
    {
        _principal.SetActive(false);
        _controles.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
