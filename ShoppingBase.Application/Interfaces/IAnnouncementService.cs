using System;
using System.Collections.Generic;
using System.Text;
using ShoppingBase.Application.ViewModels.System;
using ShoppingBase.Data.Entities;
using ShoppingBase.Infrastructure.Interfaces;
using ShoppingBase.Utilities.Dtos;

namespace ShoppingBase.Application.Interfaces
{
    public interface IAnnouncementService
    {
        PagedResult<AnnouncementViewModel> GetAllUnReadPaging(Guid userId, int pageIndex, int pageSize);

        bool MarkAsRead(Guid userId, string id);
    }
}
