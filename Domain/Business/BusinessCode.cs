using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
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
            return _persistence.getClients(sortingPar);
        }
        public List<ContractCode> GetContracts(string sortingPar)
        {
            return _persistence.getContract(sortingPar);
        }
        public List<CRACode> GetCRAs()
        {
            return _persistence.getCRA();
        }
        public List<DepartmentCode> GetDepartments()
        {
            return _persistence.getDepartment();
        }
        public List<DoctorCode> GetDoctors()
        {
            return _persistence.getDoctor();
        }
        public List<EvaluationCode> GetEvaluations()
        {
            return _persistence.getEvaluation();
        }
        public List<HospitalCode> GetHospitals()
        {
            return _persistence.getHospital();
        }
        public List<ProjectCode> GetProjects()
        {
            return _persistence.getProject();
        }
        public List<ProjectManagerCode> GetProjectManagers()
        {
            return _persistence.getProjectManager();
        }
        public List<StudyCoördinatorCode> GetStudyCoördinators()
        {
            return _persistence.getStudyCoördinator();
        }
        #endregion

        #region GetDropDownContent
        public List<List<string>> GetClientDropDownContent()
        {
            return _persistence.getClientDropDown();
        }
        public List<List<string>> GetContractDropDownContent()
        {
            return _persistence.getContractDropDown();
        }
        public List<List<string>> GetCRADropDownContent()
        {
            return _persistence.getCRADropDown();
        }
        public List<List<string>> GetDepartmentDropDownContent()
        {
            return _persistence.getDepartmentDropDown();
        }
        public List<List<string>> GetDoctorDropDownContent()
        {
            return _persistence.getDoctorDropDown();
        }
        public List<List<string>> GetEvaluationDropDownContent()
        {
            return _persistence.getEvaluationDropDown();
        }
        public List<List<string>> GetHospitalDropDownContent()
        {
            return _persistence.getHospitalDropDown();
        }
        public List<List<string>> GetProjectDropDownContent()
        {
            return _persistence.getProjectDropDown();
        }
        public List<List<string>> GetProjectManagerDropDownContent()
        {
            return _persistence.getProjectManagerDropDown();
        }
        public List<List<string>> GetStudyCoordinatorDropDownContent()
        {
            return _persistence.getStudyCoordinatorDropDown();
        }
        #endregion

        #region GetRelation
        public List<int> GetRelationHospitalHasDoctor(int Doctor_ID_p2)
        {
            return _persistence.getRelationHospitalHasDoctor(Doctor_ID_p2);
        }
        #endregion

        #region Set
        public void SetClient(string name_p2, string adress_p2, string postalcode_p2, string city_p2, string country_p2, string contactperson_p2, string invoiceinfo_p2, string kindofclinet_p2)
        {
            _persistence.addClient(name_p2, adress_p2, postalcode_p2, city_p2, country_p2, contactperson_p2, invoiceinfo_p2, kindofclinet_p2);
        }
        public void SetContract(string legalcountry_p2, double fee_p2, DateTime startdate_p2, DateTime enddate_p2)
        {
            _persistence.addContract(legalcountry_p2, fee_p2, startdate_p2, enddate_p2);
        }
        public void SetCRA(string name_p2, string cv_p2, string email_p2, string phone1_p2, string phone2_p2)
        {
            _persistence.addCRA(name_p2, cv_p2, email_p2, phone1_p2, phone2_p2);
        }
        public void SetDepartment(string name_p2, string email_p2, string phone1_p2)
        {
            _persistence.addDepartment(name_p2, email_p2, phone1_p2);
        }
        public void SetDoctor(string name_p2, string email_p2, string phone1_p2, string phone2_p2, string adress_p2, string postalcode_p2, string city_p2, string country_p2, string specialisation_p2, string cv_p2)
        {
            _persistence.addDoctor(name_p2, email_p2, phone1_p2, phone2_p2, adress_p2, postalcode_p2, city_p2, country_p2, specialisation_p2, cv_p2);
        }
        public void SetEvaluation(DateTime date_p2, string feedback_p2, string accuracy_p2, string quality_p2, string evaluationtxt_p2, string label_p2)
        {
            _persistence.addEvaluation(date_p2, feedback_p2, accuracy_p2, quality_p2, evaluationtxt_p2, label_p2);
        }
        public void SetHospital(string name_p2, string adress_p2, string postalcode_p2, string city_p2, string country_p2, string centralnumber_p2)
        {
            _persistence.addHospital(name_p2, adress_p2, postalcode_p2, city_p2, country_p2, centralnumber_p2);
        }
        public void SetProject(string title_p2, DateTime startdate_p2, DateTime enddate_p2)
        {
            _persistence.addProject(title_p2, startdate_p2, enddate_p2);
        }
        public void SetProjectManager(string name_p2, string cv_p2, string email_p2, string phone1_p2, string phone2_p2)
        {
            _persistence.addProjectManager(name_p2, cv_p2, email_p2, phone1_p2, phone2_p2);
        }
        public void SetStudyCoördinator(string name_p2, string cv_p2, string email_p2, string phone1_p2, string phone2_p2, string specialisation_p2)
        {
            _persistence.addStudyCoördinator(name_p2, cv_p2, email_p2, phone1_p2, phone2_p2, specialisation_p2);
        }
        #endregion

        #region SetRelation
        public void addHospitalToDoctor(int hospital_id_p2, int doctor_id_p2)
        {
            _persistence.addHospitalToDoctor(hospital_id_p2, doctor_id_p2);
        }
        #endregion
        // relations nog niet af

        #region Update
        public void UpdateClient(int id_p2, string name_p2, string adress_p2, string postalcode_p2, string city_p2, string country_p2, string contactperson_p2, string invoiceinfo_p2, string kindofclinet_p2)
        {
            _persistence.updateClients(id_p2, name_p2, adress_p2, postalcode_p2, city_p2, country_p2, contactperson_p2, invoiceinfo_p2, kindofclinet_p2);
        }
        public void UpdateContract(int id_p2, string legalcountry_p2, double fee_p2, DateTime startdate_p2, DateTime enddate_p2)
        {
            _persistence.UpdateContract(id_p2, legalcountry_p2, fee_p2, startdate_p2, enddate_p2);
        }
        public void UpdateCRA(int id_p2, string name_p2, string cv_p2, string email_p2, string phone1_p2, string phone2_p2)
        {
            _persistence.UpdateCRA(id_p2, name_p2, cv_p2, email_p2, phone1_p2, phone2_p2);
        }
        public void UpdateDepartment(int id_p2, string name_p2, string email_p2, string phone1_p2)
        {
            _persistence.UpdateDepartment(id_p2, name_p2, email_p2, phone1_p2);
        }
        public void UpdateDoctor(int id_p2, string name_p2, string email_p2, string phone1_p2, string phone2_p2, string adress_p2, string postalcode_p2, string city_p2, string country_p2, string specialisation_p2, string cv_p2)
        {
            _persistence.UpdateDoctor(id_p2, name_p2, email_p2, phone1_p2, phone2_p2, adress_p2, postalcode_p2, city_p2, country_p2, specialisation_p2, cv_p2);
        }
        public void UpdateEvaluation(int id_p2, DateTime date_p2, string feedback_p2, string accuracy_p2, string quality_p2, string evaluationtxt_p2, string label_p2)
        {
            _persistence.UpdateEvaluation(id_p2, date_p2, feedback_p2, accuracy_p2, quality_p2, evaluationtxt_p2, label_p2);
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
        public void UpdateStudyCoördinator(int id_p2, string name_p2, string cv_p2, string email_p2, string phone1_p2, string phone2_p2, string specialisation_p2)
        {
            _persistence.UpdateStudyCoördinator(id_p2, name_p2, cv_p2, email_p2, phone1_p2, phone2_p2, specialisation_p2);
        }
        #endregion

        #region Delete
        public void DeleteClient(int id_p2)
        {
            _persistence.deleteClient(id_p2);
        }
        public void DeleteContract(int id_p2)
        {
            _persistence.deleteContract(id_p2);
        }
        public void DeleteCRA(int id_p2)
        {
            _persistence.deleteCRA(id_p2);
        }
        public void DeleteDepartment(int id_p2)
        {
            _persistence.deleteDepartment(id_p2);
        }
        public void DeleteDoctor(int id_p2)
        {
            _persistence.deleteDoctor(id_p2);
        }
        public void DeleteEvaluation(int id_p2)
        {
            _persistence.deleteEvaluation(id_p2);
        }
        public void DeleteHospital(int id_p2)
        {
            _persistence.deleteHospital(id_p2);
        }
        public void DeleteProject(int id_p2)
        {
            _persistence.deleteProject(id_p2);
        }
        public void DeleteProjectManager(int id_p2)
        {
            _persistence.deleteProjectManager(id_p2);
        }
        public void DeleteStudyCoördinator(int id_p2)
        {
            _persistence.deleteStudyCoördinator(id_p2);
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
                invalid = true;
            }
            return match.Groups[1].Value + domainName;
        }
        bool invalid = false;
        public bool IsValidEmail(string parEmail)
		{
            invalid = false;
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
        #endregion
    }
}
