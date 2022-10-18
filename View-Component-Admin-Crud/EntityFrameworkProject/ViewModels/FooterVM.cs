using EntityFrameworkProject.Models;
using System.Collections.Generic;


namespace EntityFrameworkProject.ViewModels
{
    public class FooterVM
    {
        public Dictionary<string, string> Settings { get; set; }
        public IEnumerable<Social> Socials { get; set; }
    }
}
