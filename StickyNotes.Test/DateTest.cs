using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using LumenWorks.Framework.IO.Csv;
using NUnit.Framework;
using StickyNotes.Lib;

namespace StickyNotes.Test
{
    class DateTest
    {
        Date sutDate;

        [Test]
        public void ShouldPassProperDate()
        {
            sutDate = new Date("yyyy-mm-dd");
            Assert.True(sutDate.FormatRegex.IsMatch("1994-12-21"));
        }
        [Test]
        public void ShouldPassProperDateWithChangedDelimiter()
        {
            sutDate = new Date("yyyy-mm-dd");
            sutDate.ChangeDelimiter('.');
            Assert.True(sutDate.FormatRegex.IsMatch("1994.12.21"));
        }
        [Test]
        public void ShouldNotPassInappropriateFormat()
        {
            ArgumentException e = Assert.Throws<ArgumentException>(() => new Date("not existing format"));
            Assert.That(e.Message, Is.EqualTo("Not existing format"));
        }

        [Test]
        public void ShouldNotPassIfItsChangedToWrongDate()
        {
            ArgumentException e = Assert.Throws<ArgumentException>(() => new Date("yyyy-mm-dd").ChangeDate("not date"));
            Assert.That(e.Message, Is.EqualTo("Wrong date format"));
        }

        [Test, TestCaseSource("GetTestData")]
        public void DataDrivenTest(String input, bool expectedOutput)
        {
            Date date = new Date("yyyy-mm-dd");
            Assert.That(expectedOutput, Is.EqualTo(date.FormatRegex.IsMatch(input)));
        }

        private static IEnumerable<object[]> GetTestData()
        {
            String path = System.IO.Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent + "/DataTestCaseData.csv";
            Console.WriteLine(path);
            using (var csv = new CsvReader(new StreamReader(path), true))
            {
                while (csv.ReadNextRecord())
                {
                    String inputDate = csv[0];
                    bool expectedOutput = bool.Parse(csv[1]);
                    yield return new object[] { inputDate, expectedOutput };
                }
            }
        }

        [Test]
        public void ShouldCheckWeatherDateIsLaterThanNow()
        {
            Date date = new Date("yyyy-mm-dd");
            date.ChangeDate("2040-07-01");

            Assert.True(date.IsLeaterThanNow());
        }


        [TearDown]
        public void TearDown()
        {
            sutDate = null;
        }
    }
}
