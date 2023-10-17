using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class CarrotRespawn : MonoBehaviour
{
    public List<GameObject> CarrotPool = new List<GameObject>();
    public GameObject[] Carrots;

    // 카메라 뷰 하나에 나오는 최대 당근 갯수
    public int objCnt = 1;

    void Awake()
    {
        for (int i = 0; i < Carrots.Length; i++)
        {
            for (int j = 0; j < objCnt; j++)
            {
                CarrotPool.Add(CreateObj(Carrots[i], transform));
            }
        }
    }

    private void Start()
    {
        StartCoroutine(CreateObj());
    }

    IEnumerator CreateObj()
    {
        while (true)
        {
            CarrotPool[Random.Range(0, CarrotPool.Count)].SetActive(true);
            yield return new WaitForSeconds(Random.Range(1.5f, 3.5f));
        }
    }

    GameObject CreateObj(GameObject obj, Transform parent)
    {

        GameObject copy = Instantiate(obj);
        copy.transform.SetParent(parent);
        copy.SetActive(false);
        
        return copy;
    }


}
