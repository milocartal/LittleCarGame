using UnityEngine;

public class TrashPickUp : MonoBehaviour
{
    public Count_Trash CT;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        CT.GetComponent<Count_Trash>().AddTrash(1);
        Destroy(gameObject);
    }
}
