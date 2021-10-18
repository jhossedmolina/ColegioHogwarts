using ColegioHogwarts.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ColegioHogwarts.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Candidate> CandidateRepository { get; }
        void SaveChanges();
        Task SaveChangesAsync();
    }
}
