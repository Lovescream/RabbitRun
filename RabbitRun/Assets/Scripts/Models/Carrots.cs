using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carrots : MonoBehaviour
{
    // 당근이 움직이는 속도, 1.5f 정도가 적당함
    public float carrotSpeed = 0.0f;
    // 당근 스폰 시작지점, 오른쪽 맨 끝은 (12, 1.05)
    public Vector2 StartPosition;

    private void OnEnable()
    {
        transform.position = StartPosition;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime * carrotSpeed);

        // 당근이 화면 밖으로 나가면 당근 오브젝트 비활성화
        if (transform.position.x < -12f)
        {
            gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D collision) {
        // ==== 토끼가 당근을 냠 했을 때 처리 ====

        // =======================================
    }
}
