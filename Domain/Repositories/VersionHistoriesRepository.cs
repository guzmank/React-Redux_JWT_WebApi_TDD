using Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Repositories
{
    public interface IVersionHistoriesRepository
    {

    }

    public class VersionHistoriesRepository : IVersionHistoriesRepository
    {
        HomeDBContext db;

        public VersionHistoriesRepository(HomeDBContext _db)
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
