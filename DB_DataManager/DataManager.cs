using DB_Models;
using DB_Models.SearchModels;
using DB_ServiceLayer;
using ImportantOptions;
using System;
using System.Configuration;
using System.ServiceProcess;
using System.Threading;

namespace DB_DataManager
{
    public class DataManager : ServiceBase
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                components?.Dispose();
            }
            base.Dispose(disposing);
        }
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            this.ServiceName = "DataManager";
        }
        public DataManager()
        {
            Option option = new Option();
            InitializeComponent();
            this.CanStop = option.ServiceOptions.CanStop;
            this.CanPauseAndContinue = option.ServiceOptions.CanPauseAndContinue;
            this.AutoLog = option.ServiceOptions.AutoLog;
        }

        protected override void OnStart(string[] args)
        {
            var Opt_Meneger = new Option();
            Opt_Meneger.DirectoryOptions.SourceDirectory = AppDomain.CurrentDomain.BaseDirectory;
            var repositories = new WorkWithDB(ConfigurationManager.ConnectionStrings["Arbitrary_Name"].ConnectionString);
            var searchCriteria = new SearchCriteria
            {
                Page = 1,
                Count = 15,
            };
            var Entities = repositories.person_Repository.GetALLInf(searchCriteria);

            Generator<Person> xml_xsd_Generator = new Generator<Person>();
            xml_xsd_Generator.XML_Service._Path = Opt_Meneger.DirectoryOptions.SourceDirectory;
            xml_xsd_Generator.XML_Service.Entities = Entities;
            xml_xsd_Generator.XML_Generating();
            xml_xsd_Generator.XSD_Generating();

        }

        protected override void OnStop()
        {
            Thread.Sleep(1000);
        }
    }
}
