using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DistanceController : MonoBehaviour
{
    public Transform red;
    public Transform green;
    public GameObject spheres;
    public TMP_Text distanceText;
    bool loaded = false;

    void Update()
    {
        float d = Vector3.Distance(red.position, green.position);
        distanceText.text = $"Distance: {d:F2}m";

        spheres.SetActive(d < 2f);

        if (d < 1f)
        {
            if (!loaded)
            {
                loaded = true;
                SceneManager.LoadSceneAsync("Scene2");
            }
        }
          
    }
}
