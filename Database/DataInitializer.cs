using PCSProject.Domain;
using System.Linq;

namespace PCSProject.Database
{
    public class DataInitializer
    {
        public static void Initialize(DBContext _context)
        {
            if (!_context.QualificationLists.Any())
            {
                var types = new QualificationList[]
                {
                    new QualificationList{Q_Name="SLC"},
                    new QualificationList{Q_Name="Intermediate"},
                    new QualificationList{Q_Name="BE"},
                    new QualificationList{Q_Name="ME"},
                    new QualificationList{Q_Name="PHD"}
                };

                _context.AddRange(types);
                _context.SaveChanges();
            }
        }
    }
}
