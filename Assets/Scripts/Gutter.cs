using UnityEngine;

public class Gutter : MonoBehaviour
{
    private void OnTriggerEnter (Collider triggeredBody) {
        if (triggeredBody.CompareTag("Ball")) {
            //Get Rigidbody of ball
            Rigidbody ballRigidBody = triggeredBody.GetComponent<Rigidbody>();

            //Store velocity magnitude before resetting the velocity
            float velocityMagnitude = ballRigidBody.linearVelocity.magnitude;

            //Reset both Linear AND Angular velocities due to ball rotating on ground when moving
            ballRigidBody.linearVelocity = Vector3.zero;
            ballRigidBody.angularVelocity = Vector3.zero;

            //Add force in forward direction of gutter
            //Use the previous velocity magnitude to keep the realism of the change
            ballRigidBody.AddForce(transform.forward * velocityMagnitude, ForceMode.VelocityChange);
        }
    }


}
