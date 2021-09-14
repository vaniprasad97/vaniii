using System;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using System.Threading.Tasks;
using System.Configuration;

using MySql.Data.MySqlClient;
using System.Data.SqlClient;

public class Employee
{
    public String EmployeeId;
    public String EmployeeName;
    public String EmployeeEmail;
    public String EmployeePhoneNumber;
    public int EmployeeAge;

}
public class Validatedetails : Employee
{
    public static object EmployeePhonenumber { get; private set; }

    public void ValidateEmployeeId()
    {
        String employeeId;
        var flag = 0;
        //var scanner = "Inputs";
        Console.WriteLine("Enter Employee ID");
        employeeId = Console.ReadLine();
        var str1 = "0000";
        while (flag == 0)
        {
            var length = employeeId.Length;
            string str2 = employeeId.Substring(3);
            if (length == 7 && (employeeId.StartsWith("ace") || employeeId.StartsWith("ACE") == true))
            {
                flag = 1;
                EmployeeId = employeeId;
                for (var i = 3; i < 7; i++)
                {
                    if (!char.IsDigit(employeeId[i]))
                    {
                        flag = 1;
                        break;
                    }
                }
                //  Console.WriteLine("Employee Id :" + EmployeeId);
            }
            else
            //  { flag = 0; }
            if (flag == 0 || str1.Equals(str2) == true)
            {
                Console.WriteLine("Invalid EmployeeID. Employee ID should start with ACE followed by 4 digits");
                Console.WriteLine("Enter a Valid ID ");
                employeeId = Console.ReadLine();
            }
        }
    }
    public void ValidateEmployeeName()
    {
        String EmployeeName1;
        var flag = 0;
        while (flag == 0)
        {
            Console.WriteLine("Enter Employee Name");
            EmployeeName1 = Console.ReadLine();
            var length = EmployeeName1.Length;
            String nameasuppercase = EmployeeName1.ToUpper();
            char[] data = nameasuppercase.ToCharArray();
            for (int k = 0; k < length; k++)
            {
                int asciinum = (int)data[k];
                if (asciinum != 32)
                {
                    if (asciinum < 65 || asciinum > 90)
                    {
                        flag = 0;
                        Console.WriteLine("Invalid Name! Name contains digits. Enter a valid name");
                        break;
                    
                    }
                    else
                        flag = 1;

                }

            }
            if (flag == 1) 
            {
                EmployeeName = EmployeeName1;
                break;
            }

        }
        if(EmployeeName.StartsWith(" "))
        {
                Console.WriteLine("The employee name starts with blankspace. Enter a valid name");
            Console.WriteLine("Enter Employee Name");
            EmployeeName = Console.ReadLine();
            return;

        }
    }
    public void ValidateEmployeeEmail()
    {
        String Email;
        var flag = 1;
        while (flag == 1)
        {
            Console.WriteLine("Enter Email ID");
            Email = Console.ReadLine();
            Regex regex = new Regex(@"^[a-zA-Z0-9+_.-]+@[a-zA-Z]+(.com|.COM)$");
        
            bool isValidEmail = regex.IsMatch(Email);
            //Pattern pattern = Pattern.compile(regex);
            //Matcher matcher = pattern.matcher(Email);
            if (isValidEmail)
            {

                flag = 0;
                EmployeeEmail = Email;
                break;
            }
            else
            {
                flag = 1;
                Console.WriteLine("Invalid email Id. Enter a valid Id");
            }
        }
    }
    public void ValidateEmployeePhoneNumber()
    {
        String PhoneNumber;
        var flag = 0;
        while (flag == 0)
        {
            Console.WriteLine("Enter Mobile Number");
            PhoneNumber = Console.ReadLine();
            Regex regex = new Regex("(91)?[5-9][0-9]{9}$");
            bool isValidPhoneNumber = regex.IsMatch(PhoneNumber);
            if ((isValidPhoneNumber) && (PhoneNumber.Length == 10))
            {
                flag = 1;
                EmployeePhoneNumber = PhoneNumber;
                break;
            }
            else
            {
                flag = 0;
                Console.WriteLine("Invalid Phone Number.Enter a 10 digit number starts with 5-9 ");
            }
        }

    }
    public void ValidateDateOfBirth()
    {
        var flag = 0;

        while (flag != 1)
        {
            Console.Write("Enter DOB in YYYY-MM-DD format");
            DateTime birthday = DateTime.Parse(Console.ReadLine());
            //Console.WriteLine("BirthDay: {0:yyy-MM-dd}", birthday.Date);
            TimeSpan diff = DateTime.Now.Date - birthday.Date;
           // Console.Write("diff is" + diff);
            DateTime zeroDate = new DateTime(1, 1, 1);
            // Console.Write("zerodate is" + zeroDate);
            //Console.WriteLine("zero date: {0:yyy-MM-dd}", zeroDate.Date );
            int age = (zeroDate + diff).Year - 1;
            if (age < 18 || age > 60)
            {
                Console.WriteLine("Invalid age !Age must be between 18-60");
            }
            else
            {
                Console.WriteLine("Valid Age:{0}", age);
                EmployeeAge = age;
                flag = 1;
                break;
            }
        }
    }
    public void ValidateEmployeeprintdetails()
    {
        Console.WriteLine("\n\n       Details of "+ EmployeeName +"\n        ");
      //  Console.WriteLine("\n   ");
        Console.WriteLine("Employee Name :" + EmployeeName);
        Console.WriteLine("Employee Id :" + EmployeeId);
        Console.WriteLine("Employee PhoneNumber :" + EmployeePhoneNumber);
        Console.WriteLine("Employee Email :" + EmployeeEmail);
        Console.WriteLine("Employee Age :" + EmployeeAge);

        //String[] DetailsInArray = { "Employee ID :"+EmployeeId, "Employee Name : "+EmployeeName ,"Employee Contact No. : "+EmployeePhoneNumber,"Employee MailID  : "+EmployeeEmail,"Employee Age : "+EmployeeAge};
        Console.WriteLine("\n     Employee details added to array   \n");
        //foreach (var details in DetailsInArray)
        //Console.WriteLine( details);
        ArrayList list;
        list = new ArrayList();
        list.Add("Employee id :"+EmployeeId);
        list.Add("Employee name : "+EmployeeName);
        list.Add("Employee email :"+EmployeeEmail);
        list.Add("Employee phone number : "+EmployeePhoneNumber);
        list.Add("Employee age :"+EmployeeAge);
        foreach (var details in list)
            Console.WriteLine(details);

    }

