using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquirrelSpawn : MonoBehaviour
{

    #region Inspector

    [Header("Prefabs")]
    [SerializeField]
    private Squirrel squirrelPrefab;
    [Header("Games")]
    [SerializeField]
    private float squirrelIntervalMin;
    [SerializeField]
    private float squirrelIntervalMax;
    [SerializeField]
    private float squirrelSpeedMin;
    [SerializeField]
    private float squirrelSpeedMax;

    #endregion

    #region Fields

    private float squirrelSpawnTimer;

    private Transform squirrelParent;

    #endregion

    #region MonoBehaviours

    void Start()
    {
        squirrelParent = GameObject.Find("SquirrelSpawn").transform;        // Find는 부하를 많이 주기 때문에 최소한으로 쓰는 게 좋습니다!
        squirrelSpawnTimer = Random.Range(squirrelIntervalMin, squirrelIntervalMax);
    }

    void Update()
    {
        if (GameManager.Instance.IsOver) return;
        // Timer가 0이 되면 당근 소환.
        squirrelSpawnTimer -= Time.deltaTime;
        if (squirrelSpawnTimer <= 0)
        {
            squirrelSpawnTimer = Random.Range(squirrelIntervalMin, squirrelIntervalMax);
            Squirrel newSquirrel = Instantiate(squirrelPrefab);
            newSquirrel.transform.SetParent(squirrelParent);                // parent = ~~ 보다는 SetParent(___)를 쓰는 게 낫습니다!

            float speed = Random.Range(squirrelIntervalMin, squirrelIntervalMax);

            newSquirrel.Initialize(speed);
        }
    }

    #endregion

}
