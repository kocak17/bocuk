using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private BoxCollider2D boxCollider;

    public float Speed = 5f;

    public Rigidbody2D rb;
    public Animator animator;
    private RaycastHit2D hit;
    private Vector3 moveDelta; 

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", x);
        animator.SetFloat("Vertical", y);
        animator.SetFloat("Speed", moveDelta.sqrMagnitude);


        // Reset moveDelta
        moveDelta = new Vector3(x, y, 0);

        //bu ne mk
        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(0, moveDelta.y), Mathf.Abs(moveDelta.y * Time.deltaTime), LayerMask.GetMask("Bug", "Blocking"));
        if (hit.collider == null)
        {
            // Move
            transform.Translate(0, moveDelta.y * Time.deltaTime * Speed, 0);
        }
        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(moveDelta.x, 0), Mathf.Abs(moveDelta.x * Time.deltaTime), LayerMask.GetMask("Bug", "Blocking"));
        if (hit.collider == null)
        {
            // Move
            transform.Translate(moveDelta.x * Time.deltaTime * Speed, 0, 0);
        }
    }
}
