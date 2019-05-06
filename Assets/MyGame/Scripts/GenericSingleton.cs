/* Generic singleton implementation
 */
using UnityEngine;

public class GenericSingletonClass<T> : MonoBehaviour where T : Component
{
    private readonly string Tag = "genericSingleton";
    private static T instance;

    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<T> ();
                if (instance = null)
                {
                    GameObject obj = new GameObject ();
                    obj.name = typeof (T).Name;
                    instance = obj.AddComponent<T> ();
                }
            }
            return instance;
        }
    }

    public virtual void Awake()
    {
        if (instance == null)
        {
            Debug.Log("Assign this " + Tag + " instance  with name " + gameObject.name);
            instance = this as T;
            DontDestroyOnLoad (this.gameObject);
        }
        else
        {
            Debug.Log ("Destroy " + Tag + " " + this.gameObject.name);
            Destroy (gameObject);
        }
    }
}