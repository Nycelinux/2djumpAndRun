using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemCollector : MonoBehaviour
{
    private int cherries;
    public TextMeshProUGUI scoreText;

    void Update()
    {
        scoreText.text = "Score: " + cherries.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Cherry"))
        {
            Destroy(collision.gameObject);
            cherries++;
            Debug.Log("Cherries: " + cherries); 
        }
    }
}
