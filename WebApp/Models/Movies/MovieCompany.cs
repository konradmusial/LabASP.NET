using System;

namespace WebApp.Models.Movies
{
    public partial class MovieCompany
    {
        public int CompanyId { get; set; }
        public int MovieId { get; set; }

        public virtual Movie Movie { get; set; }
    }
}