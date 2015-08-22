using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.Utilities.BaseCore.Analytics
{
    public class AnalyticsDatabase
    {
          private string conn;

        private DataContext _context;
        public DataContext Context
        {
            get
            {
                if (_context == null)
                {
                    
                    _context = new DataContext(conn);
                }
                return _context;
            }
        }

        public AnalyticsDatabase()
            : this(Sitecore.Analytics.Data.DataAccess.DataAdapterManager.ConnectionStrings.Reporting)
        {
        }

        public AnalyticsDatabase(string stConnection)
        {
            conn = stConnection;
        }

        public Table<Conversions> Conversions()
        {
            return Context.GetTable<Conversions>();
        }

        
        /// <summary>
        /// Most Common searches that produced some results
        /// </summary>
        /// <param name="count">max number of top terms to return</param>
        /// <returns>Enumerable with searchterms</returns>
        public IEnumerable<string> MostCommonSearches(int count = 5)
        {

            var noresults = Conversions()
                .Where(pe => pe.PageEventDefinitionId == Guid.Parse("{632525EF-985B-44C5-BD29-353634C99C64}"))
                .Select(pe => pe.GoalName)
                .Distinct();

            var pouplarsearches = Conversions()
                .Where(pe => pe.PageEventDefinitionId == Guid.Parse("{0C179613-2073-41AB-992E-027D03D523BF}"))
                .GroupBy(pe => pe.GoalName)
                .OrderByDescending(g => g.Count())
                .Select(g => g.Key);

           return pouplarsearches.Except(noresults).Take(count).ToArray();
        }


        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
