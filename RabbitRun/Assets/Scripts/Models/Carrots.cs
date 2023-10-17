using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class Carrots : MonoBehaviour
{
    public Vector2 size;
    public LayerMask whatIsLayer;

    // ����� �����̴� �ӵ�, 1.5f ������ ������
    public float carrotSpeed = 0.0f;
    // ��� ���� ��������, ������ �� ���� (12, 1.05)
    public Vector2[] StartPosition = new Vector2[2];
    Vector2 TemPosition;

    private void OnEnable()
    {
        int index = Random.Range(0, StartPosition.Length);
        transform.position = StartPosition[index];
        TemPosition = StartPosition[index];
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

        //if (hit.name == "Carrot(Clone)");
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, size);
    }

    void OnTriggerEnter2D(Collider2D collision) {
        // ==== �䳢�� ����� �� ���� �� ó�� ====

        Collider2D[] hit = Physics2D.OverlapBoxAll(transform.position, size, 0, whatIsLayer);
        Debug.Log(hit);
        transform.position = TemPosition;

        // =======================================
    }
}
