﻿using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using System.Linq;
using MimeKit;

namespace Test_Shop.Shared.Models.Identity
{
    public class Message
    {
        public List<MailboxAddress> To { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public IFormFileCollection Attachments { get; set; }

        public Message(IEnumerable<string> to, string subject, string content, IFormFileCollection attachments)
        {
            To = new List<MailboxAddress>();

            To.AddRange(to.Select(x => new MailboxAddress("", x)));
            Subject = subject;
            Content = content;
            Attachments = attachments;
        }
    }
}
