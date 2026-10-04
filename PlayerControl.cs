//DERSTE YAPTIKLARIMIZ


//using UnityEngine;
//using UnityEngine.InputSystem;
//using UnityEngine.Rendering;

//public class PlayerControl : MonoBehaviour


//{

//    Vector2 movement;

//    [SerializeField] float controlSpeed = 10f;

//    // Start is called once before the first execution of Update after the MonoBehaviour is created
//    void Start()
//    {

//    }

//    // Update is called once per frame
//    void Update()
//    {
//       float xOffset = movement.x * controlSpeed * Time.deltaTime;
//       float xPos = transform.localPosition.x + xOffset;
//       transform.localPosition = new Vector3(xPos, 0f, 0f);
//    }

//    public void OnMove(InputValue value)
//    {
//        Debug.Log(value.Get<Vector2>());
//        movement = value.Get<Vector2>();
//    }


//}

//using UnityEngine;
//using UnityEngine.InputSystem;

//public class PlayerControl : MonoBehaviour
//{
//    private Vector2 movement;

//    [Header("Movement Settings")]
//    [SerializeField] private float controlSpeed = 10f;

//    [Header("Screen Bounds")]
//    [SerializeField] private float xMin = -8f;
//    [SerializeField] private float xMax = 8f;
//    [SerializeField] private float yMin = -4.5f;
//    [SerializeField] private float yMax = 4.5f;

//    void Update()
//    {
//        float xOffset = movement.x * controlSpeed * Time.deltaTime;
//        float yOffset = movement.y * controlSpeed * Time.deltaTime;


//        float rawXPos = transform.localPosition.x + xOffset;
//        float rawYPos = transform.localPosition.y + yOffset;


//        float clampedXPos = Mathf.Clamp(rawXPos, xMin, xMax);
//        float clampedYPos = Mathf.Clamp(rawYPos, yMin, yMax);


//        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
//    }


//    public void OnMove(InputValue value)
//    {
//        movement = value.Get<Vector2>();
//    }
//}

using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Parameters")]
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] float controlSpeed = 20f;
    [SerializeField] float xClampedRange = 8f;
    [SerializeField] float xClampedRangeRight = 8f;
    [SerializeField] float yClampedRange = 8f;
    [SerializeField] float yClampedRangeUp = 8f;
    [Header("Rotation Parameters")]
    [SerializeField] float rollControl = 20f;
    [SerializeField] float pitchControl = 20f;
    [SerializeField] float rotationSpeed = 2f;


    Vector2 movement;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ProcessTranslation();
        ProcessRotation();

    }


    public void OnMove(InputValue value)
    {
        Debug.Log(value.Get<Vector2>());
        movement = value.Get<Vector2>();

    }
    private void ProcessTranslation()
    {
        float xOffset = movement.x * controlSpeed * Time.deltaTime;
        float xPos = transform.localPosition.x + xOffset;
        float xClampedPos = Mathf.Clamp(xPos, -xClampedRange, xClampedRangeRight);

        float yOffset = movement.y * controlSpeed * Time.deltaTime;
        float yPos = transform.localPosition.y + yOffset;

        float yClampedPose = Mathf.Clamp(yPos, -yClampedRange, yClampedRangeUp);

        transform.localPosition = new Vector3(xClampedPos, yClampedPose, 0f);
    }
    private void ProcessRotation()
    {
        Quaternion targetRotation = Quaternion.Euler(-pitchControl * movement.y, 0f, -rollControl * movement.x);
        transform.localRotation = Quaternion.Lerp(transform.localRotation, targetRotation, Time.deltaTime * 5f);
    }
    
}
