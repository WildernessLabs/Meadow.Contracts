using System;

namespace Meadow.Modbus;

/// <summary>
/// Delegate for handling Modbus read requests.
/// </summary>
public delegate IModbusResult? ReadDelegate(byte modbusAddress, ushort startRegister, short length);
/// <summary>
/// Delegate for handling Modbus write coil requests.
/// </summary>
public delegate IModbusResult? WriteCoilDelegate(byte modbusAddress, ushort startRegister, bool[] data);
/// <summary>
/// Delegate for handling Modbus write register requests.
/// </summary>
public delegate IModbusResult? WriteRegisterDelegate(byte modbusAddress, ushort startRegister, ushort[] data);

/// <summary>
/// Interface for a Modbus server.
/// </summary>
public interface IModbusServer : IDisposable
{
    /// <summary>
    /// Event that is raised when a read coil request is received.
    /// </summary>
    event ReadDelegate? ReadCoilRequest;

    /// <summary>
    /// Event that is raised when a read discrete request is received.
    /// </summary>
    event ReadDelegate? ReadDiscreteRequest;

    /// <summary>
    /// Event that is raised when a read holding register request is received.
    /// </summary>
    event ReadDelegate? ReadHoldingRegisterRequest;

    /// <summary>
    /// Event that is raised when a read input register request is received.
    /// </summary>
    event ReadDelegate? ReadInputRegisterRequest;

    /// <summary>
    /// Event that is raised when a write coil request is received.
    /// </summary>
    event WriteCoilDelegate? WriteCoilRequest;

    /// <summary>
    /// Starts the Modbus server.
    /// </summary>
    void Start();

    /// <summary>
    /// Stops the Modbus server.
    /// </summary>
    void Stop();

    /// <summary>
    /// Gets a value indicating whether the server is running.
    /// </summary>
    bool IsRunning { get; }

    /// <summary>
    /// Gets a value indicating whether the server is disposed.
    /// </summary>
    bool IsDisposed { get; }
}
