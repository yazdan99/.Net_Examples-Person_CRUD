using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Base
{
    public class BasePerson : Framework.Interface.IPerson
    {
        #region [- ctor -]
        public BasePerson(string name, string surname, string nationalCode,string mobileNumber,string title)
        {
            Name = name;
            Surname = surname;
            NationalCode = nationalCode;
            MobileNumber = mobileNumber;
            Title = title;
        }
        #endregion

        #region [- Props -]
        public string Name { get; set; }
        public string Surname { get; set; }
        public string NationalCode { get; set; }
        public string MobileNumber { get; set; }
        public string Title { get; set; }
        #endregion
    }
}
