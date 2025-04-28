namespace Meadow.Gateways.Bluetooth;

/// <summary>
/// Extension methods for Meadow Bluetooth objects
/// </summary>
public static class BluetoothExtensionMethods
{
    /// <summary>
    /// Returns true if an ICharacteristic can be read, otherwise False
    /// </summary>
    /// <param name="c"></param>
    /// <returns></returns>
    public static bool CanBeRead(this ICharacteristic c)
    {
        if ((c.Properties | CharacteristicProperty.Read) != CharacteristicProperty.Read)
        {
            return false;
        }

        return c.Permissions switch
        {
            CharacteristicPermission.Read => true,
            CharacteristicPermission.ReadEncMITM => true,
            CharacteristicPermission.ReadEncrypted => true,
            _ => false
        };
    }
}

/// <summary>
/// Delegate representing the event handler for the ValueSet event of a Bluetooth characteristic.
/// </summary>
/// <param name="c">The characteristic associated with the event.</param>
/// <param name="data">The data associated with the event.</param>
public delegate void CharacteristicValueSetHandler(ICharacteristic c, object data);

/// <summary>
/// Delegate representing the event handler for the ServerValueSet event of a Bluetooth characteristic.
/// </summary>
/// <param name="c">The characteristic associated with the event.</param>
/// <param name="valueBytes">The value bytes associated with the event.</param>
public delegate void ServerValueChangedHandler(ICharacteristic c, byte[] valueBytes);

/// <summary>
/// Represents a Bluetooth characteristic.
/// </summary>
public interface ICharacteristic : IAttribute
{
    /// <summary>
    /// Occurs when the value of the characteristic is set.
    /// </summary>
    event CharacteristicValueSetHandler ValueSet;

    /// <summary>
    /// Occurs when the server value of the characteristic is set.
    /// </summary>
    event ServerValueChangedHandler ServerValueSet;

    /// <summary>
    /// Sets the value of the characteristic.
    /// </summary>
    /// <param name="value">The value to set.</param>
    void SetValue(object value);

    /// <summary>
    /// Gets the name of the characteristic. This is only for user reference and is not used in Bluetooth Low Energy (BLE) functionality.
    /// </summary>
    string Name { get; }

    /// <summary>
    /// Gets the UUID of the characteristic.
    /// </summary>
    string Uuid { get; }

    /// <summary>
    /// Gets the permissions of the characteristic.
    /// </summary>
    CharacteristicPermission Permissions { get; }

    /// <summary>
    /// Gets the properties of the characteristic.
    /// </summary>
    CharacteristicProperty Properties { get; }

    /// <summary>
    /// Gets the maximum length of the characteristic value.
    /// </summary>
    int MaxLength { get; }

    /// <summary>
    /// Gets the descriptors associated with the characteristic.
    /// </summary>
    IDescriptor[] Descriptors { get; }
}