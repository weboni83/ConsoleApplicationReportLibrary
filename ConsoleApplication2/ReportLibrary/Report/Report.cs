using System;
using System.Collections.Generic;
using System.Reflection;

namespace ReportLibrary.Report
{
    public abstract class Report
    {
        public abstract void Load();
        public abstract void SetDataSource();
        /// <summary>
        /// 해당 클래스의 Assembly에 존재하는 모든 Class 중 BaseType이 CrystalDecisions.CrystalReports.Engine.ReportClass인 목록을 호출함.
        /// </summary>
        /// <returns>Report Class List</returns>
        public virtual List<string> GetReportInstances()
        {
            List<string> list = new List<string>();
            Assembly assembly = typeof(CReport).Assembly;
            foreach (Type type in assembly.GetTypes())
            {
                if (type.BaseType.FullName.Equals("CrystalDecisions.CrystalReports.Engine.ReportClass"))
                {
                    //Console.WriteLine(type.Name);
                    //ReportName is Class Name
                    list.Add(type.Name);
                }
            }

            return list;
        }

        [Obsolete("사용할 필요가 없음.")]
        public virtual object GetCreatedInstance(string reportName)
        {
            Assembly assembly = typeof(CReport).Assembly;
            foreach (Type type in assembly.GetTypes())
            {
                if (type.BaseType.FullName.Equals("CrystalDecisions.CrystalReports.Engine.ReportClass"))
                {
                    Console.WriteLine(type.Name);
                    //ReportName is Class Name
                    if (type.Name == reportName)
                    {
                        Console.WriteLine("Create Instance : {0}", type.Name);

                        return Activator.CreateInstance(type);
                    }

                }
            }

            return null;
        }
    }
}
