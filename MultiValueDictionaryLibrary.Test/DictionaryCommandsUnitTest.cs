using FluentAssertions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MultiValueDictionaryLibrary.Test
{
    public class DictionaryCommandsUnitTest
    {

        public DictionaryCommandsUnitTest()
        {
        }

        private DictionaryCommands BuildMockInstance()
        {
            return new DictionaryCommands();
        }

        [Fact]
        public void Add()
        {
            //arrange
            var testDictionary = new Dictionary<string, List<string>>();
            var key = "testKey";
            var value = "testValue";

            using (var stringWriter = new StringWriter())
            {

                Console.SetOut(stringWriter);

                var sut = BuildMockInstance();

                //act
                sut.Add(testDictionary, key, value);

                //assert
                testDictionary.ContainsKey(key).Should().BeTrue();
                List<string> testList;
                testDictionary.TryGetValue(key, out testList);
                testList.Any(x => x == value).Should().BeTrue();
                stringWriter.ToString().Trim().Should().Be(") Added");
            }
        }

        [Fact]
        public void Keys()
        {
            //arrange
            var testDictionary = new Dictionary<string, List<string>>()
            {
                { "testKey1", new List<string>{ "testValue1" }},
                { "testKey2", new List<string>{ "testValue2" }}

            };

            using (var stringWriter = new StringWriter())
            {

                Console.SetOut(stringWriter);

                var sut = BuildMockInstance();

                //act
                sut.Keys(testDictionary);

                //assert
                stringWriter.ToString().Trim().Should().Be("1) testKey1" + System.Environment.NewLine + "2) testKey2");
            }
        }       
        [Fact]
        public void Keys_EmptySet()
        {
            //arrange
            var testDictionary = new Dictionary<string, List<string>>()
            {
            };

            using (var stringWriter = new StringWriter())
            {

                Console.SetOut(stringWriter);

                var sut = BuildMockInstance();

                //act
                sut.Keys(testDictionary);

                //assert
                stringWriter.ToString().Trim().Should().Be(") empty set");
            }
        }

        [Fact]
        public void Members()
        {
            //arrange
            var testDictionary = new Dictionary<string, List<string>>()
            {
                { "testKey1", new List<string>{"testValue1", "testValue2"  }},
            };

            using (var stringWriter = new StringWriter())
            {

                Console.SetOut(stringWriter);

                var sut = BuildMockInstance();

                //act
                sut.Members(testDictionary, "testKey1");

                //assert
                stringWriter.ToString().Trim().Should().Be("1) testValue1" + System.Environment.NewLine + "2) testValue2");
            }
        }
        [Fact]
        public void Remove_ValuesRemaining()
        {
            //arrange
            var testDictionary = new Dictionary<string, List<string>>()
            {
                { "testKey1",new List<string>{ "testValue1", "testValue2"}},
            };

            using (var stringWriter = new StringWriter())
            {

                Console.SetOut(stringWriter);

                var sut = BuildMockInstance();

                //act
                sut.Remove(testDictionary, "testKey1", "testValue2");

                //assert
                stringWriter.ToString().Trim().Should().Be(") Removed");
                testDictionary.Any(x => x.Key == "testKey1").Should().BeTrue();
            }
        }
        [Fact]
        public void Remove_NoValuesRemaining()
        {
            //arrange
            var testDictionary = new Dictionary<string, List<string>>()
            {
                { "testKey1",new List<string>{ "testValue2"}},
            };

            using (var stringWriter = new StringWriter())
            {

                Console.SetOut(stringWriter);

                var sut = BuildMockInstance();

                //act
                sut.Remove(testDictionary, "testKey1", "testValue2");

                //assert
                stringWriter.ToString().Trim().Should().Be(") Removed");
                testDictionary.Any(x => x.Key == "testKey1").Should().BeFalse();
            }
        }
        [Fact]
        public void Remove_NoMembers()
        {
            //arrange
            var testDictionary = new Dictionary<string, List<string>>()
            {
                { "testKey1",new List<string>{ "testValue1", "testValue2"}},
            };

            using (var stringWriter = new StringWriter())
            {

                Console.SetOut(stringWriter);

                var sut = BuildMockInstance();

                //act
                sut.Remove(testDictionary, "testKey1", "testValue3");

                //assert
                stringWriter.ToString().Trim().Should().Be(") ERROR, member does not exist.");
                testDictionary.Any(x => x.Key == "testKey1").Should().BeTrue();
            }
        }        
        [Fact]
        public void RemoveAll()
        {
            //arrange
            var testDictionary = new Dictionary<string, List<string>>()
            {
                { "testKey1",new List<string>{ "testValue1", "testValue2"}},
                { "testKey2",new List<string>{ "testValue1", "testValue2"}},
            };

            using (var stringWriter = new StringWriter())
            {

                Console.SetOut(stringWriter);

                var sut = BuildMockInstance();

                //act
                sut.RemoveAll(testDictionary, "testKey1");

                //assert
                stringWriter.ToString().Trim().Should().Be(") Removed");
                testDictionary.Any(x => x.Key == "testKey1").Should().BeFalse();
                testDictionary.Any(x => x.Key == "testKey2").Should().BeTrue();
            }
        }       
        [Fact]
        public void Clear()
        {
            //arrange
            var testDictionary = new Dictionary<string, List<string>>()
            {
                { "testKey1",new List<string>{ "testValue1", "testValue2"}},
                { "testKey2",new List<string>{ "testValue1", "testValue2"}},
            };

            using (var stringWriter = new StringWriter())
            {

                Console.SetOut(stringWriter);

                var sut = BuildMockInstance();

                //act
                sut.Clear(testDictionary);

                //assert
                stringWriter.ToString().Trim().Should().Be(") Cleared");
                testDictionary.Any(x => x.Key == "testKey1").Should().BeFalse();
                testDictionary.Any(x => x.Key == "testKey2").Should().BeFalse();
            }
        } 
        [Theory]
        [InlineData("testKey1", "true")]
        [InlineData("testKey3", "false")]
        public void KeyExists(string key, string result)
        {
            //arrange
            var testDictionary = new Dictionary<string, List<string>>()
            {
                { "testKey1",new List<string>{ "testValue1", "testValue2"}},
                { "testKey2",new List<string>{ "testValue1", "testValue2"}},
            };

            using (var stringWriter = new StringWriter())
            {

                Console.SetOut(stringWriter);

                var sut = BuildMockInstance();

                //act
                sut.KeyExists(testDictionary, key);

                //assert
                stringWriter.ToString().Trim().Should().Be($") {result}");
    
            }
        }

        [Theory]
        [InlineData("testKey1", "testValue2", "true")]
        [InlineData("testKey3", "testValue2", "false")]
        [InlineData("testKey1", "testValue3", "false")]
        public void MemberExists(string key, string value, string result)
        {
            //arrange
            var testDictionary = new Dictionary<string, List<string>>()
            {
                { "testKey1",new List<string>{ "testValue1", "testValue2"}},
                { "testKey2",new List<string>{ "testValue1", "testValue2"}},
            };

            using (var stringWriter = new StringWriter())
            {

                Console.SetOut(stringWriter);

                var sut = BuildMockInstance();

                //act
                sut.MemberExists(testDictionary, key, value);

                //assert
                stringWriter.ToString().Trim().Should().Be($") {result}");

            }
        }
        [Fact]
        public void AllMembers()
        {
            //arrange
            var testDictionary = new Dictionary<string, List<string>>()
            {
                { "testKey1",new List<string>{ "testValue1", "testValue2"}},
                { "testKey2",new List<string>{ "testValue1", "testValue2"}},
            };

            using (var stringWriter = new StringWriter())
            {

                Console.SetOut(stringWriter);

                var sut = BuildMockInstance();

                //act
                sut.AllMembers(testDictionary);

                //assert
                stringWriter.ToString().Trim().Should().Be("1) testValue1" + System.Environment.NewLine + "2) testValue2" + System.Environment.NewLine + "3) testValue1" + System.Environment.NewLine + "4) testValue2");

            }
        }
        [Fact]
        public void Items()
        {
            //arrange
            var testDictionary = new Dictionary<string, List<string>>()
            {
                { "testKey1",new List<string>{ "testValue1", "testValue2"}},
                { "testKey2",new List<string>{ "testValue1", "testValue2"}},
            };

            using (var stringWriter = new StringWriter())
            {

                Console.SetOut(stringWriter);

                var sut = BuildMockInstance();

                //act
                sut.Items(testDictionary);

                //assert
                stringWriter.ToString().Trim().Should().Be("1) testKey1: testValue1" + System.Environment.NewLine + "2) testKey1: testValue2" + System.Environment.NewLine + "3) testKey2: testValue1" + System.Environment.NewLine + "4) testKey2: testValue2");

            }
        }
    }
}
