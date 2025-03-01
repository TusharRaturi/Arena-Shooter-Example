using UnityEngine;

public class BigEnemy : MonoBehaviour
{
    public GameObject player;

    public float speed = 5;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (player)
        {
            Vector3 enemyToPlayer = player.transform.position - transform.position;
            enemyToPlayer.Normalize();

            transform.position += speed * enemyToPlayer * Time.deltaTime;
        }
    }
}
