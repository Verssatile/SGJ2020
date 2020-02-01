using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInputs : MonoBehaviour
{
    int x = 0;
    int y = 0;
    CharacterMovements character;
    public GridDisplay gridDisplay;

    private void Start()
    {
        character = GetComponent<CharacterMovements>();
    }

    void Update()
    {
        x = GetInputX();
        y = GetInputY();
        
        if(CanMove())
        {
            character.MoveTo(gridDisplay.grid.GetWorldPosition(x, y));
        }
    }
    private bool CanMove()
    {
        return (x >= 0 && x < 8 && y >= 0 && y < 8);
    }

    int GetInputX()
    {
        if (Input.GetKey(KeyCode.A))
        {
            return 0;
        }
        if (Input.GetKey(KeyCode.B))
        {
            return 1;
        }
        if (Input.GetKey(KeyCode.C))
        {
            return 2;
        }
        if (Input.GetKey(KeyCode.D))
        {
            return 3;
        }
        if (Input.GetKey(KeyCode.E))
        {
            return 4;
        }
        if (Input.GetKey(KeyCode.F))
        {
            return 5;
        }
        if (Input.GetKey(KeyCode.G))
        {
            return 6;
        }
        if (Input.GetKey(KeyCode.H))
        {
            return 7;
        }
        else return -1;
    }
    int GetInputY()
    {
        if(Input.GetKey(KeyCode.Alpha1))
        {
            return 0;
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            return 1;
        }
        if (Input.GetKey(KeyCode.Alpha3))
        {
            return 2;
        }
        if (Input.GetKey(KeyCode.Alpha4))
        {
            return 3;
        }
        if (Input.GetKey(KeyCode.Alpha5))
        {
            return 4;
        }
        if (Input.GetKey(KeyCode.Alpha6))
        {
            return 5;
        }
        if (Input.GetKey(KeyCode.Alpha7))
        {
            return 6;
        }
        if (Input.GetKey(KeyCode.Alpha8))
        {
            return 7;
        }
        else return -1;
    }


}
