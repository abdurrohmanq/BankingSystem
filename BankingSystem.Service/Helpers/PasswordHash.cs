using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.Service.Helpers;

public static class PasswordHash
{
	public static string Hash(string password)
		=> BCrypt.Net.BCrypt.HashPassword(password);

	public static bool Verify(string password,string hashedPassword)
		=> BCrypt.Net.BCrypt.Verify(password, hashedPassword);
}
