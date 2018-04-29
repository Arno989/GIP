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
        public List<ClientCode> GetClients(string sortingPar)
		{
            List<ClientCode> ListClients = new List<ClientCode>();
			MySqlConnection conn = new MySqlConnection(_connectionString);
            MySqlCommand cmd = new MySqlCommand(string.Format("SELECT * FROM cliniresearchdb.Client {0};", sortingPar) , conn);
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

		public List<ContractCode> GetContracts(string sortingPar)
		{
            List<ContractCode> ListContracts = new List<ContractCode>();
			MySqlConnection conn = new MySqlConnection(_connectionString);
			MySqlCommand cmd = new MySqlCommand(string.Format("SELECT * FROM cliniresearchdb.Contract {0};", sortingPar), conn);
			conn.Open();
			MySqlDataReader dataReader = cmd.ExecuteReader();

			while (dataReader.Read())
			{
                int id = Convert.ToInt16(dataReader["Contract_ID"]);
                string legal_country = Convert.ToString(dataReader["Legal_Country"]);
				double fee = Convert.ToDouble(dataReader["Fee"]);
				DateTime Start_date = Convert.ToDateTime(dataReader["Start_Date"]);
				DateTime End_date = Convert.ToDateTime(dataReader["End_Date"]);

                CultureInfo.CurrentCulture = CultureInfo.CreateSpecificCulture("nl-BE");
                ContractCode c = new ContractCode(id, legal_country, fee.ToString("C", CultureInfo.CurrentCulture), Start_date.ToString("dd-MMM-yyyy"), End_date.ToString("dd-MMM-yyyy"));

				ListContracts.Add(c);
			}

            conn.Close();
            return ListContracts;
		}

		public List<CRACode> GetCRAs(string sortingPar)
		{
            List<CRACode> ListCRAs = new List<CRACode>();
			MySqlConnection conn = new MySqlConnection(_connectionString);
			MySqlCommand cmd = new MySqlCommand(string.Format("SELECT * FROM cliniresearchdb.CRA {0};", sortingPar), conn);
            conn.Open();
			MySqlDataReader dataReader = cmd.ExecuteReader();

			while (dataReader.Read())
			{
                int id = Convert.ToInt16(dataReader["CRA_ID"]);
                string name = Convert.ToString(dataReader["Name"]);
				string cv = Convert.ToString(dataReader["CV"]);
				string email = Convert.ToString(dataReader["E-mail"]);
				string phone1 = Convert.ToString(dataReader["Phone1"]);
				string phone2 = Convert.ToString(dataReader["Phone2"]);

				CRACode c = new CRACode(id,name,cv,email,phone1,phone2);

				ListCRAs.Add(c);
			}

            conn.Close();
            return ListCRAs;
		}

		public List<DepartmentCode> GetDepartments(string sortingPar)
		{
            List<DepartmentCode> ListDepartments = new List<DepartmentCode>();
			MySqlConnection conn = new MySqlConnection(_connectionString);
			MySqlCommand cmd = new MySqlCommand(string.Format("SELECT * FROM cliniresearchdb.Department {0};", sortingPar), conn);
            conn.Open();
			MySqlDataReader dataReader = cmd.ExecuteReader();

			while (dataReader.Read())
			{
                int id = Convert.ToInt16(dataReader["Department_ID"]);
                string name = Convert.ToString(dataReader["Name"]);
				string email = Convert.ToString(dataReader["E-mail"]);
				string phone1 = Convert.ToString(dataReader["Phone1"]);
                int hospitalID = Convert.ToInt16(dataReader["Hospital_ID"]);

                DepartmentCode c = new DepartmentCode(id,name,email,phone1, hospitalID);

				ListDepartments.Add(c);
			}

            conn.Close();
            return ListDepartments;
		}

		public List<DoctorCode> GetDoctors(string sortingPar)
		{
            List<DoctorCode> ListDoctors = new List<DoctorCode>();
			MySqlConnection conn = new MySqlConnection(_connectionString);
			MySqlCommand cmd = new MySqlCommand(string.Format("SELECT * FROM cliniresearchdb.Doctor {0};", sortingPar), conn);
            conn.Open();
			MySqlDataReader dataReader = cmd.ExecuteReader();

			while (dataReader.Read())
			{
                int id = Convert.ToInt16(dataReader["Doctor_ID"]);
                string name = Convert.ToString(dataReader["Name"]);
				string email = Convert.ToString(dataReader["E-mail"]);
				string phone1 = Convert.ToString(dataReader["Phone1"]);
				string phone2 = Convert.ToString(dataReader["Phone2"]);
				string adress = Convert.ToString(dataReader["Adress"]);
				string postal_code = Convert.ToString(dataReader["Postal_Code"]);
				string city = Convert.ToString(dataReader["City"]);
				string country = Convert.ToString(dataReader["Country"]);
				string specialisation = Convert.ToString(dataReader["Specialisation"]);
				string cv = Convert.ToString(dataReader["CV"]);

				DoctorCode c = new DoctorCode(id,name,email,phone1,phone2,adress,postal_code,city,country,specialisation,cv);

				ListDoctors.Add(c);
			}

            conn.Close();
            return ListDoctors;
		}

		public List<EvaluationCode> GetEvaluations(string sortingPar)
		{
            List<EvaluationCode> ListEvaluations = new List<EvaluationCode>();
			MySqlConnection conn = new MySqlConnection(_connectionString);
			MySqlCommand cmd = new MySqlCommand(string.Format("SELECT * FROM cliniresearchdb.Evaluation {0};", sortingPar), conn);
            conn.Open();
			MySqlDataReader dataReader = cmd.ExecuteReader();

			while (dataReader.Read())
			{
                int id = Convert.ToInt16(dataReader["Evaluation_ID"]);
                DateTime date = Convert.ToDateTime(dataReader["Date"]);
				string feedback = Convert.ToString(dataReader["Feedback"]);
				string accuracy = Convert.ToString(dataReader["Accuracy"]);
				string quality = Convert.ToString(dataReader["Quality"]);
				string evalauation_txt = Convert.ToString(dataReader["Evaluation_Text"]);
				string label = Convert.ToString(dataReader["Label"]);

				EvaluationCode c = new EvaluationCode(id,date.ToString("dd-MMM-yyyy"),feedback,accuracy,quality,evalauation_txt,label);

				ListEvaluations.Add(c);
			}

            conn.Close();
            return ListEvaluations;
		}

		public List<HospitalCode> GetHospitals(string sortingPar)
		{
            List<HospitalCode> ListHospitals = new List<HospitalCode>();
			MySqlConnection conn = new MySqlConnection(_connectionString);
			MySqlCommand cmd = new MySqlCommand(string.Format("SELECT * FROM cliniresearchdb.Hospital {0};", sortingPar), conn);
            conn.Open();
			MySqlDataReader dataReader = cmd.ExecuteReader();

			while (dataReader.Read())
			{
                int id = Convert.ToInt16(dataReader["Hospital_ID"]);
                string name = Convert.ToString(dataReader["Name"]);
				string adress = Convert.ToString(dataReader["Adress"]);
				string postal_code = Convert.ToString(dataReader["Postal_Code"]);
				string city = Convert.ToString(dataReader["City"]);
				string country = Convert.ToString(dataReader["Country"]);
				string central_number = Convert.ToString(dataReader["Central_Number"]);

				HospitalCode c = new HospitalCode(id,name,adress,postal_code,city,country,central_number);

				ListHospitals.Add(c);
			}
            
            conn.Close();
            return ListHospitals;
		}

		public List<ProjectCode> GetProjects(string sortingPar)
		{
            List<ProjectCode> ListProjects = new List<ProjectCode>();
			MySqlConnection conn = new MySqlConnection(_connectionString);
			MySqlCommand cmd = new MySqlCommand(string.Format("SELECT * FROM cliniresearchdb.Project {0};", sortingPar), conn);
            conn.Open();
			MySqlDataReader dataReader = cmd.ExecuteReader();

			while (dataReader.Read())
			{
                int id = Convert.ToInt16(dataReader["Project_ID"]);
                string title = Convert.ToString(dataReader["Title"]);
				DateTime start_date = Convert.ToDateTime(dataReader["Start_Date"]).Date;
				DateTime end_date = Convert.ToDateTime(dataReader["End_Date"]).Date;

				ProjectCode c = new ProjectCode(id,title,start_date.ToString("dd-MMM-yyyy"), end_date.ToString("dd-MMM-yyyy"));

				ListProjects.Add(c);
			}

            conn.Close();
            return ListProjects;
		}

		public List<ProjectManagerCode> GetProjectManagers(string sortingPar)
		{
            List<ProjectManagerCode> ListProjectManagers = new List<ProjectManagerCode>();
			MySqlConnection conn = new MySqlConnection(_connectionString);
			MySqlCommand cmd = new MySqlCommand(string.Format("SELECT * FROM cliniresearchdb.ProjectManager {0};", sortingPar), conn);
            conn.Open();
			MySqlDataReader dataReader = cmd.ExecuteReader();

			while (dataReader.Read())
			{
                int id = Convert.ToInt16(dataReader["PM_ID"]);
                string name = Convert.ToString(dataReader["Name"]);
				string cv = Convert.ToString(dataReader["CV"]);
				string email = Convert.ToString(dataReader["E-mail"]);
				string phone1 = Convert.ToString(dataReader["Phone1"]);
				string phone2 = Convert.ToString(dataReader["Phone2"]);

				ProjectManagerCode c = new ProjectManagerCode(id,name,cv,email,phone1,phone2);

				ListProjectManagers.Add(c);
			}

            conn.Close();
            return ListProjectManagers;
		}

		public List<StudyCoordinatorCode> GetStudyCoordinators(string sortingPar)
		{
            List<StudyCoordinatorCode> ListStudyCoordinators = new List<StudyCoordinatorCode>();
			MySqlConnection conn = new MySqlConnection(_connectionString);
			MySqlCommand cmd = new MySqlCommand(string.Format("SELECT * FROM cliniresearchdb.StudyCoordinator {0};", sortingPar), conn);
            conn.Open();
			MySqlDataReader dataReader = cmd.ExecuteReader();

			while (dataReader.Read())
			{
                int id = Convert.ToInt16(dataReader["SC_ID"]);
                string name = Convert.ToString(dataReader["Name"]);
				string cv = Convert.ToString(dataReader["CV"]);
				string email = Convert.ToString(dataReader["E-mail"]);
				string phone1 = Convert.ToString(dataReader["Phone1"]);
				string phone2 = Convert.ToString(dataReader["Phone2"]);
				string specialisation = Convert.ToString(dataReader["Specialisation"]);

				StudyCoordinatorCode c = new StudyCoordinatorCode(id,name,cv,email,phone1,phone2,specialisation);

				ListStudyCoordinators.Add(c);
			}

            conn.Close();
			return ListStudyCoordinators;
		}
        #endregion
        
        #region GetRelation
        public List<int> GetRelationDoctorHasHospital(int Doctor_ID_p)
        {
            List<int> ListAllRelations = new List<int>();
            MySqlConnection conn = new MySqlConnection(_connectionString);
            MySqlCommand cmd = new MySqlCommand("SELECT Hospital_ID FROM Doctor_has_Hospital WHERE Doctor_ID = @id", conn);
            cmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = Doctor_ID_p;
            conn.Open();
            MySqlDataReader dataReader = cmd.ExecuteReader();

            while (dataReader.Read())
            {
                int id = Convert.ToInt16(dataReader["Hospital_ID"]);
                ListAllRelations.Add(id);
            }

            conn.Close();
            return ListAllRelations;
        }

        public List<int> GetRelationStudyCoordinatorHasDoctor(int StudyCoordinator_ID_p)
        {
            List<int> ListAllRelations = new List<int>();
            MySqlConnection conn = new MySqlConnection(_connectionString);
            MySqlCommand cmd = new MySqlCommand("SELECT Doctor_ID FROM StudyCoordinator_has_Doctor WHERE StudyCoordinator_ID = @id", conn);
            cmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = StudyCoordinator_ID_p;
            conn.Open();
            MySqlDataReader dataReader = cmd.ExecuteReader();

            while (dataReader.Read())
            {
                int id = Convert.ToInt16(dataReader["Doctor_ID"]);
                ListAllRelations.Add(id);
            }

            conn.Close();
            return ListAllRelations;
        }

        //--------------------------------------------------------------------------------------------------------1 op 1

        public int GetRelationHospitalHasDepartment(int Department_ID_p)
        {
            int Relation = 0;
            MySqlConnection conn = new MySqlConnection(_connectionString);
            MySqlCommand cmd = new MySqlCommand("SELECT Hospital_ID FROM Department WHERE Department_ID = @id", conn);
            cmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = Department_ID_p;
            conn.Open();
            MySqlDataReader dataReader = cmd.ExecuteReader();

            while (dataReader.Read())
            {
                int id = Convert.ToInt16(dataReader["Hospital_ID"]);
                Relation = id;
            }

            conn.Close();
            return Relation;
        }
        #endregion

        #region GetDropDownContent
        public List<List<string>> GetClientDropDown()
        {
            List<List<string>> ListCount = new List<List<string>>();
            List<string> ListDropdown = new List<string>();
            MySqlConnection conn = new MySqlConnection(_connectionString);
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM Client ORDER BY Name ASC", conn);
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

        public List<List<string>> GetCRADropDown()
        {
            List<List<string>> ListCount = new List<List<string>>();
            List<string> ListDropdown = new List<string>();
            MySqlConnection conn = new MySqlConnection(_connectionString);
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM CRA ORDER BY Name ASC", conn);
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

        public List<List<string>> GetDoctorDropDown()
        {
            List<List<string>> ListCount = new List<List<string>>();
            List<string> ListDropdown = new List<string>();
            MySqlConnection conn = new MySqlConnection(_connectionString);
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM Doctor ORDER BY Name ASC", conn);
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

        public List<List<string>> GetHospitalDropDown()
        {
            List<List<string>> ListCount = new List<List<string>>();
            int count = 0;
            MySqlConnection conn = new MySqlConnection(_connectionString);
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM Hospital ORDER BY Name ASC", conn);
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

        public List<List<string>> GetProjectDropDown()
        {
            List<List<string>> ListCount = new List<List<string>>();
            List<string> ListDropdown = new List<string>();
            MySqlConnection conn = new MySqlConnection(_connectionString);
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM Project ORDER BY Title ASC", conn);
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

        public List<List<string>> GetProjectManagerDropDown()
        {
            List<List<string>> ListCount = new List<List<string>>();
            List<string> ListDropdown = new List<string>();
            MySqlConnection conn = new MySqlConnection(_connectionString);
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM ProjectManager ORDER BY Name ASC", conn);
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

        public List<List<string>> GetStudyCoordinatorDropDown()
        {
            List<List<string>> ListCount = new List<List<string>>();
            List<string> ListDropdown = new List<string>();
            MySqlConnection conn = new MySqlConnection(_connectionString);
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM StudyCoordiantor ORDER BY Name ASC", conn);
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


        #region Set
        public void AddClient(string name_p,string adress_p,string postalcode_p,string city_p,string country_p,string contactperson_p,string invoiceinfo_p,string kindofclinet_p)
		{
			MySqlConnection conn = new MySqlConnection(_connectionString);

			conn.Open();

			MySqlCommand cmd = new MySqlCommand("INSERT INTO Client (Name, Adress, Postal_Code, City, Country, Contact_Person, Invoice_Info, Kind_of_Client) VALUES (@name, @adress, @postal_code, @city, @country, @contact_person, @invoice_info, @kind_of_client);",conn);

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

		public void AddContract(string legalcountry_p,double fee_p,DateTime startdate_p,DateTime enddate_p)
		{
			MySqlConnection conn = new MySqlConnection(_connectionString);

			conn.Open();

			MySqlCommand cmd = new MySqlCommand("INSERT INTO Contract (Legal_Country, Fee, Start_Date, End_Date) VALUES (@legal_country, @fee, @start_date, @end_date);", conn);

			cmd.Parameters.Add("@legal_country",MySqlDbType.VarChar).Value = legalcountry_p;
			cmd.Parameters.Add("@fee",MySqlDbType.Double).Value = fee_p;
			cmd.Parameters.Add("@start_date",MySqlDbType.DateTime).Value = startdate_p.Date;
			cmd.Parameters.Add("@end_date",MySqlDbType.DateTime).Value = enddate_p.Date;
			cmd.ExecuteNonQuery();

			conn.Close();
		}

		public void AddCRA(string name_p,string cv_p,string email_p,string phone1_p,string phone2_p)
		{
			MySqlConnection conn = new MySqlConnection(_connectionString);

			conn.Open();

			MySqlCommand cmd = new MySqlCommand("INSERT INTO CRA (Name, CV, E-mail, Phone1, Phone2) VALUES (@name, @cv, @email, @phone1, @phone2);",conn);

			cmd.Parameters.Add("@name",MySqlDbType.VarChar).Value = name_p;
			cmd.Parameters.Add("@cv",MySqlDbType.VarChar).Value = cv_p;
			cmd.Parameters.Add("@email",MySqlDbType.VarChar).Value = email_p;
			cmd.Parameters.Add("@phone1",MySqlDbType.VarChar).Value = phone1_p;
			cmd.Parameters.Add("@phone2",MySqlDbType.VarChar).Value = phone2_p;
			cmd.ExecuteNonQuery();

			conn.Close();
		}

		public void AddDepartment(string name_p,string email_p,string phone1_p, int hospital_id_p)
		{
			MySqlConnection conn = new MySqlConnection(_connectionString);

			conn.Open();

			MySqlCommand cmd = new MySqlCommand("INSERT INTO Department (Name, E-mail, Phone1, Hospital_ID) VALUES (@name, @email, @phone1, @hospital_id);", conn);

			cmd.Parameters.Add("@name",MySqlDbType.VarChar).Value = name_p;
			cmd.Parameters.Add("@email",MySqlDbType.VarChar).Value = email_p;
			cmd.Parameters.Add("@phone1",MySqlDbType.VarChar).Value = phone1_p;
            cmd.Parameters.Add("@hospital_id", MySqlDbType.VarChar).Value = hospital_id_p;
            cmd.ExecuteNonQuery();

			conn.Close();
		}

		public void AddDoctor(string name_p,string email_p,string phone1_p,string phone2_p,string adress_p,string postalcode_p,string city_p,string country_p,string specialisation_p,string cv_p)
		{
			MySqlConnection conn = new MySqlConnection(_connectionString);

			conn.Open();

			MySqlCommand cmd = new MySqlCommand("INSERT INTO Doctor (Name, E-mail, Phone1, Phone2, Adress, Postal_Code, City, Country, Specialisation, CV) VALUES (@name, @email, @phone1, @phone2, @adress, @postal_code, @city, @country, @specialisation, @cv);", conn);

			cmd.Parameters.Add("@name",MySqlDbType.VarChar).Value = name_p;
			cmd.Parameters.Add("@email",MySqlDbType.VarChar).Value = email_p;
			cmd.Parameters.Add("@phone1",MySqlDbType.VarChar).Value = phone1_p;
			cmd.Parameters.Add("@phone2",MySqlDbType.VarChar).Value = phone2_p;
			cmd.Parameters.Add("@adress",MySqlDbType.VarChar).Value = adress_p;
			cmd.Parameters.Add("@postal_code",MySqlDbType.VarChar).Value = postalcode_p;
			cmd.Parameters.Add("@city",MySqlDbType.VarChar).Value = city_p;
			cmd.Parameters.Add("@country",MySqlDbType.VarChar).Value = country_p;
			cmd.Parameters.Add("@specialisation",MySqlDbType.VarChar).Value = specialisation_p;
			cmd.Parameters.Add("@cv",MySqlDbType.VarChar).Value = cv_p;
			cmd.ExecuteNonQuery();

			conn.Close();
		}

		public void AddEvaluation(DateTime date_p,string feedback_p,string accuracy_p,string quality_p,string evaluationtxt_p,string label_p)
		{
			MySqlConnection conn = new MySqlConnection(_connectionString);

			conn.Open();

			MySqlCommand cmd = new MySqlCommand("INSERT INTO Evaluation (Date, Feedback, Accuracy, Quality, Evaluation_Text, Label) VALUES (@date, @feedback, @accuracy, @quality, @evaluation_txt, @label);",conn);

			cmd.Parameters.Add("@date",MySqlDbType.Date).Value = date_p;
			cmd.Parameters.Add("@feedback",MySqlDbType.VarChar).Value = feedback_p;
			cmd.Parameters.Add("@accuracy",MySqlDbType.VarChar).Value = accuracy_p;
			cmd.Parameters.Add("@quality",MySqlDbType.VarChar).Value = quality_p;
			cmd.Parameters.Add("@evaluation_txt",MySqlDbType.VarChar).Value = evaluationtxt_p;
			cmd.Parameters.Add("@label",MySqlDbType.VarChar).Value = label_p;

			cmd.ExecuteNonQuery();

			conn.Close();
		}

		public void AddHospital(string name_p,string adress_p,string postalcode_p,string city_p,string country_p,string centralnumber_p)
		{
			MySqlConnection conn = new MySqlConnection(_connectionString);

			conn.Open();

			MySqlCommand cmd = new MySqlCommand("INSERT INTO Hospital (Name, Adress, Postal_Code, City, Country, Central_Number) VALUES (@name, @adress, @postal_code, @city, @country, @central_number);",conn);

			cmd.Parameters.Add("@name",MySqlDbType.VarChar).Value = name_p;
			cmd.Parameters.Add("@adress",MySqlDbType.VarChar).Value = adress_p;
			cmd.Parameters.Add("@postal_code",MySqlDbType.VarChar).Value = postalcode_p;
			cmd.Parameters.Add("@city",MySqlDbType.VarChar).Value = city_p;
			cmd.Parameters.Add("@country",MySqlDbType.VarChar).Value = country_p;
			cmd.Parameters.Add("@central_number",MySqlDbType.VarChar).Value = centralnumber_p;
			cmd.ExecuteNonQuery();

			conn.Close();
		}

		public void AddProject(string title_p,DateTime startdate_p, DateTime enddate_p)
		{
			MySqlConnection conn = new MySqlConnection(_connectionString);

			conn.Open();

			MySqlCommand cmd = new MySqlCommand("INSERT INTO Project (Title, Start_Date, End_Date) VALUES (@title, @start_date, @end_date);",conn);

			cmd.Parameters.Add("@title",MySqlDbType.VarChar).Value = title_p;
			cmd.Parameters.Add("@start_date",MySqlDbType.Date).Value = startdate_p.Date;
			cmd.Parameters.Add("@end_date",MySqlDbType.Date).Value = enddate_p.Date;
			cmd.ExecuteNonQuery();

			conn.Close();
		}

		public void AddProjectManager(string name_p,string cv_p,string email_p,string phone1_p,string phone2_p)
		{
			MySqlConnection conn = new MySqlConnection(_connectionString);

			conn.Open();

			MySqlCommand cmd = new MySqlCommand("INSERT INTO ProjectManager (Name, CV, E-mail, Phone1, Phone2) VALUES (@name, @cv, @email, @phone1, @phone2);",conn);

			cmd.Parameters.Add("@name",MySqlDbType.VarChar).Value = name_p;
			cmd.Parameters.Add("@cv",MySqlDbType.VarChar).Value = cv_p;
			cmd.Parameters.Add("@email",MySqlDbType.VarChar).Value = email_p;
			cmd.Parameters.Add("@phone1",MySqlDbType.VarChar).Value = phone1_p;
			cmd.Parameters.Add("@phone2",MySqlDbType.VarChar).Value = phone2_p;
			cmd.ExecuteNonQuery();

			conn.Close();
		}

		public void AddStudyCoordinator(string name_p,string cv_p,string email_p,string phone1_p,string phone2_p,string specialisation_p)
		{
			MySqlConnection conn = new MySqlConnection(_connectionString);

			conn.Open();

			MySqlCommand cmd = new MySqlCommand("INSERT INTO StudyCoordinator(Name, CV, E-mail, Phone1, Phone2, Specialisation) VALUES (@name, @cv, @email, @phone1, @phone2, @specialisation);",conn);

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
        public void AddHospitalToDoctor(int hospital_id_p, int doctor_id_p)
        {
            MySqlConnection conn = new MySqlConnection(_connectionString);

            conn.Open();

            MySqlCommand cmd = new MySqlCommand("INSERT INTO Doctor_has_Hospital (Hospital_ID, Doctor_ID) VALUES (@hospital_id, @doctor_id);", conn);

            cmd.Parameters.Add("@hospital_id", MySqlDbType.VarChar).Value = hospital_id_p;
            cmd.Parameters.Add("@doctor_id", MySqlDbType.VarChar).Value = doctor_id_p;
            cmd.ExecuteNonQuery();

            conn.Close();
        }
        #endregion



        #region Update
        public void UpdateClient(int id_p, string name_p, string adress_p, string postalcode_p, string city_p, string country_p, string contactperson_p, string invoiceinfo_p, string kindofclinet_p)
        {
            MySqlConnection conn = new MySqlConnection(_connectionString);

            conn.Open();

            MySqlCommand cmd = new MySqlCommand("UPDATE Client SET Name = @name, Adress = @adress, Postal_Code = @postal_code, City = @city, Country = @country, Contact_Person = @contact_person, Invoice_Info = @invoice_info, Kind_of_Client = @kind_of_client WHERE Client_ID = @id;", conn);

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

            MySqlCommand cmd = new MySqlCommand("UPDATE Contract SET Legal_Country = @legal_country, Fee = @fee, Duration = @duration, Date = @date WHERE Contract_ID = @id;", conn);

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

            MySqlCommand cmd = new MySqlCommand("UPDATE CRA SET Name = @name, CV = @cv, E_mail = @email, Phone1 = @phone1, Phone2 = @phone2 WHERE CRA_ID = @id;", conn);

            cmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = id_p;
            cmd.Parameters.Add("@name", MySqlDbType.VarChar).Value = name_p;
            cmd.Parameters.Add("@cv", MySqlDbType.VarChar).Value = cv_p;
            cmd.Parameters.Add("@email", MySqlDbType.VarChar).Value = email_p;
            cmd.Parameters.Add("@phone1", MySqlDbType.VarChar).Value = phone1_p;
            cmd.Parameters.Add("@phone2", MySqlDbType.VarChar).Value = phone2_p;
            cmd.ExecuteNonQuery();

            conn.Close();
        }

        public void UpdateDepartment(int id_p, string name_p, string email_p, string phone1_p, int hospitalID_p)
        {
            MySqlConnection conn = new MySqlConnection(_connectionString);

            conn.Open();

            MySqlCommand cmd = new MySqlCommand("UPDATE Department SET Name = @name, E-mail = @email, Phone1 = @phone1, tblHospital_Hospital_ID = @hospital_id WHERE Department_ID = @department_id;", conn);

            cmd.Parameters.Add("@name", MySqlDbType.VarChar).Value = name_p;
            cmd.Parameters.Add("@email", MySqlDbType.VarChar).Value = email_p;
            cmd.Parameters.Add("@phone1", MySqlDbType.VarChar).Value = phone1_p;
            cmd.Parameters.Add("@Hospital_id", MySqlDbType.VarChar).Value = hospitalID_p;
            cmd.Parameters.Add("@department_id", MySqlDbType.VarChar).Value = id_p;
            cmd.ExecuteNonQuery();

            conn.Close();
        }

        public void UpdateDoctor(int id_p, string name_p, string email_p, string phone1_p, string phone2_p, string adress_p, string postalcode_p, string city_p, string country_p, string specialisation_p, string cv_p)
        {
            MySqlConnection conn = new MySqlConnection(_connectionString);

            conn.Open();

            MySqlCommand cmd = new MySqlCommand("UPDATE Doctor SET Name = @name, E-mail = @email, Phone1 = @phone1, Phone2 = @phone2, Adress = @adress, Postal_Code = @postal_code, City = @city, Country = @country, Specialisation = @specialisation, CV = @cv WHERE Doctor_ID = @id;", conn);

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
            cmd.Parameters.Add("@cv", MySqlDbType.VarChar).Value = cv_p;
            cmd.ExecuteNonQuery();

            conn.Close();
        }

        public void UpdateEvaluation(int id_p, DateTime date_p, string feedback_p, string accuracy_p, string quality_p, string evaluationtxt_p, string label_p)
        {
            MySqlConnection conn = new MySqlConnection(_connectionString);

            conn.Open();

            MySqlCommand cmd = new MySqlCommand("UPDATE Evaluation SET Date = @date, Feedback = @feedback, Accuracy = @accuracy, Quality = @quality, Evaluation_Text = @ evaluation_txt, Label = @label WHERE Evaluation_ID = @id;", conn);

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

            MySqlCommand cmd = new MySqlCommand("UPDATE Hospital SET Name = @name, Adress = @adress, Postal_Code = @postal_code, City = @city, Country = @country, Central_Number = @central_number WHERE Hospital_ID = @id;", conn);

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

            MySqlCommand cmd = new MySqlCommand("UPDATE Project SET Title = @title, Start_Date = @start_date, End_Date = @end_date WHERE Project_ID = @id;", conn);

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

            MySqlCommand cmd = new MySqlCommand("UPDATE ProjectManager SET Name = @name, CV = @cv, E-mail = @email, Phone1 = @phone1, Phone2 = @phone2 WHERE PM_ID = @id;", conn);

            cmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = id_p;
            cmd.Parameters.Add("@name", MySqlDbType.VarChar).Value = name_p;
            cmd.Parameters.Add("@cv", MySqlDbType.VarChar).Value = cv_p;
            cmd.Parameters.Add("@email", MySqlDbType.VarChar).Value = email_p;
            cmd.Parameters.Add("@phone1", MySqlDbType.VarChar).Value = phone1_p;
            cmd.Parameters.Add("@phone2", MySqlDbType.VarChar).Value = phone2_p;
            cmd.ExecuteNonQuery();

            conn.Close();
        }

        public void UpdateStudyCoordinator(int id_p, string name_p, string cv_p, string email_p, string phone1_p, string phone2_p, string specialisation_p)
        {
            MySqlConnection conn = new MySqlConnection(_connectionString);

            conn.Open();

            MySqlCommand cmd = new MySqlCommand("UPDATE StudyCoördinator SET Name = @name, CV = @cv, E-mail = @email, Phone1 = @phone1, Phone2 = @phone2, Specialisation = @specialisation WHERE SC_ID = @id;", conn);
            
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
        //--------------------------------------------------
        #endregion
        


        #region Delete
        public void DeleteClient(int id_p)
        {
            MySqlConnection conn = new MySqlConnection(_connectionString);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("DELETE from Client where Client_ID = @id", conn);
            cmd.Parameters.AddWithValue("@id", id_p);
            cmd.ExecuteNonQuery();
            conn.Close();

        }

        public void DeleteContract(int id_p)
        {
            MySqlConnection conn = new MySqlConnection(_connectionString);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("DELETE from Contract where Contract_ID = @id", conn);
            cmd.Parameters.AddWithValue("@id", id_p);
            cmd.ExecuteNonQuery();
            conn.Close();

        }

        public void DeleteCRA(int id_p)
        {
            MySqlConnection conn = new MySqlConnection(_connectionString);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("DELETE from CRA where CRA_ID = @id", conn);
            cmd.Parameters.AddWithValue("@id", id_p);
            cmd.ExecuteNonQuery();
            conn.Close();

        }

        public void DeleteDepartment(int id_p)
        {
            MySqlConnection conn = new MySqlConnection(_connectionString);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("DELETE from Department where Department_ID = @id", conn);
            cmd.Parameters.AddWithValue("@id", id_p);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void DeleteDoctor(int id_p)
        {
            MySqlConnection conn = new MySqlConnection(_connectionString);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("DELETE from Doctor where Doctor_ID = @id", conn);
            cmd.Parameters.AddWithValue("@id", id_p);
            cmd.ExecuteNonQuery();
            conn.Close();

        }

        public void DeleteEvaluation(int id_p)
        {
            MySqlConnection conn = new MySqlConnection(_connectionString);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("DELETE from Evaluation where Evaluation_ID = @id", conn);
            cmd.Parameters.AddWithValue("@id", id_p);
            cmd.ExecuteNonQuery();
            conn.Close();

        }

        public void DeleteHospital(int id_p)
        {
            MySqlConnection conn = new MySqlConnection(_connectionString);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("DELETE from Hospital where Hospital_ID = @id", conn);
            cmd.Parameters.AddWithValue("@id", id_p);
            cmd.ExecuteNonQuery();
            conn.Close();

        }

        public void DeleteProject(int id_p)
        {
            MySqlConnection conn = new MySqlConnection(_connectionString);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("DELETE from Project where Project_ID = @id", conn);
            cmd.Parameters.AddWithValue("@id", id_p);
            cmd.ExecuteNonQuery();
            conn.Close();

        }

        public void DeleteProjectManager(int id_p)
        {
            MySqlConnection conn = new MySqlConnection(_connectionString);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("DELETE from ProjectManager where PM_ID = @id", conn);
            cmd.Parameters.AddWithValue("@id", id_p);
            cmd.ExecuteNonQuery();
            conn.Close();

        }

        public void DeleteStudyCoordinator(int id_p)
        {
            MySqlConnection conn = new MySqlConnection(_connectionString);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("DELETE from StudyCoordinator where SC_ID = @id", conn);
            cmd.Parameters.AddWithValue("@id", id_p);
            cmd.ExecuteNonQuery();
            conn.Close();

        }
        #endregion

        #region DeleteRelation
        public void DeleteRelationDoctorHasHospitals(int doctor_id_p)
        {
            MySqlConnection conn = new MySqlConnection(_connectionString);

            conn.Open();

            MySqlCommand cmd = new MySqlCommand("DELETE FROM Doctor_has_Hospital WHERE Doctor_ID = @doctor_id ;", conn);

            cmd.Parameters.Add("@doctor_id", MySqlDbType.VarChar).Value = doctor_id_p;
            cmd.ExecuteNonQuery();

            conn.Close();
        }
        #endregion
    }
}
