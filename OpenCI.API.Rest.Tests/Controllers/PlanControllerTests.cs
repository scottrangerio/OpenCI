﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OpenCI.API.Rest.Controllers;
using OpenCI.API.Rest.Tests.Controllers.Contracts;
using OpenCI.Business.Contracts;
using OpenCI.Business.Models;
using OpenCI.Exceptions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http.Results;

namespace OpenCI.API.Rest.Tests.Controllers
{
    [TestClass]
    public class PlanControllerTests : IPlanControllerTests
    {
        [TestMethod]
        public async Task CreatePlan_ShouldReturnTheCreatedPlan()
        {
            var planOperations = new Mock<IPlanOperations>();

            var model = new CreatePlanModel();
            var expected = new PlanModel();

            planOperations.Setup(o => o.CreatePlan(model)).Returns(
                Task.FromResult(expected)
            );

            var controller = new PlanController(planOperations.Object);

            var result = await controller.CreatePlan(model).ConfigureAwait(false) as OkNegotiatedContentResult<PlanModel>;

            Assert.AreEqual(expected, result.Content);
        }

        [TestMethod]
        public async Task DeletePlan_ShouldReturnBadRequestIfTheDeleteIsUnsuccessfull()
        {
            var planOperations = new Mock<IPlanOperations>();

            var guid = Guid.NewGuid();

            planOperations.Setup(o => o.DeletePlan(guid)).Returns(Task.FromResult(false));

            var controller = new PlanController(planOperations.Object);

            var result = await controller.DeletePlan(guid).ConfigureAwait(false) as BadRequestResult;

            Assert.AreEqual(typeof(BadRequestResult), result.GetType());
        }

        [TestMethod]
        public async Task DeletePlan_ShouldReturnSuccessIfTheDeleteIsSuccessfull()
        {
            var planOperations = new Mock<IPlanOperations>();

            var guid = Guid.NewGuid();

            planOperations.Setup(o => o.DeletePlan(guid)).Returns(Task.FromResult(true));

            var controller = new PlanController(planOperations.Object);

            var result = await controller.DeletePlan(guid).ConfigureAwait(false) as OkResult;

            Assert.AreEqual(typeof(OkResult), result.GetType());
        }

        [TestMethod]
        public async Task GetAllPlans_ShouldReturnTheCorrectListOfPlans()
        {
            var planOperations = new Mock<IPlanOperations>();

            var guid = Guid.NewGuid();
            var expected = new List<PlanModel> { new PlanModel { Guid = Guid.NewGuid() } };

            planOperations.Setup(o => o.GetAllPlans()).Returns(
                Task.FromResult(expected)
            );

            var controller = new PlanController(planOperations.Object);

            var result = await controller.GetAllPlans().ConfigureAwait(false) as OkNegotiatedContentResult<List<PlanModel>>;

            CollectionAssert.AreEquivalent(expected, result.Content);
        }

        [TestMethod]
        public async Task GetPlan_ShouldReturnBadRequestIfTheEntityDoesNotExist()
        {
            var planOperations = new Mock<IPlanOperations>();

            var guid = Guid.NewGuid();

            planOperations.Setup(o => o.GetPlan(guid)).Throws<EntityNotFoundException>();

            var controller = new PlanController(planOperations.Object);

            var result = await controller.GetPlan(guid).ConfigureAwait(false);

            Assert.AreEqual(typeof(BadRequestResult), result.GetType());
        }

        [TestMethod]
        public async Task GetPlan_ShouldReturnTheCorrectPlan()
        {
            var planOperations = new Mock<IPlanOperations>();

            var expected = new PlanModel
            {
                Guid = Guid.NewGuid(),
                Name = "Test"
            };
            var guid = Guid.NewGuid();

            planOperations.Setup(o => o.GetPlan(guid)).Returns(Task.FromResult(expected));

            var controller = new PlanController(planOperations.Object);

            var result = await controller.GetPlan(guid).ConfigureAwait(false) as OkNegotiatedContentResult<PlanModel>;

            Assert.AreEqual(expected, result.Content);
        }

        [TestMethod]
        public async Task UpdatePlan_ShouldReturnBadRequestIfTheEntityDoesNotExist()
        {
            var planOperations = new Mock<IPlanOperations>();

            var guid = Guid.NewGuid();
            var model = new UpdatePlanModel();

            planOperations.Setup(o => o.UpdatePlan(guid, model)).Throws<EntityNotFoundException>();

            var controller = new PlanController(planOperations.Object);

            var result = await controller.UpdatePlan(guid, model).ConfigureAwait(false);

            Assert.AreEqual(typeof(BadRequestResult), result.GetType());
        }

        [TestMethod]
        public async Task UpdatePlan_ShouldReturnTheUpdatedPlan()
        {
            var planOperations = new Mock<IPlanOperations>();

            var expected = new PlanModel();
            var model = new UpdatePlanModel();
            var guid = Guid.NewGuid();

            planOperations.Setup(o => o.UpdatePlan(guid, model)).Returns(Task.FromResult(expected));

            var controller = new PlanController(planOperations.Object);

            var result = await controller.UpdatePlan(guid, model).ConfigureAwait(false) as OkNegotiatedContentResult<PlanModel>;

            Assert.AreEqual(expected, result.Content);
        }
    }
}