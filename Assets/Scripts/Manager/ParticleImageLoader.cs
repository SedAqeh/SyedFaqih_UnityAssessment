using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.VFX;
using TMPro;
using System.Threading.Tasks;

public class ParticleImageLoader : MonoBehaviour
{
    public TMP_InputField urlInput;
    public VisualEffect vfx;

    public async void OnApplyClicked()
    {
        string url = urlInput.text.Trim();

        if (!IsValidImageUrl(url))
        {
            Debug.LogWarning("Invalid image URL. Must be .jpg or .png");
            return;
        }

        Texture2D tex = await DownloadTextureAsync(url);

        if (tex == null)
        {
            Debug.LogError("Image download failed.");
            return;
        }

        vfx.SetTexture("Material", tex);
    }

    bool IsValidImageUrl(string url)
    {
        url = url.ToLower();
        return url.EndsWith(".jpg") || url.EndsWith(".png");
    }

    async Task<Texture2D> DownloadTextureAsync(string url)
    {
        using UnityWebRequest req = UnityWebRequestTexture.GetTexture(url);
        var operation = req.SendWebRequest();

        while (!operation.isDone)
            await Task.Yield();

        if (req.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError(req.error);
            return null;
        }

        return DownloadHandlerTexture.GetContent(req);
    }
}