    abstract class SalaryFind
    {
        public abstract int GetSalary();
    }

    class Seniordeveloper : SalaryFind
    {
        private int salary;
        public Seniordeveloper(int s)

        {

            salary = s;
        }
        public override int GetSalary() // method overriding
        {

            return salary;
        }
    }
    class Trainee : SalaryFind
    {
        private int salary;
        public Trainee(int s)
        {
            salary = s;

        }

        public override int GetSalary()
        {
            //Console.WriteLine("enter the salary");
            // Console.ReadLine();
            //  Console.WriteLine("salary is"+salary);
            //Console.ReadLine();
            return salary;
        }
    }
    class manager : SalaryFind
    {
        private int salary;
        public manager(int s, int r) // method overloading
        {
            salary = s + r;
            // allowance = r;

        }

        public override int GetSalary()
        {
            //Console.WriteLine("enter the salary");
            // Console.ReadLine();
            //  Console.WriteLine("salary is"+salary);
            //Console.ReadLine();
            return salary;
            // return allowance;
        }
    }

    public void newconnection()
    {
        string comString = "server = localhost;Port = 3306; Database=db; user id = root; password=root;";
        MySqlConnection conn = new MySqlConnection(comString);
        MySqlCommand command = conn.CreateCommand();
        command.CommandText = ("insert into employee(EmployeeId,EmployeeName,EmployeeEmail,EmployeePhoneNumber,EmployeeAge)values(@0,@1,@2,@3,@4)");

        command.Parameters.Add("0", MySqlDbType.VarChar).Value = EmployeeId;
        command.Parameters.Add("1", MySqlDbType.VarChar).Value = EmployeeName;
        command.Parameters.Add("2", MySqlDbType.VarChar).Value = EmployeeEmail;
        command.Parameters.Add("3", MySqlDbType.VarChar).Value = EmployeePhoneNumber;
        command.Parameters.Add("4", MySqlDbType.Int64).Value = EmployeeAge;

        conn.Open();

        command.ExecuteNonQuery();
        conn.Close();
    }


    public static void Main(string[] arg)
    {
        Validatedetails p = new Validatedetails();
        p.ValidateEmployeeId();
        p.ValidateEmployeeName();
        p.ValidateEmployeeEmail();
        p.ValidateEmployeePhoneNumber();
        p.ValidateDateOfBirth();
        p.ValidateEmployeeprintdetails();
       // p.newconnection();
        Seniordeveloper d = new Seniordeveloper(5000);
        int a = d.GetSalary();
        Trainee t = new Trainee(2000);
      //  int x, y;
        int b = t.GetSalary();
        manager m = new manager(2000,3000);
        Console.WriteLine("enter the value");
     //   x= Console.ReadLine();
      //  y = Console.ReadLine();
      //  Console.WriteLine("x is" + x);
      //  Console.WriteLine("y is" + y);

        int c = m.GetSalary();
        Console.WriteLine("\n    salary details     \n");
        Console.WriteLine("salary of senior developer is " + a);
        Console.WriteLine("salary of trainee is " + b);
       // Console.WriteLine("salary of manager is(sum of basic pay and allowance) are" + c);
        // p.empconn();
        p.newconnection();
        Console.ReadLine();


    }

}
      /*  string comString = "server = localhost;Port = 3306; Database=db; user id = root; password=root;";
        MySqlConnection conn = new MySqlConnection(comString);
        MySqlCommand command = conn.CreateCommand();
        // command.CommandText = ("insert into employee(EmployeeId,EmployeeName,EmployeeEmail,EmployeePhonenumber)values('ACE1234','vani','vani@gmail.com',9539741399)");
        command.CommandText = ("insert into employee(EmployeeId,EmployeeName,EmployeeEmail,EmployeePhonenumber)values(@0,@1,@2,@3)");
        command.Parameters.Add(EmployeeId);
        conn.Open();





        command.ExecuteNonQuery();
        conn.Close();




        /* command.CommandText = "select * from programmer";
         try
         {
             conn.Open();

         }
         catch (Exception ex)
         {
             Console.WriteLine(ex.Message);

         }
         MySqlDataReader reader = command.ExecuteReader();
         while (reader.Read())
         {
             Console.WriteLine(reader["text"].ToString());
         }
         Console.ReadLine();
        */


   







