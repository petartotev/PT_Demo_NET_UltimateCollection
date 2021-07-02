using CarDemo.Services.Models.Engine;
using System;
using System.Collections.Generic;

namespace CarDemo.Services.Contracts
{
    public interface IEngineService
    {
        IEnumerable<EngineServiceModel> GetAllEngines();

        EngineServiceModel GetEngineById(Guid id);
    }
}
