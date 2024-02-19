using UnityEngine;

public class PickUp_Object : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Inventory.instance.AddJournal(1);
            Destroy(gameObject);
        }
    }
}
