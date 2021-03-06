﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OpenCI.Business.Models;

namespace OpenCI.Business.Contracts
{
    public interface IProjectOperations
    {
        Task<List<ProjectModel>> GetAllProjects();
        Task<ProjectModel> GetProject(Guid projectGuid);
        Task<ProjectModel> CreateProject(CreateProjectModel model);
        Task<ProjectModel> UpdateProject(Guid projectGuid, UpdateProjectModel model);
        Task<bool> DeleteProject(Guid projectGuid);
    }
}