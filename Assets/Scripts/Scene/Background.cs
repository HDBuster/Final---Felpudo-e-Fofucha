using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Background : MonoBehaviour
{
    [Range(-1f,1f)]
    public float Speed;
    private float offset;
    private Material mat;

    public Player player;

    public GameObject objplayer;

    private void Start()
    {
        mat = GetComponent<Renderer>().material;
    }

    void Update()
    {

        if (player._rb2d.velocity.x > 0)
        {
            offset -= (Time.deltaTime * Speed) / 10;
        }
        if (player._rb2d.velocity.x < 0)
        {
            offset += (Time.deltaTime * Speed) / 10;
        }

        mat.SetTextureOffset("_MainTex", new Vector2(offset, 0));

        this.transform.position = new Vector2(objplayer.transform.position.x,this.transform.position.y);
    }

}
