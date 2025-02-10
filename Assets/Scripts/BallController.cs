using UnityEngine;
using UnityEngine.Events;

public class BallController : MonoBehaviour
{
    [SerializeField] private float force = 1f;
    [SerializeField] private InputManager inputManager;
    [SerializeField] private Transform ballAnchor;
    [SerializeField] private Transform launchIndicator;
    

    private Rigidbody ballRb;
    private bool isBallLaunched;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ballRb = GetComponent<Rigidbody>(); //Grabs reference to Rigidboy

        //Adds a listener to the OnSpacePressed Event
        //When space pressed, LaunchBall method called
        inputManager.OnSpacePressed.AddListener(LaunchBall);
        transform.parent = ballAnchor;
        transform.localPosition = Vector3.zero;
        ballRb.isKinematic = true;

        Cursor.lockState = CursorLockMode.Locked;
        ResetBall();

    }

    private void LaunchBall() {
        if (isBallLaunched) return; //Do nothing if launched
        isBallLaunched = true; //Mark True when function is running
        transform.parent = null; //Remove parent so that the ball doesn't take the parent with it
        ballRb.isKinematic = false; //Set "IsKinematic" to false so that the ball can collide/perform via physics engine
        ballRb.AddForce(launchIndicator.transform.forward * force, ForceMode.Impulse);
        launchIndicator.gameObject.SetActive(false);
    }

    public void ResetBall() {
        isBallLaunched = false;

        ballRb.isKinematic = false;
        launchIndicator.gameObject.SetActive(true);
        transform.parent = ballAnchor;
        transform.localPosition = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
