using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackScript : MonoBehaviour
{
    private float attackDelay;
    public float startatkDelay;

    public Transform attackPos;
    public LayerMask whatIsEnemies;
    public float attackRange;

    // Update is called once per frame
    void Start()
    {
        //anim = gameObject.GetComponent<Animation>();
    }
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Attack();
        }
    }

    void Attack()
    {
            attackDelay = startatkDelay;
            Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
            foreach(Collider2D enemy in enemiesToDamage)
            {
                Debug.Log("We hit " + enemy.name);
                enemy.gameObject.SendMessage("DealDamage", 50);
            }
    }

    
    void OnDrawGizmosSelected()
    {
        if(attackPos == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}
