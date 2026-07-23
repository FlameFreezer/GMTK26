using UnityEngine;
using UnityEngine.InputSystem;

public class ClickTest : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        var interact = InputSystem.actions.FindAction("Interact");
        interact.performed += OnClick;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnClick(InputAction.CallbackContext context)
    {
        Vector2 mousePos = Mouse.current.position.ReadValue();
        Vector3 mousePosWorld = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 0.0f));
        Vector3 size = GetComponent<SpriteRenderer>().sprite.bounds.size;
        Vector3 pos = GetComponent<Transform>().position;
        Vector3 scale = GetComponent<Transform>().localScale;
        bool xWithin = mousePosWorld.x >= pos.x - size.x / 2 * scale.x && mousePosWorld.x <= pos.x + size.x / 2 * scale.x;
        bool zWithin = mousePosWorld.z >= pos.z - size.z / 2 * scale.z && mousePosWorld.z <= pos.z + size.z / 2 * scale.z;
        if(xWithin && zWithin)
        {
            Debug.Log("I am the one!");
        }
    }
}
