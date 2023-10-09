using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rabbit : MonoBehaviour {

    #region Inspector

    [Header("Rabbit Physics")]
    [SerializeField]
    [Tooltip("�䳢�� ���� ����")]
    private float jumpHeight;

    #endregion

    #region Fields

    // States.
    private bool isJumping;

    // Components.
    private Rigidbody2D rigid;
    private Animator animator;

    #endregion

    #region MonoBehaviours

    void Awake() {
        // Connect components.
        this.rigid = this.GetComponent<Rigidbody2D>();
        this.animator = this.GetComponent<Animator>();
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
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