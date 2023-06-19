using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillUruca : MonoBehaviour
{
    int _urucaHealth = 3;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Felpudo") && _urucaHealth > 1)
        {
            Rigidbody2D playerRB = other.GetComponent<Rigidbody2D>();   //Acessar Rigidbody de Felpudo
            playerRB.AddForce(Vector2.left * 4, ForceMode2D.Impulse);     //Felpudo terá um impulso para cima ao matar
            _urucaHealth -= 1;
        }
        else if (other.CompareTag("Felpudo") && _urucaHealth == 1)
        {
            Rigidbody2D playerRB = other.GetComponent<Rigidbody2D>();   //Acessar Rigidbody de Felpudo
            playerRB.AddForce(Vector2.left * 2, ForceMode2D.Impulse);     //Felpudo terá um impulso para cima ao matar
            SceneManager.LoadScene(3);
        }
    }
}
