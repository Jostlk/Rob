using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetonationBomb : MonoBehaviour
{
    static public int BombActive = 0;
    public GameObject Explosion;
    public List<Transform> ExplosionsSpawn;
    public List<GameObject> DestroingGameObject;
    private void Update()
    {
        if (BombActive == 4)
        {
            Invoke("DetonateBoms",5);
        }
    }
    public void DetonateBoms()
    {
        for (int i = 0; i < ExplosionsSpawn.Count; i++)
        {
            Instantiate(Explosion, ExplosionsSpawn[i].transform.position,Random.rotation);
        }
        for (int i = 0;i < DestroingGameObject.Count; i++)
        {
            Destroy(DestroingGameObject[i]);
        }
        Destroy(gameObject);
    }
}
