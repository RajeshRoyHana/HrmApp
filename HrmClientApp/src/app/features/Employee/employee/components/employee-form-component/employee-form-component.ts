import { CommonModule } from '@angular/common';
import { Component, effect, inject, OnInit, signal } from '@angular/core';
import { ReactiveFormsModule, FormBuilder, FormGroup, FormArray, AbstractControl, Validators } from '@angular/forms';
import { environment } from '../../../../../../environments/environment';
import { DropdownService } from '../../../../../shared/services/dropdown.service';
import { FileUtilService } from '../../../../../shared/services/file-util.service';
import { ToastService } from '../../../../../shared/services/toast.service';
import { EmployeeDto } from '../../../models/employee.models';
import { EmployeeStateService } from '../../../services/employee-state.service';

@Component({
  selector: 'app-employee-form-component',
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './employee-form-component.html',
  styleUrl: './employee-form-component.css',
})
export class EmployeeFormComponent implements OnInit{
  state = inject(EmployeeStateService);
  dd = inject(DropdownService);
  private fb = inject(FormBuilder);
  private fileUtil = inject(FileUtilService);
  private toast = inject(ToastService);

  isViewOnly = signal(false);
  form!: FormGroup;

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
  toggleViewMode() { this.isViewOnly.update(v => !v); }

  ngOnInit() {
    this.buildForm();
    this.dd.loadAll();
    this.state.loadList();
    effect(() => {
      const emp = this.state.selectedEmployee();
      const mode = this.state.mode();
      if (emp) { this.patchForm(emp); this.isViewOnly.set(mode === 'edit'); }
    }, { allowSignalWrites: true });
  }

  private buildForm() {
    this.form = this.fb.group({
      idClient: [environment.idClient],
      id: [null],
      employeeName: ['', [Validators.required, Validators.maxLength(250)]],
      employeeNameBangla: ['', Validators.maxLength(250)],
      employeeImage: [null],
      fatherName: ['', Validators.maxLength(250)],
      motherName: ['', Validators.maxLength(250)],
      idReportingManager: [null],
      idJobType: [null], idEmployeeType: [null],
      birthDate: [null], joiningDate: [null],
      idGender: [null], idReligion: [null],
      idDepartment: ['', Validators.required],
      idSection: ['', Validators.required],
      idDesignation: [null],
      hasOvertime: [false], hasAttendenceBonus: [false],
      idWeekOff: [null],
      address: ['', Validators.maxLength(250)],
      presentAddress: ['', Validators.maxLength(250)],
      nationalIdentificationNumber: ['', Validators.maxLength(30)],
      contactNo: ['', Validators.maxLength(250)],
      idMaritalStatus: [null], isActive: [true], createdBy: [''],
      employeeFamilyInfos: this.fb.array([]),
      employeeEducationInfos: this.fb.array([]),
      employeeDocuments: this.fb.array([]),
      employeeProfessionalCertifications: this.fb.array([]),
    });
  }

  private patchForm(emp: EmployeeDto) {
    this.familyArray.clear(); this.educationArray.clear();
    this.documentArray.clear(); this.certificationArray.clear();
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
      id: [null], idEmployee: [0],
      name: ['', [Validators.required, Validators.maxLength(50)]],
      idRelationship: ['', Validators.required],
      idGender: ['', Validators.required],
      dateOfBirth: [null], contactNo: ['', Validators.maxLength(50)],
      currentAddress: ['', Validators.maxLength(500)],
      permanentAddress: ['', Validators.maxLength(500)],
    }));
  }

  addEducation() {
    this.educationArray.push(this.fb.group({
      id: [null], idEmployee: [0],
      idEducationLevel: ['', Validators.required],
      idEducationExamination: ['', Validators.required],
      idEducationResult: ['', Validators.required],
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
      id: [null], idEmployee: [0],
      documentName: ['', [Validators.required, Validators.maxLength(200)]],
      fileName: ['', [Validators.required, Validators.maxLength(100)]],
      uploadDate: [new Date().toISOString().substring(0, 10)],
      uploadedFileExtention: ['', Validators.maxLength(10)],
      uploadedFile: [null],
    }));
  }

  addCertification() {
    this.certificationArray.push(this.fb.group({
      id: [null], idEmployee: [0],
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

  imagePreview: string | ArrayBuffer | null = null;

  onImageSelected(event: Event): void {
    const input = event.target as HTMLInputElement;

    if (input.files && input.files[0]) {
      const file = input.files[0];

      const reader = new FileReader();
      reader.onload = () => {
        this.imagePreview = reader.result;
      };
      reader.readAsDataURL(file);
    }
  }
  onSave() {
    this.form.markAllAsTouched();
    if (this.form.invalid) { this.toast.warning('Please fill all required fields.'); return; }
    this.state.save(this.buildDto());
  }

  onReset() {
    if (this.state.mode() === 'add') { this.buildForm(); this.state.startNew(); }
    else { const e = this.state.selectedEmployee(); if (e) { this.patchForm(e); this.isViewOnly.set(true); } }
  }

  private buildDto(): EmployeeDto {
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
