using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))] // memastikan objek game sudah punya komponen Rigidbody2D kalo ga kaga bisa dipake scriptnya
public class PlayerControl : MonoBehaviour
{
    Vector2 moveInput;
    Rigidbody2D rb2d;
    Animator animator;
    public float walkSpeed = 5f;
    public float runSpeed = 8f;
    public bool facingRight = true;

    [SerializeField]
    private bool _isMoving = false;

    [SerializeField]
    private bool _isRunning = false;

    public float CurrentSpeed {
        
        get {

            if(IsRunning) {
                return runSpeed;

            }else {
                return walkSpeed;
            }
    }}

    public bool IsMoving { get {

        return _isMoving;

    }private set {
        _isMoving = value;
        animator.SetBool("IsMoving", value);
    } 
    }

    public bool IsRunning {
        
        get {
            return _isRunning;

        } set {
            _isRunning = value;
            animator.SetBool("IsRunning", value);

        }  }

    void Awake() {

        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void FixedUpdate() {

        rb2d.linearVelocity = new Vector2(moveInput.x * CurrentSpeed, rb2d.linearVelocity.y);

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

    public void OnRun(InputAction.CallbackContext context) {

        if(context.started) {
            IsRunning = true;

        }else if(context.canceled) {
            IsRunning = false;
        }
    }  

    void FlipSprite() {

        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;

        facingRight = !facingRight;
    }
}