using UnityEngine;

public class BringKeyCard : MonoBehaviour
{
    [HideInInspector] public bool pickedUp;
    [HideInInspector] public bool key;
    private void Update()
    {
        if(pickedUp)
        {
            key = true;
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            pickedUp = true;
        }
    }
}
