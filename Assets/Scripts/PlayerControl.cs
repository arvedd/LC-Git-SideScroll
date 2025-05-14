using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D), typeof(TouchObject))]
public class PlayerControl : MonoBehaviour
{
    Vector2 moveInput;
    TouchObject touchObject;
    Rigidbody2D rb2d;
    Animator animator;
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

    }

    void FixedUpdate() {

        rb2d.linearVelocity = new Vector2(moveInput.x * moveSpeed, rb2d.linearVelocity.y);
        
        if(moveInput.x > 0 && !facingRight) {
            FlipSprite();

        }else if(moveInput.x < 0 && facingRight) {
            FlipSprite();

        } 
    }

    public void OnMove(InputAction.CallbackContext context) {
          moveInput = context.ReadValue<Vector2>();

          IsMoving = moveInput != Vector2.zero;
        
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

    void FlipSprite() {

        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;

        facingRight = !facingRight;
    }
}