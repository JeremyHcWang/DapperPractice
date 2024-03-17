using Dapper;
using DapperApplicationCore.Models;
using DapperApplicationCore.RepositoryInterface;
using DapperInfrastructure.Data;

namespace DapperInfrastructure.Repositories;

public class ReviewRepository(PracticeDbContext practiceDbContext) : IReviewRepository
{
    private readonly PracticeDbContext _practiceDbContext = practiceDbContext;

    public int Insert(Review entity)
    {
        var conn = _practiceDbContext.GetDbConnection();

        return conn.Execute("INSERT INTO Reviews VALUES (@content)", entity);
    }

    public int Update(Review entity)
    {
        var conn = _practiceDbContext.GetDbConnection();
        return conn.Execute("UPDATE Reviews SET Content=@Content where Id=@Id", entity);
    }

    public int Delete(int id)
    {
        var conn = _practiceDbContext.GetDbConnection();
        return conn.Execute("DELETE FROM Reviews Where Id=@id", id);
    }

    public IEnumerable<Review> GetAll()
    {
        var conn = _practiceDbContext.GetDbConnection();
        return conn.Query<Review>("SELECT Id, Content FROM Reviews");
    }

    public Review GetById(int id)
    {
        var conn = _practiceDbContext.GetDbConnection();
        return conn.QueryFirstOrDefault<Review>("SELECT Id, Content FROM Reviews WHERE Id=@id", id);
    }
}