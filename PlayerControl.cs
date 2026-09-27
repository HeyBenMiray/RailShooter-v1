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

using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    private Vector2 movement;

    [Header("Movement Settings")]
    [SerializeField] private float controlSpeed = 10f;

    [Header("Screen Bounds (Sınırlar)")]
    [SerializeField] private float xMin = -8f;
    [SerializeField] private float xMax = 8f;
    [SerializeField] private float yMin = -4.5f;
    [SerializeField] private float yMax = 4.5f;

    void Update()
    {
        float xOffset = movement.x * controlSpeed * Time.deltaTime;
        float yOffset = movement.y * controlSpeed * Time.deltaTime;

        
        float rawXPos = transform.localPosition.x + xOffset;
        float rawYPos = transform.localPosition.y + yOffset;

       
        float clampedXPos = Mathf.Clamp(rawXPos, xMin, xMax);
        float clampedYPos = Mathf.Clamp(rawYPos, yMin, yMax);

       
        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }

  
    public void OnMove(InputValue value)
    {
        movement = value.Get<Vector2>();
    }
}
