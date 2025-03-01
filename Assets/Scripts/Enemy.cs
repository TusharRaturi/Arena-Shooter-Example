using UnityEngine;

public enum EnemyType
{
    SmallEnemy,
    BigEnemy
}

public class Enemy : MonoBehaviour
{
    public GameObject player;
    public MeshRenderer meshRenderer;

    public Color color;

    // Start is called before the first frame update
    void Start()
    {
        meshRenderer.material.color = color;
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
