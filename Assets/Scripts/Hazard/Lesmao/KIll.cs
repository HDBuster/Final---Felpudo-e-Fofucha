using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KIll : MonoBehaviour
{
    public int _points = 1; //Pontos

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Felpudo"))
        {
            _points = _points + 10;
            Rigidbody2D playerRB = other.GetComponent<Rigidbody2D>();   //Acessar Rigidbody de Felpudo
            playerRB.AddForce(Vector2.up * 2, ForceMode2D.Impulse);     //Felpudo terá um impulso para cima ao matar
            //Destroy(this.transform.parent.gameObject);                  //Destuir Lesmão atacado
            this.transform.parent.gameObject.SetActive(false);
        }
    }
}
