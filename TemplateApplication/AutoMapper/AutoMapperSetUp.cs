using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Application.ViewModel;
using Template.Domain.Entities;

namespace Template.Application.AutoMapper
{
    public class AutoMapperSetUp: Profile
    {
        public AutoMapperSetUp()
        {
            #region ViewModelToDomain

            CreateMap<UserViewModel, User>();

            #endregion

            #region DomainToViewModel

            CreateMap<User, UserViewModel>();

            #endregion 
        }
    }
}
