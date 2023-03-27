using UnityEngine;

public class PlusPoint : MonoBehaviour
{
    [SerializeField] GameObject FireFloor;
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            FireFloor.SetActive(true);
        }
    }
}
