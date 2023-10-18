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
        if (collision.gameObject.CompareTag("Player")) {            // Tag 비교는 CompareTag를 사용하는 것이 낫습니다!
            Debug.Log("냠");
            Destroy(this.gameObject);
        }
    }

    #endregion

    #region Initialize

    public void Initialize(CarrotHeight height, float speed) {
        this.transform.position = new(12f, height switch { CarrotHeight.High => 4f, CarrotHeight.Low => 1.05f, _ => 4f });      // height 타입에 따라 4f 또는 1.05f의 y값을 가짐.
        this.speed = speed;
    }

    #endregion

}