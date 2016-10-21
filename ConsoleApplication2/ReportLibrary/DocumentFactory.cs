using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportLibrary
{
    //public class ReportFile
    //{
    //    public readonly string Extension = "rpt";

    //    public string Name { get; set; }
    //    public string Path { get; set; }
        
    //}

    //public class SchemaFile
    //{
    //    private readonly string Extension = "xsd";

    //    public string Name { get; set; }
    //    public string Path { get; set; }

    //}

    //public class ScriptFile
    //{
    //    private readonly string Extension = "sql";

    //    public string Name { get; set; }
    //    public string Path { get; set; }
    //}

    //public abstract class Document : ISetReport, ISetQuery
    //{
    //    public ReportFile MyReport { get; private set; }
    //    public SchemaFile MySchema { get; private set; }
    //    public ScriptFile MyScript { get; private set; }

    //    private ISetReport _report;
    //    private ISetQuery _query;

    //    public Document ()
    //    {

    //    }

    //    public Document(string type)
    //        : base()
    //    {
    //        MyReport.Name = type;
    //        MySchema.Name = type;
    //        MyScript.Name = type;
    //    }

    //    public void Load()
    //    {
    //        _report.Load();
    //    }

    //    public void Query()
    //    {
    //        _query.Query();
    //    }

    //    public void SetReportSource()
    //    { }
    //    public void SetReportQuery()
    //    { }
    //    public void SetReportSource(ISetReport rep)
    //    {
    //        this._report = rep;
    //    }
    //    public void SetReportQuery(ISetQuery que)
    //    {
    //        this._query = que;
    //    }

    //}

    //public interface ISetReport
    //{
    //    void Load();
    //}

    //public interface ISetQuery
    //{
    //    void Query();
    //}


    //public class DocumentFactory
    //{
    //    public DocumentFactory()
    //    {

    //    }
        
    //    public Document CreateDocumnet(string type)
    //    {
    //        //추상 클래스라서... instance 생성 불가..
    //        Document doc = new Document(type);
    //        doc.SetReportSource();
    //        doc.SetReportQuery();
    //        return doc;
    //    }

    //    //public abstract Document LoadReport(string Type);

    //}



    
}

    
