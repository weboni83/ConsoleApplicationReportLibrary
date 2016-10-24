using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportLibrary
{
    public abstract class ReportViewer
    {
        public ReportViewer(){ }
        public void Refresh() { }
        public abstract void SetReportSource(object dataSet);

    }

    public class CrystalReportViewer : ReportViewer
    {
        //실제 Report Control로 선언
        private object _reportViewer1;
        
        public CrystalReportViewer()
        {
            
        }
        //ReportSoucre를 Property로 지정해도 됨.
        public override void SetReportSource(object dataSet)
        {
            _reportViewer1 = dataSet;
        }
    }

    public class DevExpressReportViewer : ReportViewer
    {
        //실제 Report Control로 선언
        private object _reportViewer1;
        
        public DevExpressReportViewer()
        {
            
        }

        public override void SetReportSource(object dataSet)
        {
            _reportViewer1 = dataSet;
        }
    }

    public class ComponentOneReportViewer : ReportViewer
    {
        //실제 Report Control로 선언
        private object _reportViewer1;

        public ComponentOneReportViewer()
        {
            
        }

        public override void SetReportSource(object dataSet)
        {
            _reportViewer1 = dataSet;
        }
    }
}
