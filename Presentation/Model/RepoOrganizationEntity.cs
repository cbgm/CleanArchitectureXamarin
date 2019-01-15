using System;
namespace CleanArch.Droid.Model
{
    public class RepoOrganizationEntity
    {
        public RepoOrganizationEntity(int id, string name, string description, string language, string html_url, OwnerEntity owner)
        {
            this.id = id;
            this.name = name;
            this.description = description;
            this.language = language;
            this.html_url = html_url;
            this.owner = owner;
        }

        public int id { get; set; }

        public string name { get; set; }

        public string description { get; set; }

        public string language { get; set; }

        public string html_url { get; set; }

        public OwnerEntity owner { get; set; }
    }
}
