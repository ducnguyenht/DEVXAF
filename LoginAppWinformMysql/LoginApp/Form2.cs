using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace LoginApp
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string MyConnection2 = "datasource=50.62.209;database=DucTestMySql;port=77;username=DucTestMySql;password=123456";
                MySqlConnection MyConn = new MySqlConnection(MyConnection2);
                MySqlCommand MyCommand = new MySqlCommand("select * from DucTestMySql.AuditTrail;", MyConn);
                MySqlDataReader MyReader;

                MyConn.Open();
                MyReader = MyCommand.ExecuteReader();
                int count = 0;
                while (MyReader.Read())
                {
                    Console.WriteLine(MyReader[count]);
                    count++;
                }
                MessageBox.Show("Username and password is correct");
                this.Hide();
                Form2 f2 = new Form2();
                f2.ShowDialog();
                //if (count == 1)
                //{
                //    MessageBox.Show("Username and password is correct");
                //    this.Hide();
                //    Form2 f2 = new Form2();
                //    f2.ShowDialog();
                //}
                //else if (count > 1)
                //{

                //    MessageBox.Show("Duplicate Username and passwor.\nAccess denied.");
                //}
                //else
                //{
                //    MessageBox.Show("Username and password is incorrect.\nPleas try again.");
                //}
                MyConn.Close();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            //    <add name="AuditTrailMySql" connectionString="metadata=res://*/AuditTrailDALModel.csdl|res://*/AuditTrailDALModel.ssdl|res://*/AuditTrailDALModel.msl;provider=MySql.Data.MySqlClient;


            ////This is my connection string i have assigned the database file address path
            //string MyConnection2 = "datasource=50.62.209;database=DucTestMySql;port=77;username=DucTestMySql;password=123456";
            ////This is my insert query in which i am taking input from the user through windows forms
            //string Query = "insert into student.studentinfo(idStudentInfo,Name,Father_Name,Age,Semester) values('" + this.IdTextBox.Text + "','" + this.NameTextBox.Text + "','" + this.FnameTextBox.Text + "','" + this.AgeTextBox.Text + "','" + this.SemesterTextBox.Text + "');";
            ////This is  MySqlConnection here i have created the object and pass my connection string.
            //MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
            ////This is command class which will handle the query and connection object.
            //MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
            //MySqlDataReader MyReader2;
            //MyConn2.Open();
            //MyReader2 = MyCommand2.ExecuteReader();     // Here our query will be executed and data saved into the database.
            //MessageBox.Show("Save Data");
            //while (MyReader2.Read())
            //{

            //}
            //MyConn2.Close();
            //}
            //catch (Exception ex)
            //{

            //    MessageBox.Show(ex.Message);
            //}
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                //This is my connection string i have assigned the database file address path
                string MyConnection2 = "datasource=50.62.209;database=DucTestMySql;port=77;username=DucTestMySql;password=123456";
                //This is my update query in which i am taking input from the user through windows forms and update the record.
                string Query = "update student.studentinfo set idStudentInfo='" + this.IdTextBox.Text + "',Name='" + this.NameTextBox.Text + "',Father_Name='" + this.FnameTextBox.Text + "',Age='" + this.AgeTextBox.Text + "',Semester='" + this.SemesterTextBox.Text + "' where idStudentInfo='" + this.IdTextBox.Text + "';";
                //This is  MySqlConnection here i have created the object and pass my connection string.
                MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                MySqlDataReader MyReader2;
                MyConn2.Open();
                MyReader2 = MyCommand2.ExecuteReader();
                MessageBox.Show("Data Updated");
                while (MyReader2.Read())
                {

                }
                MyConn2.Close();//Connection closed here
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string MyConnection2 = "datasource=50.62.209;database=DucTestMySql;port=77;username=DucTestMySql;password=123456";
                string Query = "delete from student.studentinfo where idStudentInfo='" + this.IdTextBox.Text + "';";
                MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                MySqlDataReader MyReader2;
                MyConn2.Open();
                MyReader2 = MyCommand2.ExecuteReader();
                MessageBox.Show("Data Deleted");
                while (MyReader2.Read())
                {

                }
                MyConn2.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }


    }
}
