using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    private MatchablePool matchablePool;
    private void Start()
    {
        matchablePool = (MatchablePool)MatchablePool.Instance;
        matchablePool.PoolObjects(10);
        StartCoroutine(Demo());
    }
    private IEnumerator Demo()
    {
        Matchable m = matchablePool.GetPooledObject();
        m.gameObject.SetActive(true);
        Vector3 randomPosition;
        for (int i = 0; i != 7; i ++)
        {
            randomPosition = new Vector3(Random.Range(-6f, 6f), Random.Range(-4f, 4f) , 0);
            yield return StartCoroutine(m.MoveToPosition(randomPosition));
        }
    }

}
