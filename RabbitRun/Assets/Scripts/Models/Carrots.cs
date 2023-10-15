using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carrots : MonoBehaviour
{
    // ����� �����̴� �ӵ�, 1.5f ������ ������
    public float carrotSpeed = 0.0f;
    // ��� ���� ��������, ������ �� ���� (12, 1.05)
    public Vector2 StartPosition;

    private void OnEnable()
    {
        transform.position = StartPosition;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime * carrotSpeed);

        // ����� ȭ�� ������ ������ ��� ������Ʈ ��Ȱ��ȭ
        if (transform.position.x < -12f)
        {
            gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D collision) {
        // ==== �䳢�� ����� �� ���� �� ó�� ====

        // =======================================
    }
}
