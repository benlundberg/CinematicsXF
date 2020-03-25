using System.Collections.Generic;

namespace CinematicsXF.Core
{
    public class CreditsResult
    {
        public int Id { get; set; }
        public IEnumerable<PersonItem> Cast { get; set; }
        public IEnumerable<PersonItem> Crew { get; set; }
    }
}
