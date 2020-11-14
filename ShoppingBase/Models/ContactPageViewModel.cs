﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShoppingBase.Application.ViewModels.Common;

namespace ShoppingBase.Models
{
    public class ContactPageViewModel
    {
        public ContactViewModel Contact { set; get; }

        public FeedbackViewModel Feedback { set; get; }
    }
}
