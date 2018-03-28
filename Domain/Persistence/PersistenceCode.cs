using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Domain.Business;
using System.Globalization;
using System.Data;

namespace Domain.Persistence
{
	public class PersistenceCode
	{
		string _connectionString;

        public PersistenceCode()
        {
            _connectionString = "server=localhost; port = 3306; user id=root; persistsecurityinfo = true; database = CliniresearchDB; password = Ratava989";
        }
        
        #region Get
        //Getting the data from every table
        public List<ClientCode> getClients(string sortingPar)
		{
            List<ClientCode> ListClients = new List<ClientCode>();
			MySqlConnection conn = new MySqlConnection(_connectionString);
            MySqlCommand cmd = new MySqlCommand(string.Format("SELECT * FROM cliniresearchdb.tblclient{0};", sortingPar) , conn);
			conn.Open();
			MySqlDataReader dataReader = cmd.ExecuteReader();

			while (dataReader.Read())
			{
				int id = Convert.ToInt16(dataReader["Client_ID"]);
				string name = Convert.ToString(dataReader["Name"]);
				string adress = Convert.ToString(dataReader["Adress"]);
				string postal_code = Convert.ToString(dataReader["Postal_Code"]);
				string city = Convert.ToString(dataReader["City"]);
				string country = Convert.ToString(dataReader["Country"]);
				string contact_person = Convert.ToString(dataReader["Contact_Person"]);
				string invoice_info = Convert.ToString(dataReader["Invoice_Info"]);
				string kind_of_client = Convert.ToString(dataReader["Kind_of_Client"]);


                ClientCode c = new ClientCode(id, name,adress,postal_code,city,country,contact_person,invoice_info,kind_of_client);

				ListClients.Add(c);
			}

            conn.Close();
            return ListClients;
		}
		public List<ContractCode> getContract(string sortingPar)
		{
            List<ContractCode> ListContract = new List<ContractCode>();
			MySqlConnection conn = new MySqlConnection(_connectionString);
			MySqlCommand cmd = new MySqlCommand(string.Format("SELECT * FROM cliniresearchdb.tblcontract{0};", sortingPar), conn);
			conn.Open();
			MySqlDataReader dataReader = cmd.ExecuteReader();

			while (dataReader.Read())
			{
                int id = Convert.ToInt16(dataReader["Contract_ID"]);
                string legal_country = Convert.ToString(dataReader["Legal_country"]);
				double fee = Convert.ToDouble(dataReader["Fee"]);
				DateTime Start_date = Convert.ToDateTime(dataReader["Start_date"]);
				DateTime End_date = Convert.ToDateTime(dataReader["End_date"]);

                CultureInfo.CurrentCulture = CultureInfo.CreateSpecificCulture("nl-BE");
                ContractCode c = new ContractCode(id, legal_country, fee.ToString("C", CultureInfo.CurrentCulture), Start_date.ToString("dd-MMM-yyyy"), End_date.ToString("dd-MMM-yyyy"));

				ListContract.Add(c);
			}

            conn.Close();
            return ListContract;
		}
		public List<CRACode> getCRA()
		{
            List<CRACode> ListCRA = new List<CRACode>();
			MySqlConnection conn = new MySqlConnection(_connectionString);
			MySqlCommand cmd = new MySqlCommand("select * from tblCRA",conn);
			conn.Open();
			MySqlDataReader dataReader = cmd.ExecuteReader();

			while (dataReader.Read())
			{
                int id = Convert.ToInt16(dataReader["CRA_ID"]);
                string name = Convert.ToString(dataReader["Name"]);
				string cv = Convert.ToString(dataReader["CV"]);
				string email = Convert.ToString(dataReader["E_mail"]);
				string phone1 = Convert.ToString(dataReader["Phone1"]);
				string phone2 = Convert.ToString(dataReader["Phone2"]);

				CRACode c = new CRACode(id,name,cv,email,phone1,phone2);

				ListCRA.Add(c);
			}

            conn.Close();
            return ListCRA;
		}
		public List<DepartmentCode> getDepartment()
		{
            List<DepartmentCode> ListDepartment = new List<DepartmentCode>();
			MySqlConnection conn = new MySqlConnection(_connectionString);
			MySqlCommand cmd = new MySqlCommand("select * from tblDepartment",conn);
			conn.Open();
			MySqlDataReader dataReader = cmd.ExecuteReader();

			while (dataReader.Read())
			{
                int id = Convert.ToInt16(dataReader["Department_ID"]);
                string name = Convert.ToString(dataReader["Name"]);
				string email = Convert.ToString(dataReader["E_mail"]);
				string phone1 = Convert.ToString(dataReader["Phone1"]);

				DepartmentCode c = new DepartmentCode(id,name,email,phone1);

				ListDepartment.Add(c);
			}

            conn.Close();
            return ListDepartment;
		}
		public List<DoctorCode> getDoctor()
		{
            List<DoctorCode> ListDoctor = new List<DoctorCode>();
			MySqlConnection conn = new MySqlConnection(_connectionString);
			MySqlCommand cmd = new MySqlCommand("select * from tblDoctor",conn);
			conn.Open();
			MySqlDataReader dataReader = cmd.ExecuteReader();

			while (dataReader.Read())
			{
                int id = Convert.ToInt16(dataReader["Doctor_ID"]);
                string name = Convert.ToString(dataReader["Name"]);
				string email = Convert.ToString(dataReader["E_mail"]);
				string phone1 = Convert.ToString(dataReader["Phone1"]);
				string phone2 = Convert.ToString(dataReader["Phone2"]);
				string adress = Convert.ToString(dataReader["Adress"]);
				string postal_code = Convert.ToString(dataReader["Postal_code"]);
				string city = Convert.ToString(dataReader["City"]);
				string country = Convert.ToString(dataReader["Country"]);
				string specialisation = Convert.ToString(dataReader["Specialisation"]);
				string cv = Convert.ToString(dataReader["CV"]);

				DoctorCode c = new DoctorCode(id,name,email,phone1,phone2,adress,postal_code,city,country,specialisation,cv);

				ListDoctor.Add(c);
			}

            conn.Close();
            return ListDoctor;
		}
		public List<EvaluationCode> getEvaluation()
		{
            List<EvaluationCode> ListEvaluation = new List<EvaluationCode>();
			MySqlConnection conn = new MySqlConnection(_connectionString);
			MySqlCommand cmd = new MySqlCommand("select * from tblEvaluation",conn);
			conn.Open();
			MySqlDataReader dataReader = cmd.ExecuteReader();

			while (dataReader.Read())
			{
                int id = Convert.ToInt16(dataReader["Evaluation_ID"]);
                DateTime date = Convert.ToDateTime(dataReader["Date"]);
				string feedback = Convert.ToString(dataReader["Feedback"]);
				string accuracy = Convert.ToString(dataReader["Accuracy"]);
				string quality = Convert.ToString(dataReader["Quality"]);
				string evalauation_txt = Convert.ToString(dataReader["Evaluation_txt"]);
				string label = Convert.ToString(dataReader["Label"]);

				EvaluationCode c = new EvaluationCode(id,date.ToString("dd-MMM-yyyy"),feedback,accuracy,quality,evalauation_txt,label);

				ListEvaluation.Add(c);
			}

            conn.Close();
            return ListEvaluation;
		}
		public List<HospitalCode> getHospital()
		{
            List<HospitalCode> ListHospital = new List<HospitalCode>();
			MySqlConnection conn = new MySqlConnection(_connectionString);
			MySqlCommand cmd = new MySqlCommand("select * from tblHospital",conn);
			conn.Open();
			MySqlDataReader dataReader = cmd.ExecuteReader();

			while (dataReader.Read())
			{
                int id = Convert.ToInt16(dataReader["Hospital_ID"]);
                string name = Convert.ToString(dataReader["Name"]);
				string adress = Convert.ToString(dataReader["Adress"]);
				string postal_code = Convert.ToString(dataReader["Postal_code"]);
				string city = Convert.ToString(dataReader["City"]);
				string country = Convert.ToString(dataReader["Country"]);
				string central_number = Convert.ToString(dataReader["Central_number"]);

				HospitalCode c = new HospitalCode(id,name,adress,postal_code,city,country,central_number);

				ListHospital.Add(c);
			}
            
            conn.Close();
            return ListHospital;
		}
		public List<ProjectCode> getProject()
		{
            List<ProjectCode> ListProject = new List<ProjectCode>();
			MySqlConnection conn = new MySqlConnection(_connectionString);
			MySqlCommand cmd = new MySqlCommand("select * from tblProject",conn);
			conn.Open();
			MySqlDataReader dataReader = cmd.ExecuteReader();

			while (dataReader.Read())
			{
                int id = Convert.ToInt16(dataReader["Project_ID"]);
                string title = Convert.ToString(dataReader["Title"]);
				DateTime start_date = Convert.ToDateTime(dataReader["Start_date"]).Date;
				DateTime end_date = Convert.ToDateTime(dataReader["End_date"]).Date;

				ProjectCode c = new ProjectCode(id,title,start_date.ToString("dd-MMM-yyyy"), end_date.ToString("dd-MMM-yyyy"));

				ListProject.Add(c);
			}

            conn.Close();
            return ListProject;
		}
		public List<ProjectManagerCode> getProjectManager()
		{
            List<ProjectManagerCode> ListProjectManager = new List<ProjectManagerCode>();
			MySqlConnection conn = new MySqlConnection(_connectionString);
			MySqlCommand cmd = new MySqlCommand("select * from tblProjectManager",conn);
			conn.Open();
			MySqlDataReader dataReader = cmd.ExecuteReader();

			while (dataReader.Read())
			{
                int id = Convert.ToInt16(dataReader["PM_ID"]);
                string name = Convert.ToString(dataReader["Name"]);
				string cv = Convert.ToString(dataReader["CV"]);
				string email = Convert.ToString(dataReader["E_mail"]);
				string phone1 = Convert.ToString(dataReader["Phone1"]);
				string phone2 = Convert.ToString(dataReader["Phone2"]);

				ProjectManagerCode c = new ProjectManagerCode(id,name,cv,email,phone1,phone2);

				ListProjectManager.Add(c);
			}

            conn.Close();
            return ListProjectManager;
		}
		public List<StudyCoördinatorCode> getStudyCoördinator()
		{
            List<StudyCoördinatorCode> ListStudyCoördinator = new List<StudyCoördinatorCode>();
			MySqlConnection conn = new MySqlConnection(_connectionString);
			MySqlCommand cmd = new MySqlCommand("select * from tblStudyCoördinator",conn);
			conn.Open();
			MySqlDataReader dataReader = cmd.ExecuteReader();

			while (dataReader.Read())
			{
                int id = Convert.ToInt16(dataReader["SC_ID"]);
                string name = Convert.ToString(dataReader["Name"]);
				string cv = Convert.ToString(dataReader["CV"]);
				string email = Convert.ToString(dataReader["E_mail"]);
				string phone1 = Convert.ToString(dataReader["Phone1"]);
				string phone2 = Convert.ToString(dataReader["Phone2"]);
				string specialisation = Convert.ToString(dataReader["Specialisation"]);

				StudyCoördinatorCode c = new StudyCoördinatorCode(id,name,cv,email,phone1,phone2,specialisation);

				ListStudyCoördinator.Add(c);
			}

            conn.Close();
			return ListStudyCoördinator;
		}
        #endregion

