using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KIll : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Felpudo"))
        {
            Rigidbody2D playerRB = other.GetComponent<Rigidbody2D>();   //Acessar Rigidbody de Felpudo
            playerRB.AddForce(Vector2.up * 2, ForceMode2D.Impulse);     //Felpudo terá um impulso para cima ao matar
            Destroy(this.transform.parent.gameObject);                  //Destuir Lesmão atacado
        }
    }
}
