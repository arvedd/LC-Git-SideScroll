using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))] // memastikan objek game sudah punya komponen Rigidbody2D kalo ga kaga bisa dipake scriptnya
public class PlayerControl : MonoBehaviour
{
    Vector2 moveInput;
    Rigidbody2D rb2d;
    Animator animator;
    public InputAction playerMove;
    public float runSpeed = 7f;
    public bool facingRight = true;

    private void OnEnable()
    {
        playerMove.Enable();
    }

    private void OnDisable()
    {
        playerMove.Disable();
    }

    void Awake() {

        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

    }

    void Start()
    {
        
    }

    void Update()
    {
        moveInput = playerMove.ReadValue<Vector2>();
        
        if(moveInput.x != 0) {
            animator.SetBool("IsMoving", true);

        }else {
            animator.SetBool("IsMoving", false);
        }
    }

    void FixedUpdate() {

        rb2d.linearVelocity = new Vector2(moveInput.x * runSpeed, rb2d.linearVelocity.y);

        if(moveInput.x > 0 && !facingRight) {
            FlipSprite();

        }else if(moveInput.x < 0 && facingRight) {
            FlipSprite();

        } 
    }

    void FlipSprite() {

        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;

        facingRight = !facingRight;
    }
}