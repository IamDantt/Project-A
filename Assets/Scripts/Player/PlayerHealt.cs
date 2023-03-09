using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealt : MonoBehaviour
{

    [SerializeField] private float playerHealt = 100f;

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
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
        playerHealt -= damage;
        if (playerHealt <= 0)
        {
            animator.SetTrigger("Dead");
        }
    }

}
