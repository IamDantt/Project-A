using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] float speed;
    [SerializeField] float JumpForce;
    public int JumpMax;
    public LayerMask capaSuelo;

    private Rigidbody2D Myrigidbody;
    private BoxCollider2D boxCollider;
    private bool lookRight = true;
    private Animator animator;
    private int JumpRest;
    private float _baseGravity;

    [Header("Dash")]
    [SerializeField] private float _dashingTime = 0.2f;
    [SerializeField] private float _timeCanDash = 1f;
    [SerializeField] private float _dahsForce = 20f;
    
    [SerializeField]private bool _isDashing;
    [SerializeField]private bool _CanDash = true;


    private void Awake()
    {
        Myrigidbody = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
        JumpRest = JumpMax;
        _baseGravity = Myrigidbody.gravityScale;
    }
            
    void Update()
    {
        if (_isDashing == false)
        {
            movePlayer();
            Jump();
        }       
    }

    void movePlayer()
    {
        float inputMove = Input.GetAxis("Horizontal");

        if (inputMove != 0)
        {
            animator.SetBool("IsRuning", true);
        }
        else
        {
            animator.SetBool("IsRuning", false);
        }

        Orientation(inputMove);
        Myrigidbody.velocity = new Vector2(inputMove * speed, Myrigidbody.velocity.y);

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            StartCoroutine(Dash(inputMove));
        }
                
    }

    private IEnumerator Dash(float inputMove)
    {
        if (inputMove != 0 && _CanDash == true)
        {
            _CanDash = false;
            _isDashing = true;            
            Myrigidbody.gravityScale = 0f;
            Myrigidbody.velocity = new Vector2(inputMove * _dahsForce, 0f);
            yield return new WaitForSeconds(_dashingTime);            
            Myrigidbody.gravityScale = _baseGravity;
            _isDashing = false;
            yield return new WaitForSeconds(_timeCanDash);
            _CanDash = true;
        }
        
    }

    void Orientation(float inputMove)
    {
        if (lookRight == true && inputMove <0 || lookRight == false && inputMove > 0)
        {
            lookRight = !lookRight;
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        }
    }

    bool IsGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, new Vector2(boxCollider.bounds.size.x, boxCollider.bounds.size.y), 0f, Vector2.down, 0.1f, capaSuelo);
        return raycastHit.collider != null;
    }

    void Jump()
    {
        if (IsGrounded())
        {
            JumpRest = JumpMax;
        }
        if (Input.GetKeyDown(KeyCode.Space) && JumpRest > 0)
        {
            JumpRest--;
            Myrigidbody.velocity = new Vector2(Myrigidbody.velocity.x, 0f);
            Myrigidbody.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
        }
    }
        
}
