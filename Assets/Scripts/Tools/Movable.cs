using System.Collections;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class Movable : MonoBehaviour
{
    private Vector3 from, to;
    private float howfar;
    [SerializeField] private float speed = 1;
    private bool idle = true;
    public bool Idle
    {
        get
        {
            return idle;
        }
    }
    // coroutine move from current position to new position
    public IEnumerator MoveToPosition(Vector3 targetPosition)
    {
        if (speed <= 0)
        {
            Debug.LogWarning("Speed must be greater than zero. Defaulting to 1.");
        }
        from = transform.position;
        to = targetPosition;
        howfar = 0;
        do
        {
            howfar += speed * Time.deltaTime;
            if (howfar > 1)
            {
                howfar = 1;
            }
            transform.position = Vector3.LerpUnclamped(from, to, Easing(howfar));
            yield return null;
        }
        while (howfar != 1);
        idle = true;
    }
    private float Easing(float x)
    {
        float c1 = 1.70158f;
        float c2 = c1 * 1.525f;

        return x < 0.5f
            ? (Mathf.Pow(2 * x, 2) * ((c2 + 1) * 2 * x - c2)) / 2
            : (Mathf.Pow(2 * x - 2, 2) * ((c2 + 1) * (x * 2 - 2) + c2) + 2) / 2;
    }
}
