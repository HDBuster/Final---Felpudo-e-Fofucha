using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillUruca : MonoBehaviour
{
    int _urucaHealth = 3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Felpudo") && _urucaHealth > 1)
        {
            Rigidbody2D playerRB = other.GetComponent<Rigidbody2D>();   //Acessar Rigidbody de Felpudo
            playerRB.AddForce(Vector2.up * 2, ForceMode2D.Impulse);     //Felpudo terá um impulso para cima ao matar
            _urucaHealth -= 1;
        }
        else if (other.CompareTag("Felpudo") && _urucaHealth == 1)
        {
            Rigidbody2D playerRB = other.GetComponent<Rigidbody2D>();   //Acessar Rigidbody de Felpudo
            playerRB.AddForce(Vector2.up * 2, ForceMode2D.Impulse);     //Felpudo terá um impulso para cima ao matar
            this.transform.parent.gameObject.SetActive(false);
        }
    }
}
