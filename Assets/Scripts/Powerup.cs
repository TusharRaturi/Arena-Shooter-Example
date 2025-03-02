using System.Collections;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    public float powerupTime = 1.5f;

    public GameObject visualGO;

    public void Apply(Player player)
    {
        visualGO.SetActive(false);
        OnApply(player);
        StartCoroutine(RemoveWaiter(player));
    }

    protected virtual void OnApply(Player player) { }

    private IEnumerator RemoveWaiter(Player player)
    {
        yield return new WaitForSeconds(powerupTime);
        Remove(player);
    }

    public void Remove(Player player)
    {
        OnRemove(player);
        Destroy(gameObject);
    }

    protected virtual void OnRemove(Player player) { }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Player pl = other.GetComponent<Player>();
            OnApply(pl);
        }
    }
}
