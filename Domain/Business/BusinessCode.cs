using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.UI;
using Domain.Persistence;
using PhoneNumbers;

namespace Domain.Business
{
	public class BusinessCode
	{
		private PersistenceCode _persistence;

        public BusinessCode()
		{
			_persistence = new PersistenceCode();
		}
        
        #region Get
        public List<ClientCode> GetClients(string sortingPar)
		{
            return _persistence.GetClients(sortingPar);
        }
        public List<ContractCode> GetContracts(string sortingPar)
        {
            return _persistence.GetContracts(sortingPar);
        }
        public List<CRACode> GetCRAs(string sortingPar)
        {
            return _persistence.GetCRAs(sortingPar);
        }
        public List<DepartmentCode> GetDepartments(string sortingPar)
        {
            return _persistence.GetDepartments(sortingPar);
        }
        public List<DoctorCode> GetDoctors(string sortingPar)
        {
            return _persistence.GetDoctors(sortingPar);
        }
        public List<EvaluationCode> GetEvaluations(string sortingPar)
        {
            return _persistence.GetEvaluations(sortingPar);
        }
        public List<HospitalCode> GetHospitals(string sortingPar)
        {
            return _persistence.GetHospitals(sortingPar);
        }
        public List<ProjectCode> GetProjects(string sortingPar)
        {
            return _persistence.GetProjects(sortingPar);
        }
        public List<ProjectManagerCode> GetProjectManagers(string sortingPar)
        {
            return _persistence.GetProjectManagers(sortingPar);
        }
        public List<StudyCoordinatorCode> GetStudyCoordinators(string sortingPar)
        {
            return _persistence.GetStudyCoordinators(sortingPar);
        }
        public List<UserCode> GetUsers(string sortingPar)
        {
            return _persistence.GetUsers(sortingPar);
        }
        #endregion

        #region GetRelation

        #region Doctor + Hospital
        public List<int> GetRelationDoctorHasHospitals(int Doctor_ID_p2)
        {
            return _persistence.GetRelationDoctorHasHospitals(Doctor_ID_p2);
        }

        public List<int> GetRelationHospitalHasDoctors(int Hospital_ID_p2)
        {
            return _persistence.GetRelationDoctorHasHospitals(Hospital_ID_p2);
        }
        #endregion

        #region StudyCoordinator + Doctor
        public List<int> GetRelationStudyCoordinatorHasDoctors(int StudyCoordinator_ID_p2)
        {
            return _persistence.GetRelationStudyCoordinatorHasDoctors(StudyCoordinator_ID_p2);
        }

        public List<int> GetRelationDoctorHasStudyCoordinators(int Doctor_ID_p2)
        {
            return _persistence.GetRelationDoctorHasStudyCoordinators(Doctor_ID_p2);
        }
        #endregion

        #region Project + CRA
        public List<int> GetRelationProjectHasCRAs(int StudyCoordinator_ID_p2)
        {
            return _persistence.GetRelationProjectHasCRAs(StudyCoordinator_ID_p2);
        }

        public List<int> GetRelationCRAHasProjects(int Doctor_ID_p2)
        {
            return _persistence.GetRelationCRAHasProjects(Doctor_ID_p2);
        }
        #endregion

        #region Project + Doctor
        public List<int> GetRelationProjectHasDoctors(int StudyCoordinator_ID_p2)
        {
            return _persistence.GetRelationProjectHasDoctors(StudyCoordinator_ID_p2);
        }

        public List<int> GetRelationDoctorHasProjects(int Doctor_ID_p2)
        {
            return _persistence.GetRelationDoctorHasProjects(Doctor_ID_p2);
        }
        #endregion

        #region Project + Hospital
        public List<int> GetRelationProjectHasHospitals(int StudyCoordinator_ID_p2)
        {
            return _persistence.GetRelationProjectHasHospitals(StudyCoordinator_ID_p2);
        }

        public List<int> GetRelationHospitalHasProjects(int Doctor_ID_p2)
        {
            return _persistence.GetRelationHospitalHasProjects(Doctor_ID_p2);
        }
        #endregion

        #region Project + Project Manager
        public List<int> GetRelationProjectHasProjectManagers(int StudyCoordinator_ID_p2)
        {
            return _persistence.GetRelationProjectHasProjectManagers(StudyCoordinator_ID_p2);
        }

