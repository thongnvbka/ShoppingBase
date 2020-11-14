using System;
using System.Collections.Generic;
using System.Text;
using ShoppingBase.Application.ViewModels.Common;

namespace ShoppingBase.Application.Interfaces
{
    public interface ICommonService
    {
        FooterViewModel GetFooter();
        List<SlideViewModel> GetSlides(string groupAlias);
        SystemConfigViewModel GetSystemConfig(string code);
    }
}
