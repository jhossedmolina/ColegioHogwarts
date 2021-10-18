using ColegioHogwarts.Core.Entities;
using System;
using System.Threading.Tasks;

namespace ColegioHogwarts.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Candidate> CandidateRepository { get; }
        ISecurityRepository SecurityRepository { get; }
        void SaveChanges();
        Task SaveChangesAsync();
    }
}
