using HrmApp.Models.Entities;
using HrmApp.Repositories.Interfaces;
using HrmApp.Services.Interfaces;
using HrmApp.Shared.Dtos;

namespace HrmApp.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _repository;

        public EmployeeService(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        public async Task<IList<EmployeeListDto>> GetEmployeeListByClientId(int clientId, CancellationToken cancellationToken)
        {
            return await _repository.GetEmployeeListByClientId(clientId, cancellationToken);
        }
        public async Task<EmployeeDto?> GetEmployeeAsync(int clientId, int id, CancellationToken cancellationToken)
        {
            var employee = await _repository.GetByIdAsync(clientId, id, cancellationToken);

            if (employee == null)
                return null;

            return new EmployeeDto
            {
                IdClient = employee.IdClient,
                Id = employee.Id,
                EmployeeName = employee.EmployeeName,
                EmployeeNameBangla = employee.EmployeeNameBangla,
                FatherName = employee.FatherName,
                MotherName = employee.MotherName,
                IdReportingManager = employee.IdReportingManager,
                IdJobType = employee.IdJobType,
                IdEmployeeType = employee.IdEmployeeType,
                BirthDate = employee.BirthDate,
                JoiningDate = employee.JoiningDate,
                IdGender = employee.IdGender,
                IdReligion = employee.IdReligion,
                IdDepartment = employee.IdDepartment,
                IdSection = employee.IdSection,
                IdDesignation = employee.IdDesignation,
                HasOvertime = employee.HasOvertime,
                HasAttendenceBonus = employee.HasAttendenceBonus,
                IdWeekOff = employee.IdWeekOff,
                Address = employee.Address,
                PresentAddress = employee.PresentAddress,
                NationalIdentificationNumber = employee.NationalIdentificationNumber,
                ContactNo = employee.ContactNo,
                IdMaritalStatus = employee.IdMaritalStatus,
                IsActive = employee.IsActive,
                SetDate = employee.SetDate,
                CreatedBy = employee.CreatedBy,

                // Documents
                EmployeeDocuments = employee.EmployeeDocuments?
                    .Select(d => new EmployeeDocumentDto
                    {
                        IdClient = d.IdClient,
                        Id = d.Id,
                        IdEmployee = d.IdEmployee,
                        DocumentName = d.DocumentName,
                        FileName = d.FileName,
                        UploadedFileExtention = d.UploadedFileExtention,
                        SetDate = d.SetDate
                    }).ToList() ?? new(),

                // Education
                EmployeeEducationInfos = employee.EmployeeEducationInfos?
                    .Select(e => new EmployeeEducationInfoDto
                    {
                        IdClient = e.IdClient,
                        Id = e.Id,
                        IdEmployee = e.IdEmployee,
                        IdEducationLevel = e.IdEducationLevel,
                        IdEducationExamination = e.IdEducationExamination,
                        IdEducationResult = e.IdEducationResult,
                        Cgpa = e.Cgpa,
                        ExamScale = e.ExamScale,
                        Marks = e.Marks,
                        Major = e.Major,
                        PassingYear = e.PassingYear,
                        InstituteName = e.InstituteName,
                        IsForeignInstitute = e.IsForeignInstitute,
                        Duration = e.Duration,
                        Achievement = e.Achievement,
                        SetDate = e.SetDate
                    }).ToList() ?? new(),

                // Family
                EmployeeFamilyInfos = employee.EmployeeFamilyInfos?
                    .Select(f => new EmployeeFamilyInfoDto
                    {
                        IdClient = f.IdClient,
                        Id = f.Id,
                        IdEmployee = f.IdEmployee,
                        Name = f.Name,
                        IdGender = f.IdGender,
                        IdRelationship = f.IdRelationship,
                        DateOfBirth = f.DateOfBirth,
                        ContactNo = f.ContactNo,
                        CurrentAddress = f.CurrentAddress,
                        PermanentAddress = f.PermanentAddress,
                        SetDate = f.SetDate,
                        CreatedBy = f.CreatedBy
                    }).ToList() ?? new(),

                // Certifications
                EmployeeProfessionalCertifications =
                    employee.EmployeeProfessionalCertifications?
                    .Select(c => new EmployeeProfessionalCertificationDto
                    {
                        IdClient = c.IdClient,
                        Id = c.Id,
                        IdEmployee = c.IdEmployee,
                        CertificationTitle = c.CertificationTitle,
                        CertificationInstitute = c.CertificationInstitute,
                        InstituteLocation = c.InstituteLocation,
                        FromDate = c.FromDate,
                        ToDate = c.ToDate,
                        SetDate = c.SetDate,
                        CreatedBy = c.CreatedBy
                    }).ToList() ?? new()
            };
        }

        public async Task<int> CreateEmployeeAsync(EmployeeDto dto, CancellationToken cancellationToken)
        {
            // Employee 
            var employee = new Employee
            {
                IdClient = dto.IdClient,
                EmployeeName = dto.EmployeeName!,
                EmployeeNameBangla = dto.EmployeeNameBangla,
                EmployeeImage = !string.IsNullOrEmpty(dto.EmployeeImage) ? Convert.FromBase64String(dto.EmployeeImage) : null,
                FatherName = dto.FatherName,
                MotherName = dto.MotherName,
                IdReportingManager = dto.IdReportingManager,
                IdJobType = dto.IdJobType,
                IdEmployeeType = dto.IdEmployeeType,
                BirthDate = dto.BirthDate,
                JoiningDate = dto.JoiningDate,
                IdGender = dto.IdGender,
                IdReligion = dto.IdReligion,
                IdDepartment = dto.IdDepartment,
                IdSection = dto.IdSection,
                IdDesignation = dto.IdDesignation,
                HasOvertime = dto.HasOvertime,
                HasAttendenceBonus = dto.HasAttendenceBonus,
                IdWeekOff = dto.IdWeekOff,
                Address = dto.Address,
                PresentAddress = dto.PresentAddress,
                NationalIdentificationNumber = dto.NationalIdentificationNumber,
                ContactNo = dto.ContactNo,
                IdMaritalStatus = dto.IdMaritalStatus,
                IsActive = dto.IsActive ?? true,
                SetDate = DateTime.UtcNow,
                CreatedBy = dto.CreatedBy
            };

            // Documents
            if (dto.EmployeeDocuments?.Any() == true)
            {
                employee.EmployeeDocuments = new List<EmployeeDocument>();

                foreach (var doc in dto.EmployeeDocuments)
                {
                    employee.EmployeeDocuments.Add(new EmployeeDocument
                    {
                        IdClient = dto.IdClient,
                        DocumentName = doc.DocumentName,
                        FileName = doc.FileName,
                        UploadedFile = !string.IsNullOrEmpty(doc.UploadedFile) ? Convert.FromBase64String(doc.UploadedFile) : null,
                        UploadedFileExtention = doc.UploadedFileExtention,
                        UploadDate = DateTime.UtcNow,
                        SetDate = DateTime.UtcNow
                    });
                }
            }

            // Education
            if (dto.EmployeeEducationInfos?.Any() == true)
            {
                employee.EmployeeEducationInfos =
                    dto.EmployeeEducationInfos.Select(e => new EmployeeEducationInfo
                    {
                        IdClient = dto.IdClient,
                        IdEducationLevel = e.IdEducationLevel,
                        IdEducationExamination = e.IdEducationExamination,
                        IdEducationResult = e.IdEducationResult,
                        Cgpa = e.Cgpa,
                        ExamScale = e.ExamScale,
                        Marks = e.Marks,
                        Major = e.Major,
                        PassingYear = e.PassingYear,
                        InstituteName = e.InstituteName,
                        IsForeignInstitute = e.IsForeignInstitute,
                        Duration = e.Duration,
                        Achievement = e.Achievement,
                        SetDate = DateTime.UtcNow
                    }).ToList();
            }

            // Family
            if (dto.EmployeeFamilyInfos?.Any() == true)
            {
                employee.EmployeeFamilyInfos =
                    dto.EmployeeFamilyInfos.Select(f => new EmployeeFamilyInfo
                    {
                        IdClient = dto.IdClient,
                        Name = f.Name,
                        IdGender = f.IdGender,
                        IdRelationship = f.IdRelationship,
                        DateOfBirth = f.DateOfBirth,
                        ContactNo = f.ContactNo,
                        CurrentAddress = f.CurrentAddress,
                        PermanentAddress = f.PermanentAddress,
                        SetDate = DateTime.UtcNow,
                        CreatedBy = f.CreatedBy
                    }).ToList();
            }

            // Professional Certifications
            if (dto.EmployeeProfessionalCertifications?.Any() == true)
            {
                employee.EmployeeProfessionalCertifications =
                    dto.EmployeeProfessionalCertifications.Select(c =>
                        new EmployeeProfessionalCertification
                        {
                            IdClient = dto.IdClient,
                            CertificationTitle = c.CertificationTitle,
                            CertificationInstitute = c.CertificationInstitute,
                            InstituteLocation = c.InstituteLocation,
                            FromDate = c.FromDate,
                            ToDate = c.ToDate,
                            SetDate = DateTime.UtcNow,
                            CreatedBy = c.CreatedBy
                        }).ToList();
            }

            return await _repository.CreateAsync(employee, cancellationToken);
        }

        public async Task<bool> UpdateEmployeeAsync(EmployeeDto dto, CancellationToken cancellationToken)
        {
            if (dto.IdClient <= 0 || dto.Id <= 0)
                throw new ArgumentException("Invalid client or employee id.");

            var employee = await _repository.GetByIdAsync(dto.IdClient, dto.Id, cancellationToken);

            if (employee == null)
                return false;


            employee.EmployeeName = dto.EmployeeName;
            employee.EmployeeNameBangla = dto.EmployeeNameBangla;
            employee.FatherName = dto.FatherName;
            employee.MotherName = dto.MotherName;
            employee.EmployeeImage = !string.IsNullOrEmpty(dto.EmployeeImage) ? Convert.FromBase64String(dto.EmployeeImage) : null;
            employee.IdReportingManager = dto.IdReportingManager;
            employee.IdJobType = dto.IdJobType;
            employee.IdEmployeeType = dto.IdEmployeeType;
            employee.BirthDate = dto.BirthDate;
            employee.JoiningDate = dto.JoiningDate;
            employee.IdGender = dto.IdGender;
            employee.IdReligion = dto.IdReligion;
            employee.IdDepartment = dto.IdDepartment;
            employee.IdSection = dto.IdSection;
            employee.IdDesignation = dto.IdDesignation;
            employee.HasOvertime = dto.HasOvertime;
            employee.HasAttendenceBonus = dto.HasAttendenceBonus;
            employee.IdWeekOff = dto.IdWeekOff;
            employee.Address = dto.Address;
            employee.PresentAddress = dto.PresentAddress;
            employee.ContactNo = dto.ContactNo;
            employee.IdMaritalStatus = dto.IdMaritalStatus;
            employee.IsActive = dto.IsActive ?? employee.IsActive;
            employee.SetDate = DateTime.UtcNow;
            employee.CreatedBy = dto.CreatedBy;




            if (employee.EmployeeDocuments.Any())
            {
                await _repository.RemoveEmployeeDocumentsAsync(employee.EmployeeDocuments, cancellationToken);
            }
            if (dto.EmployeeDocuments?.Any() == true)
            {
                foreach (var doc in dto.EmployeeDocuments)
                {
                    employee.EmployeeDocuments.Add(new EmployeeDocument
                    {
                        IdClient = dto.IdClient,
                        DocumentName = doc.DocumentName,
                        FileName = doc.FileName,
                        UploadedFile = !string.IsNullOrEmpty(doc.UploadedFile) ? Convert.FromBase64String(doc.UploadedFile) : null,
                        UploadedFileExtention = doc.UploadedFileExtention,
                        UploadDate = DateTime.UtcNow,
                        SetDate = DateTime.UtcNow
                    });
                }
            }


            if (employee.EmployeeEducationInfos.Any())
            {
                await _repository.RemoveEmployeeEducationInfosAsync(employee.EmployeeEducationInfos, cancellationToken);
            }

            if (dto.EmployeeEducationInfos?.Any() == true)
            {
                foreach (var edu in dto.EmployeeEducationInfos)
                {
                    employee.EmployeeEducationInfos.Add(
                        new EmployeeEducationInfo
                        {
                            IdClient = dto.IdClient,
                            IdEducationLevel = edu.IdEducationLevel,
                            IdEducationExamination = edu.IdEducationExamination,
                            IdEducationResult = edu.IdEducationResult,
                            Cgpa = edu.Cgpa,
                            ExamScale = edu.ExamScale,
                            Marks = edu.Marks,
                            Major = edu.Major,
                            PassingYear = edu.PassingYear,
                            InstituteName = edu.InstituteName,
                            IsForeignInstitute = edu.IsForeignInstitute,
                            Duration = edu.Duration,
                            Achievement = edu.Achievement,
                            SetDate = DateTime.UtcNow
                        });
                }
            }

            if (employee.EmployeeFamilyInfos.Any())
            {
                await _repository.RemoveEmployeeFamilyInfosAsync(employee.EmployeeFamilyInfos, cancellationToken);
            }
            if (dto.EmployeeFamilyInfos?.Any() == true)
            {
                foreach (var fam in dto.EmployeeFamilyInfos)
                {
                    employee.EmployeeFamilyInfos.Add(
                        new EmployeeFamilyInfo
                        {
                            IdClient = dto.IdClient,
                            Name = fam.Name,
                            IdGender = fam.IdGender,
                            IdEmployee = fam.IdEmployee,
                            IdRelationship = fam.IdRelationship,
                            DateOfBirth = fam.DateOfBirth,
                            ContactNo = fam.ContactNo,
                            CurrentAddress = fam.CurrentAddress,
                            PermanentAddress = fam.PermanentAddress,
                            SetDate = DateTime.UtcNow,
                            CreatedBy = fam.CreatedBy
                        });
                }
            }

            if (employee.EmployeeProfessionalCertifications.Any())
            {
                await _repository.RemoveEmployeeProfessionalCertificationsAsync(employee.EmployeeProfessionalCertifications, cancellationToken);
            }
            if (dto.EmployeeProfessionalCertifications?.Any() == true)
            {
                foreach (var cert in dto.EmployeeProfessionalCertifications)
                {
                    employee.EmployeeProfessionalCertifications.Add(
                        new EmployeeProfessionalCertification
                        {
                            IdClient = dto.IdClient,
                            CertificationTitle = cert.CertificationTitle,
                            CertificationInstitute =
                                cert.CertificationInstitute,
                            InstituteLocation = cert.InstituteLocation,
                            FromDate = cert.FromDate,
                            ToDate = cert.ToDate,
                            SetDate = DateTime.UtcNow,
                            CreatedBy = cert.CreatedBy
                        });
                }
            }

            await _repository.SaveChangesAsync(cancellationToken);

            return true;
        }

        public async Task<bool> DeleteEmployee(int clientId, int id, CancellationToken cancellationToken)
        {
            if (id <= 0)
                throw new ArgumentException("Invalid id");

            return await _repository.DeleteEmployee(clientId, id, cancellationToken);
        }

    }
}
