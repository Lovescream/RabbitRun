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

    [SerializeField]
    [Tooltip("���� ����: ���� �ð��� ���Ͽ� ������ ����.")]
    private float scoreBonus;

    #endregion

    #region Properties

    public float Score => playTime * scoreBonus;

    #endregion

    #region Fields

    private float playTime;

    #endregion

    void Update() {
        playTime += Time.deltaTime;
    }

}