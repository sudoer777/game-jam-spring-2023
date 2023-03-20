using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MidBoss : Script.Enemies.Enemy
{
    public float detectionRange;
    public Transform attackPoint;
    public float attackRange;
    public float attackDmg;
    public LayerMask playerLayer;
    public float attackDelay;
    public Animator animator;

    private float attackTimer;
    private Transform target;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    override protected void StartEnemy()
    {
        target = GameObject.Find("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        attackTimer = 0;
    }

    // Update is called once per frame
    override protected void UpdateEnemy()
    {
        if(attackTimer >= attackDelay)
        {
            if (target.position.x > transform.position.x - detectionRange && target.position.x < transform.position.x + detectionRange)
            {
                if (target.position.y < transform.position.y + detectionRange && target.position.y > transform.position.y - detectionRange)
                {
                    Attack();
                    attackTimer = 0;
                }
            }
        }
        attackTimer += Time.deltaTime;
    }

    private void Attack()
    {
        animator.SetTrigger("Attack");
        Collider2D[] hitPlayers = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayer);

        foreach(Collider2D player in hitPlayers)
        {
            player.gameObject.SendMessage("DealDamage", attackDmg);
            Debug.Log("Player hit by midboss");
        }
    }

    private void OnDrawGizmosSelected()
    {
        if(attackPoint == null)
        {
            return;
        }

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
