﻿using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_.Utility
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            return Task.CompletedTask;
        }
    }
}