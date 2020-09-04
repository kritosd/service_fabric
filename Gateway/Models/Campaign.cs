using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gateway.Models
{
    public class Campaign
    {
        //
        // Summary:
        //     Gets or sets the identifier.
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public long Id { get; set; }
        //
        // Summary:
        //     Gets or sets the title.
        [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get; set; }
        //
        // Summary:
        //     Gets or sets the subject.
        [JsonProperty("subject", NullValueHandling = NullValueHandling.Ignore)]
        public string Subject { get; set; }
        //
        // Summary:
        //     Gets or sets the sender identifier.
        [JsonProperty("sender_id", NullValueHandling = NullValueHandling.Ignore)]
        public long SenderId { get; set; }
        //
        // Summary:
        //     Gets or sets the lists.
        [JsonProperty("list_ids", NullValueHandling = NullValueHandling.Ignore)]
        public long[] Lists { get; set; }
        //
        // Summary:
        //     Gets or sets the segments.
        [JsonProperty("segment_ids", NullValueHandling = NullValueHandling.Ignore)]
        public long[] Segments { get; set; }
        //
        // Summary:
        //     Gets or sets the categories.
        [JsonProperty("categories", NullValueHandling = NullValueHandling.Ignore)]
        public string[] Categories { get; set; }
        //
        // Summary:
        //     Gets or sets the suppression group identifier.
        [JsonProperty("suppression_group_id", NullValueHandling = NullValueHandling.Ignore)]
        public long? SuppressionGroupId { get; set; }
        //
        // Summary:
        //     Gets or sets the custom unsubscribe URL.
        [JsonProperty("custom_unsubscribe_url", NullValueHandling = NullValueHandling.Ignore)]
        public string CustomUnsubscribeUrl { get; set; }
        //
        // Summary:
        //     Gets or sets the ip pool.
        [JsonProperty("ip_pool", NullValueHandling = NullValueHandling.Ignore)]
        public string IpPool { get; set; }
        //
        // Summary:
        //     Gets or sets the HTML content.
        [JsonProperty("html_content", NullValueHandling = NullValueHandling.Ignore)]
        public string HtmlContent { get; set; }
        //
        // Summary:
        //     Gets or sets the plain text content.
        [JsonProperty("plain_content", NullValueHandling = NullValueHandling.Ignore)]
        public string TextContent { get; set; }
    }
    public class MailAddress
    {
        //
        // Summary:
        //     Initializes a new instance of the StrongGrid.Models.MailAddress class.
        //
        // Parameters:
        //   email:
        //     The email.
        //
        //   name:
        //     The name.
        //public MailAddress(string email, string name);

        //
        // Summary:
        //     Gets or sets the email.
        [JsonProperty("email", NullValueHandling = NullValueHandling.Ignore)]
        public string Email { get; set; }
        //
        // Summary:
        //     Gets or sets the name.
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }
    }

    public class SendEmailDescriptor
    {
        public MailAddress to { get; set; }
        public MailAddress from { get; set; }
        public string subject { get; set; }
        public string htmlContent { get; set; }
        public string textContent { get; set; }
    }
}
