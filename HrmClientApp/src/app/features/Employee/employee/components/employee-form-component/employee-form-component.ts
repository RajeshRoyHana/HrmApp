import { CommonModule } from '@angular/common';
import { Component, effect, inject, OnInit, signal } from '@angular/core';
import { ReactiveFormsModule, FormBuilder, FormGroup, FormArray, AbstractControl, Validators, ValidatorFn, ValidationErrors } from '@angular/forms';
import { environment } from '../../../../../../environments/environment';
import { DropdownService } from '../../../../../shared/services/dropdown.service';
import { FileUtilService } from '../../../../../shared/services/file-util.service';
import { ToastService } from '../../../../../shared/services/toast.service';
import { EmployeeDto } from '../../../models/employee.models';
import { EmployeeStateService } from '../../../services/employee-state.service';
import { ConfirmDialogService } from '../../../../../shared/services/confirm-dialog-service';


@Component({
  selector: 'app-employee-form-component',
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './employee-form-component.html',
  styleUrl: './employee-form-component.css',
})
export class EmployeeFormComponent implements OnInit {
  employeeService = inject(EmployeeStateService);
  dd = inject(DropdownService);
  private fb = inject(FormBuilder);
  private fileUtil = inject(FileUtilService);
  private toast = inject(ToastService);
  private confirmDialog = inject(ConfirmDialogService);

  form!: FormGroup;
  imagePreview = signal<string | null>(null);


  constructor() {
    this.employeeForm();
    effect(() => {
      const emp = this.employeeService.selectedEmployee();
      if (emp) { this.patchForm(emp); }
    });
  }

  get familyArray(): FormArray { return this.form.get('employeeFamilyInfos') as FormArray; }
  get educationArray(): FormArray { return this.form.get('employeeEducationInfos') as FormArray; }
  get documentArray(): FormArray { return this.form.get('employeeDocuments') as FormArray; }
  get certificationArray(): FormArray { return this.form.get('employeeProfessionalCertifications') as FormArray; }

  showErr(n: string): boolean {
    const c = this.form.get(n);
    return !!(c?.invalid && (c.dirty || c.touched));
  }
  tblErr(arr: FormArray, i: number, f: string): boolean {
    const c = (arr.at(i) as FormGroup).get(f);
    return !!(c?.invalid && c.touched);
  }
  asGroup(ctrl: AbstractControl): FormGroup { return ctrl as FormGroup; }

  ngOnInit() {
    this.dd.loadAll();
    this.employeeService.loadList();
  }

  private employeeForm() {
    this.form = this.fb.group({
      idClient: [environment.idClient],
      id: [0],
      employeeName: ['', [Validators.required, Validators.maxLength(250)]],
      employeeNameBangla: ['', Validators.maxLength(250)],
      employeeImage: [null],
      fatherName: ['', Validators.maxLength(250)],
      motherName: ['', Validators.maxLength(250)],
      idReportingManager: [null],
      idJobType: [null],
      idEmployeeType: [null],
      birthDate: [null],
      joiningDate: [null],
      idGender: [null],
      idReligion: [null],
      idDepartment: [null, Validators.required],
      idSection: [null, Validators.required],
      idDesignation: [null],
      hasOvertime: [false],
      hasAttendenceBonus: [false],
      idWeekOff: [null],
      address: ['', Validators.maxLength(250)],
      presentAddress: ['', Validators.maxLength(250)],
      nationalIdentificationNumber: ['', [Validators.maxLength(30), Validators.pattern('^[0-9]*$')]],
      contactNo: ['', [Validators.maxLength(250), Validators.pattern('^[0-9]*$')]],
      idMaritalStatus: [null],
      isActive: [true],
      createdBy: [''],
      employeeFamilyInfos: this.fb.array([]),
      employeeEducationInfos: this.fb.array([]),
      employeeDocuments: this.fb.array([]),
      employeeProfessionalCertifications: this.fb.array([]),
    });
  }

