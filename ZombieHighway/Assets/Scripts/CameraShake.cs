using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public static CameraShake Instance;

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
    static void AutoAttach()
    {
        if (Camera.main != null && Camera.main.GetComponent<CameraShake>() == null)
        {
            Camera.main.gameObject.AddComponent<CameraShake>();
        }
    }

    private float shakeDuration;
    private float shakeMagnitude;
    private float shakeTimer;
    private Vector3 currentOffset;

    void Awake()
    {
        Instance = this;
    }

    void LateUpdate()
    {
        transform.position -= currentOffset;
        currentOffset = Vector3.zero;

        if (shakeTimer > 0f)
        {
            shakeTimer -= Time.deltaTime;
            float strength = Mathf.Clamp01(shakeTimer / shakeDuration) * shakeMagnitude;
            currentOffset = new Vector3(
                Random.Range(-1f, 1f) * strength,
                Random.Range(-1f, 1f) * strength,
                0f
            );
            transform.position += currentOffset;
        }
    }

    public void Shake(float duration = 0.15f, float magnitude = 0.2f)
    {
        if (duration > shakeTimer)
        {
            shakeDuration = duration;
            shakeMagnitude = magnitude;
            shakeTimer = duration;
        }
    }

    public void ShakeStrong()
    {
        Shake(0.5f, 0.6f);
    }
}
