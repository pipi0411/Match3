using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    private static T instance;

    // Getter
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                Debug.LogError("Singleton instance is null. Make sure to create an instance of " + typeof(T).Name);
            }
            return instance;
        }
    }

    // Create the reference in Awake()
    protected void Awake()
    {
        if (instance == null)
        {
            instance = this as T;
            Init();
        }
        else
        {
            Debug.LogWarning("An instance of " + typeof(T).Name + " already exists. Destroying the new instance.");
            Destroy(gameObject);
        }
    }

    // destroy the reference in OnDestroy()
    protected void OnDestroy()
    {
        if (instance == this)
        {
            instance = null;
        }
    }

    // init will replace the functionality of Awake() 
    protected virtual void Init()
    {
        // This method can be overridden by derived classes to perform initialization tasks.
    }
}