  private patchForm(emp: EmployeeDto) {
    this.familyArray.clear();
    this.educationArray.clear();
    this.documentArray.clear();
    this.certificationArray.clear();
    
    if (emp.employeeImage && emp.employeeImage.trim() !== '') {
      this.imagePreview.set(
        this.fileUtil.base64ToUrl(emp.employeeImage)
      );
    }

    this.form.patchValue({
      ...emp,
      birthDate: emp.birthDate?.substring(0, 10) ?? null,
      joiningDate: emp.joiningDate?.substring(0, 10) ?? null,
    });
    emp.employeeFamilyInfos?.forEach(f => this.familyArray.push(this.fb.group({
      id: [f.id], idEmployee: [f.idEmployee],
      name: [f.name, [Validators.required, Validators.maxLength(50)]],
      idRelationship: [f.idRelationship, Validators.required],
      idGender: [f.idGender, Validators.required],
      dateOfBirth: [f.dateOfBirth?.substring(0, 10) ?? null],
      contactNo: [f.contactNo, Validators.maxLength(50)],
      currentAddress: [f.currentAddress, Validators.maxLength(500)],
      permanentAddress: [f.permanentAddress, Validators.maxLength(500)],
    })));
    emp.employeeEducationInfos?.forEach(e => this.educationArray.push(this.fb.group({
      id: [e.id], idEmployee: [e.idEmployee],
      idEducationLevel: [e.idEducationLevel, Validators.required],
      idEducationExamination: [e.idEducationExamination, Validators.required],
      idEducationResult: [e.idEducationResult, Validators.required],
      major: [e.major, [Validators.required, Validators.maxLength(50)]],
      passingYear: [e.passingYear, Validators.required],
      instituteName: [e.instituteName, [Validators.required, Validators.maxLength(250)]],
      isForeignInstitute: [e.isForeignInstitute ?? false],
      cgpa: [e.cgpa], examScale: [e.examScale], marks: [e.marks],
      duration: [e.duration], achievement: [e.achievement, Validators.maxLength(500)],
    })));
    emp.employeeDocuments?.forEach(d => this.documentArray.push(this.fb.group({
      id: [d.id], idEmployee: [d.idEmployee],
      documentName: [d.documentName, [Validators.required, Validators.maxLength(200)]],
      fileName: [d.fileName, [Validators.required, Validators.maxLength(100)]],
      uploadDate: [d.uploadDate?.substring(0, 10)],
      uploadedFileExtention: [d.uploadedFileExtention, Validators.maxLength(10)],
      uploadedFile: [d.uploadedFile],
    })));
    emp.employeeProfessionalCertifications?.forEach(c => this.certificationArray.push(this.fb.group({
      id: [c.id], idEmployee: [c.idEmployee],
      certificationTitle: [c.certificationTitle, [Validators.required, Validators.maxLength(255)]],
      certificationInstitute: [c.certificationInstitute, [Validators.required, Validators.maxLength(250)]],
      instituteLocation: [c.instituteLocation, [Validators.required, Validators.maxLength(250)]],
      fromDate: [c.fromDate?.substring(0, 10), Validators.required],
      toDate: [c.toDate?.substring(0, 10) ?? null],
    })));
  }

  addFamily() {
    this.familyArray.push(this.fb.group({
      id: [0], idEmployee: [0],
      name: ['', [Validators.required, Validators.maxLength(50)]],
      idRelationship: ['', Validators.required],
      idGender: [0, Validators.required],
      dateOfBirth: [null], contactNo: ['', Validators.maxLength(50)],
      currentAddress: ['', Validators.maxLength(500)],
      permanentAddress: ['', Validators.maxLength(500)],
    }));
  }

  addEducation() {
    this.educationArray.push(this.fb.group({
      id: [0], idEmployee: [0],
      idEducationLevel: ['', Validators.required],
      idEducationExamination: ['', Validators.required],
      idEducationResult: [0, Validators.required],
      major: ['', [Validators.required, Validators.maxLength(50)]],
      passingYear: ['', Validators.required],
      instituteName: ['', [Validators.required, Validators.maxLength(250)]],
      isForeignInstitute: [false],
      cgpa: [null], examScale: [null], marks: [null], duration: [null],
      achievement: ['', Validators.maxLength(500)],
    }));
  }

  addDocument() {
    this.documentArray.push(this.fb.group({
      id: [0], idEmployee: [0],
      documentName: ['', [Validators.required, Validators.maxLength(200)]],
      fileName: ['', [Validators.required, Validators.maxLength(100)]],
      uploadDate: [new Date().toISOString().substring(0, 10)],
      uploadedFileExtention: ['', Validators.maxLength(10)],
      uploadedFile: [null],
    }));
  }

