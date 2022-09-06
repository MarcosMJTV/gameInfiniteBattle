using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    protected bool alive = true;
    public Mapping spe;
    public GameObject Object;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    protected void remove()
    {
        spe.spawnDrop(gameObject);
        spe.removeEnemy(gameObject);
        Destroy(gameObject);
        alive = false;
    }

    protected void Collision(float Speed)
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 8);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.gameObject.GetComponent<Enemy>() != null)
            {
                if (hitCollider.gameObject == gameObject)
                {
                    continue;
                }
                Vector3 vectorExtra = new Vector3(hitCollider.gameObject.transform.position.x, transform.position.y, hitCollider.gameObject.transform.position.z);
                transform.position = Vector3.MoveTowards(transform.position, vectorExtra, -Speed * Time.deltaTime);
                continue;
            }
        }
    }

    protected void Damege(int damage)
    {
        Object.GetComponent<PlayerController>().Life = Object.GetComponent<PlayerController>().Life - damage;
    }
}
