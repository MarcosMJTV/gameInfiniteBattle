using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mapping : MonoBehaviour
{
    public List<GameObject> listDoor = new List<GameObject>();
    public List<GameObject> listEnemy = new List<GameObject>();
    public List<GameObject> listSpawn = new List<GameObject>();
    public GameObject player;
    public GameObject Hearth;
    public GameObject scripter;
    public SpawnItem spa;
    public Transform center;
    private Score score;
    private EnemyContainer enemyContainer;
    private Vector3 direction;
    public int count = 0;
    private bool activeRoom = false;

    void Start()
    {
        enemyContainer = scripter.GetComponent<EnemyContainer>();
        score = scripter.GetComponent<Score>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (activeRoom)
            {
                return;
            }
            foreach (GameObject door in listDoor)
            {
                door.GetComponent<Door>().Close(door.transform.position.x, door.transform.position.z);
            }
            foreach (GameObject spaw in listSpawn)
            {
                spawnEnemies(spaw.GetComponent<Spawn>().numero, spaw.GetComponent<Spawn>().Xmax, spaw.GetComponent<Spawn>().Zmax,
                    spaw.GetComponent<Spawn>().center, spaw.GetComponent<Spawn>().max, spaw.GetComponent<Spawn>().min);
            }
            activeRoom = true;
        }
    }

    void Update()
    {

    }

    private void SpawnItem(List<GameObject> listItem)
    {
        int randow = Random.Range(0, 9);
        Instantiate(listItem[randow], center.position, Quaternion.identity);
        listItem.Remove(listItem[randow]);
    }
    public void removeEnemy(GameObject enemy)
    {
        listEnemy.Remove(enemy);
        if (listEnemy.Count == 0)
        {
            count++;
            score.waves++;
            if (count >= 3 * score.rooms)
            {
                foreach (GameObject door in listDoor)
                {
                    door.GetComponent<Door>().Open(door.transform.position.x, door.transform.position.z);
                }
                score.rooms++;
                SpawnItem(spa.listItem);
                return;
            }
            else
            {
                foreach (GameObject spaw in listSpawn)
                {
                    spawnEnemies(spaw.GetComponent<Spawn>().numero, spaw.GetComponent<Spawn>().Xmax,
                        spaw.GetComponent<Spawn>().Zmax, spaw.GetComponent<Spawn>().center, spaw.GetComponent<Spawn>().max, spaw.GetComponent<Spawn>().min);
                }
            }
        }
    }

    public void spawnEnemies(int numero, float Xmax, float Zmax, Vector3 vector, int max, int min)
    {
        float randoExplosion;
        if (numero == 2)
        {
            randoExplosion = ((int)Random.Range((Mathf.Sqrt(score.waves + 1) * min) * 0.5f, (Mathf.Sqrt(score.waves + 1) * max)) * 0.5f);
            for (int i = 0; i < randoExplosion; i++)
            {
                direction = new Vector3(Random.Range(vector.x - Xmax / 2, vector.x + Xmax / 2), 2.4f,
                     Random.Range(vector.z - Zmax / 2, vector.z + Zmax / 2));
                GameObject rgb = Instantiate(enemyContainer.explosionEnemy, direction, Quaternion.identity);
                listEnemy.Add(rgb);
                rgb.GetComponent<Enemy>().Object = player;
                rgb.GetComponent<Enemy>().spe = this;
            }
        }
        if (numero == 1)
        {
            randoExplosion = ((int)Random.Range((Mathf.Sqrt(score.waves + 1) * min) * 0.5f, (Mathf.Sqrt(score.waves + 1) * max)) * 0.5f);
            for (int i = 0; i < randoExplosion; i++)
            {
                direction = new Vector3(Random.Range(vector.x - Xmax / 2, vector.x + Xmax / 2), 2.4f,
                    Random.Range(vector.z - Zmax / 2, vector.z + Zmax / 2));
                GameObject rgb = Instantiate(enemyContainer.distanceEnemy, direction, Quaternion.identity);
                listEnemy.Add(rgb);
                rgb.GetComponent<Enemy>().Object = player;
                rgb.GetComponent<Enemy>().spe = this;
            }
        }

        if (numero == 3)
        {
            randoExplosion = ((int)Random.Range((Mathf.Sqrt(score.waves + 1) * min) * 0.5f, (Mathf.Sqrt(score.waves + 1) * max)) * 0.5f);
            for (int i = 0; i < randoExplosion; i++)
            {
                direction = new Vector3(Random.Range(vector.x - Xmax / 2, vector.x + Xmax / 2), 2.4f,
                    Random.Range(vector.z - Zmax / 2, vector.z + Zmax / 2));
                GameObject rgb = Instantiate(enemyContainer.cqcEnemy, direction, Quaternion.identity);
                listEnemy.Add(rgb);
                rgb.GetComponent<Enemy>().Object = player;
                rgb.GetComponent<Enemy>().spe = this;
            }
        }

        if (numero == 4)
        {
            randoExplosion = ((int)Random.Range((Mathf.Sqrt(score.waves + 1) * min) * 0.5f, (Mathf.Sqrt(score.waves + 1) * max)) * 0.5f);
            for (int i = 0; i < randoExplosion; i++)
            {
                direction = new Vector3(Random.Range(vector.x - Xmax / 2, vector.x + Xmax / 2), 2.4f,
                     Random.Range(vector.z - Zmax / 2, vector.z + Zmax / 2));
                GameObject rgb = Instantiate(enemyContainer.wormEnemy, direction, Quaternion.identity);
                listEnemy.Add(rgb);
                rgb.GetComponent<Enemy>().Object = player;
                rgb.GetComponent<Enemy>().spe = this;
            }
        }

    }

    public void spawnDrop(GameObject enemy)
    {
        int number = Random.Range(1, 6);
        if (number == 1)
        {
            int counHeart = player.GetComponent<PlayerController>().Life;
            if (counHeart < 3)
            {
                Vector3 positionObject = new Vector3(enemy.transform.position.x, 1.5f, enemy.transform.position.z);
                Instantiate(Hearth, positionObject, Quaternion.identity);

            }
        }
    }
}
