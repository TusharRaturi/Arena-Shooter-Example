using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject player;

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

            transform.position += 5 * enemyToPlayer * Time.deltaTime;
        }
    }
}
