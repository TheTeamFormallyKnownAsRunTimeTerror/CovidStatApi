using System;
using System.Collections.Generic;
using System.Text;

namespace CovidStatApi.Domain.Domain
{
    public class CountryInfo
    {
        public string CountryId { get; set; }
        public string CountryName { get; set; }

        //TODO will need to check data types in db
        public string Latitude { get; set; }
        public string Longitude { get; set; }

        public int Active { get; set; }

        public override bool Equals(object obj)
        {
            var other = obj as CountryInfo;

            if(other == null)
            {
                return false;
            }

            return CountryId.Equals(other.CountryId);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
