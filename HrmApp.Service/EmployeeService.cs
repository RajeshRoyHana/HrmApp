using HrmApp.Models.Entities;
using HrmApp.Services.DataContext;
using HrmApp.Services.Interfaces;
using HrmApp.Shared.Dtos;
using Microsoft.EntityFrameworkCore;

namespace HrmApp.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly AppDbContext _context;

        public EmployeeService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IList<EmployeeListDto>> GetEmployeeListAsync(int idClient, CancellationToken cancellationToken)
        {
            var data = await _context.Employees
                .AsNoTracking()
                .Where(e => e.IdClient == idClient && e.IsActive == true)
                .Select(e => new EmployeeListDto
                {
                    Id = e.Id,
                    IdClient = e.IdClient,
                    EmployeeName = e.EmployeeName,
                    DesignationName = e.Designation != null ? e.Designation.DesignationName : "N/A"
                })
                .ToListAsync(cancellationToken);

            return data;
        }

        public async Task<EmployeeDto?> GetEmployeeAsync( int idClient,int id, CancellationToken cancellationToken)
        {
            var data = await _context.Employees
                .Where(e => e.Id == id && e.IdClient == idClient)
                .Select(employee => new EmployeeDto
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

                    EmployeeDocuments = employee.EmployeeDocuments
                        .Select(d => new EmployeeDocumentDto
                        {
                            IdClient = d.IdClient,
                            Id = d.Id,
                            IdEmployee = d.IdEmployee,
                            DocumentName = d.DocumentName,
                            FileName = d.FileName,
                            UploadedFileExtention = d.UploadedFileExtention,
                            SetDate = d.SetDate
                        }).ToList(),

                    EmployeeEducationInfos = employee.EmployeeEducationInfos
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
                        }).ToList(),

                    EmployeeFamilyInfos = employee.EmployeeFamilyInfos
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
                        }).ToList(),

                    EmployeeProfessionalCertifications =
                        employee.EmployeeProfessionalCertifications
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
                        }).ToList()
                })
                .FirstOrDefaultAsync(cancellationToken);
            return data;
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
                        }).ToList();
            }

            _context.Employees.Add(employee);
            await _context.SaveChangesAsync(cancellationToken);
            return employee.Id;
        }

        public async Task<bool> UpdateEmployeeAsync(EmployeeDto dto, CancellationToken cancellationToken)
        {
            if (dto.IdClient <= 0 || dto.Id <= 0)
                throw new ArgumentException("Invalid client or employee id.");

            var employee = await _context.Employees
                .Include(e => e.EmployeeDocuments)
                .Include(e => e.EmployeeEducationInfos)
                .Include(e => e.EmployeeFamilyInfos)
                .Include(e => e.EmployeeProfessionalCertifications)
                .AsSplitQuery()
                .FirstOrDefaultAsync(
                    e => e.Id == dto.Id && e.IdClient == dto.IdClient,cancellationToken);

            if (employee == null)
                return false;

            // Update Employee scalar properties
            employee.EmployeeName = dto.EmployeeName;
            employee.EmployeeNameBangla = dto.EmployeeNameBangla;
            employee.FatherName = dto.FatherName;
            employee.MotherName = dto.MotherName;
            employee.EmployeeImage = !string.IsNullOrEmpty(dto.EmployeeImage)
                ? Convert.FromBase64String(dto.EmployeeImage)
                : employee.EmployeeImage;
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


            // Update or add EmployeeDocuments
            foreach (var doc in dto.EmployeeDocuments)
            {
                var existingDoc = doc.Id > 0
                    ? employee.EmployeeDocuments.FirstOrDefault(d => d.Id == doc.Id)
                    : null;

                if (existingDoc != null)
                {
                    existingDoc.DocumentName = doc.DocumentName;
                    existingDoc.FileName = doc.FileName;
                    existingDoc.UploadedFile = !string.IsNullOrEmpty(doc.UploadedFile)
                        ? Convert.FromBase64String(doc.UploadedFile)
                        : existingDoc.UploadedFile;
                    existingDoc.UploadedFileExtention = doc.UploadedFileExtention;

                }
                else
                {
                    employee.EmployeeDocuments.Add(new EmployeeDocument
                    {
                        IdClient = dto.IdClient,
                        DocumentName = doc.DocumentName,
                        FileName = doc.FileName,
                        UploadedFile = !string.IsNullOrEmpty(doc.UploadedFile)
                            ? Convert.FromBase64String(doc.UploadedFile)
                            : null,
                        UploadedFileExtention = doc.UploadedFileExtention,
                        UploadDate = DateTime.UtcNow,

                    });
                }
            }


            // Update or add EducationInfos
            foreach (var edu in dto.EmployeeEducationInfos)
            {
                var existingEdu = edu.Id > 0
                    ? employee.EmployeeEducationInfos.FirstOrDefault(e => e.Id == edu.Id)
                    : null;

                if (existingEdu != null)
                {
                    existingEdu.IdEducationLevel = edu.IdEducationLevel;
                    existingEdu.IdEducationExamination = edu.IdEducationExamination;
                    existingEdu.IdEducationResult = edu.IdEducationResult;
                    existingEdu.Cgpa = edu.Cgpa;
                    existingEdu.ExamScale = edu.ExamScale;
                    existingEdu.Marks = edu.Marks;
                    existingEdu.Major = edu.Major;
                    existingEdu.PassingYear = edu.PassingYear;
                    existingEdu.InstituteName = edu.InstituteName;
                    existingEdu.IsForeignInstitute = edu.IsForeignInstitute;
                    existingEdu.Duration = edu.Duration;
                    existingEdu.Achievement = edu.Achievement;
                }
                else
                {
                    employee.EmployeeEducationInfos.Add(new EmployeeEducationInfo
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
                    });
                }
            }



            foreach (var fam in dto.EmployeeFamilyInfos)
            {
                var existingFamily = fam.Id > 0
                    ? employee.EmployeeFamilyInfos.FirstOrDefault(f => f.Id == fam.Id)
                    : null;

                if (existingFamily != null)
                {
                    // Update existing family info
                    existingFamily.Name = fam.Name;
                    existingFamily.IdGender = fam.IdGender;
                    existingFamily.IdRelationship = fam.IdRelationship;
                    existingFamily.DateOfBirth = fam.DateOfBirth;
                    existingFamily.ContactNo = fam.ContactNo;
                    existingFamily.CurrentAddress = fam.CurrentAddress;
                    existingFamily.PermanentAddress = fam.PermanentAddress;
                    existingFamily.CreatedBy = fam.CreatedBy;
                }
                else
                {
                    // Add new family info
                    employee.EmployeeFamilyInfos.Add(new EmployeeFamilyInfo
                    {
                        IdClient = dto.IdClient,
                        IdEmployee = dto.Id,
                        Name = fam.Name,
                        IdGender = fam.IdGender,
                        IdRelationship = fam.IdRelationship,
                        DateOfBirth = fam.DateOfBirth,
                        ContactNo = fam.ContactNo,
                        CurrentAddress = fam.CurrentAddress,
                        PermanentAddress = fam.PermanentAddress,
                    });
                }
            }


            foreach (var cert in dto.EmployeeProfessionalCertifications)
            {
                var existingCert = cert.Id > 0
                    ? employee.EmployeeProfessionalCertifications
                        .FirstOrDefault(c => c.Id == cert.Id)
                    : null;

                if (existingCert != null)
                {
                    // Update existing certification
                    existingCert.CertificationTitle = cert.CertificationTitle;
                    existingCert.CertificationInstitute = cert.CertificationInstitute;
                    existingCert.InstituteLocation = cert.InstituteLocation;
                    existingCert.FromDate = cert.FromDate;
                    existingCert.ToDate = cert.ToDate;
                }
                else
                {
                    // Add new certification
                    employee.EmployeeProfessionalCertifications.Add(
                        new EmployeeProfessionalCertification
                        {
                            IdClient = dto.IdClient,
                            IdEmployee = dto.Id,
                            CertificationTitle = cert.CertificationTitle,
                            CertificationInstitute = cert.CertificationInstitute,
                            InstituteLocation = cert.InstituteLocation,
                            FromDate = cert.FromDate,
                            ToDate = cert.ToDate
                        });
                }
            }

            var result = await _context.SaveChangesAsync(cancellationToken);
            return result > 0;
        }

        public async Task<bool> DeleteEmployeeAsync(int idClient, int id, CancellationToken cancellationToken)
        {
            var employee = await _context.Employees
                .FirstOrDefaultAsync(e => e.IdClient == idClient && e.Id == id && e.IsActive == true, cancellationToken);

            if (employee == null)
                return false;

            employee.IsActive = false;
            employee.SetDate = DateTime.UtcNow;

            var savechangeVales = await _context.SaveChangesAsync(cancellationToken);
            return savechangeVales > 0;
        }
    }

}
