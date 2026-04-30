import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../_services/authService.service';
import { BiodataService } from '../_services/biodata.service';
import { LocationService } from '../_services/location.service';
import { Address } from '../model/Address.model';

@Component({
  selector: 'app-step2-address',
  templateUrl: './step2-address.component.html',
  styleUrls: ['./step2-address.component.css']
})
export class Step2AddressComponent implements OnInit {

  formData: Address = {
    userId: 0,
    permanentCountry: 'Bangladesh',
    permanentDivisionId: null,
    permanentDivision: '',
    permanentDistrictId: null,
    permanentDistrict: '',
    permanentUpazilaId: null,
    permanentUpazila: '',
    permanentVillage: '',
    permanentRoad: '',
    permanentHouse: '',
    currentCountry: 'Bangladesh',
    currentDivisionId: null,
    currentDivision: '',
    currentDistrictId: null,
    currentDistrict: '',
    currentUpazilaId: null,
    currentUpazila: '',
    currentVillage: '',
    currentRoad: '',
    currentHouse: '',
    hometown: '',
    isSameAddress: false
  };

  divisions: any[] = [];
  permanentDistricts: any[] = [];
  permanentUpazilas: any[] = [];
  permanentVillages: any[] = [];

  currentDistricts: any[] = [];
  currentUpazilas: any[] = [];
  currentVillages: any[] = [];

  constructor(
    private authService: AuthService,
    private biodataService: BiodataService,
    private locationService: LocationService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.formData.userId = this.authService.getUser().id;
   debugger;
    this.locationService.getDivisions().subscribe((res: any) => {
      this.divisions = res;
      this.loadExistingAddress(); // ✅ divisions loaded first
    });
  }

  // ---------------- LOAD EXISTING ----------------
  loadExistingAddress() {
    this.biodataService.getAddressByUserId(this.formData.userId)
      .subscribe((res: any) => {
        if (!res) return;

        this.formData = res;

        if (this.formData.permanentDivisionId) {
          this.onPermanentDivisionChange(true);
        }

        if (!this.formData.isSameAddress && this.formData.currentDivisionId) {
          this.onCurrentDivisionChange(true);
        }

        if (this.formData.isSameAddress) {
          this.copyPermanentToCurrent();
        }
      });
  }

  copyPermanentToCurrent() {
    this.formData.currentDivisionId = this.formData.permanentDivisionId;
    this.formData.currentDistrictId = this.formData.permanentDistrictId;
    this.formData.currentUpazilaId = this.formData.permanentUpazilaId;
    this.formData.currentVillage = this.formData.permanentVillage;
    this.formData.currentRoad = this.formData.permanentRoad;
    this.formData.currentHouse = this.formData.permanentHouse;

    this.onCurrentDivisionChange(true);
  }

  // ================= PERMANENT =================
  onPermanentDivisionChange(loadExisting = false) {

    if (!this.formData.permanentDivisionId) return;

    // ✅ FIX: number vs number (removed toString)
    const div = this.divisions.find(
      d => d.id === this.formData.permanentDivisionId
    );
    this.formData.permanentDivision = div?.name || '';

    // ✅ FIX: reset children
    if (!loadExisting) {
      this.formData.permanentDistrictId = null;
      this.formData.permanentUpazilaId = null;
      this.permanentUpazilas = [];
      this.permanentVillages = [];
    }

    this.locationService
      .getDistrictsByDivision(this.formData.permanentDivisionId)
      .subscribe((res: any) => {
        this.permanentDistricts = res;

        if (loadExisting && this.formData.permanentDistrictId) {
          this.onPermanentDistrictChange(true);
        }
      });
  }

  onPermanentDistrictChange(loadExisting = false) {
    if (!this.formData.permanentDistrictId) return;

    const dist = this.permanentDistricts.find(
      d => d.id === this.formData.permanentDistrictId
    );
    this.formData.permanentDistrict = dist?.name || '';

    if (!loadExisting) {
      this.formData.permanentUpazilaId = null;
      this.permanentVillages = [];
    }

    this.locationService
      .getUpazilasByDistrict(this.formData.permanentDistrictId)
      .subscribe((res: any) => {
        this.permanentUpazilas = res;

        if (loadExisting && this.formData.permanentUpazilaId) {
          this.onPermanentUpazilaChange(true);
        }
      });
  }

  onPermanentUpazilaChange(loadExisting = false) {
    if (!this.formData.permanentUpazilaId) return;

    const upz = this.permanentUpazilas.find(
      u => u.id === this.formData.permanentUpazilaId
    );
    this.formData.permanentUpazila = upz?.name || '';

    this.locationService
      .getUnionsByUpazila(this.formData.permanentUpazilaId)
      .subscribe((res: any) => {
        this.permanentVillages = res;
      });
  }

  // ================= CURRENT =================
  onCurrentDivisionChange(loadExisting = false) {
    if (!this.formData.currentDivisionId) return;

    const div = this.divisions.find(
      d => d.id === this.formData.currentDivisionId
    );
    this.formData.currentDivision = div?.name || '';

    if (!loadExisting) {
      this.formData.currentDistrictId = null;
      this.formData.currentUpazilaId = null;
      this.currentUpazilas = [];
      this.currentVillages = [];
    }

    this.locationService
      .getDistrictsByDivision(this.formData.currentDivisionId)
      .subscribe((res: any) => {
        this.currentDistricts = res;

        if (loadExisting && this.formData.currentDistrictId) {
          this.onCurrentDistrictChange(true);
        }
      });
  }

  onCurrentDistrictChange(loadExisting = false) {
    if (!this.formData.currentDistrictId) return;

    const dist = this.currentDistricts.find(
      d => d.id === this.formData.currentDistrictId
    );
    this.formData.currentDistrict = dist?.name || '';

    if (!loadExisting) {
      this.formData.currentUpazilaId = null;
      this.currentVillages = [];
    }

    this.locationService
      .getUpazilasByDistrict(this.formData.currentDistrictId)
      .subscribe((res: any) => {
        this.currentUpazilas = res;

        if (loadExisting && this.formData.currentUpazilaId) {
          this.onCurrentUpazilaChange(true);
        }
      });
  }

  onCurrentUpazilaChange(loadExisting = false) {
    if (!this.formData.currentUpazilaId) return;

    const upz = this.currentUpazilas.find(
      u => u.id === this.formData.currentUpazilaId
    );
    this.formData.currentUpazila = upz?.name || '';

    this.locationService
      .getUnionsByUpazila(this.formData.currentUpazilaId)
      .subscribe((res: any) => {
        this.currentVillages = res;
      });
  }

  toggleSameAddress() {
    if (this.formData.isSameAddress) {
      this.copyPermanentToCurrent();
    }
  }

  onSave() {
    this.biodataService.saveAddress(this.formData).subscribe(() => {
      alert('Address saved successfully ✅');
    });
  }
}
