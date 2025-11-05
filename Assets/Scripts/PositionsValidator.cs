using UnityEngine;

public class PositionValidator : MonoBehaviour
{
    [Tooltip("If the position is invalid, reset to this value.")]
    public Vector3 safePosition = Vector3.zero;

void LateUpdate()
    {
        Vector3 pos = transform.position;

        if (!IsFinite(pos))
        {
            Debug.LogError($"Invalid position detected on '{gameObject.name}'. Resetting to safe position.");
            transform.position = safePosition;
        }
    }

    bool IsFinite(Vector3 v)
    {
        return float.IsFinite(v.x) && float.IsFinite(v.y) && float.IsFinite(v.z);
    }

}
