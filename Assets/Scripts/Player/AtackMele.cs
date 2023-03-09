using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtackMele : MonoBehaviour
{
    [SerializeField] private Transform HitControl;
    [SerializeField] private float HitRadius;
    [SerializeField] private float HitDamage;

    [Header("Atack")]
    [SerializeField] private float _timeCanAtack;
    [SerializeField] private float _nextAtack;

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (_nextAtack > 0)
        {
            _nextAtack -= Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.I) && _nextAtack <= 0)
        {            
            _nextAtack = _timeCanAtack;
            Hit();
        }
    }
    void Hit()
    {
        animator.SetTrigger("Ataking");

        Collider2D[] objetos = Physics2D.OverlapCircleAll(HitControl.position, HitRadius);

        foreach (Collider2D  colisionador in objetos)
        {
            if (colisionador.CompareTag("Enemy"))
            {
               colisionador.transform.GetComponent<Enemy>().recibeDamage(HitDamage);
            }
        }      
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(HitControl.position, HitRadius);
    }

}
