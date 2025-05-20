using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D), typeof(TouchObject))]
public class PlayerControl : MonoBehaviour
{
    Vector2 moveInput;
    TouchObject touchObject;
    Rigidbody2D rb2d;
    Animator animator;
    Damageable damageable;
    public float moveSpeed = 7f;
    public bool facingRight = true;
    public float jumpImpulse = 5f;


    public float CurrentMove {

        get {
            if(IsMoving && !touchObject.IsOnWall) {
                return moveSpeed;

            } else {
                
                return 0;
            }
        }
    }


    [SerializeField]
    private bool _isMoving = false;

    public bool IsMoving {get {
        return _isMoving;

    } private set {
        _isMoving = value;
        animator.SetBool("IsMoving", value);

    }}

    public bool CanMove { get {
        return animator.GetBool("canMove");

    }}

    void Awake() {

        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        touchObject = GetComponent<TouchObject>();
        damageable = GetComponent<Damageable>();
    }

    void FixedUpdate() {

        if(!damageable.LockVelocity) {
            rb2d.linearVelocity = new Vector2(moveInput.x * moveSpeed, rb2d.linearVelocity.y);
        }
        
        
        animator.SetFloat("yVelocity", rb2d.linearVelocity.y);
    }

    private void FacingDirection(Vector2 moveInput) {

        if(moveInput.x > 0 && !facingRight) {
            FlipSprite();

        }else if(moveInput.x < 0 && facingRight) {
            FlipSprite();

        } 
    }

    public void OnMove(InputAction.CallbackContext context) {
          moveInput = context.ReadValue<Vector2>();

        if(IsAlive) {
            IsMoving = moveInput != Vector2.zero;
            FacingDirection(moveInput);
        }else {
            IsMoving = false;
        }
          
        
    }

    public void OnJump(InputAction.CallbackContext context) {
        
        if(context.started && touchObject.IsGround && CanMove) {
            animator.SetTrigger("Jump");
            rb2d.linearVelocity = new Vector2(moveInput.x, jumpImpulse);

        }
    }

    public void OnAttack(InputAction.CallbackContext context) {
        
       if(context.started) { 
            animator.SetTrigger("attack");
    
       }
    }

    public bool IsAlive {
        get {
            return animator.GetBool("IsAlive");
        }
    }
    
    void FlipSprite() {

        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;

        facingRight = !facingRight;
    }

    public void OnHit(int damage, Vector2 knockback) {

        rb2d.linearVelocity = new Vector2(knockback.x, rb2d.linearVelocity.y + knockback.y);
    }
}