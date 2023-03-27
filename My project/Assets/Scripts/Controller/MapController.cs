using UnityEngine;

public class MapController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = new Vector3(0,player.transform.position.y,0);        
    }
}
