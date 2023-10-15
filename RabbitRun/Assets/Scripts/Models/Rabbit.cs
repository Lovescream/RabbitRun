using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rabbit : MonoBehaviour {

    #region Inspector

    [Header("Rabbit Physics")]
    [SerializeField]
    [Tooltip("토끼의 점프 높이")]
    private float jumpHeight;
    [SerializeField]
    [Tooltip("무한 점프 방지")]
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
        // 무한 점프 방지
        Bounds bounds = boxCollider2D.bounds;
        footPosition = new Vector2(bounds.center.x, bounds.min.y);

        isGrounded = Physics2D.OverlapCircle(footPosition, 0.1f, groundLayer);

        if (isGrounded == true && Input.GetKeyDown(KeyCode.Space)) {
            // #1. 상태 변경 및 애니메이션 상태 변경.
            isJumping = true;
            animator.SetBool("IsJump", true);

            // #2. 위 방향으로 힘 주기.
            //    대충 물리 공식에 의해서 루트2gH만큼 주면 딱 jumpHeight까지 올라가는듯. 순간적인 힘이므로 ForceMode2D는 Impulse.
            rigid.AddForce(Vector2.up * Mathf.Sqrt(2 * 9.8f * jumpHeight), ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        // 닿은 물체의 태그가 Ground라면,
        if (collision.transform.CompareTag("Ground")) {
            // 점프 상태라면,
            if (isJumping) {
                // #1. 상태 변경 및 애니메이션 상태 변경.
                isJumping = false;
                animator.SetBool("IsJump", false);

                // #2. 속도 0으로.
                rigid.velocity = Vector2.zero;
            }
        }
    }




    #endregion

}