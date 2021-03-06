﻿using OpenCI.EmailTemplates.MVC.Attributes;

namespace OpenCI.EmailTemplates.MVC.Models
{
    [TemplateName("ResetPassword")]
    public class ResetPasswordModel : EmailTemplateModel
    {
        public int Id { get; set; }
        public string Link { get; set; }
        public string Token { get; set; }
    }
}