using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float strength = 1;

    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
          
            if(GameManager.Instance.gameOn == false)
            {
                GameManager.Instance.gameOn = true;
                Time.timeScale = 1;
                GameManager.Instance.spaceToStartText.gameObject.SetActive(false);
            }
            //rb.AddForce(new Vector2(0, strength), ForceMode2D.Impulse);
            rb.velocity = Vector2.up * strength;
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag != "Coin")
        {
            GameManager.Instance.OnGameOver();
        }
        
    }
}
