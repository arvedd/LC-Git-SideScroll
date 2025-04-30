using UnityEngine;

public class Knight : MonoBehaviour
{

    public float walkSpeed = 3f;
    Rigidbody2D rb2d;
    public enum WalkableDirection {Right, Left}
    private WalkableDirection _walkDirection;
    private Vector2 WalkDirectionVector;

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


    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rb2d.linearVelocity = new Vector2(walkSpeed * Vector2.right.x, rb2d.linearVelocity.y);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
