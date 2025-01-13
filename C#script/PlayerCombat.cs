using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    
    public Animator animator;

    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public float fireRate = 0.2f;
    public float nextFireRate = 0.0f;
    public int attackDamage = 40;

    void Start()
    {
         animator= gameObject.GetComponent<Animator>();
    }
    void Update()
{
          if(Input.GetKey(KeyCode.P) && Time.time > nextFireRate)
          {
            nextFireRate = Time.time + fireRate;
            animator.SetBool("Attack",true);
            Attack();
        }else{
            animator.SetBool("Attack",false);
        }
}

void Attack()
{
       animator.SetTrigger("Attack");
       Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position,attackRange, enemyLayers);
       foreach(Collider2D enemy in hitEnemies)
       {
        enemy.GetComponent<Enemy>().TakeDamage(attackDamage);

 }
}
void OnDrawGizmosSelected()
{
    if (attackPoint == null)
    return;

    Gizmos.DrawWireSphere(attackPoint.position, attackRange);
}
}