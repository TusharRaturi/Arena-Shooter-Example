using UnityEngine;

public enum EnemyState
{
    Moving, Still
}

public class Enemy : MonoBehaviour
{
    public GameObject player;
    public MeshRenderer meshRenderer;

    public Color color;

    public EnemyState enemyState;

    private static int enemiesAvailable = 0;

    private void Awake()
    {
        enemiesAvailable++;
    }

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

            Debug.Log(enemyToPlayer.magnitude);

            // Evaluating states
            if (enemiesAvailable >= 4)
                enemyState = EnemyState.Still;
            else if (enemiesAvailable < 4)
                enemyState = EnemyState.Moving;

            enemyToPlayer.Normalize();

            // Transformations according to the states
            if (enemyState == EnemyState.Moving)
                transform.position += 5 * enemyToPlayer * Time.deltaTime;
        }
    }

    private void OnDestroy()
    {
        enemiesAvailable--;
    }
}
