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

        public void Delete()
        {
            throw new NotImplementedException();
        }

        public void Read()
        {
            throw new NotImplementedException();
        }

        public void Update(UserModel user)
        {
            _appDbContext.Birthday.Update(user);
            _appDbContext.SaveChanges();
        }
    }
}

