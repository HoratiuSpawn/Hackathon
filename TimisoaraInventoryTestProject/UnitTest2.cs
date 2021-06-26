using AutoMapper;
using Hackathon.Abstractions.Repositories;
using Hackathon.Controllers;
using Hackathon.Models;
using Hackathon.Models.DTOs;
using Hackathon.Persistance.AutoMapper;
using Hackathon.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TimisoaraInventoryTestProject
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public async Task TestMethod1()
        {
            var configuration = new MapperConfiguration(options => { options.CreateMap<PinTypes, PinTypesDto>(); });
            var pinTypeMapper = configuration.CreateMapper();
            var repositoryMockUp = new PinTypeRepositoryMockup();
            var pinTypeService = new PinTypesService(repositoryMockUp, pinTypeMapper);
            var pinTypeController = new PinTypesController(pinTypeService);
            
            var result = await pinTypeController.ReturnAll();
            Assert.IsNotNull(result);
            
            
            
            
        }
    }
    
        
}