        #region GetDropDownContent
        public List<List<string>> getClientDropDown()
        {
            List<List<string>> ListCount = new List<List<string>>();
            List<string> ListDropdown = new List<string>();
            MySqlConnection conn = new MySqlConnection(_connectionString);
            MySqlCommand cmd = new MySqlCommand("select * from tblclient ORDER BY Name ASC", conn);
            conn.Open();
            MySqlDataReader dataReader = cmd.ExecuteReader();

            while (dataReader.Read())
            {
                int id = Convert.ToInt16(dataReader["Client_ID"]);
                string name = Convert.ToString(dataReader["Name"]);

                ListDropdown.Add(Convert.ToString(id));
                ListDropdown.Add(name);
                ListCount.Add(ListDropdown);
            }

            conn.Close();
            return ListCount;
        }
        public List<List<string>> getContractDropDown()
        {
            List<List<string>> ListCount = new List<List<string>>();
            List<string> ListDropdown = new List<string>();
            MySqlConnection conn = new MySqlConnection(_connectionString);
            MySqlCommand cmd = new MySqlCommand("select * from tblcontract ORDER BY Legal_country ASC", conn);
            conn.Open();
            MySqlDataReader dataReader = cmd.ExecuteReader();

            //Legal country is niet de beste column om op te halen als referentie naar een contract. Aangezien tblContract geen Name als column heeft laat ik het voorlopig zo.
            while (dataReader.Read())
            {
                int id = Convert.ToInt16(dataReader["Contract_ID"]);
                string name_not_really = Convert.ToString(dataReader["Legal_country"]);

                ListDropdown.Add(Convert.ToString(id));
                ListDropdown.Add(name_not_really);
                ListCount.Add(ListDropdown);
            }

            conn.Close();
            return ListCount;
        }
        public List<List<string>> getCRADropDown()
        {
            List<List<string>> ListCount = new List<List<string>>();
            List<string> ListDropdown = new List<string>();
            MySqlConnection conn = new MySqlConnection(_connectionString);
            MySqlCommand cmd = new MySqlCommand("select * from tblcra ORDER BY Name ASC", conn);
            conn.Open();
            MySqlDataReader dataReader = cmd.ExecuteReader();

            while (dataReader.Read())
            {
                int id = Convert.ToInt16(dataReader["CRA_ID"]);
                string name = Convert.ToString(dataReader["Name"]);

                ListDropdown.Add(Convert.ToString(id));
                ListDropdown.Add(name);
                ListCount.Add(ListDropdown);
            }

            conn.Close();
            return ListCount;
        }
        public List<List<string>> getDepartmentDropDown()
        {
            List<List<string>> ListCount = new List<List<string>>();
            List<string> ListDropdown = new List<string>();
            MySqlConnection conn = new MySqlConnection(_connectionString);
            MySqlCommand cmd = new MySqlCommand("select * from tbldepartment ORDER BY Name ASC", conn);
            conn.Open();
            MySqlDataReader dataReader = cmd.ExecuteReader();

            while (dataReader.Read())
            {
                int id = Convert.ToInt16(dataReader["Department_ID"]);
                string name = Convert.ToString(dataReader["Name"]);

                ListDropdown.Add(Convert.ToString(id));
                ListDropdown.Add(name);
                ListCount.Add(ListDropdown);
            }

            conn.Close();
            return ListCount;
        }
        public List<List<string>> getDoctorDropDown()
        {
            List<List<string>> ListCount = new List<List<string>>();
            List<string> ListDropdown = new List<string>();
            MySqlConnection conn = new MySqlConnection(_connectionString);
            MySqlCommand cmd = new MySqlCommand("select * from tbldoctor ORDER BY Name ASC", conn);
            conn.Open();
            MySqlDataReader dataReader = cmd.ExecuteReader();

            while (dataReader.Read())
            {
                int id = Convert.ToInt16(dataReader["Doctor_ID"]);
                string name = Convert.ToString(dataReader["Name"]);

                ListDropdown.Add(Convert.ToString(id));
                ListDropdown.Add(name);
                ListCount.Add(ListDropdown);
            }

            conn.Close();
            return ListCount;
        }
        public List<List<string>> getEvaluationDropDown()
        {
            List<List<string>> ListCount = new List<List<string>>();
            List<string> ListDropdown = new List<string>();
            MySqlConnection conn = new MySqlConnection(_connectionString);
            MySqlCommand cmd = new MySqlCommand("select * from tblevaluation ORDER BY Date ASC", conn);
            conn.Open();
            MySqlDataReader dataReader = cmd.ExecuteReader();
            //Date is niet de beste column om als referentie op te halen naar Evalaution. Aangezien tblEvaluation voorlopig nog geen column Name heeft laat ik het zo.
            while (dataReader.Read())
            {
                int id = Convert.ToInt16(dataReader["Evaluation_ID"]);
                DateTime date = Convert.ToDateTime(dataReader["Date"]);

                ListDropdown.Add(Convert.ToString(id));
                ListDropdown.Add(Convert.ToString(date));
                ListCount.Add(ListDropdown);
            }

            conn.Close();
            return ListCount;
        }
        public List<List<string>> getHospitalDropDown()
        {
            List<List<string>> ListCount = new List<List<string>>();
            int count = 0;
            MySqlConnection conn = new MySqlConnection(_connectionString);
            MySqlCommand cmd = new MySqlCommand("select * from tblhospital ORDER BY Name ASC", conn);
            conn.Open();
            MySqlDataReader dataReader = cmd.ExecuteReader();

            while (dataReader.Read())
            {
                int id = Convert.ToInt16(dataReader["Hospital_ID"]);
                string name = Convert.ToString(dataReader["Name"]);

                ListCount.Add(new List<String>());
                ListCount[count].Add(Convert.ToString(id));
                ListCount[count].Add(name);
                count++;
            }

            conn.Close();
            return ListCount;
        }
        public List<List<string>> getProjectDropDown()
        {
            List<List<string>> ListCount = new List<List<string>>();
            List<string> ListDropdown = new List<string>();
            MySqlConnection conn = new MySqlConnection(_connectionString);
            MySqlCommand cmd = new MySqlCommand("select * from tblProject ORDER BY Title ASC", conn);
            conn.Open();
            MySqlDataReader dataReader = cmd.ExecuteReader();

            while (dataReader.Read())
            {
                int id = Convert.ToInt16(dataReader["Hospital_ID"]);
                string title = Convert.ToString(dataReader["Title"]);

                ListDropdown.Add(Convert.ToString(id));
                ListDropdown.Add(title);
                ListCount.Add(ListDropdown);
            }

            conn.Close();
            return ListCount;
        }
        public List<List<string>> getProjectManagerDropDown()
        {
            List<List<string>> ListCount = new List<List<string>>();
            List<string> ListDropdown = new List<string>();
            MySqlConnection conn = new MySqlConnection(_connectionString);
            MySqlCommand cmd = new MySqlCommand("select * from tblprojectmanager ORDER BY Name ASC", conn);
            conn.Open();
            MySqlDataReader dataReader = cmd.ExecuteReader();

            while (dataReader.Read())
            {
                int id = Convert.ToInt16(dataReader["PM_ID"]);
                string name = Convert.ToString(dataReader["Name"]);

                ListDropdown.Add(Convert.ToString(id));
                ListDropdown.Add(name);
                ListCount.Add(ListDropdown);
            }

            conn.Close();
            return ListCount;
        }
        public List<List<string>> getStudyCoordinatorDropDown()
        {
            List<List<string>> ListCount = new List<List<string>>();
            List<string> ListDropdown = new List<string>();
            MySqlConnection conn = new MySqlConnection(_connectionString);
            MySqlCommand cmd = new MySqlCommand("select * from tblstudycoördinator ORDER BY Name ASC", conn);
            conn.Open();
            MySqlDataReader dataReader = cmd.ExecuteReader();

            while (dataReader.Read())
            {
                int id = Convert.ToInt16(dataReader["SC_ID"]);
                string name = Convert.ToString(dataReader["Name"]);

                ListDropdown.Add(Convert.ToString(id));
                ListDropdown.Add(name);
                ListCount.Add(ListDropdown);
            }

            conn.Close();
            return ListCount;
        }
        #endregion
        // Dropdowns nog niet volledig af (bijna wel)

