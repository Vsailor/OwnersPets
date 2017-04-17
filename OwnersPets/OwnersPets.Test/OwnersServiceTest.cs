using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OwnersPets.Abstract;
using OwnersPets.Data.Abstract;
using OwnersPets.Data.Models;
using OwnersPets.Model;
using OwnersPets.Service;

namespace OwnersPets.Test
{
    [TestClass]
    public class OwnersServiceTest
    {
        private readonly Mock<IPetsRepository> _petsRepository;

        private readonly Mock<IOwnersRepository> _ownersRepository;

        private readonly IOwnersService _ownersService;

        public OwnersServiceTest()
        {
            _petsRepository = new Mock<IPetsRepository>();
            _ownersRepository = new Mock<IOwnersRepository>();
            _ownersService = new OwnersService(
                _ownersRepository.Object,
                _petsRepository.Object);
        }

        [TestMethod]
        public void GetAllOwnersBasicInfo_OnDefault_ReturnsCorrectResult()
        {
            // Arrange
            var ownerBasicInfos = new[]
            {
                new GetAllOwnerBasicInfoResult
                {
                    Name = "Bob",
                    OwnerId = 1,
                    PetsCount = 10
                }
            };

            _ownersRepository.Setup(a => a.GetAllOwnersBasicInfo())
                .Returns(Task.FromResult(ownerBasicInfos));

            // Act
            OwnerBasicInfo[] results = _ownersService.GetAllOwnersBasicInfo().Result;

            // Assert
            GetAllOwnerBasicInfoResult ownerBasicInfo = ownerBasicInfos.Single();
            OwnerBasicInfo result = results.Single();

            Assert.AreEqual(ownerBasicInfo.OwnerId, result.OwnerId);
            Assert.AreEqual(ownerBasicInfo.Name, result.Name);
            Assert.AreEqual(ownerBasicInfo.PetsCount, result.PetsCount);
        }

        [TestMethod]
        public void GetAllOwnersBasicInfo_EmptyResponse_ReturnsEmptyCollection()
        {
            // Arrange
            var ownerBasicInfos = new GetAllOwnerBasicInfoResult[0];

            _ownersRepository.Setup(a => a.GetAllOwnersBasicInfo())
                .Returns(Task.FromResult(ownerBasicInfos));

            // Act
            OwnerBasicInfo[] results = _ownersService.GetAllOwnersBasicInfo().Result;

            // Assert
            Assert.IsTrue(results.Length == 0);
        }

        [TestMethod]
        public void GetOwnerDetails_OnDefault_ReturnsCorrectResult()
        {
            // Arrange
            var owner = new GetOwnerByOwnerIdResult
            {
                Name = "Bob",
                RowId = 1
            };

            var pets = new GetPetsByOwnerIdResult[]
            {
                new GetPetsByOwnerIdResult
                {
                    Name = "Rex",
                    RowId = 1,
                    OwnerId = 1
                }
            };

            _ownersRepository.Setup(a => a.GetOwnerDetailedInfo(owner.RowId))
                .Returns(Task.FromResult(owner));

            _petsRepository.Setup(a => a.GetPetsByOwnerId(owner.RowId))
                .Returns(Task.FromResult(pets));

            // Act
            OwnerDetailedInfo result = _ownersService.GetOwnerDetails(owner.RowId).Result;

            // Assert
            Assert.AreEqual(owner.Name, result.OwnerName);
            Assert.AreEqual(owner.RowId, result.OwnerId);
            Assert.AreEqual(pets.Single().Name, result.Pets.Single().PetName);
            Assert.AreEqual(pets.Single().RowId, result.Pets.Single().PetId);
        }

        [TestMethod]
        public void GetOwnerDetails_OwnerNotFound_ReturnsNull()
        {
            // Arrange
            int ownerId = 1; 
            GetOwnerByOwnerIdResult owner = null;
            _ownersRepository.Setup(a => a.GetOwnerDetailedInfo(ownerId))
                .Returns(Task.FromResult(owner));

            // Act
            OwnerDetailedInfo result = _ownersService.GetOwnerDetails(ownerId).Result;

            // Assert
            Assert.IsTrue(result == null);
        }
    }
}
