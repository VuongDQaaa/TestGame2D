using UnityEngine;

public class FloorSpawner : MonoBehaviour
{
    [SerializeField] private GameObject leftLevel, rightLevel, movingLevel;
    public bool spawnLeft;
    public bool spawnRight;
    public float currentHigh = 7.68f;
    Vector3 position;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        position = new Vector3(0, currentHigh, 0);
        GenerateLevel();
    }

    void GenerateLevel()
    {

    }
}
