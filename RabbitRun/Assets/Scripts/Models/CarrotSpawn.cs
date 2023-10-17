using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarrotSpawn : MonoBehaviour
{
    public GameObject carrot;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("carrotRespawn", 0, Random.Range(1.5f, 3.5f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void carrotRespawn()
    {
        // 당근을 CarrotSpawn 밑에 생성하기
        GameObject newCarrot = Instantiate(carrot);
        newCarrot.transform.parent = GameObject.Find("CarrotSpawn").transform;
    }
}