        public List<int> GetRelationProjectManagerHasProjects(int Doctor_ID_p2)
        {
            return _persistence.GetRelationProjectManagerHasProjects(Doctor_ID_p2);
        }
        #endregion
        //------------------------------------------------------------------------------ 1 op 1

        public int GetRelationHospitalHasDepartment(int Department_ID_p2)
        {
            return _persistence.GetRelationHospitalHasDepartment(Department_ID_p2);
        }
        #endregion

        #region GetDropDownContent
        public List<List<string>> GetClientDropDownContent()
        {
            return _persistence.GetClientDropDown();
        }
        public List<List<string>> GetCRADropDownContent()
        {
            return _persistence.GetCRADropDown();
        }
        public List<List<string>> GetContractDropDown()
        {
            return _persistence.GetContractDropDown();
        }
        public List<List<string>> GetDoctorDropDownContent()
        {
            return _persistence.GetDoctorDropDown();
        }
        public List<List<string>> GetHospitalDropDownContent()
        {
            return _persistence.GetHospitalDropDown();
        }
        public List<List<string>> GetProjectDropDownContent()
        {
            return _persistence.GetProjectDropDown();
        }
        public List<List<string>> GetProjectManagerDropDownContent()
        {
            return _persistence.GetProjectManagerDropDown();
        }
        public List<List<string>> GetStudyCoordinatorDropDownContent()
        {
            return _persistence.GetStudyCoordinatorDropDown();
        }
        #endregion
        
        #region Set
        public void SetClient(string name_p2, string adress_p2, string postalcode_p2, string city_p2, string country_p2, string contactperson_p2, string invoiceinfo_p2, string kindofclinet_p2)
        {
            _persistence.AddClient(name_p2, adress_p2, postalcode_p2, city_p2, country_p2, contactperson_p2, invoiceinfo_p2, kindofclinet_p2);
        }
        public void SetContract(string legalcountry_p2, double fee_p2, DateTime startdate_p2, DateTime enddate_p2, int client_id_p2, int project_id_p2)
        {
            _persistence.AddContract(legalcountry_p2, fee_p2, startdate_p2, enddate_p2, client_id_p2, project_id_p2);
        }
        public void SetCRA(string name_p2, string cv_p2, string email_p2, string phone1_p2, string phone2_p2)
        {
            _persistence.AddCRA(name_p2, cv_p2, email_p2, phone1_p2, phone2_p2);
        }
        public void SetDepartment(string name_p2, string email_p2, string phone1_p2, int hospital_id_p2)
        {
            _persistence.AddDepartment(name_p2, email_p2, phone1_p2, hospital_id_p2);
        }
        public void SetDoctor(string name_p2, string email_p2, string phone1_p2, string phone2_p2, string adress_p2, string postalcode_p2, string city_p2, string country_p2, string specialisation_p2, string cv_p2)
        {
            _persistence.AddDoctor(name_p2, email_p2, phone1_p2, phone2_p2, adress_p2, postalcode_p2, city_p2, country_p2, specialisation_p2, cv_p2);
        }
        public void SetEvaluation(DateTime date_p2, string feedback_p2, string accuracy_p2, string quality_p2, string evaluationtxt_p2, string label_p2, int cra_p2, int doctor_p2, int sc_p2)
        {
            _persistence.AddEvaluation(date_p2, feedback_p2, accuracy_p2, quality_p2, evaluationtxt_p2, label_p2, cra_p2, doctor_p2, sc_p2);
        }
        public void SetHospital(string name_p2, string adress_p2, string postalcode_p2, string city_p2, string country_p2, string centralnumber_p2)
        {
            _persistence.AddHospital(name_p2, adress_p2, postalcode_p2, city_p2, country_p2, centralnumber_p2);
        }
        public void SetProject(string title_p2, DateTime startdate_p2, DateTime enddate_p2)
        {
            _persistence.AddProject(title_p2, startdate_p2, enddate_p2);
        }
        public void SetProjectManager(string name_p2, string cv_p2, string email_p2, string phone1_p2, string phone2_p2)
        {
            _persistence.AddProjectManager(name_p2, cv_p2, email_p2, phone1_p2, phone2_p2);
        }
        public void SetStudyCoordinator(string name_p2, string cv_p2, string email_p2, string phone1_p2, string phone2_p2, string specialisation_p2)
        {
            _persistence.AddStudyCoordinator(name_p2, cv_p2, email_p2, phone1_p2, phone2_p2, specialisation_p2);
        }
        public void SetUser(string username_p2,string email_p2,string password_p2)
        {
            _persistence.AddUser(username_p2,email_p2,password_p2);
        }
        #endregion

