using UnityEngine;

public abstract class Singleton<TChild> : MonoBehaviour
    where TChild : Singleton<TChild>
{
    private static TChild instance;

    public static TChild Instance { get => instance; }

    protected Singleton()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this as TChild;
        }
    }
}
