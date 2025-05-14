using UnityEngine;

public class Knight : MonoBehaviour
{
    Rigidbody2D rb2d;
    TouchObject touchObject;
    Animator animator;
    public DetectionZone attackZone;
    public float walkSpeed = 3f;
    public float walkStopRate = 0.02f;
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

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        touchObject = GetComponent<TouchObject>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        HasTarget = attackZone.detectColliders.Count > 0;
    }

    void FixedUpdate()
    {
        if(touchObject.IsGround && touchObject.IsOnWall) {

            FlipSprite();

        }

        if(CanMove) {
            rb2d.linearVelocity = new Vector2(walkSpeed * WalkDirectionVector.x, rb2d.linearVelocity.y);

        }else {
            rb2d.linearVelocity = new Vector2(Mathf.Lerp(rb2d.linearVelocity.x, 0, walkStopRate), rb2d.linearVelocity.y);
        }
    }

    private void FlipSprite() {

        if(WalkDirection == WalkableDirection.Right) {

            WalkDirection = WalkableDirection.Left;

        } else if(WalkDirection == WalkableDirection.Left) {

            WalkDirection = WalkableDirection.Right;
        }
    
    }
}
