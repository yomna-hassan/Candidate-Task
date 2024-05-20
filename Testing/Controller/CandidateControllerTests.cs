using BussinessLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FakeItEasy;
using Xunit;
using BussinessLayer.ViewModels;
using DataAccessLayer.Models;
using ApplicationLayer.Controller;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;

namespace Testing.Controller
{
    public class CandidateControllerTests
    {
        private readonly ICandidateService _candidateService;
        public CandidateControllerTests()
        {
            _candidateService = A.Fake<ICandidateService>();
        }

        [Fact]
        public async  void CandidateController_AddCandidateReturnedOK()
        {
            //Arrange 
            var candidateDto = A.Fake<CandidateVM>();
            var candidateCreated= A.Fake<CandidateVM>();
            A.CallTo(()=>_candidateService.AddCandidate(candidateDto)).Returns(candidateCreated);
            var controller = new CandidateController(_candidateService);

            //Act
            var result=await controller.AddCandidate(candidateDto);

            //Assert
            result.Should().NotBeNull();
        }


        [Fact]
        public async void CandidateController_AddCandidate_ReturnedBadRequest()
        {
            var candidateDto = A.Fake<CandidateVM>();
            var candidateCreated = A.Fake<CandidateVM>();
            A.CallTo(() => _candidateService.AddCandidate(candidateDto)).Returns(candidateCreated);
            var controller = new CandidateController(_candidateService);
            controller.ModelState.AddModelError("Email", "Required");


            //Act
            var result = await controller.AddCandidate(candidateDto);

            //Assert
            Assert.IsType<BadRequestObjectResult>(result);
           
        }

        public async  void CandidateController_AddCandidate_ReturnedException()
        {
            var candidateDto = A.Fake<CandidateVM>();
            var candidateCreated = A.Fake<CandidateVM>();
            A.CallTo(() => _candidateService.AddCandidate(candidateDto)).Returns(candidateCreated);
            var controller = new CandidateController(_candidateService);
            var exceptionType = typeof(InvalidOperationException);
            var expectionMessage = "The operation is invalid.";


            //Act
            var result = await controller.AddCandidate(candidateDto);
            var ex = Record.ExceptionAsync(() =>
            {
                throw new InvalidOperationException(expectionMessage);
            });

            //Assert
            Assert.Contains("invalid", ex.Result.Message);

        }
    }
}
