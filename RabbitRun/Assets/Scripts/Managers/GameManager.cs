using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    #region Singleton

    private static GameManager instance;
    public static GameManager Instance {
        get {
            if (instance == null) instance = FindAnyObjectByType<GameManager>();
            return instance;
        }
    }

    #endregion

    #region Inspector

    [Header("Game Parameters")]
    [SerializeField]
    [Tooltip("진행 속도")]
    private float scrollSpeed;
    [SerializeField]
    [Tooltip("빨라지는 배율")]
    private float scrollSpeedRatio;
    [SerializeField]
    [Tooltip("점수 배율: 진행 시간에 곱하여 점수가 계산됨.")]
    private float scoreBonus;

    #endregion

    #region Properties

    public float ScrollSpeed => scrollSpeed + (Score / 100) * scrollSpeedRatio;     // 점수 100점마다 빨라짐.

    public float Score => playTime * scoreBonus;

    #endregion

    #region Fields

    private float playTime;

    #endregion

    void Update() {
        playTime += Time.deltaTime;
    }

    public void gameOver() {
        Time.timeScale = 0.0f;
    }

}