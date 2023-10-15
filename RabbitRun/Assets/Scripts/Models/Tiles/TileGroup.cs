using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGroup : MonoBehaviour {

    #region Inspector

    [Header("Tiles")]
    [SerializeField]
    private List<Sprite> sprites = new();

    [Header("Scrolling")]
    [SerializeField]
    private float scrollingRatio;

    #endregion

    #region Properties

    public float MinX { get; private set; }
    public float MaxX { get; private set; }

    #endregion


    private List<Tile> tiles = new();

    void Awake() {
        MinX = float.MaxValue;
        MaxX = float.MinValue;
        for (int i = 0; i < this.transform.childCount; i++) {
            Tile tile = this.transform.GetChild(i).GetComponent<Tile>();
            tiles.Add(tile);
            tile.Initialize(this, sprites[i % sprites.Count], scrollingRatio);

            float x = tile.transform.position.x;
            if (x < MinX) MinX = x;
            if (x > MaxX) MaxX = x;
        }
    }
}