using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Thunder : MonoBehaviour
{

    #region Fields

    // Status.
    private float speed;


    #endregion

    #region MonoBehaviours

    void Update()
    {
        if (GameManager.Instance.IsOver) return;
        transform.position += new Vector3(-speed * Time.deltaTime, 0f, 0f);
        if (this.transform.position.x < -12f)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {            // Tag 비교는 CompareTag를 사용하는 것이 낫습니다!
            Debug.Log("번개 맞고 쥬금");
            GameManager.Instance.GameOver();
        }
    }

    #endregion

    #region Initialize

    public void Initialize(float speed)
    {
        this.speed = speed;
    }

    #endregion


}