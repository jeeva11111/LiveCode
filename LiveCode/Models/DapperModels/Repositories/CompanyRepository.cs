using Dapper;

namespace LiveCode.Models.DapperModels.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {

        private readonly DapperContext.DapperContextModel _context;

        public CompanyRepository(DapperContext.DapperContextModel context)
        {
            _context = context;
        }


        async Task<IEnumerable<Company>> ICompanyRepository.GetCompanies()
        {
            var query = "Select * from Companies";

            using (var connection = _context.CreateConnection())
            {
                var companyList = await connection.QueryAsync<Company>(query);
                return companyList.ToList();
            }
        }
    }

    public interface ICompanyRepository
    {
        public Task<IEnumerable<Company>> GetCompanies();

    }
}


// 