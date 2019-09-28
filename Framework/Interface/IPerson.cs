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
        int NationalCode { get; set; }
        string Name { get; set; }
        string Surname { get; set; }
        string FullInfo { get; } 
        #endregion
    }
}
