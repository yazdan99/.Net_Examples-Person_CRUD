using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
   public class PersonViewModel
    {
        #region [- ctor -]
        public PersonViewModel()
        {
            Ref_PersonCrud = new Model.DomainModel.POCO.PersonCrud();
        }
        #endregion

        #region [- Props -]
        public Model.DomainModel.POCO.PersonCrud Ref_PersonCrud { get; set; } 
        #endregion

        #region [- Edit(...) -]
        public void Edit(string id,string title, string nationalCode, string firstName, string surname, string country,
                           DateTime dateOfBirth, string contactEmail, string mobilNumber,
                           string username, string password, string address)
        {
            Ref_PersonCrud.Update( id,title,  nationalCode,  firstName,  surname,  country,
                            dateOfBirth,  contactEmail,  mobilNumber,
                            username,  password,  address);
        }
        #endregion

        #region [- Save(...) -]
        public void Save(string title, string nationalCode, string firstName, string surname, string country,
                           DateTime dateOfBirth, string contactEmail, string mobilNumber,
                           string username, string password, string address)
        {
            Ref_PersonCrud.Insert(title, nationalCode, firstName, surname, country,
                            dateOfBirth, contactEmail, mobilNumber,
                            username, password, address);
        }
        #endregion

        #region [- FillGrid() -]
        public dynamic FillGrid(string nationalCode)
        {
            return Ref_PersonCrud.Select(nationalCode);
        }
        #endregion

        #region [- Delete(int rowid) -]
        public void Delete(int rowid)
        {
            Ref_PersonCrud.Delete(rowid);
        }
        #endregion
    }
}
