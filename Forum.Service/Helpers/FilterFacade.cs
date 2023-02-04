﻿using Forum.DAL.Entity;
using Forum.Model;
using Forum.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Service.Helpers
{
    public class FilterFacade : IFilterFacade
    {
        public IFilter<UserEntity> BuildUserFilter(IUserFilterModel userFilter)
        {
            var expressions = new Expression<Func<UserEntity, bool>>[typeof(IUserFilterModel).GetProperties().Length];
            if(userFilter != null)
            {
                if(userFilter.Username != null)
                {
                    expressions[0] = u => u.Username == userFilter.Username;
                }
                if (userFilter.FirstName != null)
                {
                    expressions[1] = u => u.FirstName == userFilter.FirstName;
                }
                if (userFilter.LastName != null)
                {
                    expressions[2] = u => u.LastName == userFilter.LastName;
                }
                if (userFilter.Email != null)
                {
                    expressions[3] = u => u.Email == userFilter.Email;
                }
                if (userFilter.Id != null)
                {
                    expressions[4] = u => u.Id == userFilter.Id;
                }
            }
            var filter = new Filter<UserEntity>();
            filter.Expressions = expressions.Where(e => e != null);
            return filter;
        }
        public IFilter<PostEntity> BuildPostFilter(IPostFilterModel postFilter)
        {
            var expressions = new Expression<Func<PostEntity, bool>>[typeof(IPostFilterModel).GetProperties().Length];
            if(postFilter != null)
            {
                if(postFilter.Id != null)
                {
                    expressions[0] = e => e.Id == postFilter.Id;
                }
                if (postFilter.UserId != null)
                {
                    expressions[1] = e => e.UserId == postFilter.UserId;
                }
            }
            var filter = new Filter<PostEntity>();
            filter.Expressions = expressions.Where(e => e != null);
            return filter;
        }
    }
}
