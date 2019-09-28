using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DomainModel.POCO
{
   public class PersonCrud
    {
        #region [- ctor -]
        public PersonCrud()
        {

        }
        #endregion

        #region [- Insert -]
        public void Insert(string title, string nationalCode, string firstName, string surname , string country,
                           DateTime dateOfBirth, string contactEmail, string mobilNumber ,
                           string username, string password, string address)
        {
            using (var context = new Model.DomainModel.DTO.EF.OnlineShoppingEntities())
            {
                try
                {
                    Model.DomainModel.DTO.EF.Person ref_Person = new DTO.EF.Person();
                    ref_Person.Title = title;
                    ref_Person.NationalCode = nationalCode;
                    ref_Person.FirstName = firstName;
                    ref_Person.Surname = surname;
                    ref_Person.Country = country;
                    ref_Person.DateofBirth = dateOfBirth;
                    ref_Person.ContactEmail = contactEmail;
                    ref_Person.MobileNumber = mobilNumber;
                    ref_Person.Username = username;
                    ref_Person.Password = password;
                    ref_Person.Address = address;
                    context.Person.Add(ref_Person);
                    context.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    if (context != null)
                    {
                        context.Dispose();
                    }
                }
            }
        }
        #endregion

        #region [- Update -]
        public void Update(string id,string title, string nationalCode, string firstName, string surname, string country,
                           DateTime dateOfBirth, string contactEmail, string mobilNumber,
                           string username, string password, string address)
        {
            using (var context = new Model.DomainModel.DTO.EF.OnlineShoppingEntities())
            {
                try
                {
                    Model.DomainModel.DTO.EF.Person ref_Person = new DTO.EF.Person();
                    ref_Person = context.Person.Find(System.Convert.ToInt32(id));
                    ref_Person.Title = title;
                    ref_Person.NationalCode = nationalCode;
                    ref_Person.FirstName = firstName;
                    ref_Person.Surname = surname;
                    ref_Person.Country = country;
                    ref_Person.DateofBirth = dateOfBirth;
                    ref_Person.ContactEmail = contactEmail;
                    ref_Person.MobileNumber = mobilNumber;
                    ref_Person.Username = username;
                    ref_Person.Password = password;
                    ref_Person.Address = address;
                    context.Entry(ref_Person).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();                    
                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    if (context != null)
                    {
                        context.Dispose();
                    }
                }
            }
        }
        #endregion    

        #region [- Select() -]
        public List<DomainModel.DTO.EF.Person> Select(string nationalCode)
        {
            using (var context = new Model.DomainModel.DTO.EF.OnlineShoppingEntities())
            {
                try
                {
                    if (nationalCode=="")
                    {
                        var person = from b in context.Person
                                     where b.Username.StartsWith(nationalCode)
                                     select b;
                        var q = person.ToList();
                        return q;
                    }
                    else
                    { 
                    var person = context.Person.Where(s => s.NationalCode == nationalCode);

                    var q = person.ToList();
                    return q;
                    }

                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    if (context != null)
                    {
                        context.Dispose();
                    }
                }
            }
        }
        #endregion

        #region [-  Delete(int rowid ) -]
        public void Delete(int rowid )
        {
            using (var context = new Model.DomainModel.DTO.EF.OnlineShoppingEntities())
            {
                try
                {
                    Model.DomainModel.DTO.EF.Person ref_Person = new DTO.EF.Person();
                    ref_Person = context.Person.Find(rowid);
                    context.Person.Remove(ref_Person);
                    context.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    if (context != null)
                    {
                        context.Dispose();
                    }
                }
            }
        }
        #endregion
    }
}