        #region GetRelation
        public List<int> getRelationHospitalHasDoctor(int Doctor_ID_p)
        {
            List<int> ListAllRelations = new List<int>();
            MySqlConnection conn = new MySqlConnection(_connectionString);
            MySqlCommand cmd = new MySqlCommand("select tblHospital_Hospital_ID from tblhospital_has_tbldoctor WHERE tblDoctor_Doctor_ID = @id", conn);
            cmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = Doctor_ID_p;
            conn.Open();
            MySqlDataReader dataReader = cmd.ExecuteReader();

            while (dataReader.Read())
            {
                int idHospital = Convert.ToInt16(dataReader["tblHospital_Hospital_ID"]);
                
                ListAllRelations.Add(idHospital);
            }

            conn.Close();
            return ListAllRelations;
        }
        #endregion 
        // relations nog niet af

        #region Set
        public void addClient(string name_p,string adress_p,string postalcode_p,string city_p,string country_p,string contactperson_p,string invoiceinfo_p,string kindofclinet_p)
		{
			MySqlConnection conn = new MySqlConnection(_connectionString);

			conn.Open();

			MySqlCommand cmd = new MySqlCommand("INSERT INTO tblClient (Name, Adress, Postal_code, City, Country, Contact_person, Invoice_info, Kind_of_Client) VALUES (@name, @adress, @postal_code, @city, @country, @contact_person, @invoice_info, @kind_of_client);",conn);

			cmd.Parameters.Add("@name",MySqlDbType.VarChar).Value = name_p;
			cmd.Parameters.Add("@adress",MySqlDbType.VarChar).Value = adress_p;
			cmd.Parameters.Add("@postal_code",MySqlDbType.VarChar).Value = postalcode_p;
			cmd.Parameters.Add("@city",MySqlDbType.VarChar).Value = city_p;
			cmd.Parameters.Add("@country",MySqlDbType.VarChar).Value = country_p;
			cmd.Parameters.Add("@contact_person",MySqlDbType.VarChar).Value = contactperson_p;
			cmd.Parameters.Add("@invoice_info",MySqlDbType.VarChar).Value = invoiceinfo_p;
			cmd.Parameters.Add("@kind_of_client",MySqlDbType.VarChar).Value = kindofclinet_p;
			cmd.ExecuteNonQuery();

			conn.Close();
		}
		public void addContract(string legalcountry_p,double fee_p,DateTime startdate_p,DateTime enddate_p)
		{
			MySqlConnection conn = new MySqlConnection(_connectionString);

			conn.Open();

			MySqlCommand cmd = new MySqlCommand("INSERT INTO tblContract (Legal_country, Fee, Duration, Date) VALUES (@legal_country, @fee, @start_date, @end_date);", conn);

			cmd.Parameters.Add("@legal_country",MySqlDbType.VarChar).Value = legalcountry_p;
			cmd.Parameters.Add("@fee",MySqlDbType.Double).Value = fee_p;
			cmd.Parameters.Add("@start_date",MySqlDbType.DateTime).Value = startdate_p.Date;
			cmd.Parameters.Add("@end_date",MySqlDbType.DateTime).Value = enddate_p.Date;
			cmd.ExecuteNonQuery();

			conn.Close();
		}
		public void addCRA(string name_p,string cv_p,string email_p,string phone1_p,string phone2_p)
		{
			MySqlConnection conn = new MySqlConnection(_connectionString);

			conn.Open();

			MySqlCommand cmd = new MySqlCommand("INSERT INTO tblCRA (Name, CV, E_mail, Phone1, Phone2) VALUES (@name, @cv, @email, @phone1, @phone2);",conn);

			cmd.Parameters.Add("@name",MySqlDbType.VarChar).Value = name_p;
			cmd.Parameters.Add("@cv",MySqlDbType.VarChar).Value = cv_p;
			cmd.Parameters.Add("@email",MySqlDbType.VarChar).Value = email_p;
			cmd.Parameters.Add("@phone1",MySqlDbType.VarChar).Value = phone1_p;
			cmd.Parameters.Add("@phone2",MySqlDbType.VarChar).Value = phone2_p;
			cmd.ExecuteNonQuery();

			conn.Close();
		}
		public void addDepartment(string name_p,string email_p,string phone1_p)
		{
			MySqlConnection conn = new MySqlConnection(_connectionString);

			conn.Open();

			MySqlCommand cmd = new MySqlCommand("INSERT INTO tblDepartment (Name, E_mail, Phone1) VALUES (@name, @email, @phone1);",conn);

			cmd.Parameters.Add("@name",MySqlDbType.VarChar).Value = name_p;
			cmd.Parameters.Add("@email",MySqlDbType.VarChar).Value = email_p;
			cmd.Parameters.Add("@phone1",MySqlDbType.VarChar).Value = phone1_p;
			cmd.ExecuteNonQuery();

			conn.Close();
		}
		public void addDoctor(string name_p,string email_p,string phone1_p,string phone2_p,string adress_p,string postalcode_p,string city_p,string country_p,string specialisation_p,string cv_p)
		{
			MySqlConnection conn = new MySqlConnection(_connectionString);

			conn.Open();

			MySqlCommand cmd = new MySqlCommand("INSERT INTO tblDoctor (Name, E_mail, Phone1, Phone2, Adress, Postal_code, City, Country, Specialisation, CV) VALUES (@name, @email, @phone1, @phone2, @adress, @postal_code, @city, @country, @specialisation, @cv);",conn);

			cmd.Parameters.Add("@name",MySqlDbType.VarChar).Value = name_p;
			cmd.Parameters.Add("@email",MySqlDbType.VarChar).Value = email_p;
			cmd.Parameters.Add("@phone1",MySqlDbType.VarChar).Value = phone1_p;
			cmd.Parameters.Add("@phone2",MySqlDbType.VarChar).Value = phone2_p;
			cmd.Parameters.Add("@adress",MySqlDbType.VarChar).Value = adress_p;
			cmd.Parameters.Add("@postal_code",MySqlDbType.VarChar).Value = postalcode_p;
			cmd.Parameters.Add("@city",MySqlDbType.VarChar).Value = city_p;
			cmd.Parameters.Add("@country",MySqlDbType.VarChar).Value = country_p;
			cmd.Parameters.Add("@specialisation",MySqlDbType.VarChar).Value = specialisation_p;
			cmd.Parameters.Add("@cv",MySqlDbType.VarChar).Value = specialisation_p;
			cmd.ExecuteNonQuery();

			conn.Close();
		}
		public void addEvaluation(DateTime date_p,string feedback_p,string accuracy_p,string quality_p,string evaluationtxt_p,string label_p)
		{
			MySqlConnection conn = new MySqlConnection(_connectionString);

			conn.Open();

			MySqlCommand cmd = new MySqlCommand("INSERT INTO tblEvaluation (Date, Feedback, Accuracy, Quality, Evaluation_txt, Label) VALUES (@date, @feedback, @accuracy, @quality, @evaluation_txt, @label);",conn);

			cmd.Parameters.Add("@date",MySqlDbType.Date).Value = date_p;
			cmd.Parameters.Add("@feedback",MySqlDbType.VarChar).Value = feedback_p;
			cmd.Parameters.Add("@accuracy",MySqlDbType.VarChar).Value = accuracy_p;
			cmd.Parameters.Add("@quality",MySqlDbType.VarChar).Value = quality_p;
			cmd.Parameters.Add("@evaluation_txt",MySqlDbType.VarChar).Value = evaluationtxt_p;
			cmd.Parameters.Add("@label",MySqlDbType.VarChar).Value = label_p;

			cmd.ExecuteNonQuery();

			conn.Close();
		}
		public void addHospital(string name_p,string adress_p,string postalcode_p,string city_p,string country_p,string centralnumber_p)
		{
			MySqlConnection conn = new MySqlConnection(_connectionString);

			conn.Open();

			MySqlCommand cmd = new MySqlCommand("INSERT INTO tblHospital (Name, Adress, Postal_code, City, Country, Central_number) VALUES (@name, @adress, @postal_code, @city, @country, @central_number);",conn);

			cmd.Parameters.Add("@name",MySqlDbType.VarChar).Value = name_p;
			cmd.Parameters.Add("@adress",MySqlDbType.VarChar).Value = adress_p;
			cmd.Parameters.Add("@postal_code",MySqlDbType.VarChar).Value = postalcode_p;
			cmd.Parameters.Add("@city",MySqlDbType.VarChar).Value = city_p;
			cmd.Parameters.Add("@country",MySqlDbType.VarChar).Value = country_p;
			cmd.Parameters.Add("@central_number",MySqlDbType.VarChar).Value = centralnumber_p;
			cmd.ExecuteNonQuery();

			conn.Close();
		}
		public void addProject(string title_p,DateTime startdate_p, DateTime enddate_p)
		{
			MySqlConnection conn = new MySqlConnection(_connectionString);

			conn.Open();

			MySqlCommand cmd = new MySqlCommand("INSERT INTO tblProject (Title, Start_date, End_date) VALUES (@title, @start_date, @end_date);",conn);

			cmd.Parameters.Add("@title",MySqlDbType.VarChar).Value = title_p;
			cmd.Parameters.Add("@start_date",MySqlDbType.Date).Value = startdate_p.Date;
			cmd.Parameters.Add("@end_date",MySqlDbType.Date).Value = enddate_p.Date;
			cmd.ExecuteNonQuery();

			conn.Close();
		}
		public void addProjectManager(string name_p,string cv_p,string email_p,string phone1_p,string phone2_p)
		{
			MySqlConnection conn = new MySqlConnection(_connectionString);

			conn.Open();

			MySqlCommand cmd = new MySqlCommand("INSERT INTO tblProjectManager (Name, CV, E_mail, Phone1, Phone2) VALUES (@name, @cv, @email, @phone1, @phone2);",conn);

			cmd.Parameters.Add("@name",MySqlDbType.VarChar).Value = name_p;
			cmd.Parameters.Add("@cv",MySqlDbType.VarChar).Value = cv_p;
			cmd.Parameters.Add("@email",MySqlDbType.VarChar).Value = email_p;
			cmd.Parameters.Add("@phone1",MySqlDbType.VarChar).Value = phone1_p;
			cmd.Parameters.Add("@phone2",MySqlDbType.VarChar).Value = phone2_p;
			cmd.ExecuteNonQuery();

			conn.Close();
		}
		public void addStudyCoördinator(string name_p,string cv_p,string email_p,string phone1_p,string phone2_p,string specialisation_p)
		{
			MySqlConnection conn = new MySqlConnection(_connectionString);

			conn.Open();

			MySqlCommand cmd = new MySqlCommand("INSERT INTO tblStudyCoördinator(Name, CV, E_mail, Phone1, Phone2, Specialisation) VALUES (@name, @cv, @email, @phone1, @phone2, @specialisation);",conn);

			cmd.Parameters.Add("@name",MySqlDbType.VarChar).Value = name_p;
			cmd.Parameters.Add("@cv",MySqlDbType.VarChar).Value = cv_p;
			cmd.Parameters.Add("@email",MySqlDbType.VarChar).Value = email_p;
			cmd.Parameters.Add("@phone1",MySqlDbType.VarChar).Value = phone1_p;
			cmd.Parameters.Add("@phone2",MySqlDbType.VarChar).Value = phone2_p;
			cmd.Parameters.Add("@specialisation",MySqlDbType.VarChar).Value = specialisation_p;
			cmd.ExecuteNonQuery();

			conn.Close();
		}
        #endregion

