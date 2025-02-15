using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Transform playerTransform;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform)
        {
            if ((playerTransform.position - transform.position).sqrMagnitude > 625)
                Destroy(gameObject);
        }

        transform.position += 20 * transform.forward * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
        }
    }
}
