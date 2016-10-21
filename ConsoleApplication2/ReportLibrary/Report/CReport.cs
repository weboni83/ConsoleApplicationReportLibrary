using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ReportLibrary.Report
{
    public enum ReportFiles
    {
        [Description("테스트1")]
        Zf0142,
        [Description("테스트1")]
        ZF0142_01,
        ZF0701_01,
        ZF0701_02,
        ZF0701_03,
        ZF0701_04,
        ZF0703_01,
        ZF0703_02,
        ZF0703_03,
        ZF0703_04,
        ZF0840,
        ZF1510,
        ZF1510_01,
        [Description("검사JIG 유효성 평가")]
        ZF1705,
        [Description("생산JIG 유효성 평가")]
        ZF1708,
        ZFS140_01,
        ZFS140_02,
        ZFS140_03,
        ZFS140_04,
        ZFS140_05,
        ZFS140_06
    }

    public enum FileExtension
    {
        [Description("Report File Extension")]
        rpt,
        [Description("Schema File Extension")]
        xsd,
        [Description("Query File Extension")]
        sql,
    }

    public class CReport : Report
    {
        //Solution Path
        //string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
        //Project Path
        string path = String.Format("{0}\\{1}", Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);


        ReportDocument reportDocument = new ReportDocument();

        public string ReportName { get; set; }

        //멤버없이 생성할경우, ReportName이 반드시 필요하다.
        public CReport()
        {
            Console.WriteLine(String.Format(@"Construct() {0}", ReportName));
        }

        public CReport(ReportFiles reportName)
            : base()
        {
            Console.WriteLine(String.Format(@"Construct ({0})", reportName));
            ReportName = reportName.ToString();
        }

        public override void Load()
        {
            if (string.IsNullOrEmpty(ReportName))
            {
                Console.WriteLine("Not Set Report Name");
                return;
            }
            reportDocument.Load(String.Format(@"{0}\Report\{1}.{2}", path, ReportName, FileExtension.rpt));
            Console.WriteLine(string.Format(@"Loaded Type : {0}, Files : {1}.{2}", reportDocument.GetClassName(), ReportName, FileExtension.rpt));
        }

        public override void SetDataSource()
        {
            DataSet DS = new DataSet();
            reportDocument.SetDataSource(DS);
            Console.WriteLine(string.Format(@"Loaded Type : {0}, Files : {1}.{2}", reportDocument.GetClassName(), ReportName, FileExtension.rpt));
        }

        //int index, string name, object value, string subreport
        //reportDocument.SetParameterValue();
        public void SetParameter()
        {
            ////passing parameters in crystal report example
            //ReportDocument reportDocument = new ReportDocument();

            //ParameterFields paramFields = new ParameterFields();
            //// ParameterDiscreteValue paramDiscreteValue = new ParameterDiscreteValue();

            //ParameterField paramField = new ParameterField();
            //ParameterDiscreteValue paramDiscreteValue = new ParameterDiscreteValue();
            //paramField.Name = "@Dept";
            //paramDiscreteValue.Value = TextBox1.Text.ToString();
            //paramField.CurrentValues.Add(paramDiscreteValue);
            //paramFields.Add(paramField);

            //paramField = new ParameterField(); // <-- This line is added
            //paramDiscreteValue = new ParameterDiscreteValue();  // <-- This line is added
            //paramField.Name = "@Name";
            //paramDiscreteValue.Value = TextBox2.Text.ToString();
            //paramField.CurrentValues.Add(paramDiscreteValue);
            //paramFields.Add(paramField);

            //CrystalReportViewer1.ParameterFieldInfo = paramFields;
            //reportDocument.Load(Server.MapPath("CrystalReport.rpt"));
            //CrystalReportViewer1.ReportSource = reportDocument;
            //reportDocument.SetDatabaseLogon("sa", "sa", "OPWFMS-7KYGZ7SB", "test");
        }
        //((CrystalDecisions.CrystalReports.Engine.InternalConnectionInfo)((new System.Linq.SystemCore_EnumerableDebugView(reportDocument.DataSourceConnections as System.Collections.IEnumerable)).Items[0])).ServerName
        public void SetDataSourceConnections()
        {
            foreach (IConnectionInfo info in reportDocument.DataSourceConnections)
            {
                info.SetConnection("192.168.1.230", "MyBatisTest", "sa", "sap2014!#%");
            }

            //reportDocument.SetDatabaseLogon("sa", "sap2014!#%", "192.168.1.230", "MyBatisTest");
            //reportDocument.VerifyDatabase();
            Console.WriteLine(string.Format(@"SetDatabaseLogon : {0}", reportDocument.));

        }
        //Void : 참조 때문에 CrystalDecisions 는 사용안하는것으로...
        public ConnectionInfo GetConnectionInfo()
        {

            ConnectionInfo ConInfo = new ConnectionInfo();

            Console.WriteLine(string.Format(@"Return ConnectionInfo : {0}", reportDocument.DataSourceConnections));
            return ConInfo;
        }

        /// <summary>
        /// 해당 클래스의 Assembly에 존재하는 모든 Class 중 BaseType이 CrystalDecisions.CrystalReports.Engine.ReportClass인 목록을 호출함.
        /// </summary>
        /// <returns>Report Class List</returns>
        public List<string> GetReportInstances()
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
        public object GetCreatedInstance()
        {
            Assembly assembly = typeof(CReport).Assembly;
            foreach (Type type in assembly.GetTypes())
            {
                if (type.BaseType.FullName.Equals("CrystalDecisions.CrystalReports.Engine.ReportClass"))
                {
                    Console.WriteLine(type.Name);
                    //ReportName is Class Name
                    if (type.Name == ReportName)
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
