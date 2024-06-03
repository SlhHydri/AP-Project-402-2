using System;
using System.Text.RegularExpressions;

public class Validator
{
	public Validator() { }

	public bool IsNameValid(string name)
	{
		string pattern = @"^[a-zA-Z]{3,32}$";
		return Regex.IsMatch(pattern, name);
    }

    public bool IsEmailValid(string email)
    {
        string pattern = @"^(?={3,32}[a-zA-Z])([a-zA-Z0-9._-]{3,32})@(?={3,32}[a-zA-Z])([a-zA-Z0-9.-]{3,32})\.[a-zA-Z]{2,3}$";
        return Regex.IsMatch(pattern, email);
    }

    public bool IsPhoneNumberValid(string phone)
    {
        string pattern = @"^09[0-9]{9}$";
        return Regex.IsMatch(pattern, phone);
    }

    public bool IsPasswordValid(string pass)
    {
        string pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])[a-zA-Z0-9]{8,32}$";
        return Regex.IsMatch(pattern, pass);
    }

    public bool IsUsernameValid(string username)
    {
        string pattern = @"^(?=(.*[a-zA-Z]){3})[a-zA-Z0-9]{3,}$";
        return Regex.IsMatch(pattern, username);
    }
}