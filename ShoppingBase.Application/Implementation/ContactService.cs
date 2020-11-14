﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using ShoppingBase.Application.Interfaces;
using ShoppingBase.Application.ViewModels.Common;
using ShoppingBase.Data.Entities;
using ShoppingBase.Infrastructure.Interfaces;
using ShoppingBase.Utilities.Dtos;

namespace ShoppingBase.Application.Implementation
{
    public class ContactService : IContactService
    {
        private IRepository<Contact, string> _contactRepository;
        private IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ContactService(IRepository<Contact, string> contactRepository,
            IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._contactRepository = contactRepository;
            this._unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void Add(ContactViewModel pageVm)
        {
            var page = _mapper.Map<ContactViewModel, Contact>(pageVm);
            _contactRepository.Add(page);
        }

        public void Delete(string id)
        {
            _contactRepository.Remove(id);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public List<ContactViewModel> GetAll()
        {
            return _mapper.ProjectTo<ContactViewModel>(
                _contactRepository.FindAll()).ToList();
        }

        public PagedResult<ContactViewModel> GetAllPaging(string keyword, int page, int pageSize)
        {
            var query = _contactRepository.FindAll();
            if (!string.IsNullOrEmpty(keyword))
                query = query.Where(x => x.Name.Contains(keyword));

            int totalRow = query.Count();
            var data = query.OrderByDescending(x => x.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize);

            var paginationSet = new PagedResult<ContactViewModel>()
            {
                Results = _mapper.ProjectTo<ContactViewModel>(data).ToList(),
                CurrentPage = page,
                RowCount = totalRow,
                PageSize = pageSize
            };

            return paginationSet;
        }

        public ContactViewModel GetById(string id)
        {
            return _mapper.Map<Contact, ContactViewModel>(_contactRepository.FindById(id));
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(ContactViewModel pageVm)
        {
            var page = _mapper.Map<ContactViewModel, Contact>(pageVm);
            _contactRepository.Update(page);
        }
    }
}