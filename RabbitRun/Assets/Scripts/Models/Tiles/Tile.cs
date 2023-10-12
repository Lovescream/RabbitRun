using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour {

    #region Fields

    private TileGroup group;
    private float speed;

    #endregion

    void Update() {
        // �������� ���� �̵�.
        this.transform.position += Vector3.left * speed * Time.deltaTime;
        // ���� ��踦 �Ѿ�����, ������ ���� �̵� �� ���� ��ŭ ���̵�.
        if (this.transform.position.x <= group.MinX - 1) {
            float x = group.MaxX + this.transform.position.x - (group.MinX - 1);
            this.transform.position = new(x, this.transform.position.y);
        }
    }

    public void Initialize(TileGroup group, Sprite sprite, float speed) {
        // Group���κ��� Sprite, �ӷ� ������ �޾� �ʱ�ȭ ����.
        this.group = group;
        this.transform.GetComponent<SpriteRenderer>().sprite = sprite;
        this.speed = speed;
    }
}