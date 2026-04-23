

export interface Employee {
  idClient: number;
  id: number;

  employeeName?: string;
  employeeNameBangla?: string;
  employeeImage?: string;

  fatherName?: string;
  motherName?: string;

  idReportingManager?: number;
  idJobType?: number;
  idEmployeeType?: number;

  birthDate?: string | Date;
  joiningDate?: string | Date;

  idGender?: number;
  idReligion?: number;

  idDepartment: number;
  idSection: number;
  idDesignation?: number;

  hasOvertime?: boolean;
  hasAttendenceBonus?: boolean;

  idWeekOff?: number;

  address?: string;
  presentAddress?: string;

  nationalIdentificationNumber?: string;
  contactNo?: string;

  idMaritalStatus?: number;

  isActive?: boolean;

  setDate?: string | Date;
  createdBy?: string;

  employeeDocuments: EmployeeDocument[];
  employeeEducationInfos: EmployeeEducationInfo[];
  employeeFamilyInfos: EmployeeFamilyInfo[];
  employeeProfessionalCertifications: EmployeeProfessionalCertification[];
}



export interface EmployeeDocument {
  idClient: number;
  id: number;
  idEmployee: number;

  documentName: string;
  fileName: string;

  uploadDate: string | Date;

  uploadedFileExtention?: string;
  uploadedFile?: string;

  setDate?: string | Date;
}

export interface EmployeeEducationInfo {
  idClient: number;
  id: number;
  idEmployee: number;

  idEducationLevel: number;
  idEducationExamination: number;
  idEducationResult: number;

  cgpa?: number;
  examScale?: number;
  marks?: number;

  major: string;
  passingYear: number;

  instituteName: string;
  isForeignInstitute: boolean;

  duration?: number;
  achievement?: string;

  setDate?: string | Date;
}




export interface EmployeeFamilyInfo {
  idClient: number;
  id: number;
  idEmployee: number;

  name: string;

  idGender: number;
  idRelationship: number;

  dateOfBirth?: string | Date;

  contactNo?: string;
  currentAddress?: string;
  permanentAddress?: string;

  setDate?: string | Date;
  createdBy?: string;
}


export interface EmployeeProfessionalCertification {
  idClient: number;
  id: number;
  idEmployee: number;

  certificationTitle: string;
  certificationInstitute: string;
  instituteLocation: string;

  fromDate: string | Date;
  toDate?: string | Date;

  setDate?: string | Date;
  createdBy?: string;
}