using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rabbit : MonoBehaviour {

    #region Inspector

    [Header("Rabbit Physics")]
    [SerializeField]
    [Tooltip("�䳢�� ���� ����")]
    private float jumpHeight;
    [SerializeField]
    [Tooltip("���� ���� ����")]
    private LayerMask groundLayer;

    #endregion

    #region Fields

    // States.
    private bool isJumping;
    private bool isGrounded;
    private Vector3 footPosition;



    // Components.
    private Rigidbody2D rigid;
    private BoxCollider2D boxCollider2D;
    private Animator animator;

    #endregion

    #region MonoBehaviours

    void Awake() {
        // Connect components.
        this.rigid = this.GetComponent<Rigidbody2D>();
        this.animator = this.GetComponent<Animator>();
        this.boxCollider2D = this.GetComponent<BoxCollider2D>();
    }

    void Update() {
        // ���� ���� ����
        Bounds bounds = boxCollider2D.bounds;
        footPosition = new Vector2(bounds.center.x, bounds.min.y);

        isGrounded = Physics2D.OverlapCircle(footPosition, 0.1f, groundLayer);

        if (isGrounded == true && Input.GetKeyDown(KeyCode.Space)) {
            // #1. ���� ���� �� �ִϸ��̼� ���� ����.
            isJumping = true;
            animator.SetBool("IsJump", true);

            // #2. �� �������� �� �ֱ�.
            //    ���� ���� ���Ŀ� ���ؼ� ��Ʈ2gH��ŭ �ָ� �� jumpHeight���� �ö󰡴µ�. �������� ���̹Ƿ� ForceMode2D�� Impulse.
            rigid.AddForce(Vector2.up * Mathf.Sqrt(2 * 9.8f * jumpHeight), ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        // ���� ��ü�� �±װ� Ground���,
        if (collision.transform.CompareTag("Ground")) {
            // ���� ���¶��,
            if (isJumping) {
                // #1. ���� ���� �� �ִϸ��̼� ���� ����.
                isJumping = false;
                animator.SetBool("IsJump", false);

                // #2. �ӵ� 0����.
                rigid.velocity = Vector2.zero;
            }
        }
    }




    #endregion

}