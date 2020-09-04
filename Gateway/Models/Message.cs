using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gateway.Models
{
    public class Message
    {
        //
        // Summary:
        //     The RFC 2822 date and time in GMT when the message was sent
        [JsonProperty("date_sent")]
        public DateTime? DateSent { get; }
        //
        // Summary:
        //     The RFC 2822 date and time in GMT that the resource was last updated
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; }
        //
        // Summary:
        //     The RFC 2822 date and time in GMT that the resource was created
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; }
        //
        // Summary:
        //     The message text
        [JsonProperty("body")]
        public string Body { get; }
        //
        // Summary:
        //     The API version used to process the message
        [JsonProperty("api_version")]
        public string ApiVersion { get; }
        //
        // Summary:
        //     The SID of the Account that created the resource
        [JsonProperty("account_sid")]
        public string AccountSid { get; }
        //
        // Summary:
        //     The description of the error_code
        [JsonProperty("error_message")]
        public string ErrorMessage { get; }
        //
        // Summary:
        //     The SID of the Messaging Service used with the message.
        [JsonProperty("messaging_service_sid")]
        public string MessagingServiceSid { get; }
        //
        // Summary:
        //     The number of media files associated with the message
        [JsonProperty("num_media")]
        public string NumMedia { get; }
        //
        // Summary:
        //     The number of messages used to deliver the message body
        [JsonProperty("num_segments")]
        public string NumSegments { get; }
        //
        // Summary:
        //     The amount billed for the message
        [JsonProperty("price")]
        public decimal? Price { get; }
        //
        // Summary:
        //     The currency in which price is measured
        [JsonProperty("price_unit")]
        public string PriceUnit { get; }
        //
        // Summary:
        //     The unique string that identifies the resource
        [JsonProperty("sid")]
        public string Sid { get; }
        //
        // Summary:
        //     The error code associated with the message
        [JsonProperty("error_code")]
        public int? ErrorCode { get; }
        //
        // Summary:
        //     A list of related resources identified by their relative URIs
        [JsonProperty("subresource_uris")]
        public Dictionary<string, string> SubresourceUris { get; }
        //
        // Summary:
        //     The phone number that received the message
        [JsonProperty("to")]
        public string To { get; }
        //
        // Summary:
        //     The URI of the resource, relative to `https://api.twilio.com`
        [JsonProperty("uri")]
        public string Uri { get; }
    }
}
