using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Script.Enemies
{
    public abstract class Enemy : MonoBehaviour
    {
        public float HP;
        public GameObject explosion;
    
        private const float maxHP = 100;

        protected abstract void StartEnemy();
        protected abstract void UpdateEnemy();
    
        // Start is called before the first frame update
        void Start()
        {
            HP = maxHP;
            StartEnemy();
        }
    
        // Update is called once per frame
        void Update()
        {
            //destroy enemy if health falls below 0
            if (HP <= 0)
            {
                Instantiate(explosion, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            UpdateEnemy();
        }
    
        public void DealDamage(float damage)
        {
            HP -= damage;
        }
    }
}

