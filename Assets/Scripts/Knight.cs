using System;
using UnityEngine;

public class Knight : MonoBehaviour
{
    Rigidbody2D rb2d;
    TouchObject touchObject;
    Animator animator;
    Damageable damageable;
    public DetectionZone attackZone;
    public float walkSpeed = 3f;
    public float walkStopRate = 0.05f;
    public bool facingRight = true;
    public enum WalkableDirection {Right, Left}
    private WalkableDirection _walkDirection;
    private Vector2 WalkDirectionVector = Vector2.right;

    public WalkableDirection WalkDirection {

        get { return _walkDirection; }
        set { 
            if(_walkDirection != value) {
                gameObject.transform.localScale = new Vector2(gameObject.transform.localScale.x * -1, gameObject.transform.localScale.y);

                if(value == WalkableDirection.Right) {
                    WalkDirectionVector = Vector2.right;

                } else if(value == WalkableDirection.Left) {
                    WalkDirectionVector = Vector2.left;
                }
            }
            
            _walkDirection = value; }
    }

    public bool _hasTarget = false;

    public bool HasTarget { 
        get { 
            return _hasTarget; 

        } private set {
            _hasTarget = value;
            animator.SetBool("HasTarget", value);
        } 
    }

    public bool CanMove {
        get {
            return animator.GetBool("canMove");
        }
    }

    public float AttackCooldown {
        get
        {
            return animator.GetFloat("AttackCooldown");
        } private set
        {
            animator.SetFloat("AttackCooldown", Mathf.Max(value, 0));
        } }

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        touchObject = GetComponent<TouchObject>();
        animator = GetComponent<Animator>();
        damageable = GetComponent<Damageable>();
    }

    void Update()
    {
        HasTarget = attackZone.detectColliders.Count > 0;

        if (AttackCooldown > 0)
        {
            AttackCooldown -= Time.deltaTime;
        }
        
    }

    void FixedUpdate()
    {
        if(touchObject.IsGround && touchObject.IsOnWall) {

            FlipSprite();

        }

        if(!damageable.LockVelocity) {
            if(CanMove) {
                rb2d.linearVelocity = new Vector2(walkSpeed * WalkDirectionVector.x, rb2d.linearVelocity.y);

            }else {
                rb2d.linearVelocity = new Vector2(Mathf.Lerp(rb2d.linearVelocity.x, 0, walkStopRate), rb2d.linearVelocity.y);
            }
        }
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Turn"))
        {
            FlipSprite();
        }
    }

    private void FlipSprite()
    {

        if (WalkDirection == WalkableDirection.Right)
        {

            WalkDirection = WalkableDirection.Left;

        }
        else if (WalkDirection == WalkableDirection.Left)
        {

            WalkDirection = WalkableDirection.Right;
        }

    }

    public void OnHit(int damage, Vector2 knockback) {

        rb2d.linearVelocity = new Vector2(knockback.x, rb2d.linearVelocity.y + knockback.y);
    }
}
