using TMPro;
using UnityEditor.Animations;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float score = 0;
    [SerializeField] private TextMeshProUGUI scoreText;

    [SerializeField] private BallController ball;
    [SerializeField] private GameObject pinCollection;
    [SerializeField] private Transform pinAnchor;
    [SerializeField] private InputManager inputManager;



    private FallTrigger[] fallTriggers;
    [SerializeField] private GameObject pinObjects;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inputManager.OnResetPressed.AddListener(HandleReset);

        //Add the Increment Score function as a listener
        //to the OnPinfall Event of each new pin
        fallTriggers = FindObjectsByType<FallTrigger>(FindObjectsInactive.Include, FindObjectsSortMode.None);

        foreach (FallTrigger pin in fallTriggers) {
            pin.OnPinFall.AddListener(IncrementScore);
        }
    }

    private void HandleReset()
    {
        ball.ResetBall();
        SetPins();
    }

    private void SetPins() {

        if (pinObjects) { //Assure there are no pins already there, we destroy them if there are
            foreach (Transform child in pinObjects.transform) {
                Destroy(child.gameObject);
            }
            Destroy(pinObjects);
        }

        //Instantiate a new set of pins
        pinObjects = Instantiate(pinCollection, pinAnchor.transform.position, Quaternion.identity, transform);

        

        //Add the Increment Score function as a listener
        //to the OnPinfall Event of each new pin
        fallTriggers = FindObjectsByType<FallTrigger>(FindObjectsInactive.Include, FindObjectsSortMode.None);

        foreach (FallTrigger pin in fallTriggers) {
            pin.OnPinFall.AddListener(IncrementScore);
        }
    }

    private void IncrementScore() {
        score++;
        scoreText.text = $"Score: {score}";
    }
}
