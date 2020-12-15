using DB_DataAccess.Repository;

namespace DB_DataManager
{
    public class WorkWithDB
    {

        private static string connectionStrings;

        public WorkWithDB(string connectionString)
        {
            connectionStrings = connectionString;
        }

        public Person_Repository person_Repository=new Person_Repository(connectionStrings);
    }
}
