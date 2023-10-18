using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CarrotHeight {
    High,
    Low,
}

public class Carrot : MonoBehaviour {

    #region Fields

    private float speed;

    #endregion

    #region MonoBehaviours

    void Update() {
        transform.position += new Vector3(-speed * Time.deltaTime, 0f, 0f);
        if (this.transform.position.x < -12f) {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player")) {            // Tag �񱳴� CompareTag�� ����ϴ� ���� �����ϴ�!
            Debug.Log("��");
            Destroy(this.gameObject);
        }
    }

    #endregion

    #region Initialize

    public void Initialize(CarrotHeight height, float speed) {
        this.transform.position = new(12f, height switch { CarrotHeight.High => 4f, CarrotHeight.Low => 1.05f, _ => 4f });      // height Ÿ�Կ� ���� 4f �Ǵ� 1.05f�� y���� ����.
        this.speed = speed;
    }

    #endregion

}