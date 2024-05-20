using BussinessLayer.ViewModels;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Services
{
    public interface ICandidateService
    {
        Task<CandidateVM> AddCandidate(CandidateVM model);
    }
}
