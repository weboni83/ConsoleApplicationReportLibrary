#define TEST

using ReportLibrary;
using ReportLibrary.Report;
using System;
using System.ComponentModel;
using System.Reflection;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {

            CReport report = new CReport(ReportFiles.ZF1705);
            report.Load();
            report.SetDataSourceConnections();
            report.GetConnectionInfo();

            Console.WriteLine(string.Format("{0} 리포트 로드됨...", GetEnumDescription(ReportFiles.ZF1705))); 
            //Enum 만들때 사용
            //foreach (var item in reports.GetReportInstances())
            //{
            //    Console.WriteLine(item);
            //}
        }

        /// <summary>
        /// GetStringValue 
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public static String GetEnumDescription(Enum e)
        {
            FieldInfo fieldInfo = e.GetType().GetField(e.ToString());

            DescriptionAttribute[] enumAttributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (enumAttributes.Length > 0)
            {
                return enumAttributes[0].Description;
            }
            return e.ToString();
        } 

    }
}
