using UnityEngine;
using System.Collections.Generic;
using RtMidi.LowLevel;
using System.Collections;

sealed class MidiInTest : MonoBehaviour
{
    #region Private members

    public GridDisplay grid;

    int lastX = 0;
    int lastY = 0;

    CharacterMovements character;

    void MoveCharToXY()
    {
        if (lastX >= 0 && lastX < 8 && lastY >= 0 && lastY < 8)
        {
            character.MoveTo(grid.grid.GetWorldPosition(lastX, lastY));
           
        }
    }
    private IEnumerator RessetCoordinates()
    {
        yield return new WaitForSeconds(0.5f);
        
            lastX = -1;
            lastY = -1;
    
    }

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
                //note = value
                //Debug.Log(string.Format("NAME : {0} CHANNEL : [{1}] NOTE : On {2} VELOCITY :  ({3})", name, channel, note, velocity)),
                {

                    lastX = note%16 ==8? note/16 : -1;
                    MoveCharToXY();
                    Debug.Log($"x : {lastX}");
                },

                 OnNoteOff = (byte channel, byte note) =>
                      StartCoroutine(RessetCoordinates()),
                
                OnControlChange = (byte channel, byte number, byte value) => 
                {
                    //number = value{
                    lastY = number-104;
                    MoveCharToXY();
                    Debug.Log($"y:{lastY}");
                }
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

    void Start()
    {
        character = GetComponent<CharacterMovements>();
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

    #endregion
}
