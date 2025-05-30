using NUnit.Framework;
using UnityEngine;

public class TouchObject : MonoBehaviour
{
    public ContactFilter2D castFilter;
    public float groundDistance = 0.05f;
    public float wallDistance = 0.2f;
    public float ceilingDistance = 0.05f;
    CapsuleCollider2D touchingCol;
    Animator animator;
    RaycastHit2D[] hitGround = new RaycastHit2D[5];
    RaycastHit2D[] hitWall = new RaycastHit2D[5];
    RaycastHit2D[] hitCeiling = new RaycastHit2D[5];

    [SerializeField]
    private bool _isGround;

    public bool IsGround { get {
        return _isGround;

    } private set {
        _isGround = value;
        animator.SetBool("IsGround", value);

    } }

    [SerializeField]
    private bool _isOnWall;

    public bool IsOnWall { get {
        return _isOnWall;

    } private set {
        _isOnWall = value;
        animator.SetBool("IsOnWall", value);

    } }

    [SerializeField]
    private bool _isOnCeiling;
    private Vector2 wallCheckDirection => gameObject.transform.localScale.x > 0 ? Vector2.right : Vector2.left;

    public bool IsOnCeiling { get {
        return _isOnCeiling;

    } private set {
        _isOnCeiling = value;
        animator.SetBool("IsOnCeiling", value);

    } }


    private void Awake() {
        touchingCol = GetComponent<CapsuleCollider2D>();
        animator = GetComponent<Animator>();

    }

    void FixedUpdate() {
        IsGround = touchingCol.Cast(Vector2.down, castFilter, hitGround, groundDistance) > 0;
        IsOnWall = touchingCol.Cast(wallCheckDirection, castFilter, hitWall, wallDistance) > 0;
        IsOnCeiling = touchingCol.Cast(Vector2.up, castFilter, hitCeiling, ceilingDistance) > 0;
    }
}
