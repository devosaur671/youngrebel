using UnityEngine;

namespace YoungRebel.Scriptes.Player
{
    public struct ClimbingParameters
    {
        public float MaxClimbSpeed;
        public float ClimbForce;
        public Transform Orientation;
    }
    
    public class ClimbingController
    {
        private const float OffsetY = 1f;
        private const float PushTimer = 0.25f;
        
        private Rigidbody controlledRigidbody;
        private Transform controlledTransform;
        private Transform pointTransform;
        private bool startClimb;
        private float forwardPushTime = 0f;
        
        public ClimbingController(Rigidbody rigidbody, Transform transform)
        {
            controlledRigidbody = rigidbody;
            controlledTransform = transform;
        }
        
        public bool IsClimbing()
        {
            return startClimb;
        }

        public void StartClimb(Transform point)
        {
            startClimb = true;
            controlledRigidbody.isKinematic = true;
            pointTransform = point;
        }

        public void Climb(ClimbingParameters climbingParameters)
        {
            if (controlledTransform.position.y < pointTransform.position.y + OffsetY)
            {
                controlledTransform.Translate(Vector3.up * climbingParameters.MaxClimbSpeed * Time.deltaTime);
            }

            if (controlledTransform.position.y > pointTransform.position.y + OffsetY)
            {
                controlledTransform.Translate(climbingParameters.Orientation.forward * climbingParameters.ClimbForce * Time.deltaTime);

                forwardPushTime += Time.deltaTime;

                if (forwardPushTime > PushTimer)
                {
                    FinishClimb();
                }
            }
        }

        public void FinishClimb()
        {
            startClimb = false;
            controlledRigidbody.isKinematic = false;
            pointTransform = null;
            forwardPushTime = 0f;
        }
    }
}