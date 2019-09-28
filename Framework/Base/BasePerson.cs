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
        public BasePerson(int nationalCode, string name, string surname)
        {
            NationalCode = nationalCode;
            Name = name;
            Surname = surname;
        }
        #endregion

        #region [- Props -]
        public int NationalCode { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public virtual string FullInfo => string.Format("{0} {1} {2}", NationalCode, Name, Surname);
        #endregion
    }
}
