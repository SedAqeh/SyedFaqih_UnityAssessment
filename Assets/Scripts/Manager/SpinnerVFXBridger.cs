using UnityEngine;
using UnityEngine.VFX;

public class SpinnerVFXBridger : MonoBehaviour
{
    public SpinnerController spinner;
    public VisualEffect vfx;

    void Update()
    {
      
        vfx.SetFloat("SpinnerAngularSpeed", Mathf.Abs(spinner.AngularSpeed));
    }
}
