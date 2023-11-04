using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<GameObject> pull = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
}
