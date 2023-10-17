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
        // 당근 높낮이에 따라 시작점이 다름
        if (type == 1)
        {
            // 평지에 있는 당근
            transform.position = new Vector3(12f, 1.05f, 0f);
        }
        else// if (type == 2)
        {
            // 점프하는 높이에 있는 당근
            transform.position = new Vector3(12f, 4f, 0f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(-speed, 0f, 0f);
        // 당근이 화면 왼쪽 밖으로 넘어가면
        if (transform.position.x < -12f)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            Debug.Log("냠");
            Destroy(gameObject);
        }
    }
}
