using UnityEngine;

public class TrashPickUp : MonoBehaviour
{


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (GameManager.instance.GetGameState() != GameStates.raceOver)
        {
            if (collision.CompareTag("Player"))
            {
                FindObjectOfType<Count_Trash>().AddTrash(1);
                Destroy(gameObject);
            }
        }
    }
}
