using System;
using System.Collections.Generic;
using System.Text;
using ShoppingBase.Data.Enums;

namespace ShoppingBase.Data.Interfaces
{
    public interface ISwitchable
    {
        Status Status { set; get; }
    }
}
