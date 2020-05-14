using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IContactsRepository
    {
        Task<List<Contacts>> GetContacts();
        Task<bool> SaveContact(Contacts contact);
        Task<bool> DeleteContact(int contactId);
    }

    public class ContactsRepository : IContactsRepository
    {
        HomeDBContext db;

        public ContactsRepository(HomeDBContext _db)
        {
            db = _db;
        }

        public async Task<List<Contacts>> GetContacts()
        {
            if (db != null)
            {
                //db.Contact.ToListAsync();

                return await (from a in db.Contacts.AsNoTracking()
                              select new Contacts
                              {
                                  ContactId = a.ContactId,
                                  FirstName = a.FirstName,
                                  LastName = a.LastName,
                                  Email = a.Email,
                                  Phone = a.Phone
                              }).ToListAsync();
            }

            return null;
        }

        public async Task<bool> SaveContact(Contacts contactModel)
        {
            if (db != null)
            {
                Contacts contact = db.Contacts.Where(x => x.ContactId == contactModel.ContactId).FirstOrDefault();

                if (contact == null)
                {
                    contact = new Contacts()
                    {
                        FirstName = contactModel.FirstName,
                        LastName = contactModel.LastName,
                        Email = contactModel.Email,
                        Phone = contactModel.Phone
                    };

                    db.Contacts.Add(contact);
                }
                else
                {
                    contact.FirstName = contactModel.FirstName;
                    contact.LastName = contactModel.LastName;
                    contact.Email = contactModel.Email;
                    contact.Phone = contactModel.Phone;
                }

                return await db.SaveChangesAsync() >= 1;
            }

            return false;
        }

        public async Task<bool> DeleteContact(int contactId)
        {
            if (db != null)
            {
                Contacts contact = db.Contacts.Where(x => x.ContactId == contactId).FirstOrDefault();

                if (contact != null)
                {
                    db.Contacts.Remove(contact);
                }

                return await db.SaveChangesAsync() >= 1;
            }

            return false;
        }

    }
}
