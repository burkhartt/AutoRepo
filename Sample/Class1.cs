using System;
using System.Linq.Expressions;
using AutoRepo;
using Simple.Data;

namespace Sample
{
    public class Sample
    {
        public static void Main()
        {
            var coursesRepository = new CategoriesRepository();
            var allRecords = coursesRepository.FindAll();


            
            var fields = coursesRepository.FindAllByThisFieldAndValue(x => x.Sequence <= 3);
        }
    }

    public class CategoriesRepository : BaseRepository<CategoriesModel>
    {
        protected override dynamic GetDatabase()
        {
            return Database.Opener.OpenConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=AGCCNSNSDCS;Integrated Security=SSPI;");
        }
    }

    public class CategoriesModel
    {
        public string CategoryName { get; set; }

        public int Sequence { get; set; }

        public Guid CategoryId { get; set; }
    }
}
