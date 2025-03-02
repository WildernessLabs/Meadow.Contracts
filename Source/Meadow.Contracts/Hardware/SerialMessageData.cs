using System;
using System.Text;

namespace Meadow.Hardware
{
    /// <summary>
    /// Represents a `SerialMessagePort` message consisting of a `byte[]` of the
    /// actual message data.
    /// </summary>
    public class SerialMessageData : EventArgs
    {
        /// <summary>
        /// A `byte[]` of the actual message data.
        /// </summary>
        public byte[] Message { get; set; } = Array.Empty<byte>();

        /// <summary>
        /// Returns a decoded version of the <see cref="Message"/> based on the specified <paramref name="encoding"/>.
        /// </summary>
        /// <param name="encoding">The character encoding used to interpret the message. (Usually <see cref="Encoding.ASCII"/>)</param>
        /// <returns>A string that contains the results of decoding the <see cref="Message"/> bytes.</returns>
        public string GetMessageString(Encoding encoding)
        {
            return encoding.GetString(Message);
        }
        /// <summary>
        /// Returns a <see cref="SerialMessageData"/> that represents <paramref name="message"/> encoded as bytes.
        /// </summary>
        /// <param name="message">The message to be encoded</param>
        /// <param name="encoding">The character encoding used to get the underlying bytes. (Usually <see cref="Encoding.ASCII"/>)</param>
        /// <returns></returns>
        public static SerialMessageData FromString(string message, Encoding encoding)
        {
            return new SerialMessageData() { Message = encoding.GetBytes(message) };
        }
    }
}
