using UnityEngine;
using System.Collections.Generic;

public class FishTank : MonoBehaviour
{
    [SerializeField]
    private Vector2 Size = new Vector2(16f, 9f);

    [SerializeField]
    private GameObject fishPrefab = null;

    [Range(0, 300)]
    [SerializeField]
    private int SpawningCount;

    //private Fish[] fishes = null;
    private List<Fish> fishs = null;

    private void Start()
    {
        fishs = new List<Fish>();
        //fishes = new Fish[SpawningCount];
        for (int i = 0; i < SpawningCount; i++)
        {
            CreateFish(Vector3.zero);
        }
    }

    void CreateFish(Vector3 worldPos)
    {
        GameObject fishInstance = Instantiate(fishPrefab, transform);
        fishInstance.gameObject.name = $"Fish {System.Guid.NewGuid()}";
        fishInstance.transform.position = worldPos;
        fishs.Add(fishInstance.GetComponent<Fish>());
    }

    private void LateUpdate()
    {

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            CreateFish(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        }


        // Loop around out of bound fishes.
        int fishesCount = fishs.Count;
        for (int i = 0; i < fishesCount; i++)
        {
            Fish fish = fishs[i];
            Vector3 position = fish.transform.localPosition;

            // Left border?
            if (position.x < -Size.x * 0.5f)
            {
                position.x += Size.x;
            }
            // Right border?
            else if (position.x > Size.x * 0.5f)
            {
                position.x -= Size.x;
            }

            // Top border?
            if (position.y > Size.y * 0.5f)
            {
                position.y -= Size.y;
            }
            // Bottom border?
            if (position.y <  -Size.y * 0.5f)
            {
                position.y += Size.y;
            }

            fish.transform.localPosition = position;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireCube(transform.position, Size);
    }

}