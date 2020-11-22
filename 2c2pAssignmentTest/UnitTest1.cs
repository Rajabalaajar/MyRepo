using Microsoft.VisualStudio.TestTools.UnitTesting;
using _2c2pAssignment.Processor;
using System;
using System.IO;
using System.Collections.Generic;
using _2c2pAssignment.Models;
using System.Linq;
using _2c2pAssignment.Logger;

namespace _2c2pAssignmentTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            try
            {
                AppLogger.InitilizeLogger();
                //Invalid extension
                FileProcessor processor = new FileProcessor();
                string SampleFile1 = @"C:\test\Book1.xlsx";
                Stream stream = new FileStream(SampleFile1, FileMode.Open);
                Tuple<bool, List<FileDiagnostics>> tuple = processor.ProcessFile(stream, SampleFile1);
                Assert.IsTrue(tuple != null && !tuple.Item1);
                //Correct File
                FileProcessor processor1 = new FileProcessor();
                string SampleFile2 = @"C:\test\SampleCSV.csv";
                Stream stream1 = new FileStream(SampleFile2, FileMode.Open);
                Tuple<bool, List<FileDiagnostics>> tuple1 = processor1.ProcessFile(stream1, SampleFile2);
                Assert.IsTrue(tuple1 != null && tuple1.Item1);
                //Correct File
                FileProcessor processor2 = new FileProcessor();
                string SampleFile3 = @"C:\test\SampleXML.xml";
                Stream stream2 = new FileStream(SampleFile3, FileMode.Open);
                Tuple<bool, List<FileDiagnostics>> tuple2 = processor2.ProcessFile(stream2, SampleFile3);
                Assert.IsTrue(tuple2 != null && tuple2.Item1);

                //Size  exceed
                FileProcessor processor3 = new FileProcessor();
                string SampleFile4 = @"C:\test\TicketDesk.xml";
                Stream stream3 = new FileStream(SampleFile3, FileMode.Open);
                Tuple<bool, List<FileDiagnostics>> tuple3 = processor3.ProcessFile(stream3, SampleFile4);
                Assert.IsTrue(tuple3 != null && !tuple3.Item1);
                //Date error
                FileProcessor processor4 = new FileProcessor();
                string SampleFile5 = @"C:\test\SampleXML - Error.xml";
                Stream stream4 = new FileStream(SampleFile5, FileMode.Open);
                Tuple<bool, List<FileDiagnostics>> tuple4 = processor4.ProcessFile(stream4, SampleFile5);
                Assert.IsTrue(tuple4 != null && !tuple4.Item1 && tuple.Item2.Where(x => x.FieldName == "transaction date").Count() > 0);
            }
            catch (Exception ex)
            {

            }
        }
    }
}