        #region SetRelation
        public void addHospitalToDoctor(int hospital_id_p, int doctor_id_p)
        {
            MySqlConnection conn = new MySqlConnection(_connectionString);

            conn.Open();

            MySqlCommand cmd = new MySqlCommand("INSERT INTO tblhospital_has_tbldoctor (tblHospital_Hospital_ID, tblDoctor_Doctor_ID) VALUES (@hospital_id, @doctor_id);", conn);

            cmd.Parameters.Add("@hospital_id", MySqlDbType.VarChar).Value = hospital_id_p;
            cmd.Parameters.Add("@doctor_id", MySqlDbType.VarChar).Value = doctor_id_p;
            cmd.ExecuteNonQuery();

            conn.Close();
        }
        #endregion
        // relations nog niet af

        #region Update
        public void updateClients(int id_p, string name_p, string adress_p, string postalcode_p, string city_p, string country_p, string contactperson_p, string invoiceinfo_p, string kindofclinet_p)
        {
            MySqlConnection conn = new MySqlConnection(_connectionString);

            conn.Open();

            MySqlCommand cmd = new MySqlCommand("UPDATE tblClient SET Name = @name, Adress = @adress, Postal_code = @postal_code, City = @city, Country = @country, Contact_person = @contact_person, Invoice_info = @invoice_info, Kind_of_Client = @kind_of_client WHERE Client_ID = @id;", conn);

            cmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = id_p;
            cmd.Parameters.Add("@name", MySqlDbType.VarChar).Value = name_p;
            cmd.Parameters.Add("@adress", MySqlDbType.VarChar).Value = adress_p;
            cmd.Parameters.Add("@postal_code", MySqlDbType.VarChar).Value = postalcode_p;
            cmd.Parameters.Add("@city", MySqlDbType.VarChar).Value = city_p;
            cmd.Parameters.Add("@country", MySqlDbType.VarChar).Value = country_p;
            cmd.Parameters.Add("@contact_person", MySqlDbType.VarChar).Value = contactperson_p;
            cmd.Parameters.Add("@invoice_info", MySqlDbType.VarChar).Value = invoiceinfo_p;
            cmd.Parameters.Add("@kind_of_client", MySqlDbType.VarChar).Value = kindofclinet_p;
            cmd.ExecuteNonQuery();

            conn.Close();
        }
        public void UpdateContract(int id_p, string legalcountry_p, double fee_p, DateTime startdate_p, DateTime enddate_p)
        {
            MySqlConnection conn = new MySqlConnection(_connectionString);

            conn.Open();

            MySqlCommand cmd = new MySqlCommand("UPDATE tblContract SET Legal_country = @legal_country, Fee = @fee, Duration = @duration, Date = @date WHERE Contract_ID = @id;", conn);

            cmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = id_p;
            cmd.Parameters.Add("@legal_country", MySqlDbType.VarChar).Value = legalcountry_p;
            cmd.Parameters.Add("@fee", MySqlDbType.Double).Value = fee_p;
            cmd.Parameters.Add("@start_date", MySqlDbType.DateTime).Value = startdate_p.Date;
            cmd.Parameters.Add("@end_date", MySqlDbType.DateTime).Value = enddate_p.Date;
            cmd.ExecuteNonQuery();

            conn.Close();
        }
        public void UpdateCRA(int id_p, string name_p, string cv_p, string email_p, string phone1_p, string phone2_p)
        {
            MySqlConnection conn = new MySqlConnection(_connectionString);

            conn.Open();

            MySqlCommand cmd = new MySqlCommand("UPDATE tblCRA SET Name = @name, CV = @cv, E_mail = @email, Phone1 = @phone1, Phone2 = @phone2 WHERE CRA_ID = @id;", conn);

            cmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = id_p;
            cmd.Parameters.Add("@name", MySqlDbType.VarChar).Value = name_p;
            cmd.Parameters.Add("@cv", MySqlDbType.VarChar).Value = cv_p;
            cmd.Parameters.Add("@email", MySqlDbType.VarChar).Value = email_p;
            cmd.Parameters.Add("@phone1", MySqlDbType.VarChar).Value = phone1_p;
            cmd.Parameters.Add("@phone2", MySqlDbType.VarChar).Value = phone2_p;
            cmd.ExecuteNonQuery();

            conn.Close();
        }
        public void UpdateDepartment(int id_p, string name_p, string email_p, string phone1_p)
        {
            MySqlConnection conn = new MySqlConnection(_connectionString);

            conn.Open();

            MySqlCommand cmd = new MySqlCommand("UPDATE tblDepartment SET Name = @name, E_mail = @email, Phone1 = @phone1 WHERE Department_ID = @id;", conn);

            cmd.Parameters.Add("@name", MySqlDbType.VarChar).Value = name_p;
            cmd.Parameters.Add("@email", MySqlDbType.VarChar).Value = email_p;
            cmd.Parameters.Add("@phone1", MySqlDbType.VarChar).Value = phone1_p;
            cmd.ExecuteNonQuery();

            conn.Close();
        }
        public void UpdateDoctor(int id_p, string name_p, string email_p, string phone1_p, string phone2_p, string adress_p, string postalcode_p, string city_p, string country_p, string specialisation_p, string cv_p)
        {
            MySqlConnection conn = new MySqlConnection(_connectionString);

            conn.Open();

            MySqlCommand cmd = new MySqlCommand("UPDATE tblDoctor SET Name = @name, E_mail = @email, Phone1 = @phone1, Phone2 = @phone2, Adress = @adress, Postal_code = @postal_code, City = @city, Country = @country, Specialisation = @specialisation, CV = @cv WHERE Doctor_ID = @id;", conn);

            cmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = id_p;
            cmd.Parameters.Add("@name", MySqlDbType.VarChar).Value = name_p;
            cmd.Parameters.Add("@email", MySqlDbType.VarChar).Value = email_p;
            cmd.Parameters.Add("@phone1", MySqlDbType.VarChar).Value = phone1_p;
            cmd.Parameters.Add("@phone2", MySqlDbType.VarChar).Value = phone2_p;
            cmd.Parameters.Add("@adress", MySqlDbType.VarChar).Value = adress_p;
            cmd.Parameters.Add("@postal_code", MySqlDbType.VarChar).Value = postalcode_p;
            cmd.Parameters.Add("@city", MySqlDbType.VarChar).Value = city_p;
            cmd.Parameters.Add("@country", MySqlDbType.VarChar).Value = country_p;
            cmd.Parameters.Add("@specialisation", MySqlDbType.VarChar).Value = specialisation_p;
            cmd.Parameters.Add("@cv", MySqlDbType.VarChar).Value = specialisation_p;
            cmd.ExecuteNonQuery();

            conn.Close();
        }
        public void UpdateEvaluation(int id_p, DateTime date_p, string feedback_p, string accuracy_p, string quality_p, string evaluationtxt_p, string label_p)
        {
            MySqlConnection conn = new MySqlConnection(_connectionString);

            conn.Open();

            MySqlCommand cmd = new MySqlCommand("UPDATE tblEvaluation SET Date = @date, Feedback = @feedback, Accuracy = @accuracy, Quality = @quality, Evaluation_txt = @ evaluation_txt, Label = @label WHERE Evaluation_ID = @id;", conn);

            cmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = id_p;
            cmd.Parameters.Add("@date", MySqlDbType.Date).Value = date_p;
            cmd.Parameters.Add("@feedback", MySqlDbType.VarChar).Value = feedback_p;
            cmd.Parameters.Add("@accuracy", MySqlDbType.VarChar).Value = accuracy_p;
            cmd.Parameters.Add("@quality", MySqlDbType.VarChar).Value = quality_p;
            cmd.Parameters.Add("@evaluation_txt", MySqlDbType.VarChar).Value = evaluationtxt_p;
            cmd.Parameters.Add("@label", MySqlDbType.VarChar).Value = label_p;

            cmd.ExecuteNonQuery();

            conn.Close();
        }
        public void UpdateHospital(int id_p, string name_p, string adress_p, string postalcode_p, string city_p, string country_p, string centralnumber_p)
        {
            MySqlConnection conn = new MySqlConnection(_connectionString);

            conn.Open();

            MySqlCommand cmd = new MySqlCommand("UPDATE tblHospital SET Name = @name, Adress = @adress, Postal_code = @postal_code, City = @city, Country = @country, Central_number = @central_number WHERE Hospital_ID = @id;", conn);

            cmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = id_p;
            cmd.Parameters.Add("@name", MySqlDbType.VarChar).Value = name_p;
            cmd.Parameters.Add("@adress", MySqlDbType.VarChar).Value = adress_p;
            cmd.Parameters.Add("@postal_code", MySqlDbType.VarChar).Value = postalcode_p;
            cmd.Parameters.Add("@city", MySqlDbType.VarChar).Value = city_p;
            cmd.Parameters.Add("@country", MySqlDbType.VarChar).Value = country_p;
            cmd.Parameters.Add("@central_number", MySqlDbType.VarChar).Value = centralnumber_p;
            cmd.ExecuteNonQuery();

            conn.Close();
        }
        public void UpdateProject(int id_p, string title_p, DateTime startdate_p, DateTime enddate_p)
        {
            MySqlConnection conn = new MySqlConnection(_connectionString);

            conn.Open();

            MySqlCommand cmd = new MySqlCommand("UPDATE tblProject SET Title = @title, Start_date = @start_date, End_date = @end_date WHERE Project_ID = @id;", conn);

            cmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = id_p;
            cmd.Parameters.Add("@title", MySqlDbType.VarChar).Value = title_p;
            cmd.Parameters.Add("@start_date", MySqlDbType.Date).Value = startdate_p.Date;
            cmd.Parameters.Add("@end_date", MySqlDbType.Date).Value = enddate_p.Date;
            cmd.ExecuteNonQuery();

            conn.Close();
        }
        public void UpdateProjectManager(int id_p, string name_p, string cv_p, string email_p, string phone1_p, string phone2_p)
        {
            MySqlConnection conn = new MySqlConnection(_connectionString);

            conn.Open();

            MySqlCommand cmd = new MySqlCommand("UPDATE tblProjectManager SET Name = @name, CV = @cv, E_mail = @email, Phone1 = @phone1, Phone2 = @phone2 WHERE PM_ID = @id;", conn);

            cmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = id_p;

            cmd.Parameters.Add("@name", MySqlDbType.VarChar).Value = name_p;
            cmd.Parameters.Add("@cv", MySqlDbType.VarChar).Value = cv_p;
            cmd.Parameters.Add("@email", MySqlDbType.VarChar).Value = email_p;
            cmd.Parameters.Add("@phone1", MySqlDbType.VarChar).Value = phone1_p;
            cmd.Parameters.Add("@phone2", MySqlDbType.VarChar).Value = phone2_p;
            cmd.ExecuteNonQuery();

            conn.Close();
        }
        public void UpdateStudyCoördinator(int id_p, string name_p, string cv_p, string email_p, string phone1_p, string phone2_p, string specialisation_p)
        {
            MySqlConnection conn = new MySqlConnection(_connectionString);

            conn.Open();

            MySqlCommand cmd = new MySqlCommand("UPDATE tblStudyCoördinator SET Name = @name, CV = @cv, E_mail = @email, Phone1 = @phone1, Phone2 = @phone2, Specialisation = @specialisation WHERE SC_ID = @id;", conn);
            
            cmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = id_p;
            cmd.Parameters.Add("@name", MySqlDbType.VarChar).Value = name_p;
            cmd.Parameters.Add("@cv", MySqlDbType.VarChar).Value = cv_p;
            cmd.Parameters.Add("@email", MySqlDbType.VarChar).Value = email_p;
            cmd.Parameters.Add("@phone1", MySqlDbType.VarChar).Value = phone1_p;
            cmd.Parameters.Add("@phone2", MySqlDbType.VarChar).Value = phone2_p;
            cmd.Parameters.Add("@specialisation", MySqlDbType.VarChar).Value = specialisation_p;
            cmd.ExecuteNonQuery();

            conn.Close();
        }
        #endregion

