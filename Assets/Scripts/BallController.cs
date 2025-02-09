using UnityEngine;
using UnityEngine.Events;

public class BallController : MonoBehaviour
{
    [SerializeField] private float force = 1f;
    [SerializeField] private InputManager inputManager;
    

    private Rigidbody ballRb;
    private bool isBallLaunched;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ballRb = GetComponent<Rigidbody>(); //Grabs reference to Rigidboy

        //Adds a listener to the OnSpacePressed Event
        //When space pressed, LaunchBall method called
        inputManager.OnSpacePressed.AddListener(LaunchBall);


    }

    private void LaunchBall() {
        if (isBallLaunched) return; //Do nothing if launched
        isBallLaunched = true; //Mark True when function is running
        ballRb.AddForce(transform.forward * force, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
