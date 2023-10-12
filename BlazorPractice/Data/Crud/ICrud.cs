using System;
using BlazorPractice.Data.Models;

namespace BlazorPractice.Data
{
	public interface ICrud
	{
		void Create(UserModel user);
        List<UserModel> Read(UserModel user);
		void Update(UserModel user);
		void Delete(int user);
	}
}

