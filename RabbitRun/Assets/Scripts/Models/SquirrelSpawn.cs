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
        squirrelParent = GameObject.Find("SquirrelSpawn").transform;        // Find�� ���ϸ� ���� �ֱ� ������ �ּ������� ���� �� �����ϴ�!
        squirrelSpawnTimer = Random.Range(squirrelIntervalMin, squirrelIntervalMax);
    }

    void Update()
    {
        if (GameManager.Instance.IsOver) return;
        // Timer�� 0�� �Ǹ� ��� ��ȯ.
        squirrelSpawnTimer -= Time.deltaTime;
        if (squirrelSpawnTimer <= 0)
        {
            squirrelSpawnTimer = Random.Range(squirrelIntervalMin, squirrelIntervalMax);
            Squirrel newSquirrel = Instantiate(squirrelPrefab);
            newSquirrel.transform.SetParent(squirrelParent);                // parent = ~~ ���ٴ� SetParent(___)�� ���� �� �����ϴ�!

            float speed = Random.Range(squirrelIntervalMin, squirrelIntervalMax);

            newSquirrel.Initialize(speed);
        }
    }

    #endregion

}
