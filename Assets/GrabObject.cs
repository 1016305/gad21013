using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GrabObject : MonoBehaviour
{
    [SerializeField] GameObject nullGrab;
    GameObject currentObject;
    private List<GameObject> invertedGravityObjects = new List<GameObject>();
    //int behaviour = -1;
    Vector3 forwards;
    Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        OnKeyPressed();
    }
    private void FixedUpdate()
    {
        InvertedGravity();
    }
    void OnKeyPressed()
    {
        if (Input.GetKey(KeyCode.E))
        {
            RaycastHit hit;
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 15f))
            {
                if (hit.collider.gameObject.CompareTag("PhysicsObject"))
                {
                    CheckInvertedList(currentObject);
                    currentObject = hit.collider.gameObject;
                    currentObject.GetComponent<Rigidbody>().useGravity = false;
                    currentObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
                    currentObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                    currentObject.transform.parent = nullGrab.transform;
                    currentObject.transform.position = nullGrab.transform.position;
                    currentObject.transform.rotation = new Quaternion(0, 0, 0, 0);
                    Debug.Log("Correct Hit");
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && currentObject != null)
        {
            int behaviour = Random.Range(0, 6);
            Debug.Log("Current iterator val: " + behaviour);
            SwitchBehaviour(behaviour);            
        }
    }
    void SwitchBehaviour(int behaviour)
    {
        switch (behaviour)
        {
            case 0:
                ThrowOne();
                break;
            case 1:
                ThrowTwo();
                break;
            case 2:
                ThrowThree();
                break;
            case 3:
                ThrowFour();
                break;
            case 4:
                ThrowFive();
                break;
            case 5:
                ThrowSix();
                break;
            case 6:
                ThrowSeven();
                break;
        }
    }
    void InvertedGravity()
    {
        if (invertedGravityObjects != null)
        {
            foreach (GameObject item in invertedGravityObjects)
            {
                item.GetComponent<Rigidbody>().useGravity = false;
                item.GetComponent<Rigidbody>().AddForce(Vector3.up * 0.001f * Time.deltaTime);
            }
        }
    }
    void ThrowOne()
    {
        CheckInvertedList(currentObject);
        Debug.Log("0");
        currentObject.GetComponent<Rigidbody>().useGravity = true;
        currentObject.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * 500);
        currentObject.transform.parent = null;
    }
    void ThrowTwo()
    {
        CheckInvertedList(currentObject);
        Debug.Log("1");
        //currentObject.GetComponent<Rigidbody>().useGravity = true;
        currentObject.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * 50);
        currentObject.transform.parent = null;
    }
    void ThrowThree()
    {
        CheckInvertedList(currentObject);
        Debug.Log("2");
        currentObject.GetComponent<Rigidbody>().useGravity = true;
        currentObject.GetComponent<Rigidbody>().AddRelativeForce(Vector3.right * 500);
        currentObject.transform.parent = null;
    }
    void ThrowFour()
    {
        CheckInvertedList(currentObject);
        Debug.Log("3");
        currentObject.GetComponent<Rigidbody>().useGravity = true;
        currentObject.GetComponent<Rigidbody>().mass = 500;
        currentObject.GetComponent<Rigidbody>().drag = 0;
        currentObject.transform.parent = null;
    }
    void ThrowFive()
    {
        CheckInvertedList(currentObject);
        Debug.Log("4");
        currentObject.GetComponent<Rigidbody>().useGravity = true;
        currentObject.GetComponent<Rigidbody>().AddTorque(Vector3.right * 500);
        currentObject.GetComponent<Rigidbody>().AddRelativeForce(Vector3.right * 50);
        currentObject.transform.parent = null;
    }
    void ThrowSix()
    {
        CheckInvertedList(currentObject);
        Debug.Log("5");
        currentObject.GetComponent<Rigidbody>().mass = 0;
        currentObject.GetComponent<Rigidbody>().useGravity = false;
        invertedGravityObjects.Add(currentObject);
        currentObject.transform.parent = null;
    }
    void ThrowSeven()
    {
        CheckInvertedList(currentObject);
        Debug.Log("6");
        currentObject.GetComponent<Rigidbody>().useGravity = true;
        currentObject.GetComponent<Rigidbody>().AddRelativeForce(-Vector3.forward * 500);
        currentObject.transform.parent = null;
    }
        void CheckInvertedList(GameObject current)
    {
        if (invertedGravityObjects != null)
        {
            if (invertedGravityObjects.Contains(current))
            {
                invertedGravityObjects.Remove(current);
            }
        }
        
    }

    }
