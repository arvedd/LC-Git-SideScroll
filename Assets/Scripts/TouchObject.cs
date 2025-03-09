using NUnit.Framework;
using UnityEngine;

public class TouchObject : MonoBehaviour
{
    public ContactFilter2D castFilter;
    public float groundDistance = 0.05f;
    CapsuleCollider2D touchingCol;
    Animator animator;
    RaycastHit2D[] hitGround = new RaycastHit2D[5];

    [SerializeField]
    private bool _isGround;

    public bool IsGround { get {
        return _isGround;

    } private set {
        _isGround = value;
        animator.SetBool("IsGround", value);

    } }

    private void Awake() {
        touchingCol = GetComponent<CapsuleCollider2D>();
        animator = GetComponent<Animator>();

    }

    void FixedUpdate() {
        IsGround = touchingCol.Cast(Vector2.down, castFilter, hitGround, groundDistance) > 0;
    }
}
