﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
    private Rigidbody2D rb2d;
    public float speed;
    public Text countText;
    public Text winText;
    private int count;
    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        count = 0;
        SetCountText();
        winText.text = "";
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2d.AddForce(movement * speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PickUp"))
        {
            collision.gameObject.SetActive(false);
            count++;
            SetCountText();
        }
    }

    private void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 12)
        {
            winText.text = "YOU WIN!!!";
        }
    }
}
