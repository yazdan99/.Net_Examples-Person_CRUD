using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Interface
{
    public interface IPerson
    {
        #region [- props -]
        string Name { get; set; }
        string Surname { get; set; }
        string NationalCode { get; set; }
        string MobileNumber { get; set; }
        string Title { get; set; }
        #endregion
    }
}