        #region SetRelation
        public void AddHospitalToDoctor(int hospital_id_p2, int doctor_id_p2)
        {
            _persistence.AddHospitalToDoctor(hospital_id_p2, doctor_id_p2);
        }
        
        public void AddDoctorToStudyCoordinator(int doctor_id_p2, int studycoordinator_id_p2)
        {
            _persistence.AddDoctorToStudyCoordinator(doctor_id_p2, studycoordinator_id_p2);
        }

        public void AddCRAToProject(int cra_id_p, int project_id_p)
        {
            _persistence.AddCRAToProject(cra_id_p, project_id_p);
        }

        public void AddDoctorToProject(int doctor_id_p, int project_id_p)
        {
            _persistence.AddDoctorToProject(doctor_id_p, project_id_p);
        }

        public void AddHospitalToProject(int hospital_id_p, int project_id_p)
        {
            _persistence.AddHospitalToProject(hospital_id_p, project_id_p);
        }

        public void AddProjectManagerToProject(int projectmanager_id_p, int project_id_p)
        {
            _persistence.AddProjectManagerToProject(projectmanager_id_p, project_id_p);
        }


        #endregion
        
        #region Update
        public void UpdateClient(int id_p2, string name_p2, string adress_p2, string postalcode_p2, string city_p2, string country_p2, string contactperson_p2, string invoiceinfo_p2, string kindofclinet_p2)
        {
            _persistence.UpdateClient(id_p2, name_p2, adress_p2, postalcode_p2, city_p2, country_p2, contactperson_p2, invoiceinfo_p2, kindofclinet_p2);
        }
        public void UpdateContract(int id_p2, string legalcountry_p2, double fee_p2, DateTime startdate_p2, DateTime enddate_p2, int project_id_p2, int client_id_p2)
        {
            _persistence.UpdateContract(id_p2, legalcountry_p2, fee_p2, startdate_p2, enddate_p2, project_id_p2, client_id_p2);
        }
        public void UpdateCRA(int id_p2, string name_p2, string cv_p2, string email_p2, string phone1_p2, string phone2_p2)
        {
            _persistence.UpdateCRA(id_p2, name_p2, cv_p2, email_p2, phone1_p2, phone2_p2);
        }
        public void UpdateDepartment(int id_p2, string name_p2, string email_p2, string phone1_p2, int hospitalID_p2)
        {
            _persistence.UpdateDepartment(id_p2, name_p2, email_p2, phone1_p2, hospitalID_p2);
        }
        public void UpdateDoctor(int id_p2, string name_p2, string email_p2, string phone1_p2, string phone2_p2, string adress_p2, string postalcode_p2, string city_p2, string country_p2, string specialisation_p2, string cv_p2)
        {
            _persistence.UpdateDoctor(id_p2, name_p2, email_p2, phone1_p2, phone2_p2, adress_p2, postalcode_p2, city_p2, country_p2, specialisation_p2, cv_p2);
        }
        public void UpdateEvaluation(int id_p2, DateTime date_p2, string feedback_p2, string accuracy_p2, string quality_p2, string evaluationtxt_p2, string label_p2, string scID_p2, string drID_p2, string crID_p2)
        {
            _persistence.UpdateEvaluation(id_p2, date_p2, feedback_p2, accuracy_p2, quality_p2, evaluationtxt_p2, label_p2, scID_p2, drID_p2, crID_p2);
        }
        public void UpdateHospital(int id_p2, string name_p2, string adress_p2, string postalcode_p2, string city_p2, string country_p2, string centralnumber_p2)
        {
            _persistence.UpdateHospital(id_p2, name_p2, adress_p2, postalcode_p2, city_p2, country_p2, centralnumber_p2);
        }
        public void UpdateProject(int id_p2, string title_p2, DateTime startdate_p2, DateTime enddate_p2)
        {
            _persistence.UpdateProject(id_p2, title_p2, startdate_p2, enddate_p2);
        }
        public void UpdateProjectManager(int id_p2, string name_p2, string cv_p2, string email_p2, string phone1_p2, string phone2_p2)
        {
            _persistence.UpdateProjectManager(id_p2, name_p2, cv_p2, email_p2, phone1_p2, phone2_p2);
        }
        public void UpdateStudyCoordinator(int id_p2, string name_p2, string cv_p2, string email_p2, string phone1_p2, string phone2_p2, string specialisation_p2)
        {
            _persistence.UpdateStudyCoordinator(id_p2, name_p2, cv_p2, email_p2, phone1_p2, phone2_p2, specialisation_p2);
        }
        #endregion

