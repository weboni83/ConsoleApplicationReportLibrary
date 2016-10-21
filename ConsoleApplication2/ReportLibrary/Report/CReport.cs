using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System;
using System.Data;
using System.IO;

namespace ReportLibrary.Report
{
    public class CReport : Report
    {
        //Solution Path
        //string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
        //Project Path
        string path = String.Format("{0}\\{1}", Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);


        ReportDocument reportDocument;

        public string ReportName { get; set; }

        //멤버없이 생성할경우, ReportName이 반드시 필요하다.
        public CReport()
        {
            Console.WriteLine(String.Format(@"Construct() : this() {0}", ReportName));
            reportDocument = new ReportDocument();
        }

        public CReport(ReportFiles reportName)
            : this()
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
                info.SetConnection("localhost", "MyBatisTest", "sa", "sap2014!#%");
            }

            //reportDocument.SetDatabaseLogon("sa", "sap2014!#%", "localhost", "MyBatisTest");
            //reportDocument.VerifyDatabase();
            Console.WriteLine(string.Format(@"SetDatabaseLogon : {0}", reportDocument.DataSourceConnections));

        }
        //Void : 참조 때문에 CrystalDecisions 는 사용안하는것으로...
        public ConnectionAdapter GetConnectionInfo()
        {
            ConnectionAdapter conAdapter = new ConnectionAdapter();

            foreach (IConnectionInfo info in reportDocument.DataSourceConnections)
            {
                conAdapter.SetConnection(info.ServerName, info.DatabaseName, info.UserID, info.Password);
            }

            Console.WriteLine(string.Format(@"Return ConnectionInfo : {0}", conAdapter.ToString()));
            return conAdapter;
        }

       


    }
}
