using AutoMapper;
using HoneyShop;
using NUnit.Framework;

namespace HoneyShopTests
{
    public class MappingTests
    {
        private IMapper _mapper;

        [SetUp]
        public void Setup()
        {
            _mapper = new MapperConfiguration(cfg => { cfg.AddProfile<HoneyShopModelsMappingProfile>(); }).CreateMapper();
        }

        [Test]
        public void CheckMapperConfiguration()
        {
            _mapper.ConfigurationProvider.AssertConfigurationIsValid();
        }
    }
}