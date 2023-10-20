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
    [Tooltip("���� �ӵ�")]
    private float scrollSpeed;
    [SerializeField]
    [Tooltip("�������� ����")]
    private float scrollSpeedRatio;
    [SerializeField]
    [Tooltip("���� ����: ���� �ð��� ���Ͽ� ������ ����.")]
    private float scoreBonus;

    #endregion

    #region Properties

    public float ScrollSpeed => scrollSpeed + (Score / 100) * scrollSpeedRatio;     // ���� 100������ ������.

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