        #region UpdateRelation
        public void UpdateRelationHospitalHasDoctor(int hospital_id_p, int doctor_id_p, int oldHospital_id_p)
        {
            MySqlConnection conn = new MySqlConnection(_connectionString);

            conn.Open();

            MySqlCommand cmd = new MySqlCommand("UPDATE tblhospital_has_tbldoctor SET tblHospital_Hospital_ID = @hospital_id, tblDoctor_Doctor_ID = @doctor_id WHERE tblHospital_Hospital_ID = @oldHospitalID AND tblDoctor_Doctor_ID = @doctor_id ;", conn);

            cmd.Parameters.Add("@hospital_id", MySqlDbType.VarChar).Value = hospital_id_p;
            cmd.Parameters.Add("@doctor_id", MySqlDbType.VarChar).Value = doctor_id_p;
            cmd.Parameters.Add("@oldHospitalID", MySqlDbType.VarChar).Value = oldHospital_id_p;
            cmd.ExecuteNonQuery();

            conn.Close();
        }
        #endregion

        #region Delete
        public void deleteClient(int id_p)
        {
            MySqlConnection conn = new MySqlConnection(_connectionString);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("DELETE from tblclient where Client_ID = @id", conn);
            cmd.Parameters.AddWithValue("@id", id_p);
            cmd.ExecuteNonQuery();
            conn.Close();

        }
        public void deleteContract(int id_p)
        {
            MySqlConnection conn = new MySqlConnection(_connectionString);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("DELETE from tblcontract where Contract_ID = @id", conn);
            cmd.Parameters.AddWithValue("@id", id_p);
            cmd.ExecuteNonQuery();
            conn.Close();

        }
        public void deleteCRA(int id_p)
        {
            MySqlConnection conn = new MySqlConnection(_connectionString);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("DELETE from tblcra where CRA_ID = @id", conn);
            cmd.Parameters.AddWithValue("@id", id_p);
            cmd.ExecuteNonQuery();
            conn.Close();

        }
        public void deleteDepartment(int id_p)
        {
            MySqlConnection conn = new MySqlConnection(_connectionString);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("DELETE from tbldepartment where Department_ID = @id", conn);
            cmd.Parameters.AddWithValue("@id", id_p);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void deleteDoctor(int id_p)
        {
            MySqlConnection conn = new MySqlConnection(_connectionString);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("DELETE from tbldoctor where Doctor_ID = @id", conn);
            cmd.Parameters.AddWithValue("@id", id_p);
            cmd.ExecuteNonQuery();
            conn.Close();

        }
        public void deleteEvaluation(int id_p)
        {
            MySqlConnection conn = new MySqlConnection(_connectionString);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("DELETE from tblevaluation where Evaluation_ID = @id", conn);
            cmd.Parameters.AddWithValue("@id", id_p);
            cmd.ExecuteNonQuery();
            conn.Close();

        }
        public void deleteHospital(int id_p)
        {
            MySqlConnection conn = new MySqlConnection(_connectionString);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("DELETE from tblhospital where Hospital_ID = @id", conn);
            cmd.Parameters.AddWithValue("@id", id_p);
            cmd.ExecuteNonQuery();
            conn.Close();

        }
        public void deleteProject(int id_p)
        {
            MySqlConnection conn = new MySqlConnection(_connectionString);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("DELETE from tblproject where Project_ID = @id", conn);
            cmd.Parameters.AddWithValue("@id", id_p);
            cmd.ExecuteNonQuery();
            conn.Close();

        }
        public void deleteProjectManager(int id_p)
        {
            MySqlConnection conn = new MySqlConnection(_connectionString);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("DELETE from tblprojectmanager where PM_ID = @id", conn);
            cmd.Parameters.AddWithValue("@id", id_p);
            cmd.ExecuteNonQuery();
            conn.Close();

        }
        public void deleteStudyCoördinator(int id_p)
        {
            MySqlConnection conn = new MySqlConnection(_connectionString);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("DELETE from tblstudycoördinator where SC_ID = @id", conn);
            cmd.Parameters.AddWithValue("@id", id_p);
            cmd.ExecuteNonQuery();
            conn.Close();

        }
        #endregion
    }
}
