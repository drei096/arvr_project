using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEST_PokeballThrow : MonoBehaviour
{
    [SerializeField]
    private float throwSpeed = 35f;
    private float speed;
    private float lastMouseX, lastMouseY;

    private bool thrown, holding;

    private Rigidbody _rigidbody;
    private Vector3 newPosition;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        Reset();
    }

    void Update()
    {
        if (holding)
            OnTouch();

        if (thrown)
            return;

        if (Input.GetMouseButtonDown(0))
        { //for pc = if(Input.GetButtonDown(0)){
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //for pc = Input.mousePosition
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100f))
            {
                if (hit.transform == transform)
                {
                    holding = true;
                    transform.SetParent(null);
                }
            }
        }

        if (Input.GetMouseButtonUp(0))
        { //for pc = if(Input.GetButtonUp(0)){
            if (lastMouseY < Input.GetTouch(0).position.y)
            {
                ThrowBall(Input.GetTouch(0).position);
            }
        }

        if (Input.touchCount == 1)
        { //for pc = if(Input.GetButton(0)){
            lastMouseX = Input.GetTouch(0).position.x;
            lastMouseY = Input.GetTouch(0).position.y;
        }
    }

    void Reset()
    {
        CancelInvoke();
        transform.position = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.2f, (Camera.main.nearClipPlane * 7.5f) + 1.0f));
        newPosition = transform.position;
        thrown = holding = false;

        _rigidbody.useGravity = false;
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.angularVelocity = Vector3.zero;
        transform.rotation = Quaternion.Euler(0f, 200f, 0f);
        transform.SetParent(Camera.main.transform);
    }

    void OnTouch()
    {
        Vector3 mousePos = Input.GetTouch(0).position;
        mousePos.z = Camera.main.nearClipPlane * 7.5f;

        newPosition = Camera.main.ScreenToWorldPoint(mousePos);

        transform.localPosition = Vector3.Lerp(transform.localPosition, newPosition, 50f * Time.deltaTime);
    }

    void ThrowBall(Vector2 mousePos)
    {
        _rigidbody.useGravity = true;

        float differenceY = (mousePos.y - lastMouseY) / Screen.height * 100;
        speed = throwSpeed * differenceY;

        float x = (mousePos.x / Screen.width) - (lastMouseX / Screen.width);
        x = Mathf.Abs(Input.GetTouch(0).position.x - lastMouseX) / Screen.width * 100 * x;

        Vector3 direction = new Vector3(x, 0f, 1f);
        direction = Camera.main.transform.TransformDirection(direction);

        _rigidbody.AddForce((direction * speed / 2f) * 5.0f + (Vector3.up * speed));

        holding = false;
        thrown = true;

        //Invoke("GameObject.FindObjectOfType<EncounterSystem>().ThrownPokeball(this.GetComponent<Pokeball>().pokeballCode)", 5.0f);
        Invoke("Reset", 5.0f);
    }
}
