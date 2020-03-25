using System.Collections.Generic;

namespace CinematicsXF.Core
{
    public class SearchResultItem
    {
        public IEnumerable<MovieItem> Movies { get; set; }
        public IEnumerable<PersonItem> Persons { get; set; }
    }
}
