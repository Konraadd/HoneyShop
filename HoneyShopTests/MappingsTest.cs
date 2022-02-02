using AutoMapper;
using HoneyShop;
using NUnit.Framework;

namespace HoneyShopTests
{
    public class MappingTests
    {
        private IMapper _sut;

        [SetUp]
        public void Setup()
        {
            _sut = new MapperConfiguration(cfg => { cfg.AddProfile<HoneyShopModelsMappingProfile>(); }).CreateMapper();
        }

        [Test]
        public void Test1()
        {
            _sut.ConfigurationProvider.AssertConfigurationIsValid();
        }
    }
}