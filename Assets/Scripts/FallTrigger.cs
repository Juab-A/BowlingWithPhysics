using UnityEngine;
using UnityEngine.Events;

public class FallTrigger : MonoBehaviour
{
    //Adds OnPinFall even in case other objects need to know a pin has fallen
    //i.e GameManager
    public UnityEvent OnPinFall = new();
    public bool isPinFallen = false;

    private void OnTriggerEnter(Collider triggeredObject) {
        
        if (triggeredObject.CompareTag("Ground") && !isPinFallen) {
            isPinFallen = true;
            OnPinFall?.Invoke();
            Debug.Log($"{gameObject.name} is fallen");
            //Using $"" is C#'s string formatting, like Java's String.format()
        }
    }
}
