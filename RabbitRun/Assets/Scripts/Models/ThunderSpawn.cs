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
        thunderParent = GameObject.Find("ThunderSpawn").transform;        // Find�� ���ϸ� ���� �ֱ� ������ �ּ������� ���� �� �����ϴ�!
        thunderSpawnTimer = Random.Range(thunderIntervalMin, thunderIntervalMax);
    }

    void Update()
    {
        if (GameManager.Instance.IsOver) return;
        // Timer�� 0�� �Ǹ� ���� ��ȯ.
        thunderSpawnTimer -= Time.deltaTime;
        if (thunderSpawnTimer <= 0)
        {
            thunderSpawnTimer = Random.Range(thunderIntervalMin, thunderIntervalMax);
            Thunder newThunder = Instantiate(thunderPrefab);
            newThunder.transform.SetParent(thunderParent);                // parent = ~~ ���ٴ� SetParent(___)�� ���� �� �����ϴ�!

            float speed = Random.Range(thunderIntervalMin, thunderIntervalMax);

            newThunder.Initialize(speed);
        }
    }

    #endregion

}