        #region UpdateRelation
        //-------------------------------------------------------------------------
        #endregion
        
        #region Delete
        public void DeleteClient(int id_p2)
        {
            _persistence.DeleteClient(id_p2);
        }
        public void DeleteContract(int id_p2, string sortingPar_p2)
        {
            _persistence.DeleteContract(id_p2, sortingPar_p2);
        }
        public void DeleteCRA(int id_p2)
        {
            _persistence.DeleteCRA(id_p2);
        }
        public void DeleteDepartment(int id_p2, string sortingPar_p2)
        {
            _persistence.DeleteDepartment(id_p2, sortingPar_p2);
        }
        public void DeleteDoctor(int id_p2)
        {
            _persistence.DeleteDoctor(id_p2);
        }
        public void DeleteEvaluation(int id_p2, string sortingPar_p2)
        {
            _persistence.DeleteEvaluation(id_p2, sortingPar_p2);
        }
        public void DeleteHospital(int id_p2)
        {
            _persistence.DeleteHospital(id_p2);
        }
        public void DeleteProject(int id_p2)
        {
            _persistence.DeleteProject(id_p2);
        }
        public void DeleteProjectManager(int id_p2)
        {
            _persistence.DeleteProjectManager(id_p2);
        }
        public void DeleteStudyCoordinator(int id_p2)
        {
            _persistence.DeleteStudyCoordinator(id_p2);
        }
        #endregion

        #region DeleteRelation

        #region Doctor + Hospital
        public void DeleteRelationDoctorHasHospitals(int doctor_id_p2)
        {
            _persistence.DeleteRelationDoctorHasHospitals(doctor_id_p2);
        }

        public void DeleteRelationHospitalHasDoctors(int doctor_id_p2)
        {
            _persistence.DeleteRelationHospitalHasDoctors(doctor_id_p2);
        }
        #endregion

        #region Study Coordinator + Doctor
        public void DeleteRelationStudyCoordinatorHasDoctors(int studycoordinator_id_p2)
        {
            _persistence.DeleteRelationStudyCoordinatorHasDoctors(studycoordinator_id_p2);
        }

        public void DeleteRelationDoctorHasStudyCoordinators(int studycoordinator_id_p2)
        {
            _persistence.DeleteRelationDoctorHasStudyCoordinators(studycoordinator_id_p2);
        }
        #endregion

        #region Project + CRA
        public void DeleteRelationProjectHasCRAs(int studycoordinator_id_p2)
        {
            _persistence.DeleteRelationProjectHasCRAs(studycoordinator_id_p2);
        }

        public void DeleteRelationCRAHasProjects(int studycoordinator_id_p2)
        {
            _persistence.DeleteRelationCRAHasProjects(studycoordinator_id_p2);
        }
        #endregion

        #region Project + Doctor
        public void DeleteRelationProjectHasDoctors(int studycoordinator_id_p2)
        {
            _persistence.DeleteRelationProjectHasDoctors(studycoordinator_id_p2);
        }

        public void DeleteRelationDoctorHasProjects(int studycoordinator_id_p2)
        {
            _persistence.DeleteRelationDoctorHasProjects(studycoordinator_id_p2);
        }
        #endregion

        #region Project + Hospital
        public void DeleteRelationProjectHasHospitals(int studycoordinator_id_p2)
        {
            _persistence.DeleteRelationProjectHasHospitals(studycoordinator_id_p2);
        }

        public void DeleteRelationHospitalHasProjects(int studycoordinator_id_p2)
        {
            _persistence.DeleteRelationHospitalHasProjects(studycoordinator_id_p2);
        }
        #endregion

        #region Project + Project Manager
        public void DeleteRelationProjectHasProjectManagers(int studycoordinator_id_p2)
        {
            _persistence.DeleteRelationProjectHasProjectManagers(studycoordinator_id_p2);
        }

        public void DeleteRelationProjectManagerHasProjects(int studycoordinator_id_p2)
        {
            _persistence.DeleteRelationProjectManagerHasProjects(studycoordinator_id_p2);
        }
        #endregion

        #endregion
        
