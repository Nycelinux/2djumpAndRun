using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Player_Life : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;

    private void Start()
    {
        rb= GetComponent<Rigidbody2D>();
        animator =GetComponent<Animator>();  
    }

   private void OnCollisionEnter2D(Collision2D collision)
   {
        if (collision.gameObject.CompareTag("Trap"))
        {
            Die();
        }
   }

    private void Die()
    {
        rb.bodyType = RigidbodyType2D.Static;
        animator.SetTrigger("death");
      
        

    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
