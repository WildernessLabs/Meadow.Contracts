﻿namespace Meadow.Hardware
{
    public interface ICanChannelInfo : IDigitalChannelInfo
    {
        //TODO: what else should this have? allowed speeds?
        // what does it share with the other digital comm protocols?
        // if it does, we need an IDigitalCommunicationProtocol or something?
    }
}
