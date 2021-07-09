using System.Linq;
using UnityEngine;

/// <summary>
///     This is a generic implementation of MonoBehaviour that can be placed only once on a scene.
///     Create a derived class where the type T is the class you want to be single on the scene.
///     It is very similar to the Singleton pattern except the object will be destroyed when the scene is unloaded.
///     Methods still can be called via the static Instance property to avoid using GetComponent().
/// </summary>
/// <typeparam name="T">
///     Class, derived from SingleOnScene.
/// </typeparam>
/// <remarks>
///     DO NOT REDEFINE Awake() and Reset() in derived classes.
///     Instead, use protected virtual methods:
///     SingleReset()
///     SingleAwake()
///     to perform the initialization.
/// </remarks>
public class SingleOnScene<T> : MonoBehaviour
    where T : MonoBehaviour
{
    /// <summary>
    ///     Global access point to the unique instance of this class.
    /// </summary>
    public static T Instance { get; private set; }

    /// <summary>
    ///     Unity3D Reset method.
    /// </summary>
    /// <remarks>
    ///     You can override this method in derived classes to customize the reset of your MonoBehaviour.
    /// </remarks>
    protected virtual void SingleReset() { }

    /// <summary>
    ///     Unity3D Awake method.
    /// </summary>
    /// <remarks>
    ///     You can override this method in derived classes to customize the initialization of your MonoBehaviour.
    /// </remarks>
    protected virtual void SingleAwake() { }

    protected void Reset()
    {
        // Remove the second instance of component if it is added to a scene.
        if (Instance == null)
        {
            Instance = this.GetComponent<T>();
        }
        else
        {
            Debug.LogErrorFormat(
                "The scene already has an object with this component: {0}",
                Instance.gameObject.name);

            var instanceToRemove = (
                from T instance in FindObjectsOfType<T>()
                where instance != Instance
                select instance).First();
            DestroyImmediate(instanceToRemove);
        }

        SingleReset();
    }

    protected void Awake()
    {
        Instance = this.GetComponent<T>();
        SingleAwake();
    }
}
