using System;
namespace CleanArch.Droid.Model
{
    public class OwnerEntity
    {
        public OwnerEntity(String login, String avatarUrl)
        {
            this.login = login;
            this.avatarUrl = avatarUrl;
        }

        public string login { get; set; }

        public string avatarUrl { get; set; }
    }
}
