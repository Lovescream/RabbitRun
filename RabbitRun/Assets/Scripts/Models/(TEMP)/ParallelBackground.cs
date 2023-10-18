using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallelBackground : MonoBehaviour
{
    [SerializeField]
    private Transform target;          // 현재 배경과 이어질 배경
    [SerializeField]
    private float scrollAmount;        // 이어지는 두 배경 사이의 거리. (배경 1의 x좌표 - 배경 2의 x좌표)의 절댓값보다 아주 조금(0.05정도) 작으면 틈이 안생김
    [SerializeField]
    private float moveSpeed;           // 이동 속도
    [SerializeField]
    private Vector3 moveDirection;     // 이동 방향

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        // 배경이 moveDirection 방향으로 moveSpeed의 속도로 이동
        transform.position += moveDirection * moveSpeed * Time.deltaTime;

        // 배경이 설정 범위를 벗어나면 위치 재설정, 무한 배경 연결
        if (transform.position.x <= -scrollAmount)
        {
            transform.position = target.position - moveDirection * scrollAmount;
        }
    }
}
