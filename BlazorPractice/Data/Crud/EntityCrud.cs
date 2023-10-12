using System;
using BlazorPractice.Data.Models;
using Microsoft.EntityFrameworkCore;


namespace BlazorPractice.Data.Crud
{
	public class EntityCrud : ICrud
	{
        private readonly ApplicationDbContext _appDbContext;

        public EntityCrud(ApplicationDbContext appDbContext)
		{
            _appDbContext = appDbContext;
        }

        public void Create(UserModel user)
        {
            _appDbContext.Birthday.Add(user);
            _appDbContext.SaveChanges();
        }

        public void Delete(int user)
        {
            var resultUser = _appDbContext.Birthday.Find(user);
            if (resultUser != null)
            {
                _appDbContext.Birthday.Remove(resultUser);
                _appDbContext.SaveChanges();
            }
        }

        public List<UserModel> Read(UserModel user)
        {
            List<UserModel> userList = _appDbContext.Birthday.ToList();
            return userList;
        }

        public void Update(UserModel user)
        {
            _appDbContext.Birthday.Update(user);
            _appDbContext.SaveChanges();
        }
    }
}

