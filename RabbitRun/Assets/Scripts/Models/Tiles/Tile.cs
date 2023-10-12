using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour {

    #region Fields

    private TileGroup group;
    private float speed;

    #endregion

    void Update() {
        // 왼쪽으로 조금 이동.
        this.transform.position += Vector3.left * speed * Time.deltaTime;
        // 왼쪽 경계를 넘었으면, 오른쪽 경계로 이동 후 넘은 만큼 재이동.
        if (this.transform.position.x <= group.MinX - 1) {
            float x = group.MaxX + this.transform.position.x - (group.MinX - 1);
            this.transform.position = new(x, this.transform.position.y);
        }
    }

    public void Initialize(TileGroup group, Sprite sprite, float speed) {
        // Group으로부터 Sprite, 속력 정보를 받아 초기화 진행.
        this.group = group;
        this.transform.GetComponent<SpriteRenderer>().sprite = sprite;
        this.speed = speed;
    }
}