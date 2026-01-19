import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { BiodataService } from '../_services/biodata.service';
import { AuthService } from '../_services/authService.service';
import { Biodata } from '../model/biodata.model';
import { DataLookup } from '../model/lookup.model';

@Component({
  selector: 'app-biodata-general-info',
  templateUrl: './biodata-general-info.component.html',
  styleUrls: ['./biodata-general-info.component.css']
})
export class BiodataGeneralInfoComponent implements OnInit {

  isSaving = false;

  biodata: Biodata = {
    biodataType: '',
    maritalStatus: '',
    birthDate: null,
    age: 0,
    height: '',
    skinTone: '',
    weight: 0,
    userId: 0,
    bloodGroup: '',
    nationality: 'Bangladeshi'
  };
  BiodataTypeList: DataLookup[] = [];
  MeritalStatusList: DataLookup[] = [];
  BloodGroupList: DataLookup[] = [];
  SkinToneList: DataLookup[] = [];

  constructor(
    private biodataService: BiodataService,
    private authService: AuthService
  ) {}

  ngOnInit(): void {
    this.loadGeneralInfo();
    this.loadbiodatatype();
    this.loadmeritalstatus();
    this.loadbloodgroup();
    this.loadskintone();
  }

  loadGeneralInfo(): void {
    const user = this.authService.getUser();
    if (!user) return;

    this.biodata.userId = user.id;

    this.biodataService.getBiodataByUserId(user.id)
      .subscribe({
        next: (data) => {
          if (data) {
            this.biodata = {
              ...data,
              birthDate: this.formatDateForInput(data.birthDate)
            };
          }
        },
        error: err => console.error('Could not fetch general info', err)
      });
  }

  loadbiodatatype() {
    this.biodataService.getLookup('BioDataType')
      .subscribe(res => this.BiodataTypeList = res);
  }

  loadmeritalstatus() {
    this.biodataService.getLookup('MaritalStatus')
      .subscribe(res => this.MeritalStatusList = res);
  }

  loadbloodgroup() {
    this.biodataService.getLookup('BloodGroup')
      .subscribe(res => this.BloodGroupList = res);
  }

  loadskintone() {
    this.biodataService.getLookup('SkinTone')
      .subscribe(res => this.SkinToneList = res);
  }

  save(form: NgForm): void {
    debugger;
    if (form.invalid) {
      form.control.markAllAsTouched();
      return;
    }

    this.isSaving = true;

    this.biodataService.saveBiodata(this.biodata)
      .subscribe({
        next: () => {
          alert('ডাটা সফলভাবে সংরক্ষণ হয়েছে ✅');
          this.isSaving = false;
        },
        error: err => {
          console.error(err);
          alert('ডাটা সংরক্ষণ ব্যর্থ হয়েছে ❌');
          this.isSaving = false;
        }
      });
  }

  formatDateForInput(date: Date | string | null): string | null {
    if (!date) return null;
    const d = new Date(date);
    if (isNaN(d.getTime())) return null;

    const year = d.getFullYear();
    const month = (d.getMonth() + 1).toString().padStart(2, '0');
    const day = d.getDate().toString().padStart(2, '0');

    return `${year}-${month}-${day}`;
  }
}
