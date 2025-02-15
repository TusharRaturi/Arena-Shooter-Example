using TMPro;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemyPrefab;
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
            GameObject newEnemy = Instantiate(enemyPrefab, new Vector3(Random.Range(-20, 20), 0, Random.Range(-20, 20)), Quaternion.identity);
            newEnemy.GetComponent<Enemy>().player = playerReference.gameObject;
            timer = 0.0f;

            count++;
            enemyText.text = count.ToString();
        }
    }
}
