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
        public Workers() { }
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
        public void Copy(Workers worker) {
            name = worker.name;
            password = worker.password;
            FIO = worker.FIO;
        }

        public void show()
        {
            MessageBox.Show(name + " " + password + " " + FIO + " ");
        }
    }
    class Worker1 : Workers 
    {
        public Worker1() { }
        public Worker1(string name, string password, string FIO) : base(name, password, FIO) { }

    }
    class Worker2 : Workers
    {
        public Worker2() { }
        public Worker2(string name, string password, string FIO) : base(name, password, FIO) { }
    }
    class Worker3 : Workers
    {
        public Worker3() { }
        public Worker3(string name, string password, string FIO) : base(name, password, FIO) { }
    }
    public class Resource
    {
        private string name;
        private string description;

        public Resource(string name, string description)
        {
            this.name = name;
            this.description = description;
        }

        public string Name { get{ return name; } }
        public string Description { get{ return description; } }

    }
    public class Extraction
    {
        private Resource resource;
        private string volumeReserve;
        private string volumeSale;
        private string volumeAgreement;
        private string volumeExport; 
        private string volumeUndistributed;
        public Extraction(Resource resource, string volumeSale, string volumeExport, string volumeReserve, string volumeUndistributed)
        {
            this.resource = resource;
            this.volumeSale = volumeSale;
            this.volumeExport = volumeExport;
            this.volumeReserve = volumeReserve;
            this.volumeUndistributed = volumeUndistributed;
        }
        public void DistributionOfResources(string volumeReserve, string volumeSale, string volumeExport)
        {
            this.volumeReserve = Convert.ToString(Convert.ToInt32(this.volumeReserve) + Convert.ToInt32(volumeReserve));
            this.volumeSale = Convert.ToString(Convert.ToInt32(this.volumeSale) + Convert.ToInt32(volumeSale));
            this.volumeExport = Convert.ToString(Convert.ToInt32(this.volumeExport) + Convert.ToInt32(volumeExport));
            try
            {
                if (Convert.ToInt32(volumeUndistributed)
                - (Convert.ToInt32(volumeReserve)
                + Convert.ToInt32(volumeSale)
                + Convert.ToInt32(volumeExport)) > 0)
                {
                    volumeUndistributed = 
                    Convert.ToString(Convert.ToInt32(volumeUndistributed)
                    - (Convert.ToInt32(volumeReserve)
                    + Convert.ToInt32(volumeSale)
                    + Convert.ToInt32(volumeExport)));
                }
                else MessageBox.Show("Недостаточно добытых ресурсов","Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);}
            SaveChanges();
        }
        public void SaveChanges()
        {       
            StreamReader reader = new StreamReader("List of extracted resources.txt");
            string str = reader.ReadToEnd();
            reader.Close();
            // извлекаем строку, которая была изменена
            string subStr = str.Substring(str.IndexOf(Resource.Name));
            try
            {
                subStr = subStr.Remove(subStr.IndexOf("\n"));
            }
            catch { }  // если выбрана последняя запись(тк в конце нет "\n")

            for (int i = 0; i < subStr.Length; i++) {
                while(int.TryParse(Convert.ToString(subStr[i]), out int x))  // проверка является ли символ числом
                {
                    subStr = subStr.Remove(i, 1); // удаляем число      
                }
            }
            // вставляем новые числа на нужные позиции
            int index;
            subStr = subStr.Insert(index = subStr.IndexOf("|") + 1, volumeReserve);
            subStr = subStr.Insert(index = subStr.IndexOf("|", index) + 1, volumeSale);
            subStr = subStr.Insert(index = subStr.IndexOf("|", index) + 1, volumeExport);
            subStr = subStr.Insert(subStr.IndexOf("|", index) + 1, volumeUndistributed);
            // вставляем строку с нужными числами, вместо старой
            string res;
            try
            {
                res = str.Remove(str.IndexOf(Resource.Name), str.IndexOf("\n", str.IndexOf(Resource.Name)) - str.IndexOf(Resource.Name));
            }
            catch { res = str.Remove(str.IndexOf(Resource.Name), str.Length - str.IndexOf(Resource.Name)); } // если выбрана последняя запись
            res = res.Insert(str.IndexOf(Resource.Name), subStr);
            // перезаписываем файл
            StreamWriter writer = new StreamWriter("List of extracted resources.txt");
            writer.Write(res);
            writer.Close();
        }
        public Resource Resource { 
            get { return resource; }
        }
        public string VolumeAgreement
        {
            get { return volumeAgreement; }
        }
        public string VolumeSale
        {
            get { return volumeSale; }
        }
        public string VolumeExport
        {
            get { return volumeExport; }
        }
        public string VolumeReserve
        {
            get { return volumeReserve; }
        }
        public string VolumeUndistributed
        {
            get { return volumeUndistributed; }
        }
    }
    public class ActiveAgreements
    { 
        string startDate;
        string endDate;
        string remainder;

        ActiveAgreements



    }

}
