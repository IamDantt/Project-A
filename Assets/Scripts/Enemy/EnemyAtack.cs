using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAtack : MonoBehaviour
{
    [SerializeField] private Transform HitControl;
    [SerializeField] private float HitRadius;
    [SerializeField] private float HitDamage;

    /*[Header("Atack")]
    [SerializeField] private float _timeCanAtack;
    [SerializeField] private float _nextAtack;*/

    //private Animator animator;

    private void Start()
    {
        //animator = GetComponent<Animator>();
    }

    private void Update()
    {
        
    }
    public void EnemyHit()
    {
        //animator.SetTrigger("Ataking");
        //animator.SetTrigger("EnemyHit");
        /*if (_nextAtack > 0)
        {
            _nextAtack -= Time.deltaTime;
        }
        if (_nextAtack <= 0)
        {

            _nextAtack = _timeCanAtack;
        }*/
        Collider2D[] objetos = Physics2D.OverlapCircleAll(HitControl.position, HitRadius);

            foreach (Collider2D colisionador in objetos)
            {
                if (colisionador.CompareTag("Player"))
                {
                    colisionador.transform.GetComponent<PlayerHealt>().recibeDamage(HitDamage);
                }
            }
        

    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(HitControl.position, HitRadius);
    }
}
