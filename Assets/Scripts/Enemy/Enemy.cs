using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float MaxEnemyHealth = 100f;
    public float currentEnemyHealth;

    public HealtBar healtBar;

    private Animator animator;

    public Transform player;

    public bool isFlipped = false;
        
    void Start()
    {
        animator = GetComponent<Animator>();
        currentEnemyHealth = MaxEnemyHealth;
        healtBar.SetMaxHealth(MaxEnemyHealth);
    }

    public void recibeDamage(float damage)
    {
        currentEnemyHealth -= damage;
        healtBar.SetHealt(currentEnemyHealth);
        if (currentEnemyHealth <= 0)
        {
            Dead();
        }
    }

    private void Dead()
    {
        animator.SetTrigger("Dead");
    }
    
    public void LookAtPlayer()
    {
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;

        if (transform.position.x > player.position.x && isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = false;
        }
        else if (transform.position.x < player.position.x && !isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = true;
        }
    }


}
