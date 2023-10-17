using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carrot : MonoBehaviour
{
    int type;
    public float speed = 0.015f;
    // Start is called before the first frame update
    void Start()
    {
        type = Random.Range(1, 3);
        // ��� �����̿� ���� �������� �ٸ�
        if (type == 1)
        {
            // ������ �ִ� ���
            transform.position = new Vector3(12f, 1.05f, 0f);
        }
        else// if (type == 2)
        {
            // �����ϴ� ���̿� �ִ� ���
            transform.position = new Vector3(12f, 4f, 0f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(-speed, 0f, 0f);
        // ����� ȭ�� ���� ������ �Ѿ��
        if (transform.position.x < -12f)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            Debug.Log("��");
            Destroy(gameObject);
        }
    }
}
