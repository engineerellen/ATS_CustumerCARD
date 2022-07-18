using System.Threading.Tasks;

namespace ATS.Domain.Interfaces
{
    public interface IUnitOfWork
    {
          Task Commit();
    }
}