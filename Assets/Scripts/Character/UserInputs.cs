using RtMidi.LowLevel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.InputSystem;


public class UserInputs : MonoBehaviour
{

    #region Private members

    MidiProbe _probe;
    List<MidiInPort> _ports = new List<MidiInPort>();

    // Does the port seem real or not?
    // This is mainly used on Linux (ALSA) to filter automatically generated
    // virtual ports.
    bool IsRealPort(string name)
    {
        return !name.Contains("Through") && !name.Contains("RtMidi");
    }

    // Scan and open all the available output ports.
    void ScanPorts()
    {
        for (var i = 0; i < _probe.PortCount; i++)
        {
            var name = _probe.GetPortName(i);
            Debug.Log("MIDI-in port found: " + name);

            _ports.Add(IsRealPort(name) ? new MidiInPort(i)
            {
                OnNoteOn = (byte channel, byte note, byte velocity) =>
                    Debug.Log(string.Format("{0} [{1}] On {2} ({3})", name, channel, note, velocity)),

                OnNoteOff = (byte channel, byte note) =>
                    Debug.Log(string.Format("{0} [{1}] Off {2}", name, channel, note)),

                OnControlChange = (byte channel, byte number, byte value) =>
                    Debug.Log(string.Format("{0} [{1}] CC {2} ({3})", name, channel, number, value))
            } : null
            );
        }
    }

    // Close and release all the opened ports.
    void DisposePorts()
    {
        foreach (var p in _ports) p?.Dispose();
        _ports.Clear();
    }

    #endregion

    #region MonoBehaviour implementation
    /*
    void Start()
    {
        _probe = new MidiProbe(MidiProbe.Mode.In);
    }

    void Update()
    {
        // Rescan when the number of ports changed.
        if (_ports.Count != _probe.PortCount)
        {
            DisposePorts();
            ScanPorts();
        }

        // Process queued messages in the opened ports.
        foreach (var p in _ports) p?.ProcessMessages();
    }

    void OnDestroy()
    {
        _probe?.Dispose();
        DisposePorts();
    }
    */
    #endregion

    int x = 0;
    int y = 0;
    CharacterMovements character;
    public GridDisplay gridDisplay;
  
    
    void Update()
    {
      
        
        x = GetInputX();
        y = GetInputY();
        
        if(CanMove())
        {
            Debug.Log("");
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
