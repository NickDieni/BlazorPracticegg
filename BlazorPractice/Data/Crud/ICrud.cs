using System;
using BlazorPractice.Data.Models;

namespace BlazorPractice.Data
{
	public interface ICrud
	{
		void Create(UserModel user);
		void Read();
		void Update(UserModel user);
		void Delete();
	}
}

