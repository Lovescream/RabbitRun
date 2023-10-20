using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Squirrel : MonoBehaviour
{

    #region Fields

    private float speed;

    #endregion

    #region MonoBehaviours

    void Update()
    {
        transform.position += new Vector3(-speed * Time.deltaTime, 0f, 0f);
        if (this.transform.position.x < -12f)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {            // Tag �񱳴� CompareTag�� ����ϴ� ���� �����ϴ�!
            Debug.Log("���");
            GameManager.Instance.gameOver();
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