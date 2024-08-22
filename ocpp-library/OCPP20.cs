using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace OcppLibrary
{
    public class OCPP20
    {
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public enum MessageType
        {
            BootNotification,
            Authorize,
            StartTransaction,
            StopTransaction,
            Heartbeat,
            MeterValues,
            StatusNotification
        }

        public abstract class BootNotificationBase
        {
            public string ChargePointVendor { get; set; }
            public string ChargePointModel { get; set; }
            public string ChargePointSerialNumber { get; set; }
            public string FirmwareVersion { get; set; }
            public string ICMSerialNumber { get; set; }
            public string MeterSerialNumber { get; set; }
        }

        [Serializable]
        public class BootNotificationRequest : BootNotificationBase
        {
        }

        [Serializable]
        public class BootNotificationResponse
        {
            public string Status { get; set; }
            public string Interval { get; set; }
        }

        [Serializable]
        public class AuthorizeRequest
        {
            public string IdTagInfo { get; set; }
        }

        [Serializable]
        public class AuthorizeResponse
        {
            public string IdTagInfo { get; set; }
        }

        [Serializable]
        public class StartTransactionRequest
        {
            public string ConnectorId { get; set; }
            public string IdTag { get; set; }
            public string MeterStart { get; set; }
            public string TIMESTAMP { get; set; }
        }

        [Serializable]
        public class StartTransactionResponse
        {
            public string TransactionId { get; set; }
            public string IdTagInfo { get; set; }
        }

        [Serializable]
        public class StopTransactionRequest
        {
            public string TransactionId { get; set; }
            public string IdTag { get; set; }
            public string MeterStop { get; set; }
            public string TIMESTAMP { get; set; }
        }

        [Serializable]
        public class StopTransactionResponse
        {
            public string IdTagInfo { get; set; }
        }

        [Serializable]
        public class HeartbeatRequest
        {
        }

        [Serializable]
        public class HeartbeatResponse
        {
            public string CurrentTime { get; set; }
        }

        [Serializable]
        public class MeterValuesRequest
        {
            public string MeterValue { get; set; }
        }

        [Serializable]
        public class MeterValuesResponse
        {
        }

        [Serializable]
        public class StatusNotificationRequest
        {
            public string ConnectorId { get; set; }
            public string Status { get; set; }
            public string ErrorCode { get; set; }
            public string Info { get; set; }
            public string VendorId { get; set; }
            public string VendorErrorCode { get; set; }
        }

        [Serializable]
        public class StatusNotificationResponse
        {
        }

        public static string SerializeRequest(object request)
        {
            return JsonSerializer.Serialize(request);
        }

        public static T DeserializeResponse<T>(string response)
        {
            return JsonSerializer.Deserialize<T>(response);
        }

        public static object DeserializeResponse(string response, MessageType messageType)
        {
            return messageType switch
            {
                MessageType.BootNotification => DeserializeResponse<BootNotificationResponse>(response),
                MessageType.Authorize => DeserializeResponse<AuthorizeResponse>(response),
                MessageType.StartTransaction => DeserializeResponse<StartTransactionResponse>(response),
                MessageType.StopTransaction => DeserializeResponse<StopTransactionResponse>(response),
                MessageType.Heartbeat => DeserializeResponse<HeartbeatResponse>(response),
                MessageType.MeterValues => DeserializeResponse<MeterValuesResponse>(response),
                MessageType.StatusNotification => DeserializeResponse<StatusNotificationResponse>(response),
                _ => throw new ArgumentException("Invalid message type", nameof(messageType)),
            };
        }
    }
}