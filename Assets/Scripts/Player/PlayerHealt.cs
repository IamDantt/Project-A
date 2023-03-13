using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealt : MonoBehaviour
{

    public float maxHealth = 100f;
    public float currentHealt;

    public HealtBar healtBar;

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        currentHealt = maxHealth;
        healtBar.SetMaxHealth(maxHealth);
    }


    // Update is called once per frame
    void Update()
    {
        /*if (playerHealt <= 0)
        {
            
        } */   
    }

    public void recibeDamage(float damage)
    {
        currentHealt -= damage;
        healtBar.SetHealt(currentHealt);
        if (currentHealt <= 0)
        {
            animator.SetTrigger("Dead");
        }
    }

}
