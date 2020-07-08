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

        public string Name { get { return name; } }
        public string Description { get { return description; } }

    }
    public class Extraction
    {
        private Resource resource;
        private string volumeReserve;
        private string volumeSale;
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
            try
            {
                this.volumeReserve = Convert.ToString(Convert.ToDecimal(this.volumeReserve) + Convert.ToDecimal(volumeReserve));
                this.volumeSale = Convert.ToString(Convert.ToDecimal(this.volumeSale) + Convert.ToDecimal(volumeSale));
                this.volumeExport = Convert.ToString(Convert.ToDecimal(this.volumeExport) + Convert.ToDecimal(volumeExport));
                ReduceUndistributed(volumeReserve, volumeSale, volumeExport);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            SaveChanges();
        }

        public void ReduceUndistributed(string volumeReserve, string volumeSale, string volumeExport) {
            if (Convert.ToDecimal(volumeUndistributed)
                - (Convert.ToDecimal(volumeReserve)
                + Convert.ToDecimal(volumeSale)
                + Convert.ToDecimal(volumeExport)) >= 0)
            {
                volumeUndistributed =
                Convert.ToString(Convert.ToDecimal(volumeUndistributed)
                - (Convert.ToDecimal(volumeReserve)
                + Convert.ToDecimal(volumeSale)
                + Convert.ToDecimal(volumeExport)));
            }
            else MessageBox.Show("Недостаточно добытых ресурсов", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public bool CheckReduceUndistributed(string volumeAgreement) {
            if (Convert.ToDecimal(volumeUndistributed) - Convert.ToDecimal(volumeAgreement) >= 0)
            {
                return true;
            }
            else
            {
                if (MessageBox.Show("Недостаточно добытых ресурсов. Компенсировать недостающую часть ресурсами из резерва?",
                    "Внимание",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    if (CheckReduceUndistributedAndReserve(Convert.ToString(Convert.ToDecimal(volumeAgreement) - Convert.ToDecimal(volumeUndistributed)))) return true;
                    else return false;
                }
                else return false;
            }
        }
        private bool CheckReduceUndistributedAndReserve(string volumeAgreement) {
            if (Convert.ToDecimal(volumeReserve) - Convert.ToDecimal(volumeAgreement) >= 0) return true;
            else {
                MessageBox.Show("Недостаточно добытых ресурсов",
                 "Ошибка",
                 MessageBoxButtons.OK,
                 MessageBoxIcon.Error);
                return false; 
            } 
        }
        public void ReduceUndistributed(string volumeAgreement)
        {
            if (Convert.ToDecimal(volumeUndistributed) - (Convert.ToDecimal(volumeAgreement)) >= 0)
            {
                volumeUndistributed = Convert.ToString(Convert.ToDecimal(volumeUndistributed) - Convert.ToDecimal(volumeAgreement));
            }
            else
            {
                ReduceUndistributedAndReserve(Convert.ToString(Convert.ToDecimal(volumeAgreement) - Convert.ToDecimal(volumeUndistributed)));             
            }
            SaveChanges();
        }
        private void ReduceUndistributedAndReserve(string volumeAgreement)
        {
                volumeUndistributed = "0";
                volumeReserve = Convert.ToString(Convert.ToDecimal(volumeReserve) - Convert.ToDecimal(volumeAgreement));
        }

        public void SaveChanges()
        {
            StreamReader reader = new StreamReader("List of extracted resources.txt");
            string str = reader.ReadToEnd();
            reader.Close();
            // извлекаем строку, которая была изменена
            string subStr = str.Substring(str.IndexOf(resource.Name));
            try
            {
                subStr = subStr.Remove(subStr.IndexOf("\n"));
            }
            catch { }  // если выбрана последняя запись(тк в конце нет "\n")
            string[] line = subStr.Split('|');
            line[1] = volumeReserve.PadRight(10);
            line[2] = volumeSale.PadRight(10);
            line[3] = volumeExport.PadRight(10);
            line[4] = volumeUndistributed.PadRight(10);
            string temp = string.Join("|", line);
            str = str.Replace(subStr, temp);
            // перезаписываем файл
            StreamWriter writer = new StreamWriter("List of extracted resources.txt");
            writer.Write(str);
            writer.Close();
        }
        public Resource Resource {
            get { return resource; }
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

    public class Agreement
    {
        private Resource resource;
        private string startDate; // дата начала
        private string endDate; // дата окончания
        private string remainder; // остаток
        private string description; // описание предмета договора
        private string status; // статус договора

        public Agreement(Resource resource, string startDate, string endDate, string remainder, string description, string status) {
            this.resource = resource;
            this.startDate = startDate;
            this.endDate = endDate;
            this.remainder = remainder;
            this.description = description;
            this.status = status;
        }

        public bool SendResourcesAccordingToAgreement(string volumeAgreement)
        {
            try
            {
                if (Convert.ToDecimal(remainder) - Convert.ToDecimal(volumeAgreement) < 0)
                {
                    MessageBox.Show("Попытка отправить больше ресурсов, чем осталось!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                else
                {
                    remainder = Convert.ToString(Convert.ToDecimal(remainder) - Convert.ToDecimal(volumeAgreement));
                    SaveChanges();
                    return true;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            return false;          
        }
        private void SaveChanges()
        {
            StreamReader reader = new StreamReader("agreements.txt");
            string str = reader.ReadToEnd();
            reader.Close();
            // извлекаем строку, которая была изменена
            string subStr = "";
            int index = 0;
            while (index != -1) { 
            index = str.IndexOf(resource.Name, index) + 1;
            subStr = str.Substring(index - 1);
            try
            {
                subStr = subStr.Remove(subStr.IndexOf("\n"));
            }
            catch { }  // если выбрана последняя запись(тк в конце нет "\n")
                if (subStr.IndexOf(resource.Name) != -1 &&
                        subStr.IndexOf(startDate) != -1 &&
                        subStr.IndexOf(endDate) != -1)
                {
                    break;
                }
            }
            string[] line = subStr.Split('|');
            if (line[3].Trim() != remainder)
            {
                line[3] = remainder.PadRight(10);
            }
            else {
                line[4] = Status.PadRight(9);
            }
            string temp = string.Join("|", line);
            str = str.Replace(subStr, temp);
            StreamWriter writer = new StreamWriter("agreements.txt");
            writer.Write(str);
            writer.Close();
        }
        public void ChangeStatus() {
            status = "Активный";
            SaveChanges();
        }
        public Resource Resource { get { return resource; } }
        public string StartDate { get { return startDate; } }
        public string EndDate { get { return endDate; } }
        public string Remainder { get { return remainder; } }
        public string Description { get { return description; } }
        public string Status { get { return status; } }
    }

    public class Equipment
    {
        private string name;
        private string manufacturer;
        private string description;
        public Equipment(string name, string manufacturer)
        {
            this.name = name;
            this.manufacturer = manufacturer;
        }
        public Equipment(string name, string manufacturer, string description) : this(name, manufacturer) {
            this.description = description;
        }

        public void SendQuery(string number, string date) {
            try
            {
                if (Convert.ToInt32(number) <= 0) { 
                    MessageBox.Show("Количество оборудования должно быть больше нуля", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); 
                    return; 
                }
                if (DateTime.Parse(date) < DateTime.Now) {
                    MessageBox.Show("Невозможно указать прошедшую дату в качестве срока поставки", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (date.Split('.').Length != 3)
                {
                    MessageBox.Show("Разделителем даты является точка", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); 
                    return;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            StreamReader reader = new StreamReader("queries.txt");
            string Str = reader.ReadToEnd();
            reader.Close();
            StreamWriter writer = new StreamWriter("queries.txt");
            writer.WriteLine("{0}|{1}|{2}|{3}|{4}|{5}|{6}", name, manufacturer, DateTime.Now.ToShortDateString(), date, number, "В рассмотрении", "");
            writer.Write(Str);
            writer.Close();
        }
        
        public string Name { get { return name; } }
        public string Manufacturer { get { return manufacturer; } }
        public string Description { get { return description; } }
    }

    public class Query {

        private Equipment equipment;
        private string queryDate;
        private string deliveryDate;
        private string number;
        private string status;
        private string descriptionOfProblem;
        public Query(Equipment equipment, string queryDate, string deliveryDate, string number, string status, string descriptionOfProblem) {
            this.equipment = equipment;
            this.queryDate = queryDate;
            this.deliveryDate = deliveryDate;
            this.number = number;
            this.status = status;
            this.descriptionOfProblem = descriptionOfProblem;
        }
        public void ChangeStatus(string status, string descriptionOfProblem)
        {
            this.status = status;
            this.descriptionOfProblem = descriptionOfProblem;
            SaveChanges();
        }
        public void ChangeStatus(string status) {
            this.status = status;
            this.descriptionOfProblem = "";
            SaveChanges();
        }
        private void SaveChanges() {
            StreamReader reader = new StreamReader("queries.txt");
            string str = reader.ReadToEnd();
            reader.Close();
            // извлекаем строку, которая была изменена
            string subStr = "";
            int index = 0;
            while (index != -1)
            {
                index = str.IndexOf(equipment.Name, index) + 1;
                subStr = str.Substring(index - 1);
                try
                {
                    subStr = subStr.Remove(subStr.IndexOf("\n"));
                }
                catch { }  // если выбрана последняя запись(тк в конце нет "\n")
                if (subStr.IndexOf(equipment.Name) != -1 &&
                        subStr.IndexOf(equipment.Manufacturer) != -1 &&
                        subStr.IndexOf(queryDate) != -1 &&
                        subStr.IndexOf(deliveryDate) != -1 &&
                        subStr.IndexOf(number) != -1)
                {
                    break;
                }
            }
            string[] line = subStr.Split('|');
            line[5] = Status;
            line[6] = descriptionOfProblem;
            string temp = string.Join("|", line);
            str = str.Replace(subStr, temp);
            StreamWriter writer = new StreamWriter("queries.txt");
            writer.Write(str);
            writer.Close();
        }

        public Equipment Equipment { get { return equipment; } }
        public string QueryDate { get { return queryDate; } }
        public string DeliveryDate { get { return deliveryDate; } }
        public string Number { get { return number; } }
        public string Status { get { return status; } }
        public string DescriptionOfProblem { get { return descriptionOfProblem; } }
    }
}
