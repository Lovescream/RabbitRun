using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarrotSpawn : MonoBehaviour{

    #region Inspector

    [Header("Prefabs")]
    [SerializeField]
    private Carrot carrotPrefab;
    [Header("Games")]
    [SerializeField]
    private float carrotIntervalMin;
    [SerializeField]
    private float carrotIntervalMax;
    [SerializeField]
    private float carrotSpeedMin;
    [SerializeField]
    private float carrotSpeedMax;

    #endregion

    #region Fields

    private float carrotSpawnTimer;

    private Transform carrotParent;

    #endregion

    #region MonoBehaviours

    void Start() {
        carrotParent = GameObject.Find("CarrotSpawn").transform;        // Find�� ���ϸ� ���� �ֱ� ������ �ּ������� ���� �� �����ϴ�!
        carrotSpawnTimer = Random.Range(carrotIntervalMin, carrotIntervalMax);
    }

    void Update() {
        if (GameManager.Instance.IsOver) return;
        // Timer�� 0�� �Ǹ� ��� ��ȯ.
        carrotSpawnTimer -= Time.deltaTime;
        if (carrotSpawnTimer <= 0) {
            carrotSpawnTimer = Random.Range(carrotIntervalMin, carrotIntervalMax);
            Carrot newCarrot = Instantiate(carrotPrefab);
            newCarrot.transform.SetParent(carrotParent);                // parent = ~~ ���ٴ� SetParent(___)�� ���� �� �����ϴ�!

            CarrotHeight height = Random.Range(0, 2) == 0 ? CarrotHeight.High : CarrotHeight.Low;
            float speed = Random.Range(carrotSpeedMin, carrotSpeedMax);

            newCarrot.Initialize(height, speed);
        }
    }

    #endregion

}
