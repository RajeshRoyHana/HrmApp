// ==================== models/dropdown.model.ts ====================
export interface DropdownDto {
  value: number;
  text: string;
}

// ==================== models/employee.model.ts ====================
export interface EmployeeListDto {
  id: number;
  clientId: number;
  employeeName: string | null;
  designationName: string;
}

export interface EmployeeDocumentDto {
  idClient?: number;
  id?: number;
  idEmployee: number;
  documentName: string;       
  fileName: string;           
  uploadDate: string;        
  uploadedFileExtention?: string | null;  
  uploadedFile?: string | null;           
  setDate?: string | null;
}

export interface EmployeeFamilyInfoDto {
  idClient?: number;
  id?: number;
  idEmployee: number;
  name: string;               
  idGender: number;           
  idRelationship: number;     
  dateOfBirth?: string | null;
  contactNo?: string | null;  
  currentAddress?: string | null;  
  permanentAddress?: string | null; 
  setDate?: string | null;
  createdBy?: string | null;  
}

export interface EmployeeEducationInfoDto {
  idClient?: number;
  id?: number;
  idEmployee: number;
  idEducationLevel: number;       
  idEducationExamination: number; 
  idEducationResult: number;      
  cgpa?: number | null;
  examScale?: number | null;
  marks?: number | null;
  major: string;              
  passingYear: number;       
  instituteName: string;     
  isForeignInstitute?: boolean;
  duration?: number | null;
  achievement?: string | null; 
  setDate?: string | null;
}

export interface EmployeeProfessionalCertificationDto {
  idClient?: number;
  id?: number;
  idEmployee: number;
  certificationTitle: string;     
  certificationInstitute: string; 
  instituteLocation: string;      
  fromDate: string;               
  toDate?: string | null;
  setDate?: string | null;
  createdBy?: string | null;      
}

export interface EmployeeDto {
  idClient: number;               
  id?: number;
  employeeName: string | null;    
  employeeNameBangla?: string | null; 
  employeeImage?: string | null;  
  fatherName?: string | null;     
  motherName?: string | null;    
  idReportingManager?: number | null;
  idJobType?: number | null;
  idEmployeeType?: number | null;
  birthDate?: string | null;
  joiningDate?: string | null;
  idGender?: number | null;
  idReligion?: number | null;
  idDepartment: number;           
  idSection: number;              
  idDesignation?: number | null;
  hasOvertime?: boolean | null;
  hasAttendenceBonus?: boolean | null;
  idWeekOff?: number | null;
  address?: string | null;       
  presentAddress?: string | null; 
  nationalIdentificationNumber?: string | null; 
  contactNo?: string | null;      
  idMaritalStatus?: number | null;
  isActive?: boolean | null;
  setDate?: string | null;
  createdBy?: string | null;      
  employeeDocuments?: EmployeeDocumentDto[];
  employeeEducationInfos?: EmployeeEducationInfoDto[];
  employeeFamilyInfos?: EmployeeFamilyInfoDto[];
  employeeProfessionalCertifications?: EmployeeProfessionalCertificationDto[];
}

export type FormMode =  'disabled' | 'add' | 'edit' | 'view';
export type PageStatus = 'idle' | 'loading' | 'saving' | 'error';
