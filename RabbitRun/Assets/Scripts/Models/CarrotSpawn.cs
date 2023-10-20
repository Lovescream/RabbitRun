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
        carrotParent = GameObject.Find("CarrotSpawn").transform;        // Find는 부하를 많이 주기 때문에 최소한으로 쓰는 게 좋습니다!
        carrotSpawnTimer = Random.Range(carrotIntervalMin, carrotIntervalMax);
    }

    void Update() {
        if (GameManager.Instance.IsOver) return;
        // Timer가 0이 되면 당근 소환.
        carrotSpawnTimer -= Time.deltaTime;
        if (carrotSpawnTimer <= 0) {
            carrotSpawnTimer = Random.Range(carrotIntervalMin, carrotIntervalMax);
            Carrot newCarrot = Instantiate(carrotPrefab);
            newCarrot.transform.SetParent(carrotParent);                // parent = ~~ 보다는 SetParent(___)를 쓰는 게 낫습니다!

            CarrotHeight height = Random.Range(0, 2) == 0 ? CarrotHeight.High : CarrotHeight.Low;
            float speed = Random.Range(carrotSpeedMin, carrotSpeedMax);

            newCarrot.Initialize(height, speed);
        }
    }

    #endregion

}
