using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallelBackground : MonoBehaviour
{
    [SerializeField]
    private Transform target;          // ���� ���� �̾��� ���
    [SerializeField]
    private float scrollAmount;        // �̾����� �� ��� ������ �Ÿ�. (��� 1�� x��ǥ - ��� 2�� x��ǥ)�� ���񰪺��� ���� ����(0.05����) ������ ƴ�� �Ȼ���
    [SerializeField]
    private float moveSpeed;           // �̵� �ӵ�
    [SerializeField]
    private Vector3 moveDirection;     // �̵� ����

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        // ����� moveDirection �������� moveSpeed�� �ӵ��� �̵�
        transform.position += moveDirection * moveSpeed * Time.deltaTime;

        // ����� ���� ������ ����� ��ġ �缳��, ���� ��� ����
        if (transform.position.x <= -scrollAmount)
        {
            transform.position = target.position - moveDirection * scrollAmount;
        }
    }
}
