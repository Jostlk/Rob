using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetonationBomb : MonoBehaviour
{
    static public int BombActive = 0;
    public GameObject Explosion;
    public GameObject METRO;
    public AudioSource ExplosionSound;
    public AudioSource SirenSound;
    public GameObject BeepListen;
    public List<Transform> ExplosionsSpawn;
    public List<GameObject> DestroingGameObject;
    private void Update()
    {
        if (BombActive == 4)
        {
            BeepListen.SetActive(true);
            Invoke("DetonateBombs", 13);
        }
    }

    public void DetonateBombs()
    {
        METRO.SetActive(true);
        ExplosionSound.Play();
        SirenSound.Play();
        for (int i = 0; i < ExplosionsSpawn.Count; i++)
        {
            Instantiate(Explosion, ExplosionsSpawn[i].transform.position, Random.rotation);
        }
        for (int i = 0; i < DestroingGameObject.Count; i++)
        {
            Destroy(DestroingGameObject[i]);
        }
        Destroy(gameObject);
    }
}
