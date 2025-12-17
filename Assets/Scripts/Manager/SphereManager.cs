using UnityEngine;

public class SphereManager : MonoBehaviour
{
    public GameObject spherePrefab;
    public int childCount = 20;

    public float[] x = new float[2]; // minX, maxX
    public float[] z = new float[2]; // minZ, maxZ

    public float spacing = 2f;
    public float height = 0.5f;

    void Start()
    {
        float startX = x[0];
        float endX = x[1];

        float currentX = startX;
        float currentZ = z[0];

        for (int i = 0; i < childCount; i++)
        {
            Vector3 pos = new Vector3(currentX, height, currentZ);
            GameObject sphere = Instantiate(spherePrefab, pos, Quaternion.identity, transform);
            sphere.GetComponent<Renderer>().material.color = Random.ColorHSV();

            // Move to next column
            currentX += spacing;

            // If we exceed X range, reset X and move Z
            if (currentX > endX)
            {
                currentX = startX;
                currentZ += spacing;
            }
        }
    }
}
