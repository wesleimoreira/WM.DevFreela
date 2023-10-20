﻿namespace WM.DevFreela.Application.Queries.GetUser
{
    public class UserViewModel
    {
        public UserViewModel(string fullName, string email)
        {
            FullName = fullName;
            Email = email;
        }
        public string FullName { get; private set; }
        public string Email { get; private set; }
    }
}
