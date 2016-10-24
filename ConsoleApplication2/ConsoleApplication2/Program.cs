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
            //reportDocument 생성
            CReport report = new CReport(ReportFiles.ZF1705);
            report.Load();
            report.SetDataSourceConnections();  //password 설정해도 다시 읽을 경우
            report.GetConnectionInfo();
            report.SetQuery();                  //Script\*.sql 파일 Load
            report.SetCondition();              //Query.sql 에 조건 Dictionary 로 넘기는게 편하려나?..
            //report.RunQuery();                  //1.SetQuery(), 2.SetCondition(), 3.RunQuery()를 통해 결과셋을 반환
            report.SetDataSource();             //1.SetQuery(), 2.SetCondition(), 3.RunQuery() -> RunQuery 결과를 DataSource로 지정함.
            Console.WriteLine(string.Format("{0} 리포트 로드됨...", GetEnumDescription(ReportFiles.ZF1705)));

            //Viewer 에 reportDocument 연결
            ReportViewer viewer = new CrystalReportViewer();
            viewer.SetReportSource(report);
            viewer.Refresh();
            

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
