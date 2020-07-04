using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Core.CIBDigitalTech;
using System.Threading.Tasks;
using Core.CIBDigitalTech.API;
using Core.CIBDigitalTech.API.Utilities;

namespace Test.CIBDigitalTech
{
    public class DogBreedAPI
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetAllDogBreeds()
        {

            var results = Task.Run(async () => await Method.Get("") ).Result;
            
            Assert.IsTrue(!String.IsNullOrEmpty(results), "no results returned");
            JsonUtil.GetChildNode(results, "message", "retriever");

            Assert.IsTrue(JsonUtil.CheckChildNode(results, "message", "retriever"), $"Sub breed retriever is not on the list");
        }

        [Test]
        public void GetRetrieverSubBreeds()
        {

            var results = Task.Run(async () => await Method.Get("")).Result;
            Assert.True(!String.IsNullOrEmpty(results));
        }

        [Test]
        public void GetGoldenSubBreedRandomImage()
        {
            var results = Task.Run(async () => await Method.Get("")).Result;
            Assert.True(!String.IsNullOrEmpty(results));
        }


    }
}
