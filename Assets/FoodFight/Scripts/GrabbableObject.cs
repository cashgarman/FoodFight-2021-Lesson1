using UnityEngine;

namespace FoodFight.Scripts
{
    public class GrabbableObject : MonoBehaviour
    {
        private Material _material;
        private Color _normalColour;
        [SerializeField] private Color _hoveredColour;

        private void Awake()
        {
            // Cache the object's material object and it's normal colour
            _material = GetComponent<MeshRenderer>().material;
            _normalColour = _material.color;
        }

        public void OnHoverStart()
        {
            // Set the object's colour to the hover colour
            _material.color = _hoveredColour;
        }

        public void OnHoverEnd()
        {
            // Set the object's colour back to the normal colour
            _material.color = _normalColour;
        }

        public void OnGrabbed(Grabber hand)
        {
            // Set the parent of this object to the hand that grabbed it
            transform.SetParent(hand.transform);
            GetComponent<Rigidbody>().useGravity = false;
            GetComponent<Rigidbody>().isKinematic = true;
        }

        public void OnDropped()
        {
            // Unparent the object from the hand that grabbed it
            transform.SetParent(null);
            GetComponent<Rigidbody>().useGravity = true;
            GetComponent<Rigidbody>().isKinematic = false;
        }
    }
}
