using CIS174GameProject.Domain;
using CIS174GameProject.Domain.Entities;
using CIS174GameProject.Shared.ViewModels;
using CIS174GameProject.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using CIS174GameProject.Shared.Orchestrators.Interfaces;

namespace CIS174GameProject.Shared.Orchestrators 
{
    public class PersonOrchestrator : IPersonOrchestrator
    {
        private readonly ProjectContext _projectContext;

        public PersonOrchestrator()
        {
            _projectContext = new ProjectContext();
        }

        public async Task<int> CreatePerson(PersonViewModel person)
        {
            _projectContext.People.Add(new Person
            {
                PersonId = person.PersonId,
                FirstName = person.FirstName,
                LastName = person.LastName,
                Gender = (int) person.Gender,
                DateCreated = DateTime.Now,
                Email = person.Email,
                PhoneNumber = person.PhoneNumber
            });

            return await _projectContext.SaveChangesAsync();
        }

        public Task<List<PersonViewModel>> GetAllPeople()
        {
            var people = _projectContext.People.Select(x => new PersonViewModel
            {
                PersonId = x.PersonId,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Gender = (GenderEnum) x.Gender, 
                DateCreated = x.DateCreated,
                Email = x.Email,
                PhoneNumber = x.PhoneNumber           
            }).ToListAsync();

            return people;
        }

        public async Task<List<string>> GetAllEmails()
        {
            var people = await _projectContext.People.Select(x => new PersonViewModel
            {
                PersonId = x.PersonId,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Gender = (GenderEnum)x.Gender,
                DateCreated = x.DateCreated,
                Email = x.Email,
                PhoneNumber = x.PhoneNumber
            }).ToListAsync();

            
            List<string> emails = new List<string>();
            for (int i = 0; i < people.Count; i++)
            {
                emails.Add(people[i].Email);
            }

            return emails;
        }

        public async Task<bool> UpdatePerson(PersonViewModel person)
        {
            var updateEntity = await _projectContext.People.FindAsync(person.PersonId);

            if (updateEntity == null)
            {
                return false;
            }

            updateEntity.FirstName = person.FirstName;
            updateEntity.LastName = person.LastName;
            updateEntity.Gender = (int) person.Gender;
            updateEntity.Email = person.Email;
            updateEntity.PhoneNumber = person.PhoneNumber;

            await _projectContext.SaveChangesAsync();

            return true;
        }

        public async Task<PersonViewModel> SearchPeople(Guid searchGuid)
        {
            var person = await _projectContext.People.Where(x => x.PersonId.Equals(searchGuid)).FirstOrDefaultAsync();

            if (person == null || person.PersonId == null)
            {
                return new PersonViewModel();
            }

            var viewModel = new PersonViewModel
            {
                PersonId = person.PersonId,
                FirstName = person.FirstName,
                LastName = person.LastName,
                Gender = (GenderEnum) person.Gender,
                DateCreated = person.DateCreated,
                Email = person.Email,
                PhoneNumber = person.PhoneNumber
            };

            return viewModel;
        }
    }
}
