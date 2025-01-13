using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour

{
    public int maxHealth = 100;
    public int currentHealth;
    public Animator animator;

   void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
    currentHealth -= damage;
    animator.SetTrigger("Hurt");

    if(currentHealth <= 0)
    {
        Die();
    }
    }
    void Die()
    {
        Debug.Log("Enemy died!");
        animator.SetBool("Death", true);
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }

}
