using AutoMapper;
using BussinessLayer.ViewModels;
using DataAccessLayer.Common;
using DataAccessLayer.Data;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace BussinessLayer.Services
{
    public class CandidateService : ICandidateService
    {
        private readonly IRepository<Candidate> _candidateRepo;
        private IMapper _mapper{ get; }
        private IUnitOfWork unitOfWork;
        public CandidateService(IRepository<Candidate> candidateRepo, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _candidateRepo = candidateRepo;
            this._mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public async Task<CandidateVM> AddCandidate(CandidateVM candidateVM)
        {
            if (candidateVM == null)
            {
                throw new Exception("InvalidInputData");
            }
           
            var model = _mapper.Map<Candidate>(candidateVM);
            if (candidateVM.Id != 0) 
             {
                 var updated = await _candidateRepo.Update(model);
                 var mappedObj=_mapper.Map<CandidateVM>(updated);
                 await unitOfWork.Commit();

                return mappedObj;
            }
             var added = await _candidateRepo.Add(model);
             var mapped = _mapper.Map<CandidateVM>(added);

            await unitOfWork.Commit();

            return mapped;


        }
    }
}
