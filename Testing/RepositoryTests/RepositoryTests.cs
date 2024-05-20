using ApplicationLayer.Controller;
using AutoMapper.Configuration.Annotations;
using DataAccessLayer.Common;
using DataAccessLayer.Data;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories;
using FakeItEasy;
using FluentAssertions;
using FluentAssertions.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Moq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Testing.RepositoryTests
{
    public class RepositoryTests
    {
           

        [Fact]
        public void AddCandidateRepositoryTest()
        {
            //Arrange
            var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
            var dbFactory = new DbFactory(configuration);
            var repository = new Repository<Candidate>(dbFactory);
            var candidate = new Candidate()
            {
                FirstName="y",
                LastName="h",
                PhoneNumber="4546",
                GitHubURL="",
                LinkedinURL="",
                Comment="hiii",
                Email = "y@yomna.com"

            };

            //Act
            var result=repository.Add(candidate);


            //Assert
            result.Should().NotBeNull();


        }


        [Fact]
        public void UpdateCandidateRepositoryTest()
        {
            //Arrange
            var configuration = new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("appsettings.json")
           .Build();
            var dbFactory = new DbFactory(configuration);
            var repository = new Repository<Candidate>(dbFactory);
            var candidate = new Candidate()
            {
                Id=1,
                FirstName = "yomna",
                LastName = "hassan",
                PhoneNumber = "5456",
                GitHubURL = "",
                LinkedinURL = "",
                Comment = "updated",
                Email="y@yomna.com"

            };

            //Act
            var result = repository.Update(candidate);


            //Assert
            result.Should().NotBeNull();


        }
    }
}
