using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin_spawner : MonoBehaviour
{
    public GameObject coinPrefab;
    // Start is called before the first frame update
    void Start()
    {
       StartCoroutine(CoinSpawer());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void CoinSpawner()
    {
        float rand = Random.Range(-1.9f,1.9f);
        Instantiate(coinPrefab,new Vector3(rand,transform.position.y,transform.position.z),Quaternion.identity);
    }
    IEnumerator CoinSpawer()
    {
        while(true)
        {
            int time = Random.Range(10,20);
            yield return new WaitForSeconds(2f);
            CoinSpawner();
        }
    }
}
