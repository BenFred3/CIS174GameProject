﻿using CIS174GameProject.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIS174GameProject.Shared.Orchestrators.Interfaces
{
    public interface IPersonOrchestrator
    {
        Task<int> CreatePerson(PersonViewModel person);
        Task<List<PersonViewModel>> GetAllPeople();
        Task<List<string>> GetAllEmails();
        Task<bool> UpdatePerson(PersonViewModel person);
        Task<PersonViewModel> SearchPeople(Guid searchGuid);
    }
}
