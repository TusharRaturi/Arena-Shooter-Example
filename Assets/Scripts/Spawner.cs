using TMPro;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject bigEnemyPrefab;
    public Player playerReference;
    public TextMeshProUGUI enemyText;

    private float timer = 0.0f;

    private int count = 0;

    private bool shouldSpawning = true;

    // Start is called before the first frame update
    void Start()
    {
        playerReference.playerDeath.AddListener(OnPlayerDied);
    }

    private void OnPlayerDied()
    {
        shouldSpawning = false;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (shouldSpawning && timer >= 2.0f)
        {
            Spawn();
        }
    }

    private void Spawn()
    {
        float chance = Random.value;

        Vector3 range = new Vector3(Random.Range(-20, 20), 0, Random.Range(-20, 20));

        if (chance <= 0.25f)
        {
            GameObject newEnemy = Instantiate(bigEnemyPrefab, range, Quaternion.identity);
            BigEnemy bgRef = newEnemy.GetComponent<BigEnemy>();
            bgRef.player = playerReference.gameObject;

            float chance2 = Random.value;

            if (chance2 > 0.1f)
                bgRef.speed = 2.5f;
        }
        else
        {
            GameObject newEnemy = Instantiate(enemyPrefab, range, Quaternion.identity);
            newEnemy.GetComponent<Enemy>().player = playerReference.gameObject;
        }

        timer = 0.0f;

        count++;
        enemyText.text = count.ToString();
    }
}
