using System;
using System.Collections.Generic;
using System.Text;

namespace Revision.Epreuve.DAL.RepositoriesDAO
{
    public abstract class ServiceBase
    {
        protected string _connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Demo.CinemaProject.Database;Integrated Security=True";
    }
}
