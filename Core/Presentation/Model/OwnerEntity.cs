using System;
namespace Core.Presentation.Model
{
    public class OwnerEntity
    {
        public OwnerEntity(string login, string avatarUrl)
        {
            this.login = login;
            this.avatarUrl = avatarUrl;
        }

        public string login { get; set; }

        public string avatarUrl { get; set; }
    }
}
