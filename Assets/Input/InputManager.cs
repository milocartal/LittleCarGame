using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{

    public static InputManager instance = null;
    public static InputManager Instance
    {
        get
        {
            if(instance == null)
            {
                instance = FindObjectOfType<InputManager>();
                if (instance == null)
                {
                    GameObject inputManager = new GameObject("InputManager");
                    instance = (inputManager.AddComponent<InputManager>());
                }
            }
            return instance;
        }
    }
   
    public bool MenuOpenCloseInput { get; private set; }

    private PlayerInput _playerInput;

    private InputAction _menuOpenCloseAction;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
            return;
        }

        _playerInput = GetComponent<PlayerInput>();
        _menuOpenCloseAction = _playerInput.actions["MenuOpenClose"];

        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        MenuOpenCloseInput = _menuOpenCloseAction.WasPressedThisFrame();
    }
}
