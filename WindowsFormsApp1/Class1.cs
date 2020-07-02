using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public class Workers
    {
        protected string name;     // логин для входа в систему
        protected string password;
        protected string FIO;      // ФИО работника

        public Workers(string name, string password, string FIO) {
            this.name = name;
            this.password = password;
            this.FIO = FIO;
        }

        public bool SingIn(string name, string password) {
            if (name == this.name) {
                if (password == this.password) return true;
                else return false;
            } 
            else return false;              
        }
        public void show()
        {
            MessageBox.Show(name + " " + password + " " + FIO + " ");
        }
    }

    class Worker1 : Workers 
    {
        public Worker1(string name, string password, string FIO) : base(name, password, FIO) { }

    }

    class Worker2 : Workers
    {
        public Worker2(string name, string password, string FIO) : base(name, password, FIO) { }
    }

    class Worker3 : Workers
    {
        public Worker3(string name, string password, string FIO) : base(name, password, FIO) { }
    }
}

class Resource {
    private string name;
    private string description;

    public Resource(string name, string description) {
        this.name = name;
        this.description = description;
    }
    
    
}


class Extraction { 

    private Resource resource;
    private int volumeAgreement;
    private int volumeSale;
    private int volumeExport;
    private int volumeReserve;
    private int volumeUndistributed;

    public Extraction(Resource resource, int volumeAgreement, int volumeSale, int volumeExport, int volumeReserve, int volumeUndistributed) {
        this
    
    
    } 


    public void DistributionOfResources() {

        // ###############
        // ###############
        // ###############
        //SaveChanges();
    }
    public void SaveChanges() {

        // ###############
        // ###############
        // ###############

    }







}


