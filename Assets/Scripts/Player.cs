using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public UnityEvent playerDeath;
    public LayerMask enemyLayer;
    public AudioSource audioSource;

    public ObjectPool bulletPool;

    public float cooldownTimer = 0.0f;

    public FixedJoystick joystick;

    public ShootButton shootButton_Android;
#if UNITY_ANDROID
    
#endif

    private void Awake()
    {
        //shootButton_Android.onClick.AddListener(ShootPressed_Android);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
            transform.position += 7 * Vector3.forward * Time.deltaTime;
        if (Input.GetKey(KeyCode.S))
            transform.position += 7 * Vector3.back * Time.deltaTime;
        if (Input.GetKey(KeyCode.A))
            transform.position += 7 * Vector3.left * Time.deltaTime;
        if (Input.GetKey(KeyCode.D))
            transform.position += 7 * Vector3.right * Time.deltaTime;


        Vector3 dir = new Vector3(joystick.Direction.x, 0, joystick.Direction.y);
        transform.position += 7 * dir * Time.deltaTime;


#if UNITY_ANDROID

#endif

        cooldownTimer += Time.deltaTime;
        if (cooldownTimer > 0.2f)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                Shoot();

                if (!GameManager.IsMute)
                    audioSource.Play();
            }

            if (shootButton_Android.PointerDown)
            {
                Shoot();

                if (!GameManager.IsMute)
                    audioSource.Play();
            }
        }
    }

    private void Shoot()
    {
        Collider[] collidersDetected = Physics.OverlapSphere(transform.position, 10.0f, enemyLayer.value);

        int closestIndex = 0;
        if (collidersDetected.Length > 2)
        {
            float closestDistance = (collidersDetected[0].transform.position - transform.position).sqrMagnitude;
            for (int i = 1; i < collidersDetected.Length; i++)
            {
                float currentDist = (collidersDetected[i].transform.position - transform.position).sqrMagnitude;

                if (currentDist < closestDistance)
                {
                    closestDistance = currentDist;
                    closestIndex = i;
                }
            }
        }

        Quaternion requiredRotation;
        if (collidersDetected.Length == 0)
        {
            requiredRotation = Quaternion.identity;
        }
        else
        {
            Transform targetEnemyTransform = collidersDetected[closestIndex].transform;
            Vector3 direction = targetEnemyTransform.position - transform.position;
            requiredRotation = Quaternion.LookRotation(direction.normalized, Vector3.up);
        }

        GameObject newBulletGO = bulletPool.GetAvailableObject();
        newBulletGO.transform.position = transform.position + new Vector3(0, 1, 0);
        newBulletGO.transform.rotation = requiredRotation;

        newBulletGO.GetComponent<Bullet>().playerTransform = transform;

        cooldownTimer = 0.0f;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            playerDeath.Invoke();
            SceneManager.LoadScene(0);
        }
    }
}
