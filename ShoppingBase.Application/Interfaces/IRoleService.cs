﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ShoppingBase.Application.ViewModels.System;
using ShoppingBase.Data.Entities;
using ShoppingBase.Utilities.Dtos;

namespace ShoppingBase.Application.Interfaces
{
    public interface IRoleService
    {
        Task<bool> AddAsync(AnnouncementViewModel announcement,List<AnnouncementUserViewModel> announcementUsers, AppRoleViewModel userVm);

        Task DeleteAsync(Guid id);

        Task<List<AppRoleViewModel>> GetAllAsync();

        PagedResult<AppRoleViewModel> GetAllPagingAsync(string keyword, int page, int pageSize);

        Task<AppRoleViewModel> GetById(Guid id);


        Task UpdateAsync(AppRoleViewModel userVm);

        List<PermissionViewModel> GetListFunctionWithRole(Guid roleId);

        void SavePermission(List<PermissionViewModel> permissions, Guid roleId);

        Task<bool> CheckPermission(string functionId, string action, string[] roles);
    }
}