  addCertification() {
    this.certificationArray.push(this.fb.group({
      id: [0], idEmployee: [0],
      certificationTitle: ['', [Validators.required, Validators.maxLength(255)]],
      certificationInstitute: ['', [Validators.required, Validators.maxLength(250)]],
      instituteLocation: ['', [Validators.required, Validators.maxLength(250)]],
      fromDate: ['', Validators.required], toDate: [null],
    }));
  }

  

  async onDocFile(event: Event, i: number) {
    const file = (event.target as HTMLInputElement).files?.[0];
    if (!file) return;
    const r = await this.fileUtil.toBase64(file);
    (this.documentArray.at(i) as FormGroup).patchValue({
      fileName: r.fileName, uploadedFileExtention: r.extension,
      uploadedFile: r.base64, uploadDate: new Date().toISOString().substring(0, 10),
    });
    const nc = (this.documentArray.at(i) as FormGroup).get('documentName');
    if (!nc?.value) nc?.setValue(file.name.split('.')[0]);
  }

  async onImageSelected(event: Event) {
    const input = event.target as HTMLInputElement;
    const file = input.files?.[0];
    if (!file) return;

    const baseFile = await this.fileUtil.toBase64(file);

    // Save base64 (for API)
    this.form.patchValue({
      employeeImage: baseFile.base64
    });

    // Preview using base64
    this.imagePreview.set(
      `data:${baseFile.mimeType};base64,${baseFile.base64}`
    );
  }

  onSave() {
    this.form.markAllAsTouched();
    if (this.form.invalid) { 
      this.toast.warning('Please fill all required fields.'); 
      return; 
    }
     this.employeeService.save(this.employeeDto());
     this.onReset();
  }

  onReset() {
    if (this.employeeService.mode() === 'add' || this.employeeService.mode() === 'edit') {
      this.form.reset({
        idClient: environment.idClient,
        isActive: true,
        hasOvertime: false,
        hasAttendenceBonus: false,
      });
      this.familyArray.clear();
      this.educationArray.clear();
      this.documentArray.clear();
      this.certificationArray.clear();
      this.form.markAsPristine();
      this.form.markAsUntouched();
      this.imagePreview.set(null);
      this.employeeService.mode.set('add');
    } else {
      const emp = this.employeeService.selectedEmployee();
      if (emp) { 
        this.patchForm(emp); 
      }
    }
  }

  //  deleteEmployee(emp: any) {
  //   if (confirm(`Delete "${emp.employeeName}"? This action cannot be undone.`)) {
  //     this.employeeService.deleteEmployee(emp.id);
  //   }

    
  // }
  
async deleteEmployee(emp: any): Promise<void> {
  const confirmed = await this.confirmDialog.confirmDelete(
    `Are you sure you want to delete "${emp.employeeName}"?`
  );

  if (!confirmed) return;

  this.employeeService.deleteEmployee(emp.id);
}


  private employeeDto(): EmployeeDto {
    const r = this.form.getRawValue();
    return {
      ...r, idClient: environment.idClient,
      birthDate: r.birthDate ? new Date(r.birthDate).toISOString() : null,
      joiningDate: r.joiningDate ? new Date(r.joiningDate).toISOString() : null,
      employeeFamilyInfos: r.employeeFamilyInfos.map((f: any) => ({
        ...f, idEmployee: r.id ?? 0,
        dateOfBirth: f.dateOfBirth ? new Date(f.dateOfBirth).toISOString() : null,
      })),
      employeeEducationInfos: r.employeeEducationInfos.map((e: any) => ({ ...e, idEmployee: r.id ?? 0 })),
      employeeDocuments: r.employeeDocuments.map((d: any) => ({
        ...d, idEmployee: r.id ?? 0,
        uploadDate: d.uploadDate ? new Date(d.uploadDate).toISOString() : new Date().toISOString(),
      })),
      employeeProfessionalCertifications: r.employeeProfessionalCertifications.map((c: any) => ({
        ...c, idEmployee: r.id ?? 0,
        fromDate: c.fromDate ? new Date(c.fromDate).toISOString() : '',
        toDate: c.toDate ? new Date(c.toDate).toISOString() : null,
      })),
    };
  }
}

