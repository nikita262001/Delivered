using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticWork4_Volkov_
{
    [Serializable]
    class Company
    {
        private string nameCompany;
        private DateTime companyFounded;

        public Company(string nameCompany_, DateTime companyFounded_)
        {
            this.NameCompany = nameCompany_;
            this.CompanyFounded = companyFounded_;
        }

        public DateTime CompanyFounded { get => companyFounded; set => companyFounded = value; }
        public string NameCompany { get => nameCompany; set => nameCompany = value; }
    }
}
