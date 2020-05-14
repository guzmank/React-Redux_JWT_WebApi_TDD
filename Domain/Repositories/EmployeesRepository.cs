using Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Repositories
{
    public interface IEmployeesRepository
    {
        
    }

    public class EmployeesRepository : IEmployeesRepository
    {
        HomeDBContext db;

        public EmployeesRepository(HomeDBContext _db)
        {
            db = _db;
        }

        #region << GET >>



        #endregion

        #region << GET BY ID >>



        #endregion

        #region << GET - SEARCHER >>



        #endregion

        #region << CREATE - POST >>



        #endregion

        #region << UPDATE - PUT >>



        #endregion

        #region << DELETE >>



        #endregion

    }

}
