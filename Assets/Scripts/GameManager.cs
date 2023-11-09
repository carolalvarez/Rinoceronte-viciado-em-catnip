using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<GameObject> pull = new List<GameObject>();
    [SerializeField] GameObject Player;

    public void PullManager(GameObject bullet)
    {
        pull.Add(bullet);
        bullet.SetActive(false);
    }

    public void ActiveBullet()
    {
        pull[0].SetActive(true);
        pull[0].GetComponent<Bullet>().timer = 0;
        pull.RemoveAt(0);
    }

    public GameObject FindPlayer()
    {
        return Player;
    }
}
