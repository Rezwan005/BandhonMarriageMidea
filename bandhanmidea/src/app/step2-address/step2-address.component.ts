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
    this.locationService.getDivisions().subscribe((res: any) => {
    this.divisions = res.data;
    // Now load existing address (after divisions are ready)
    this.loadExistingAddress();
  });
  }

  // Load all divisions
  loadDivisions() {
    this.locationService.getDivisions().subscribe((res: any) => {
      this.divisions = res.data;
    });
  }

loadExistingAddress() {
  this.biodataService.getAddressByUserId(this.formData.userId).subscribe((res: any) => {
    if (!res) return;

    this.formData = res;

    // ---------- PERMANENT ----------
    if (this.formData.permanentDivisionId) {
      this.onPermanentDivisionChange(true);
    }

    // ---------- CURRENT ----------
    if (!this.formData.isSameAddress && this.formData.currentDivisionId) {
      this.onCurrentDivisionChange(true);
    }

    // ---------- SAME ADDRESS ----------
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

  // ---------------- PERMANENT ADDRESS ----------------
  onPermanentDivisionChange(loadExisting = false) {
    debugger;
  if (!this.formData.permanentDivisionId) return;

  const div = this.divisions.find(d => d.id === this.formData.permanentDivisionId?.toString());
  this.formData.permanentDivision = div?.name || '';

  this.locationService.getDistrictsByDivision(this.formData.permanentDivisionId)
    .subscribe((res :any)=> {
      this.permanentDistricts = res.data;

      if (loadExisting && this.formData.permanentDistrictId) {
        this.onPermanentDistrictChange(true);
      }
    });
}

  onPermanentDistrictChange(loadExisting = false) {
    if (!this.formData.permanentDistrictId) {
      this.permanentUpazilas = [];
      this.permanentVillages = [];
      return;
    }

    const dist = this.permanentDistricts.find(d => d.id === this.formData.permanentDistrictId);
    this.formData.permanentDistrict = dist?.name || '';

    this.locationService.getUpazilasByDistrict(this.formData.permanentDistrictId!)
      .subscribe((res: any) => {
        this.permanentUpazilas = res.data;
        this.permanentVillages = [];

        if (loadExisting && this.formData.permanentUpazilaId) {
          this.onPermanentUpazilaChange(true);
        }
      });
  }

  onPermanentUpazilaChange(loadExisting = false) {
    if (!this.formData.permanentUpazilaId) {
      this.permanentVillages = [];
      return;
    }

    const upz = this.permanentUpazilas.find(u => u.id === this.formData.permanentUpazilaId);
    this.formData.permanentUpazila = upz?.name || '';

    this.locationService.getUnionsByUpazila(this.formData.permanentUpazilaId!)
      .subscribe((res: any) => {
        this.permanentVillages = res.data;
      });
  }

  // ---------------- CURRENT ADDRESS ----------------
  onCurrentDivisionChange(loadExisting = false) {
    if (!this.formData.currentDivisionId) {
      this.currentDistricts = [];
      this.currentUpazilas = [];
      this.currentVillages = [];
      return;
    }

    const div = this.divisions.find(d => d.id === this.formData.currentDivisionId);
    this.formData.currentDivision = div?.name || '';

    this.locationService.getDistrictsByDivision(this.formData.currentDivisionId!)
      .subscribe((res: any) => {
        this.currentDistricts = res.data;
        this.currentUpazilas = [];
        this.currentVillages = [];

        if (loadExisting && this.formData.currentDistrictId) {
          this.onCurrentDistrictChange(true);
        }
      });
  }

  onCurrentDistrictChange(loadExisting = false) {
    if (!this.formData.currentDistrictId) {
      this.currentUpazilas = [];
      this.currentVillages = [];
      return;
    }

    const dist = this.currentDistricts.find(d => d.id === this.formData.currentDistrictId);
    this.formData.currentDistrict = dist?.name || '';

    this.locationService.getUpazilasByDistrict(this.formData.currentDistrictId!)
      .subscribe((res: any) => {
        this.currentUpazilas = res.data;
        this.currentVillages = [];

        if (loadExisting && this.formData.currentUpazilaId) {
          this.onCurrentUpazilaChange(true);
        }
      });
  }

  onCurrentUpazilaChange(loadExisting = false) {
    if (!this.formData.currentUpazilaId) {
      this.currentVillages = [];
      return;
    }

    const upz = this.currentUpazilas.find(u => u.id === this.formData.currentUpazilaId);
    this.formData.currentUpazila = upz?.name || '';

    this.locationService.getUnionsByUpazila(this.formData.currentUpazilaId!)
      .subscribe((res: any) => {
        this.currentVillages = res.data;
      });
  }

  toggleSameAddress() {
    if (this.formData.isSameAddress) {
      this.formData.currentDivisionId = this.formData.permanentDivisionId;
      this.formData.currentDistrictId = this.formData.permanentDistrictId;
      this.formData.currentUpazilaId = this.formData.permanentUpazilaId;
      this.formData.currentVillage = this.formData.permanentVillage;
      this.formData.currentRoad = this.formData.permanentRoad;
      this.formData.currentHouse = this.formData.permanentHouse;

      this.onCurrentDivisionChange(true);
    }
  }

  onSave() {
    this.biodataService.saveAddress(this.formData).subscribe(() => {
      alert('Address saved successfully ✅');
      // Optionally navigate to next step
      // this.router.navigate(['/dashboard/editbio/step3']);
    });
  }

}
