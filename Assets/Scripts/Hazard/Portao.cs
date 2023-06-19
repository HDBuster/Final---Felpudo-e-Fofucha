using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Portao : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Felpudo")){
            this.gameObject.SetActive(false);
        }
    }
}