        #region Search
        public List<ClientCode> SearchClients(string sortingPar)
        {
            return _persistence.SearchClients(sortingPar);
        }
        public List<ContractCode> SearchContracts(string sortingPar)
        {
            return _persistence.SearchContracts(sortingPar);
        }
        public List<CRACode> SearchCRAs(string sortingPar)
        {
            return _persistence.SearchCRAs(sortingPar);
        }
        public List<DepartmentCode> SearchDepartments(string sortingPar)
        {
            return _persistence.SearchDepartments(sortingPar);
        }
        public List<DoctorCode> SearchDoctors(string sortingPar)
        {
            return _persistence.SearchDoctors(sortingPar);
        }
        public List<EvaluationCode> SearchEvaluations(string sortingPar)
        {
            return _persistence.SearchEvaluations(sortingPar);
        }
        public List<HospitalCode> SearchHospitals(string sortingPar)
        {
            return _persistence.SearchHospitals(sortingPar);
        }
        public List<ProjectManagerCode> SearchProjectManagers(string sortingPar)
        {
            return _persistence.SearchProjectManagers(sortingPar);
        }
        public List<ProjectCode> SearchProjects(string sortingPar)
        {
            return _persistence.SearchProjects(sortingPar);
        }
        public List<StudyCoordinatorCode> SearchStudyCoordinators(string sortingPar)
        {
            return _persistence.SearchStudyCoordinators(sortingPar);
        }
        #endregion
        
        #region Control

        private string DomainMapper(Match match)
        {
            // IdnMapping class with default property values.
            IdnMapping idn = new IdnMapping();

            string domainName = match.Groups[2].Value;
            try
            {
                domainName = idn.GetAscii(domainName);
            }
            catch (ArgumentException)
            {

            }
            return match.Groups[1].Value + domainName;
        }

        public bool IsValidEmail(string parEmail)
		{
            bool invalid = false;
            if (String.IsNullOrEmpty(parEmail))
                return false;

            // Use IdnMapping class to convert Unicode domain names.
            try
            {
                parEmail = Regex.Replace(parEmail, @"(@)(.+)$", this.DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }

            if (invalid)
                return false;

            // Return true if strIn is in valid email format.
            try
            {
                return Regex.IsMatch(parEmail,
                      @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                      @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                      RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }

        public bool IsValidPhone(string parNumber)
        {
            string number = PhoneNumberUtil.NormalizeDigitsOnly(parNumber);
            return PhoneNumberUtil.IsViablePhoneNumber(number);
        }

        public string BeginUpperCase(string word)
        {
            if(word != "")
            {
                word = word.First().ToString().ToUpper() + word.Substring(1);
            }
            else
            {
                word = "";
            }
            return word;
        }
        #endregion

        #region UserWarning
        //public static void MessageBoxShow(this Page Page, String Message)
        //{
        //    Page.ClientScript.RegisterStartupScript(
        //       Page.GetType(),
        //       "MessageBox",
        //       "<script language='javascript'>alert('" + Message + "');</script>"
        //    );
        //}
        #endregion
        
        
        #region Hash
            /*
        public string HashPassword(string password)
        {
            //STEP 1 Create the salt value with a cryptographic PRNG:

            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);

            //STEP 2 Create the Rfc2898DeriveBytes and get the hash value:

            var pbkdf2 = new Rfc2898DeriveBytes(password,salt,10000);
            byte[] hash = pbkdf2.GetBytes(20);

            //STEP 3 Combine the salt and password bytes for later use:

            byte[] hashBytes = new byte[36];
            Array.Copy(salt,0,hashBytes,0,16);
            Array.Copy(hash,0,hashBytes,16,20);

            //STEP 4 Turn the combined salt+hash into a string for storage

            return Convert.ToBase64String(hashBytes);
        }

        //STEP 5 Verify the user-entered password against a stored password

        public bool UnHashPassword(string password)
        {
            //Extract the bytes 
            byte[] hashBytes = Convert.FromBase64String(password);
            // Get the salt 
            byte[] salt = new byte[16];
            Array.Copy(hashBytes,0,salt,0,16);
            // Compute the hash on the password the user entered
            var pbkdf2 = new Rfc2898DeriveBytes(password,salt,1000);
            byte[] hash = pbkdf2.GetBytes(20);
            //Compare the results 
            for (int i = 0; i < 20; i++)
            {
                if (hashBytes[i + 16] != hash[i])
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
        */
        #endregion
        
    }
}
