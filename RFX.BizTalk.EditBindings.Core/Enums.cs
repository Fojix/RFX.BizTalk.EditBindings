using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFX.BizTalk.EditBindings.Core
{

    public enum ServiceRefState
    {
        Default,
        Unenlisted,
        Enlisted,
        Started
    }

    public enum OrchestrationTrackingType
    {
        InboundMessageBody,
        MessageSendReceive,
        None,
        OrchestrationEvents,
        OutboundMessageBody,
        ServiceStartEnd,
        TrackPropertiesForIncomingMessages,
        TrackPropertiesForOutgoingMessages
    }

    public enum HostType
    {
        InProcess = 1,
        Invalid = 0,
        Isolated = 2
    }

    public enum RoleType
    {
        Uknown,
        Implements,
        Uses
    }

    public enum BindingStatus
    {
        Unknown,
        NoBindings,
        Unbound,
        PartiallyBound,
        FullyBound
    }

    public enum PipelineType
    {
        Receive = 1,
        Send = 2,
        Transform = 3,
        Unknown = 0
    }

    public enum PipelineTrackingType
    {
        InboundMessageBody,
        MessageSendReceive,
        None,
        OutboundMessageBody,
        PipelineEvents,
        ServiceStartEnd
    }

    public enum BindingType
    {
        Direct = 3,
        Dynamic = 4,
        Logical = 1,
        Physical = 2,
        Role = 5,
        Unknown = 0
    }

    public enum CapabilityType
    {
        ApplicationProtocol = 16,
        DeleteProtected = 32,
        InitInboundProtocolContext = 2048,
        InitOutboundProtocolContext = 1024,
        InitReceiveLocationContext = 4096,
        InitTransmitLocationContext = 8192,
        InitTransmitterOnServiceStart = 32678,
        ReceiveIsCreatable = 8,
        RequireSingleInstance = 4,
        StaticHandlers = 64,
        SupportsOrderedDelivery = 16384,
        SupportsReceive = 1,
        SupportsRequestResponse = 128,
        SupportsSend = 2,
        SupportsSoap = 512,
        SupportsSolicitResponse = 256
    }

    public enum CertUsageType
    {
        Both = 3,
        Encryption = 1,
        None = 0,
        Signature = 2
    }
}
