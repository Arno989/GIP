using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Domain.Persistence;

namespace Domain.Business
{
	public class BusinessCode
	{
		private PersistenceCode _persistence;

        public BusinessCode()
		{
			_persistence = new PersistenceCode();
		}

		public void SetClient(string name_p2,string adress_p2,string postalcode_p2,string city_p2,string country_p2,string contactperson_p2,string invoiceinfo_p2,string kindofclinet_p2)
		{
			_persistence.addClient(name_p2,adress_p2,postalcode_p2,city_p2,country_p2,contactperson_p2,invoiceinfo_p2,kindofclinet_p2);
		}
        public List<ClientCode> GetClients()
		{
            return _persistence.getClients();
        }

        public void SetContract(string legalcountry_p2, double fee_p2, DateTime duration_p2, DateTime date_p2)
        {
            _persistence.addContract(legalcountry_p2, fee_p2, duration_p2, date_p2);
        }
        public List<ContractCode> GetContracts()
        {
            return _persistence.getContract();
        }

        public void SetCRA(string name_p2, string cv_p2, string email_p2, string phone1_p2, string phone2_p2)
        {
            _persistence.addCRA(name_p2, cv_p2, email_p2, phone1_p2, phone2_p2);
        }
        public List<CRACode> GetCRAs()
        {
            return _persistence.getCRA();
        }

        public void SetDepartment(string name_p2, string email_p2, string phone1_p2)
        {
            _persistence.addDepartment(name_p2, email_p2, phone1_p2);
        }
        public List<DepartmentCode> GetDepartments()
        {
            return _persistence.getDepartment();
        }

        public void SetDoctor(string name_p2, string email_p2, string phone1_p2, string phone2_p2, string adress_p2, string postalcode_p2, string city_p2, string country_p2, string specialisation_p2, string cv_p2)
        {
            _persistence.addDoctor(name_p2, email_p2, phone1_p2, phone2_p2, adress_p2, postalcode_p2, city_p2, country_p2, specialisation_p2, cv_p2);
        }
        public List<DoctorCode> GetDoctors()
        {
            return _persistence.getDoctor();
        }

        public void SetEvaluation(DateTime date_p2, string feedback_p2, string accuracy_p2, string quality_p2, string evaluationtxt_p2, string label_p2)
        {
            _persistence.addEvaluation(date_p2, feedback_p2, accuracy_p2, quality_p2, evaluationtxt_p2, label_p2);
        }
        public List<EvaluationCode> GetEvaluations()
        {
            return _persistence.getEvaluation();
        }

        public void SetHospital(string name_p2, string adress_p2, string postalcode_p2, string city_p2, string country_p2, string centralnumber_p2)
        {
            _persistence.addHospital(name_p2, adress_p2, postalcode_p2, city_p2, country_p2, centralnumber_p2);
        }
        public List<HospitalCode> GetHospitals()
        {
            return _persistence.getHospital();
        }

        public void SetProject(string title_p2, DateTime startdate_p2, DateTime enddate_p2)
        {
            _persistence.addProject(title_p2, startdate_p2, enddate_p2);
        }
        public List<ProjectCode> GetProjects()
        {
            return _persistence.getProject();
        }

        public void SetProjectManager(string name_p2, string cv_p2, string email_p2, string phone1_p2, string phone2_p2)
        {
            _persistence.addProjectManager(name_p2, cv_p2, email_p2, phone1_p2, phone2_p2);
        }
        public List<ProjectManagerCode> GetProjectManagers()
        {
            return _persistence.getProjectManager();
        }

        public void SetStudyCoördinator(string name_p2, string cv_p2, string email_p2, string phone1_p2, string phone2_p2, string specialisation_p2)
        {
            _persistence.addStudyCoördinator(name_p2, cv_p2, email_p2, phone1_p2, phone2_p2, specialisation_p2);
        }
        public List<StudyCoördinatorCode> GetStudyCoördinators()
        {
            return _persistence.getStudyCoördinator();
        }

        public void DeleteClient(int id_p2)
        {
            _persistence.deleteClient(id_p2);
        }

		public bool IsValidEmail(string parEmail)
		{
			try
			{
				var addr = new System.Net.Mail.MailAddress(parEmail);
				return addr.Address == parEmail;
			}
			catch
			{
				return false;
			}
		}

		public bool IsValidPhone(string parNumber)
		{
			return Regex.Match(parNumber,@"^(\(?\+?[0-9]*\)?)?[0-9_\- \(\)]*$").Success;
		}
	}
}
