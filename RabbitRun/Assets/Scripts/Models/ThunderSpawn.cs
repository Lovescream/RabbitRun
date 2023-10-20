using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderSpawn : MonoBehaviour
{

    #region Inspector

    [Header("Prefabs")]
    [SerializeField]
    private Thunder thunderPrefab;
    [Header("Games")]
    [SerializeField]
    private float thunderIntervalMin;
    [SerializeField]
    private float thunderIntervalMax;
    [SerializeField]
    private float thunderSpeedMin;
    [SerializeField]
    private float thunderSpeedMax;

    #endregion

    #region Fields

    private float thunderSpawnTimer;

    private Transform thunderParent;

    #endregion

    #region MonoBehaviours

    void Start()
    {
        thunderParent = GameObject.Find("ThunderSpawn").transform;        // Find는 부하를 많이 주기 때문에 최소한으로 쓰는 게 좋습니다!
        thunderSpawnTimer = Random.Range(thunderIntervalMin, thunderIntervalMax);
    }

    void Update()
    {
        if (GameManager.Instance.IsOver) return;
        // Timer가 0이 되면 번개 소환.
        thunderSpawnTimer -= Time.deltaTime;
        if (thunderSpawnTimer <= 0)
        {
            thunderSpawnTimer = Random.Range(thunderIntervalMin, thunderIntervalMax);
            Thunder newThunder = Instantiate(thunderPrefab);
            newThunder.transform.SetParent(thunderParent);                // parent = ~~ 보다는 SetParent(___)를 쓰는 게 낫습니다!

            float speed = Random.Range(thunderIntervalMin, thunderIntervalMax);

            newThunder.Initialize(speed);
        }
    }

    #endregion

}
